using ProjectE__SENAI.Domains;

namespace ProjectE__SENAI.Interfaces
{
    public interface IFeedback
    {
        void Cadastrar(Feedback novofeedback);
        void deletar(Guid id);
        List<Feedback> Comentarios();
        List<Feedback> BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId);
    }
}