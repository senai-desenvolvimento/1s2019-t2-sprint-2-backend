using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;

namespace Senai.SviGufo.WebApi.Repositories
{

    /// <summary>
    /// Repositorio da Instituicao
    /// </summary>
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=SENAI_SVIGUFO_MANHA_BACKEND; integrated security=true";

        /// <summary>
        /// Altera uma instituição
        /// </summary>
        /// <param name="instituicao">Instituição</param>
        /// <param name="id">Id da instituição</param>
        public void Alterar(InstituicaoDomain instituicao, int id)
        {
            string QueryUpdate = "UPDATE INSTITUICOES SET RAZAO_SOCIAL = @RAZAO_SOCIAL, NOME_FANTASIA = @NOME_FANTASIA, CNPJ = @CNPJ, LOGRADOURO = @LOGRADOURO, CEP = @CEP, UF = @UF, CIDADE = @CIDADE WHERE ID = @ID;";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                    cmd.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                    cmd.Parameters.AddWithValue("@CNPJ", instituicao.Cnpj);
                    cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                    cmd.Parameters.AddWithValue("@CEP", instituicao.Cep);
                    cmd.Parameters.AddWithValue("@UF", instituicao.Uf);
                    cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca uma Instituição pelo Id
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Retorna uma instituição</returns>
        public InstituicaoDomain BuscarPorId(int id)
        {
            string QuerySelect = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, UF, CIDADE FROM INSTITUICOES WHERE ID = @ID";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    sdr = cmd.ExecuteReader();


                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            InstituicaoDomain instituicao = new InstituicaoDomain
                            {
                                Id = Convert.ToInt32(sdr["ID"])
                                ,NomeFantasia = sdr["NOME_FANTASIA"].ToString()
                                ,RazaoSocial = sdr["RAZAO_SOCIAL"].ToString()
                                ,Cnpj = sdr["CNPJ"].ToString()
                                ,Cep = sdr["CEP"].ToString()
                                ,Cidade = sdr["CIDADE"].ToString()
                                ,Uf = sdr["UF"].ToString()
                                ,Logradouro = sdr["LOGRADOURO"].ToString()
                            };

                            return instituicao;
                        }
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra uma instituição
        /// </summary>
        /// <param name="instituicao">Instituição</param>
        public void Cadastrar(InstituicaoDomain instituicao)
        {
            string QueryInsert = "INSERT INTO INSTITUICOES (RAZAO_SOCIAL, NOME_FANTASIA, CNPJ, LOGRADOURO, CEP, UF, CIDADE) " +
                " VALUES (@RAZAO_SOCIAL, @NOME_FANTASIA, @CNPJ, @LOGRADOURO, @CEP, @UF, @CIDADE)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                    cmd.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                    cmd.Parameters.AddWithValue("@CNPJ", instituicao.Cnpj);
                    cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                    cmd.Parameters.AddWithValue("@CEP", instituicao.Cep);
                    cmd.Parameters.AddWithValue("@UF", instituicao.Uf);
                    cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Exclui uma instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        public void Deletar(int id)
        {
            string QueryDelete = "DELETE FROM INSTITUICOES WHERE ID = @ID;";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista as instituições
        /// </summary>
        /// <returns>Retorna uma lista de instituição</returns>
        public List<InstituicaoDomain> Listar()
        {
            string QuerySelect = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, UF, CIDADE FROM INSTITUICOES";

            List<InstituicaoDomain> ListaInstituicoes = new List<InstituicaoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        InstituicaoDomain instituicao = new InstituicaoDomain
                        {
                            Id = Convert.ToInt32(sdr["ID"])
                            ,
                            NomeFantasia = sdr["NOME_FANTASIA"].ToString()
                            ,
                            RazaoSocial = sdr["RAZAO_SOCIAL"].ToString()
                            ,
                            Cnpj = sdr["CNPJ"].ToString()
                            ,
                            Cep = sdr["CEP"].ToString()
                            ,
                            Cidade = sdr["CIDADE"].ToString()
                            ,
                            Uf = sdr["UF"].ToString()
                            ,
                            Logradouro = sdr["LOGRADOURO"].ToString()
                        };

                        ListaInstituicoes.Add(instituicao);
                    }
                }
            }

            return ListaInstituicoes;
        }
    }
}
