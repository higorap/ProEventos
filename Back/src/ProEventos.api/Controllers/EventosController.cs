using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;
using Microsoft.AspNetCore.Http;
using ProEventos.Persistence.Contexto;

namespace ProEventos.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

      //  // essa 
        // public readonly ProEventosContext _context;
        // public EventosController(ProEventosContext context)
        // {
        //     _context = context;

        // }
      //   //fim
        private  IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;

        }

        [HttpGet]
        public async Task <IActionResult> Get() //aulas 68
        {
            try
            {
               var eventos = await _eventoService.GetAllEventosAsync(true);
               if (eventos ==null) return NotFound("Nenhum evento encontrado2") ;
               return Ok(eventos);
               
            }
            catch (Exception falha)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro au tentar Recuperar evento1 . Erro {falha.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task <IActionResult> GetById(int id)
        {
            try
            {
               var eventos = await _eventoService.GetEventoByIdAsync(id,true);
               if (eventos ==null) return NotFound("Nenhum evento encontrado1") ;
               return Ok(eventos);
               
            }
            catch (Exception falha)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro au tentar Recuperar evento2 . Erro {falha.Message}");
            }
        }
        [HttpGet("{tema}/tema")]
        public async Task <IActionResult> GetByTema(string tema)
        {
            try
            {
               var eventos = await _eventoService.GetAllEventosByTemaAsync(tema,true);
               if (eventos ==null) return NotFound("Nenhum Tema encontrado") ;
               return Ok(eventos);
               
            }
            catch (Exception falha)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro au tentar Recuperar evento3 . Erro {falha.Message}");
            }
        }

        [HttpPost]
        public async Task <IActionResult> Post(Evento model)
        {
            try
            {
               var eventos = await _eventoService.AddEvento(model);
               if (eventos ==null) return BadRequest("erro ao add") ;
               return Ok(eventos);
               
            }
            catch (Exception falha)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro au tentar Recuperar evento4 . Erro {falha.Message}");
            }
        }
         [HttpPut("{id}")]
        public async Task <IActionResult> Put (int id, Evento model)
        {
            try
            {
               var eventos = await _eventoService.UpdateEvento(id,model);
               if (eventos ==null) return BadRequest("erro ao add") ;
               return Ok(eventos);
               
            }
            catch (Exception falha)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro au tentar Recuperar evento5 . Erro {falha.Message}");
            }
        }
         [HttpDelete("{id}")]
        public async Task <IActionResult> Delete (int id)
        {
            try
            {
              if (await _eventoService.DeleteEvento(id))
                return Ok("deletado");
            else
                return BadRequest("nao foi deletado"); 

            }
            catch (Exception falha)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError,
               $"Erro au tentar Deletar evento . Erro {falha.Message}");
            }
        }

    }
}
