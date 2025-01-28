using Curriculo.API.Data;
using Curriculo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curriculo.API;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly DataContext _dataContext;
    public EventoController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IEnumerable<Candidato> Get(){
        return _dataContext.Candidatos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Candidato> GetById(int id){
        return _dataContext.Candidatos.Where(c => c.IdCandidato == id );
    }

}
