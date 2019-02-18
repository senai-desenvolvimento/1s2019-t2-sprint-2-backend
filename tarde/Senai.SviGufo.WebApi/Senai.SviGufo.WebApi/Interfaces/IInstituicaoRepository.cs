using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Interfaces
{
    /// <summary>
    /// Interface do Repositorio referente a Instituição
    /// </summary>
    public interface IInstituicaoRepository
    {
        //Lista todas as instituições        
        List<InstituicaoDomain> Listar();

        //Busca uma instituição pelo Id
        InstituicaoDomain BuscarPorId(int id);

        //Cadastra uma nova instituição
        void Cadastrar(InstituicaoDomain instituicao);

        //Altera uma instituição
        void Alterar(int id, InstituicaoDomain instituicao);

        //Deleta uma instituição
        void Deletar(int id);
    }
}
