using System;
using System.Linq;
using Chinook.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chinook.Data.Test
{
    [TestClass]
    public class ArtistDATest
    {
        [TestMethod]
        public void GetCount()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDA();
            var cantidad = da.GetCount();

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(cantidad > 0);
        }

        [TestMethod]
        public void GetsArtist()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDA();
            var listado = da.GetsArtist();

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void GetsArtistWithParam()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDA();
            var listado = da.GetsArtistWithParam("a%");

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void GetsArtistWithParamSP()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDA();
            var listado = da.GetsArtistWithParamSP("a%");

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(listado.Count() > 0);
        }
        [TestMethod]
        public void InsertArtist()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new ArtistDA();
            var objArtista = new Artist();
            objArtista.Name = "Amén";
            int codParámetro = da.InsertArtist(objArtista);

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(codParámetro!=0);
        }
    }
}
