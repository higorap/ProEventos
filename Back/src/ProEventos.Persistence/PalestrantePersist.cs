using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PaletrantePersist : IPaletrantePersist
    {
        private readonly ProEventosContext _context;//foi adicionado o field
        public PaletrantePersist(ProEventosContext context)//feito field
        {
            _context = context;

        }
        

        
        
        // Task<Evento[]> IEventoPersist.GetAllEv entosByIdAsync(int EventoId, bool IncludePalestrantes)
        // {
        //     throw new System.NotImplementedException();
        // }

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool IncludeEventos =false)
        {
           IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
           .Include(e=>e.RedesSociais);
           if (IncludeEventos)
           {
               query=query
               .Include(e=>e.PalestrantesEventos)
               .ThenInclude(pe=>pe.Evento);
           }
           query=query.OrderBy(e=>e.Id);
           return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome,bool IncludeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
           .Include(p=>p.RedesSociais);
           if (IncludeEventos)
           {
               query=query
               .Include(p=>p.PalestrantesEventos)
               .ThenInclude(pe=>pe.Evento);
           }
           query=query.OrderBy(p=>p.Id).Where(p=>p.Nome.ToLower().Contains(nome.ToLower()));
           return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeIdAsync(string nome, bool IncludeEventos)
        {
           IQueryable<Palestrante> query = _context.Palestrantes.AsNoTracking()
           .Include(e=>e.RedesSociais);
           if (IncludeEventos)
           {
               query=query
               .Include(p=>p.PalestrantesEventos)
               .ThenInclude(pe=>pe.Evento);
           }
           query=query.OrderBy(p=>p.Id).Where(p=>p.Nome.ToLower().Contains(nome.ToLower()));
           return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByIdAsync(string Nome, bool IncludeEventos)
        {
            IQueryable<Palestrante>query = _context.Palestrantes.AsNoTracking()
            .Include(p=>p.RedesSociais);
            if(IncludeEventos)

                { query=query
                    .Include(p=>p.PalestrantesEventos)
                    .ThenInclude(pe=>pe.Evento);
                }
            query=query.OrderBy(p=>p.Id).Where(p=>p.Nome.ToLower().Contains(Nome.ToLower()));
            return await query.ToArrayAsync();

        }

        public async Task<Palestrante> GetAllPalestranteByIdAsyn2c(int PalestranteId, bool IncludeEventos)
        {
            IQueryable<Palestrante>query = _context.Palestrantes.AsNoTracking()
            .Include(p=>p.RedesSociais);
            if(IncludeEventos)

                { query=query
                    .Include(p=>p.PalestrantesEventos)
                    .ThenInclude(pe=>pe.Evento);
                }
            query=query.OrderBy(p=>p.Id).Where(p=>p.Id== PalestranteId);
            return await query.FirstOrDefaultAsync();
        }

        // Task<Palestrante[]> IPaletrantePersist.GetAllPalestranteByIdAsy2nc(int PalestranteId, bool IncludeEventos)
        // {
        //     throw new System.NotImplementedException();
        // }

        public Task<Palestrante[]> GetAllPalestranteByAsync(bool IncludeEventos)
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestranteByIdAsync(int PalestranteId, bool IncludeEventos)
        {
            throw new System.NotImplementedException();
        }
    }
}
            

    