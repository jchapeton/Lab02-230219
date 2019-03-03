using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using Dapper;
using System.Linq;
namespace Chinook.Data
{
    public class ArtistDapeprDA : BaseConnection
    {
        public int GetCount()
        {
            var result = 0;
            var sql = "select count(1) from dbo.Artist";

            //1. Crear el objeto de conexión

            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                //Usando Dapper
                result = cn.Query<int>(sql).Single();
            }

            return result;
        }
        public IEnumerable<Artist> GetsArtist()
        {
            var result = new List<Artist>();
            var sql = "select ArtistId,Name from Artist";
            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                result = cn.Query<Artist>(sql).ToList();
            }
            return result;
        }

        public IEnumerable<Artist> GetsArtistWithParam(string nombre)
        {
            var result = new List<Artist>();
            var sql = "select ArtistId,Name from Artist Where Name Like @FiltroPorNombre";//evitar concatenar para los parametros para evtar SQL INJECTION
            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                result = cn.Query<Artist>(sql,
                    new { FiltroPorNombre = nombre }).ToList();
            }
            return result;
        }
        public IEnumerable<Artist> GetsArtistWithParamSP(string nombre)
        {
            var result = new List<Artist>();
            var sql = "usp_GetArtists";
            using (IDbConnection cn = new SqlConnection(GetConnection()))//Se usa el using para liberar el recurso
            {
                result = cn.Query<Artist>(sql,
                    new { FiltroPorNombre = nombre }, commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
        }

        public int InsertArtist(Artist objArtista)
        {
            var result = 0;
            var sql = "usp_InsertArtist";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<int>(sql,
                    new { Nombre = objArtista.Name }, commandType: CommandType.StoredProcedure).Single();
            }
            return result;
        }

        public int InsertArtisttTX(Artist objArtista)
        {
            var result = 0;
            var sql = "usp_InsertArtist";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                //En el caso de Dapper para ejecutar una transacción local, necesita tener la conexión abierta
                cn.Open();
                //Inicinado la transacción local
                var transaccion = cn.BeginTransaction();
                try
                {
                    result = cn.Query<int>(sql,
                        new { Nombre = objArtista.Name }, transaction: transaccion, commandType: CommandType.StoredProcedure).Single();

                    transaccion.Commit();

                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception(ex.Message);
                }

            }
            return result;
        }
        public int InsertArtisttTXDist(Artist objArtista)
        {
            var result = 0;

            //Con el objeto TransactionScope se inicia la transacción
            using (var tx = new TransactionScope())
            {
                try
                {
                    var sql = "usp_InsertArtist";
                    //1, Crea el objeto COnnection
                    using (IDbConnection cn = new SqlConnection(GetConnection()))
                    {
                        result = cn.Query<int>(sql,
                            new { Nombre = objArtista.Name }, commandType: CommandType.StoredProcedure).Single();
                    }
                    //Método COmplete se confirma la transaccion
                    tx.Complete();//Se confirma la transacción
                }
                catch (Exception ex)
                {
                    //ya no va rollback, ya que si el complete no se ejecuta significa  que entrará al catch  
                    throw new Exception(ex.Message);
                }
            }//Se libera la tabla cuando sale del USING

            return result;
        }
        public int UpdateArtist(Artist objArtista)
        {
            var result = 0;
            using (var tx = new TransactionScope())
            {


                try
                {
                    //Cuando se tiene parámetros de salida se instancia de la clase DynamicParameters y se le agrega todos los parametros E/S
                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("Nombre", objArtista.Name);
                    dynamicParameter.Add("ID", objArtista.ArtistId);
                    dynamicParameter.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);//Se indica el tipo de dato a la variable output

                    string sql = "usp_UpdateArtist";
                    using (IDbConnection cn = new SqlConnection(GetConnection()))
                    {
                        cn.Execute(sql, dynamicParameter, commandType: CommandType.StoredProcedure);//Se ejecuta el Query
                        result = dynamicParameter.Get<int>("Result");//Accedemos a la variable que contiene los parámetros y recogemos el valor de la variable Output
                    }
                    tx.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return result;
        }
        public bool DeleteArtist(Artist objArtista)
        {
            var result = false;
            using (var tx = new TransactionScope())
            {
                try
                {

                    string sql = "usp_DeleteArtist";
                    using (IDbConnection cn = new SqlConnection(GetConnection()))
                    {
                        //El Execute de Dapper devuelve la cantidad de filas afectadas por la transaccion
                        result = cn.Execute(sql,
                             new { ID = objArtista.ArtistId }, commandType: CommandType.StoredProcedure) > 0;//Se ejecuta el Query

                    }
                    tx.Complete();
                }
                catch (Exception ex)
                {
                    result = false;
                    throw new Exception(ex.Message);
                }
            }
            return result;
        }
    }
}
