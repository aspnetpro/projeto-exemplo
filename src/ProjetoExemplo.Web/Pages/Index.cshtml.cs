using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoExemplo.Application.Modules.Tickets.DTOs;
using ProjetoExemplo.Application.Modules.Tickets.Services;

namespace ProjetoExemplo.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICreateNewTicket createNewTicket;

        public IndexModel(ILogger<IndexModel> logger,
            ICreateNewTicket createNewTicket)
        {
            _logger = logger;
            this.createNewTicket = createNewTicket;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost([FromForm] NewTicketRequest request) 
        {
            var result = createNewTicket.Create(request);
            if (result.Success)
            {
                return Page();
            }

            ViewData["Message"] = result.GetError();

            return Page();
        }
    }
}
