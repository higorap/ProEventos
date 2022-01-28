using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.api.Models;

namespace ProEventos.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
       public IEnumerable<Evento> _evento = new Evento []{
                new Evento()
              {
                EventoId= 1,
                Tema = "angular",
                Local="SP",               
                Lote="primeiro lote",
                QtdPessoas=200,
                DataEvento= DateTime.Now.AddDays(2).ToString()
              },
                new Evento()
              {
                EventoId= 2,
                Tema = "CSS",
                Local="BH",               
                Lote="primeiro lote",
                QtdPessoas=2020,
                DataEvento= DateTime.Now.AddDays(32).ToString()
              }
            };

        public EventoController()
        {
        }

        [HttpGet] 
        public IEnumerable<Evento> Get()
        {     
            return _evento;
        }
         [HttpGet("{id}")] 
        public IEnumerable<Evento> GetById(int id)
        {     
            return _evento.Where(Evento=>Evento.EventoId==id);
        }

         [HttpPost] 
        public string Post()
        {     
            return "value-Post";
        }
    }
}
