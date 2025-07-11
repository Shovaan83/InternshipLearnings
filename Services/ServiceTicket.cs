using Dapper;
using JPT.Data;
using JPT.Hubs;
using JPT.Models.Entities;
using JPT.Models.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPT.Services
{
    public class ServiceTicket : IServiceTicket
    {
        private readonly DapperContext _context;
        private readonly IHubContext<SupportTicketHub> _hubContext;

        public ServiceTicket(DapperContext context, IHubContext<SupportTicketHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<IEnumerable<SupportTicket>> GetRecentTicketsAsync(int count)
        {
            var query = "SELECT * FROM support_tickets ORDER BY date_submitted DESC LIMIT @Count";
            using (var connection = _context.CreateConnection())
            {
                var tickets = await connection.QueryAsync<SupportTicket>(query, new { Count = count });
                return tickets;
            }
        }
        public async Task<IEnumerable<FaqItemViewModel>> GetFaqsAsync()
        {
            var query = "SELECT question, answer FROM faqs ORDER BY display_order";
            using (var connection = _context.CreateConnection())
            {
                var faqs = await connection.QueryAsync<FaqItemViewModel>(query);
                return faqs;
            }
        }

        public async Task CreateTicketAsync(CreateViewModel ticket)
        {
            var insertQuery = @"
                INSERT INTO support_tickets (
                    request_number, request_type, transaction_id, client_name, account_number, subject, remarks, status, date_submitted
                ) VALUES (
                    @RequestNumber, @RequestType, @TransactionId, @ClientName, @AccountNumber, @Subject, @Remarks, @Status, @DateSubmitted
                ) RETURNING *;";

            SupportTicket newDbTicket;
            using (var connection = _context.CreateConnection())
            {
                var requestNumber = $"SR#{DateTime.UtcNow.Ticks}";
                var parameters = new
                {
                    RequestNumber = requestNumber,
                    ticket.RequestType,
                    ticket.TransactionId,
                    ticket.ClientName,
                    ticket.AccountNumber,
                    Subject = ticket.RequestType,
                    ticket.Remarks,
                    Status = "Submitted",
                    DateSubmitted = DateTime.UtcNow
                };
                newDbTicket = await connection.QuerySingleAsync<SupportTicket>(insertQuery, parameters);
            }

            if (newDbTicket != null)
            {
                var newTicketForUi = new SupportHistoryItemViewModel
                {
                    RequestNumber = newDbTicket.RequestNumber,
                    ClientName = newDbTicket.ClientName,
                    ClientPhoneNumber = newDbTicket.ClientPhoneNumber,
                    Subject = newDbTicket.Subject,
                    Date = newDbTicket.DateSubmitted,
                    Status = newDbTicket.Status
                };
                await _hubContext.Clients.All.SendAsync("ReceiveNewTicket", newTicketForUi);
            }
        }
    }
}