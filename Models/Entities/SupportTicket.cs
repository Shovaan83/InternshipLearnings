using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPT.Models.Entities
{
    public class SupportTicket
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("request_number")]
        public string RequestNumber { get; set; }

        [Column("request_type")]
        public string RequestType { get; set; }

        [Column("transaction_id")]
        public string TransactionId { get; set; }

        [Column("client_name")]
        public string ClientName { get; set; }

        [Column("client_phone_number")]
        public string ClientPhoneNumber { get; set; }

        [Column("account_number")]
        public string AccountNumber { get; set; }

        [Column("subject")]
        public string Subject { get; set; }

        [Column("remarks")]
        public string Remarks { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("date_submitted")]
        public DateTime DateSubmitted { get; set; }
    }
}