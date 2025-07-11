using System; 

namespace JPT.Models.ViewModels
{
    public class SupportHistoryItemViewModel
    {
        public string RequestNumber { get; set; }
        public string ClientName { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}