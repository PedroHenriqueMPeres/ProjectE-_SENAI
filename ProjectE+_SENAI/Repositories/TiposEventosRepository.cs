using ProjectE__SENAI.Context;
using ProjectE__SENAI.Domains;
using ProjectE__SENAI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectE__SENAI.Repositories
{
    public class TiposEventosRepository : ITipoEvento
    {
        private readonly TiposEventos _context;

        public TiposEventosRepository(TiposEventos context)
        {
            _context = context;
        }

        
        public void Cadastrar(TiposEventos novotipoevento)
        {
            try
            {
                _context.TiposEventos.Add(novotipoevento); 
                _context.SaveChanges(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar novo tipo de evento", ex); 
            }
        }

        
        public void atualizar(Guid id, TiposEventos novotipoevento)
        {
            try
            {
                var eventoExistente = _context.TiposEventos.FirstOrDefault(e => e.Id == id); 
                if (eventoExistente != null)
                {
                    eventoExistente.titulostipoevento = novotipoevento.TituloTiposEventos; 
                    eventoExistente.Descricao = novotipoevento.Descricao; 
                    

                    _context.SaveChanges(); 
                }
                else
                {
                    throw new KeyNotFoundException("Tipo de evento não encontrado"); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar tipo de evento", ex); 
            }
        }

        
        public TiposEventos BuscarPorId(Guid id)
        {
            try
            {
                var evento = _context.TiposEventos.FirstOrDefault(e => e.Id == id); 
                if (evento == null)
                {
                    throw new KeyNotFoundException("Tipo de evento não encontrado"); 
                }
                return evento; 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar tipo de evento por ID", ex); 
            }
        }

        
        public void deletar(Guid id)
        {
            try
            {
                var eventoExistente = _context.TiposEventos.FirstOrDefault(e => e.Id == id); 
                if (eventoExistente != null)
                {
                    _context.TiposEventos.Remove(eventoExistente); 
                    _context.SaveChanges(); 
                }
                else
                {
                    throw new KeyNotFoundException("Tipo de evento não encontrado"); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar tipo de evento", ex); 
            }
        }

        
        public List<TiposEventos> Listar()
        {
            try
            {
                return _context.TiposEventos.ToList(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar tipos de eventos", ex); 
            }
        }

        public void deletar(Guid id, TiposEventos novotiposeventos)
        {
            throw new NotImplementedException();
        }
    }
}
