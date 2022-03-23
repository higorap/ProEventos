using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext _context;//foi adicionado o field
        public EventoPersist(ProEventosContext context)//feito field
        {
            _context = context;

        }
        
        //eventos

        public async Task<Evento[]> GetAllEventosByAsync(bool IncludePalestrantes =false)
        {
            IQueryable<Evento>query= _context.Eventos.Include(e =>e.Lotes)
                                                     .Include(e =>e.RedesSociais);

              if(IncludePalestrantes)
              {
                  query=query
                    .Include( e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
              }                                      

            
            query = query.OrderBy(e=> e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventosByIdAsync(int EventoId, bool IncludePalestrantes =false)
        {
            IQueryable<Evento>query= _context.Eventos.Include(e =>e.Lotes)
                                                     .Include(e =>e.RedesSociais);

              if(IncludePalestrantes)
              {
                  query=query
                    .Include( e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
              }                                      

            
            query = query.OrderBy(e=> e.Id)
                         .Where(e => e.Id ==EventoId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrantes =false)
        {
            IQueryable<Evento>query= _context.Eventos.Include(e =>e.Lotes)
                                                     .Include(e =>e.RedesSociais);

              if(IncludePalestrantes)
              {
                  query=query
                    .Include( e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
              }                                      

            
            query = query.OrderBy(e=> e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        }

        public Task<Evento> GetEventoByIdAsync(int id, bool v)
        {
            throw new System.NotImplementedException();
        }

        Task<Evento[]> IEventoPersist.GetAllEventosByIdAsync(int EventoId, bool IncludePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        // Task<Evento[]> IEventoPersist.GetAllEventosByIdAsync(int EventoId, bool IncludePalestrantes)
        // {
        //     throw new System.NotImplementedException();
        // }


    }
    }

            

    //     Task <Evento[]> IEventoPersist.GetAllEventosByIdAsync(int EventoId, bool IncludePalestrantes)
    //     {
    //          IQueryable<Evento>query= _context.Eventos.Include(e =>e.Lotes)
    //                                                  .Include(e =>e.RedesSociais);

    //           if(IncludePalestrantes)
    //           {
    //               query=query
    //                 .Include( e => e.PalestrantesEventos)
    //                 .ThenInclude(pe => pe.Palestrante);
    //           }          
    //     }

    //     Task async <Palestrante[]> IEventoPersist.GetAllPalestranteByIdAsync(int PalestranteId, bool IncludeEventos)
    //     {
    //          IQueryable<Evento>query= _context.Eventos.Include(e =>e.Lotes)
    //                                                  .Include(e =>e.RedesSociais);

    //           if(IncludePalestrantes)
    //           {
    //               query=query
    //                 .Include( e => e.PalestrantesEventos)
    //                 .ThenInclude(pe => pe.Palestrante);
    //           }          ;
    //     }
    // }
//}