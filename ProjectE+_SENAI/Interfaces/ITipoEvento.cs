using ProjectE__SENAI.Domains;

namespace ProjectE__SENAI.Interfaces
{
    public interface ITipoEvento
    {
        void deletar(Guid id, TiposEventos novotiposeventos);
        void Cadastrar(TiposEventos novotipoevento);
        void atualizar(Guid id, TiposEventos novotipoevento);
        List<TiposEventos>Listar();
        TiposEventos BuscarPorId(Guid id);

    }
}
