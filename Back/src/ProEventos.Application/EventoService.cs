using System;
using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        /** -------------------- IMPORTANTE ---------
        usado Ctor para criar
        geralPersist foi feito com FIELD FROM PARAMETER(alterado com _)
        Deixei os dois exemplos **/
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception falha)
            {

                throw new Exception(falha.Message);
            };
        }

        public async Task<Evento> UpdateEvento(int EventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(EventoId, false);
                if (evento == null) return null;
                model.Id = evento.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception falha)
            {

                throw new Exception(falha.Message);
            };
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("evento nao encontrado");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();


            }
            catch (Exception falha)
            {

                throw new Exception(falha.Message);
            };
        }

        public async Task<Evento[]> GetAllEventosByAsync(bool IncludePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByAsync(IncludePalestrantes);
                if (eventos == null) return null;
                return eventos;

            }

            catch (Exception falha)
            {

                throw new Exception(falha.Message);
            }
        }



        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, IncludePalestrantes);
                if (eventos == null) return null;
                return eventos;

            }

            catch (Exception falha)
            {

                throw new Exception(falha.Message);
            }
        }



        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool IncludePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, IncludePalestrantes);
                if (eventos == null) return null;
                return eventos;

            }

            catch (Exception falha)
            {

                throw new Exception(falha.Message);
            };
        }

        public async Task<Evento[]> GetAllEventosAsync(bool IncludePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByAsync(IncludePalestrantes);
                if (eventos ==null) return null;
                return eventos;
            }
            catch (Exception falha)
            {
                
                 throw new Exception (falha.Message);
            }
        }

        
    } }
