using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chinook.Entities;
namespace Chinook.Data.Test
{
    [TestClass]
    public class ArtistDapperDATest
    {
        [TestMethod]
        public void GetCount()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDapeprDA();
            var cantidad = da.GetCount();

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(cantidad > 0);
        }

        [TestMethod]
        public void GetsArtist()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDapeprDA();
            var listado = da.GetsArtist();

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void GetsArtistWithParam()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDapeprDA();
            var listado = da.GetsArtistWithParam("a%");

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void GetsArtistWithParamSP()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDapeprDA();
            var listado = da.GetsArtistWithParamSP("a%");

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(listado.Count() > 0);
        }
        [TestMethod]
        public void InsertArtist()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDapeprDA();
            var objArtista = new Artist();
            objArtista.Name = "Guns And Roses";
            int codParámetro = da.InsertArtist(objArtista);

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(codParámetro != 0);
        }

        [TestMethod]
        public void InsertArtistTX()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDapeprDA();
            var objArtista = new Artist();
            objArtista.Name = "Libido";
            int codParámetro = da.InsertArtisttTX(objArtista);

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(codParámetro != 0);
        }

        [TestMethod]
        public void InsertArtistTXDist()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDapeprDA();
            var objArtista = new Artist();
            objArtista.Name = "Red Hot Chilli Pepers";
            int codParámetro = da.InsertArtisttTXDist(objArtista);

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(codParámetro != 0);
        }

        [TestMethod]
        public void UpdateArtistTXDist()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDapeprDA();
            var objArtista = new Artist();
            objArtista.ArtistId = 284;
            objArtista.Name = "Keane2";
            int codParámetro = da.UpdateArtist(objArtista);

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(codParámetro ==1);
        }

        [TestMethod]
        public void DeleteArtistTXDist()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDapeprDA();
            var objArtista = new Artist();
            objArtista.ArtistId = 285;
            bool result = da.DeleteArtist(objArtista);

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(result);
        }
    }
}
