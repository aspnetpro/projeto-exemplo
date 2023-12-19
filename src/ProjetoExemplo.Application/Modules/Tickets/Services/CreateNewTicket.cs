using Dapper;
using ProjetoExemplo.Application.Common;
using ProjetoExemplo.Application.Infrastructure.Data;
using ProjetoExemplo.Application.Modules.Tickets.Constantes;
using ProjetoExemplo.Application.Modules.Tickets.DTOs;
using System.ComponentModel;

namespace ProjetoExemplo.Application.Modules.Tickets.Services;

public interface ICreateNewTicket
{
    Result Create(NewTicketRequest newTicketDTO);
}

public class CreateNewTicket : ICreateNewTicket
{
    private readonly IDbContext dbContext;

    public CreateNewTicket(IDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Result Create(NewTicketRequest newTicketDTO)
    {
        var result = new Result();

        // validate
        if (String.IsNullOrWhiteSpace(newTicketDTO.Title))
        {
            result.AddError("Titulo é obrigatório");
            return result;
        }

        // gravar BD
        using (var conn = dbContext.Connection)
        {
            var sql = 
                "Insert into Tickets (Title, Description, Status) " +
                "VALUES " +
                "(@Title, @Description, @Status)";
            conn.Execute(sql, new
            {
                Title = newTicketDTO.Title,
                Description = newTicketDTO.Description,
                Status = TicketStatus.Open
            });
        }

        return result;
    }
}
