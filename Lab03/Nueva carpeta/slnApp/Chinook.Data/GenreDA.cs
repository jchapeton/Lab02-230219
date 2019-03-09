using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Transactions;

namespace Chinook.Data
{
    public class GenreDA : BaseConnection
    {
        public int GetCount()
        {
            var result = 0;
            var sql = "select count(1) from dbo.Genre";

            //1. Crear el objeto de conexión

            // Forma Tradicional
            //IDbConnection cn = new SqlConnection(GetConnection());
            //cn.Open();

            ////....
            //cn.Close();

            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                //cn.Open();

                ////2. Crear el objeto Command
                //IDbCommand cmd = new SqlCommand(sql);
                //cmd.Connection = cn;

                ////3. Ejecutamos el Comando
                //result = (int)cmd.ExecuteScalar();

                //DAPPER
                result = cn.Query<int>(sql).Single();
            }

            return result;
        }
        public IEnumerable<Genre> GetsGenre()
        {
            var result = new List<Genre>();
            var sql = "select GenreId,Name from Genre";
            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                //cn.Open();

                ////2. Crear el objeto Command
                //IDbCommand cmd = new SqlCommand(sql);
                //cmd.Connection = cn;

                ////3. Ejecutamos el Comando
                //var reader = cmd.ExecuteReader();
                //var indice = 0;
                //while (reader.Read())
                //{
                //    var entity = new Genre();
                //    indice = reader.GetOrdinal("GenreId");
                //    entity.GenreId = reader.GetInt32(indice);
                //    //entity.ArtistId = Convert.ToInt32(reader["ArtistId"]);  No es una buena practica, ya que el convert cosume procesador

                //    indice = reader.GetOrdinal("Name");
                //    entity.Name = reader.GetString(indice);

                //    result.Add(entity);
                //}

                //DAPPER
                result = cn.Query<Genre>(sql).ToList();
            }
            return result;
        }

        public IEnumerable<Genre> GetsGenreWithParam(string nombre)
        {
            var result = new List<Genre>();

            var sql = "select GenreId,Name from Genre Where Name Like @FiltroPorNombre";//evitar concatenar para los parametros para evtar SQL INJECTION

            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                //cn.Open();

                ////2. Crear el objeto Command
                //IDbCommand cmd = new SqlCommand(sql);
                //cmd.Connection = cn;

                ////Configurando los parámetros de la consulta SQL
                //cmd.Parameters.Add(new SqlParameter("@FiltroPorNombre", nombre));

                ////3. Ejecutamos el Comando
                //var reader = cmd.ExecuteReader();
                //var indice = 0;
                //while (reader.Read())
                //{
                //    var entity = new Genre();
                //    indice = reader.GetOrdinal("GenreId");
                //    entity.GenreId = reader.GetInt32(indice);
                //    //entity.ArtistId = Convert.ToInt32(reader["ArtistId"]);  No es una buena practica, ya que el convert cosume procesador

                //    indice = reader.GetOrdinal("Name");
                //    entity.Name = reader.GetString(indice);

                //    result.Add(entity);
                //}

                //DAPPER
                result = cn.Query<Genre>(sql,
                                        new { FiltroPorNombre = nombre }).ToList();
            }
            return result;
        }
        public IEnumerable<Genre> GetsGenreWithParamSP(string nombre)
        {
            var result = new List<Genre>();
            var sql = "usp_GetGenreXName";
            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                //cn.Open();

                ////2. Crear el objeto Command
                //IDbCommand cmd = new SqlCommand(sql);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = cn;

                ////Configurando los parámetros de la consulta SQL
                //cmd.Parameters.Add(new SqlParameter("@FiltroPorNombre", nombre));

                ////3. Ejecutamos el Comando
                //var reader = cmd.ExecuteReader();
                //var indice = 0;
                //while (reader.Read())
                //{
                //    var entity = new Genre();
                //    indice = reader.GetOrdinal("GenreId");
                //    entity.GenreId = reader.GetInt32(indice);
                //    //entity.ArtistId = Convert.ToInt32(reader["ArtistId"]);  No es una buena practica, ya que el convert cosume procesador

                //    indice = reader.GetOrdinal("Name");
                //    entity.Name = reader.GetString(indice);

                //    result.Add(entity);
                //}
                //DAPPER
                result = cn.Query<Genre>(sql,
                                        new { FiltroPorNombre = nombre }, commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
        }

        public int InsertGenre(Genre objGenre)
        {
            var result = 0;
            var sql = "usp_InsertGenre";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                //cn.Open();
                ////2. Crear el Objeto Command
                //IDbCommand cmd = new SqlCommand(sql);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = cn;
                ////Agregando parametros

                //cmd.Parameters.Add(new SqlParameter("@Name", objGenre.Name));

                ////resultado
                //result = Convert.ToInt32(cmd.ExecuteScalar());
                //DAPPER
                result = cn.Query<int>(sql,
                                        new { Name = objGenre.Name }, commandType: CommandType.StoredProcedure).Single();

            }
            return result;
        }
        public int UpdateGenre(Genre objGenre)
        {
            var result = 0;
            var sql = "usp_UpdateGenre";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                //cn.Open();
                ////2. Crear el Objeto Command
                //IDbCommand cmd = new SqlCommand(sql);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = cn;
                ////Agregando parametros
                //cmd.Parameters.Add(new SqlParameter("@GenreId", objGenre.GenreId));
                //cmd.Parameters.Add(new SqlParameter("@Name", objGenre.Name));
                ////resultado
                //result = Convert.ToInt32(cmd.ExecuteScalar());

                //DAPPER
                result = cn.Query<int>(sql,
                                        new { GenreId = objGenre.GenreId, Name = objGenre.Name }, commandType: CommandType.StoredProcedure).Single();
            }
            return result;
        }
        public int DeleteGenre(Genre objGenre)
        {
            var result = 0;

            var sql = "usp_DeleteGenre";

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                //cn.Open();
                ////2. Crear el Objeto Command
                //IDbCommand cmd = new SqlCommand(sql);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = cn;
                ////Agregando parametros
                //cmd.Parameters.Add(new SqlParameter("@GenreId", objGenre.GenreId));

                ////resultado
                //result = Convert.ToInt32(cmd.ExecuteScalar());

                //DAPPER
                result = cn.Query<int>(sql,
                                    new { GenreId = objGenre.GenreId }, commandType: CommandType.StoredProcedure).Single();
            }
            return result;
        }
        #region transacciones
        public int InsertGenreTX(Genre objGenre)
        {
            var result = 0;
            var sql = "usp_InsertGenre";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                var transaction = cn.BeginTransaction();

                try
                {
                    result = cn.Query<int>(sql,
                                          new { Name = objGenre.Name }, transaction: transaction, commandType: CommandType.StoredProcedure).Single();

                    transaction.Commit();
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
            return result;
        }
        public int InsertGenreTXDist(Genre objGenre)
        {
            var result = 0;
            using (var tx = new TransactionScope())
            {

                var sql = "usp_InsertGenre";
                using (IDbConnection cn = new SqlConnection(GetConnection()))
                {
                    cn.Open();
                    var transaction = cn.BeginTransaction();

                    try
                    {
                        result = cn.Query<int>(sql,
                                              new { Name = objGenre.Name }, commandType: CommandType.StoredProcedure).Single();

                        tx.Complete();
                    }

                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return result;
        }

        #endregion

    }
}
