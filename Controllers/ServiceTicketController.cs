using Microsoft.AspNetCore.Mvc;
using JPT.Models.ViewModels;
using JPT.Services;
using System.Linq;
using System.Threading.Tasks;

namespace JPT.Controllers
{
    public class ServiceTicketController : Controller
    {
        private readonly IServiceTicket _ticketService;

        public ServiceTicketController(IServiceTicket ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new SupportTicketViewModel();
            var ticketsFromDb = await _ticketService.GetRecentTicketsAsync(4);
            viewModel.History = ticketsFromDb.Select(t => new SupportHistoryItemViewModel
            {
                RequestNumber = t.RequestNumber,
                ClientName = t.ClientName,
                ClientPhoneNumber = t.ClientPhoneNumber,
                Subject = t.Subject,
                Date = t.DateSubmitted,
                Status = t.Status
            }).ToList();
            viewModel.Faqs = (await _ticketService.GetFaqsAsync()).ToList();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTicket([Bind(Prefix = "CreateTicket")] CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _ticketService.CreateTicketAsync(model);
                TempData["SuccessMessage"] = $"Your ticket for '{model.RequestType}' has been submitted successfully!";
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new SupportTicketViewModel
            {
                CreateTicket = model,
                History = (await _ticketService.GetRecentTicketsAsync(4))
                            .Select(t => new SupportHistoryItemViewModel
                            {
                                RequestNumber = t.RequestNumber,
                                ClientName = t.ClientName,
                                ClientPhoneNumber = t.ClientPhoneNumber,
                                Subject = t.Subject,
                                Date = t.DateSubmitted,
                                Status = t.Status
                            }).ToList(),
                Faqs = (await _ticketService.GetFaqsAsync()).ToList()
            };
            return View("Index", viewModel);
        }

        public async Task<IActionResult> TicketDetail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var viewModel = new TicketDetailViewModel
            {
                TicketId = id
            };

            return View(viewModel);
        }
    }
}