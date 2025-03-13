using ProjectE__SENAI.Domains;

namespace ProjectE__SENAI.Interfaces
{
    public interface IUsuario
    {
        void Cadastrar(Usuario novoUsuario);
        void Deletar(Guid id);
        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
