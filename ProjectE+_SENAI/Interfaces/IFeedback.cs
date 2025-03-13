using ProjectE__SENAI.Domains;

namespace ProjectE__SENAI.Interfaces
{
    public interface IFeedback
    {
        void Cadastrar(Feedback novofeedback);
        void atualizar(Guid id, Feedback novofeedback);
        void deletar(Guid id);
        List<Feedback> Comentarios();
        List<Feedback> BuscarPorId(Guid id);
    }
}
