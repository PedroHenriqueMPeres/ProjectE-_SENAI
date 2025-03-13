using ProjectE__SENAI.Domains;

namespace ProjectE__SENAI.Interfaces
{
    public interface IEvento
    {
        void Cadastrar(Evento novoEvento);

        List<Evento> Listar();

        void Atualizar(Guid id, IEvento evento);

        void Deletar(Guid id);

        Evento BuscarPorId(Guid id);
        
    }
}
