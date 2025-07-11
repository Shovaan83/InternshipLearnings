using JPT.Models.Entities;
using JPT.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JPT.Services
{
    public interface IServiceTicket
    {
        Task<IEnumerable<SupportTicket>> GetRecentTicketsAsync(int count);
        Task CreateTicketAsync(CreateViewModel ticket);

        Task<IEnumerable<FaqItemViewModel>> GetFaqsAsync();
    }
}