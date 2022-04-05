using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoService
    {
         Task <Evento> AddEvento (Evento model);
         Task <Evento> UpdateEvento (int EventoId,Evento model);
         Task <bool> DeleteEvento (int EventoId);

          Task <Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrantes=false);
         Task <Evento[]> GetAllEventosAsync( bool IncludePalestrantes=false );
         Task<Evento> GetEventoByIdAsync(int id, bool IncludePalestrantes=false);
    }
}