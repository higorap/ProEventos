using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos

{
    public interface IEventoPersist
    {
   

         
         //eventos
         Task <Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrantes=false);
         Task <Evento[]> GetAllEventosByAsync( bool IncludePalestrantes=false);
       //  Task <Evento[]> GetEventoByIdAsync(int EventoId, bool IncludePalestrantes=false) ;
        Task<Evento> GetEventoByIdAsync(int id, bool IncludePalestrantes=false);
    }
}