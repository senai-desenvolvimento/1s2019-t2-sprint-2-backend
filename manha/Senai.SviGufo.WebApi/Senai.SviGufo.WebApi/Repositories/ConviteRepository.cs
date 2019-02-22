using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Domains.Enums;
using Senai.SviGufo.WebApi.Interfaces;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class ConviteRepository : IConviteRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=SENAI_SVIGUFO_MANHA_BACKEND; integrated security=true";

        public void Cadastrar(ConviteDomain convite)
        {
            string QueryInsert = @"INSERT INTO CONVITES(ID_EVENTO,ID_USUARIO,SITUACAO) VALUES (@ID_EVENTO, @ID_USUARIO, @SITUACAO)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using(SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@ID_EVENTO", convite.EventoId);
                    cmd.Parameters.AddWithValue("@ID_USUARIO", convite.UsuarioId);
                    cmd.Parameters.AddWithValue("@SITUACAO", convite.Situacao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os convites
        /// </summary>
        /// <returns>Retorna uma lista de Convites</returns>
        public List<ConviteDomain> Listar()
        {
            string QuerySelect = @"SELECT
	                                C.ID AS ID_CONVITE,
	                                C.SITUACAO,
	                                E.TITULO AS TITULO_EVENTO,
	                                E.DATA_EVENTO,
	                                TE.ID AS ID_TIPO_EVENTO,
	                                TE.TITULO AS TITULO_TIPO_EVENTO,
	                                U.NOME AS NOME_USUARIO,
	                                U.EMAIL AS EMAIL_USUARIO,
	                                U.ID AS ID_USUARIO
                                FROM CONVITES C
                                INNER JOIN EVENTOS E
                                ON C.ID_EVENTO = E.ID
                                INNER JOIN USUARIOS U
                                ON C.ID_USUARIO = U.ID
                                INNER JOIN TIPOS_EVENTOS TE
                                ON TE.ID = E.ID_TIPO_EVENTO;";

            List<ConviteDomain> convites = new List<ConviteDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        ConviteDomain convite = new ConviteDomain
                        {
                            Id = Convert.ToInt32(sdr["ID_CONVITE"]),
                            Situacao = (EnSituacaoConvite)Convert.ToInt32(sdr["SITUACAO"]),
                            Usuario = new UsuarioDomain
                            {
                                Id = Convert.ToInt32(sdr["ID_USUARIO"]),
                                Nome = sdr["NOME_USUARIO"].ToString(),
                                Email = sdr["EMAIL_USUARIO"].ToString()
                            },
                            Evento = new EventoDomain
                            {
                                Titulo = sdr["TITULO_EVENTO"].ToString(),
                                DataEvento = Convert.ToDateTime(sdr["DATA_EVENTO"]),
                                TipoEvento = new TipoEventoDomain
                                {
                                    Id = Convert.ToInt32(sdr["ID_TIPO_EVENTO"]),
                                    Nome = sdr["TITULO_TIPO_EVENTO"].ToString()
                                }
                            }
                        };

                        convites.Add(convite);
                    }
                }
            }

            return convites;
        }

        public List<ConviteDomain> ListarMeusConvites(int id)
        {
            string QuerySelect = @"SELECT
	                                C.ID AS ID_CONVITE,
	                                C.SITUACAO,
	                                E.TITULO AS TITULO_EVENTO,
	                                E.DATA_EVENTO,
	                                TE.ID AS ID_TIPO_EVENTO,
	                                TE.TITULO AS TITULO_TIPO_EVENTO,
	                                U.NOME AS NOME_USUARIO,
	                                U.EMAIL AS EMAIL_USUARIO,
	                                U.ID AS ID_USUARIO
                                FROM CONVITES C
                                INNER JOIN EVENTOS E
                                ON C.ID_EVENTO = E.ID
                                INNER JOIN USUARIOS U
                                ON C.ID_USUARIO = U.ID
                                INNER JOIN TIPOS_EVENTOS TE
                                ON TE.ID = E.ID_TIPO_EVENTO
                                WHERE C.ID_USUARIO = @ID;";

            List<ConviteDomain> convites = new List<ConviteDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        ConviteDomain convite = new ConviteDomain
                        {
                            Id = Convert.ToInt32(sdr["ID_CONVITE"]),
                            Situacao = (EnSituacaoConvite)Convert.ToInt32(sdr["SITUACAO"]),
                            Usuario = new UsuarioDomain
                            {
                                Id = Convert.ToInt32(sdr["ID_USUARIO"]),
                                Nome = sdr["NOME_USUARIO"].ToString(),
                                Email = sdr["EMAIL_USUARIO"].ToString()
                            },
                            Evento = new EventoDomain
                            {
                                Titulo = sdr["TITULO_EVENTO"].ToString(),
                                DataEvento = Convert.ToDateTime(sdr["DATA_EVENTO"]),
                                TipoEvento = new TipoEventoDomain
                                {
                                    Id = Convert.ToInt32(sdr["ID_TIPO_EVENTO"]),
                                    Nome = sdr["TITULO_TIPO_EVENTO"].ToString()
                                }
                            }
                        };

                        convites.Add(convite);
                    }
                }
            }

            return convites;
        }
    }
}
