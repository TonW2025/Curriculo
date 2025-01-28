using Curriculo.API.Data;
using Curriculo.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Curriculo.API;

[ApiController]
[Route("api/[controller]")]
public class CandidatoController : ControllerBase
{
    private readonly DataContext _dataContext;
    public CandidatoController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IEnumerable<Candidato> Get(){
        return _dataContext.Candidatos;
    }

    [HttpGet("{id}")]
    public Candidato GetById(int id){
        return _dataContext.Candidatos.FirstOrDefault(c => c.Id == id );
        //return _dataContext.Candidatos.FirstOrDefault(c => c.Id == id );
    }

}
