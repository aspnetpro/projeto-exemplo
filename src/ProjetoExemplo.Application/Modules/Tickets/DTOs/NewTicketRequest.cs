namespace ProjetoExemplo.Application.Modules.Tickets.DTOs;

public record NewTicketRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
}
