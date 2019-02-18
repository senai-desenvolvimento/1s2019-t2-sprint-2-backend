using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;

namespace Senai.SviGufo.WebApi.Repositories
{
    /// <summary>
    /// Implementa a Interface referente a instituição
    /// </summary>
    public class InstituicaoRepository : IInstituicaoRepository
    {

        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog= SENAI_SVIGUFO_TARDE_BACKEND; integrated security=true";

        /// <summary>
        /// Altera uma instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <param name="instituicao">Dados da instituição</param>
        public void Alterar(int id, InstituicaoDomain instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Query de inserção dos dados
                string QueryUpdate = "UPDATE INSTITUICOES SET NOME_FANTASIA = @NOME_FANTASIA," +
                    " RAZAO_SOCIAL = @RAZAO_SOCIAL," +
                    " CNPJ = @CNPJ," +
                    " LOGRADOURO = @LOGRADOURO," +
                    " CEP = @CEP," +
                    " UF = @UF," +
                    " CIDADE = @CIDADE" +
                    " WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(QueryUpdate, con);

                //Atribui os valores aos parametros das querys
                cmd.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                cmd.Parameters.AddWithValue("@CNPJ", instituicao.Cnpj);
                cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", instituicao.Cep);
                cmd.Parameters.AddWithValue("@UF", instituicao.Uf);
                cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);
                cmd.Parameters.AddWithValue("@ID", id);

                //Abre a conexão
                con.Open();

                //Executa o comando
                cmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Buscar uma instituição pelo Id
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Retorna uma instituição</returns>
        public InstituicaoDomain BuscarPorId(int id)
        {
            //Declara uma conexão passando a String de Conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Query referente ao Select
                string QuerySelect = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO," +
                    " CEP, UF, CIDADE FROM INSTITUICOES WHERE ID = @ID";

                //Declara um comando passando a query e o objeto referente a conexão
                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    //Abre a conexão
                    con.Open();
                    //Declara o ID como parametro
                    cmd.Parameters.AddWithValue("@ID", id);
                    //Executa a query
                    SqlDataReader sdr = cmd.ExecuteReader();

                    //Verifica se existe alguma instituição
                    if (sdr.HasRows)
                    {
                        //Percorre o SqlDataReader
                        while (sdr.Read())
                        {
                            //Atribui os valores a instituição
                            InstituicaoDomain instituicao = new InstituicaoDomain
                            {
                                Id = Convert.ToInt32(sdr["id"]),
                                NomeFantasia = sdr["NOME_FANTASIA"].ToString(),
                                RazaoSocial = sdr["RAZAO_SOCIAL"].ToString(),
                                Cnpj = sdr["CNPJ"].ToString(),
                                Logradouro = sdr["LOGRADOURO"].ToString(),
                                Cep = sdr["CEP"].ToString(),
                                Uf = sdr["UF"].ToString(),
                                Cidade = sdr["CIDADE"].ToString()
                            };

                            //Retorna a instituição
                            return instituicao;
                        }
                    }

                    //Caso não encontre retorna null
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
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Query de inserção dos dados
                string QueryInsert = "INSERT INTO INSTITUICOES(NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, UF, CIDADE) " +
                    "VALUES(@NOME_FANTASIA, @RAZAO_SOCIAL, @CNPJ, @LOGRADOURO, @CEP, @UF, @CIDADE)";

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    //Atribui os valores aos parametros das querys
                    cmd.Parameters.AddWithValue("@NOME_FANTASIA", instituicao.NomeFantasia);
                    cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", instituicao.RazaoSocial);
                    cmd.Parameters.AddWithValue("@CNPJ", instituicao.Cnpj);
                    cmd.Parameters.AddWithValue("@LOGRADOURO", instituicao.Logradouro);
                    cmd.Parameters.AddWithValue("@CEP", instituicao.Cep);
                    cmd.Parameters.AddWithValue("@UF", instituicao.Uf);
                    cmd.Parameters.AddWithValue("@CIDADE", instituicao.Cidade);

                    //Abre a conexão
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Query de inserção dos dados
                string QueryDeletar = "DELETE FROM INSTITUICOES WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(QueryDeletar, con))
                {
                    //Atribui os valores aos parametros das querys
                    
                    cmd.Parameters.AddWithValue("@ID", id);

                    //Abre a conexão
                    con.Open();

                    //Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todas as Instituições
        /// </summary>
        /// <returns>Retorna uma lista de instituições</returns>
        public List<InstituicaoDomain> Listar()
        {
            //
            List<InstituicaoDomain> ListaInstituicoes = new List<InstituicaoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO," +
                    " CEP, UF, CIDADE FROM INSTITUICOES";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        InstituicaoDomain instituicao = new InstituicaoDomain
                        {
                            Id = Convert.ToInt32(sdr["id"]),
                            NomeFantasia = sdr["NOME_FANTASIA"].ToString(),
                            RazaoSocial = sdr["RAZAO_SOCIAL"].ToString(),
                            Cnpj = sdr["CNPJ"].ToString(),
                            Logradouro = sdr["LOGRADOURO"].ToString(),
                            Cep = sdr["CEP"].ToString(),
                            Uf = sdr["UF"].ToString(),
                            Cidade = sdr["CIDADE"].ToString()
                        };

                        ListaInstituicoes.Add(instituicao);
                    }
                }
            }

            return ListaInstituicoes;
        }
    }
}
