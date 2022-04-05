using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext _context;//foi adicionado o field
        public EventoPersist(ProEventosContext context)//feito field
        {
            _context = context;

           // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // serve para caso 'segurar dados ignorar essa etapa

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

            
            query = query.AsNoTracking().OrderBy(e=> e.Id);
            return await query.ToArrayAsync();
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

            
            query = query.AsNoTracking().OrderBy(e=> e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool IncludePalestrantes)
        {
            IQueryable<Evento>query= _context.Eventos.Include(e =>e.Lotes)
                                                     .Include(e =>e.RedesSociais);

              if(IncludePalestrantes)
              {
                  query=query
                    .Include( e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
              }                                      

            
            query = query.AsNoTracking().OrderBy(e=> e.Id)
                         .Where(e => e.Id== EventoId);
            return await query.FirstOrDefaultAsync();       }

        

        public async Task<Evento[]> GetAllEventosAsync(bool IncludePalestrantes)
        {
            IQueryable<Evento>query= _context.Eventos.AsNoTracking().Include(e =>e.Lotes)
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

        
    }
    }

            

    