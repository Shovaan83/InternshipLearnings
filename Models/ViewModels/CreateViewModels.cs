using System.ComponentModel.DataAnnotations;

namespace JPT.Models.ViewModels
{
    public class CreateViewModel
    {
        [Display(Name = "Request Type")]
        public string RequestType { get; set; }

        [Display(Name = "Transaction ID / Client ID")]
        public string TransactionId { get; set; }

        [Display(Name = "Client Name")]
        [Required(ErrorMessage = "Client Name is required.")]
        public string ClientName { get; set; }

        [Display(Name = "Account Number")]
        [Required(ErrorMessage = "Account Number is required.")] 
        public string AccountNumber { get; set; }

        [Display(Name = "Details / Remarks")]
        [Required(ErrorMessage = "Please provide some details about your request.")] 
        public string Remarks { get; set; }
    }
}