using JPT.Models.ViewModels;
using System.Collections.Generic;

namespace JPT.Models.ViewModels
{
    public class SupportTicketViewModel
    {
        public CreateViewModel CreateTicket { get; set; }
        public List<SupportHistoryItemViewModel> History { get; set; }
        public List<FaqItemViewModel> Faqs { get; set; }

        public SupportTicketViewModel()
        {
            CreateTicket = new CreateViewModel();
            History = new List<SupportHistoryItemViewModel>();
            Faqs = new List<FaqItemViewModel>();
        }
    }
}