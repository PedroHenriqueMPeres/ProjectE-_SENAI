using ProjectE__SENAI.Domains;

namespace ProjectE__SENAI.Interfaces
{
    public interface ITipoUsuario
    {
        void Cadastrar(TiposUsuarios novotipousuario);
        void Atualizar(Guid Id, TiposUsuarios tiposUsuario);
        void Deletar(Guid Id);
        List<TiposUsuarios> Listar();
        TiposUsuarios BuscarPorId(Guid id);

    }
}
