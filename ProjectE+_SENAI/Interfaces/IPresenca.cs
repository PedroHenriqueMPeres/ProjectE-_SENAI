using ProjectE__SENAI.Domains;

namespace ProjectE__SENAI.Interfaces
{
    public interface IPresenca
    {
        void Inscrever(Presenca novapresenca);
        void atualizar(Guid id, Presenca novapresenca);
        List<Presenca> Listar();
        List<Presenca> ListarMinhas(Guid id);

    }
}
