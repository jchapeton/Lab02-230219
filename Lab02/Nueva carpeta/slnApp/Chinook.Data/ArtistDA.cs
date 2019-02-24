using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Chinook.Data
{
    public class ArtistDA : BaseConnection
    {
        public int GetCount()
        {
            var result = 0;
            var sql = "select count(1) from dbo.Artist";

            //1. Crear el objeto de conexión

            // Forma Tradicional
            //IDbConnection cn = new SqlConnection(GetConnection());
            //cn.Open();

            ////....
            //cn.Close();

            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                cn.Open();

                //2. Crear el objeto Command
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;

                //3. Ejecutamos el Comando
                result = (int)cmd.ExecuteScalar();
            }

            return result;
        }
        public IEnumerable<Artist> GetsArtist()
        {
            var result = new List<Artist>();
            var sql = "select ArtistId,Name from Artist";
            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                cn.Open();

                //2. Crear el objeto Command
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;

                //3. Ejecutamos el Comando
                var reader = cmd.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    var entity = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    entity.ArtistId = reader.GetInt32(indice);
                    //entity.ArtistId = Convert.ToInt32(reader["ArtistId"]);  No es una buena practica, ya que el convert cosume procesador

                    indice = reader.GetOrdinal("Name");
                    entity.Name = reader.GetString(indice);

                    result.Add(entity);
                }
            }
            return result;
        }

        public IEnumerable<Artist> GetsArtistWithParam(string nombre)
        {
            var result = new List<Artist>();
            var sql = "select ArtistId,Name from Artist Where Name Like @FiltroPorNombre";//evitar concatenar para los parametros para evtar SQL INJECTION
            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                cn.Open();

                //2. Crear el objeto Command
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;

                //Configurando los parámetros de la consulta SQL
                cmd.Parameters.Add(new SqlParameter("@FiltroPorNombre",nombre));

                //3. Ejecutamos el Comando
                var reader = cmd.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    var entity = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    entity.ArtistId = reader.GetInt32(indice);
                    //entity.ArtistId = Convert.ToInt32(reader["ArtistId"]);  No es una buena practica, ya que el convert cosume procesador

                    indice = reader.GetOrdinal("Name");
                    entity.Name = reader.GetString(indice);

                    result.Add(entity);
                }
            }
            return result;
        }
        public IEnumerable<Artist> GetsArtistWithParamSP(string nombre)
        {
            var result = new List<Artist>();
            var sql = "usp_GetArtists";
            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                cn.Open();

                //2. Crear el objeto Command
                IDbCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                //Configurando los parámetros de la consulta SQL
                cmd.Parameters.Add(new SqlParameter("@FiltroPorNombre", nombre));

                //3. Ejecutamos el Comando
                var reader = cmd.ExecuteReader();
                var indice = 0;
                while (reader.Read())
                {
                    var entity = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    entity.ArtistId = reader.GetInt32(indice);
                    //entity.ArtistId = Convert.ToInt32(reader["ArtistId"]);  No es una buena practica, ya que el convert cosume procesador

                    indice = reader.GetOrdinal("Name");
                    entity.Name = reader.GetString(indice);

                    result.Add(entity);
                }
            }
            return result;
        }

        public int InsertArtist(Artist objArtista)
        {
            var result = 0;
            var sql = "usp_InsertArtist";
            using (IDbConnection cn= new SqlConnection(GetConnection()))
            {
                cn.Open();
                //2. Crear el Objeto Command
                IDbCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                //Agregando parametros
                cmd.Parameters.Add(new SqlParameter("@Nombre", objArtista.Name));

                //resultado
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return result;
        }
    }
}
