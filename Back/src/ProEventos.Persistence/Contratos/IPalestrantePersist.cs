using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos

{
    public interface IPaletrantePersist
    {
        
         // Palestrante

        Task <Palestrante[]> GetAllPalestranteByNomeAsync(string Nome, bool IncludeEventos);
         Task <Palestrante[]> GetAllPalestranteByAsync(bool IncludeEventos);
         Task <Palestrante[]> GetAllPalestranteByIdAsync(int PalestranteId, bool IncludeEventos) ;
    }
}