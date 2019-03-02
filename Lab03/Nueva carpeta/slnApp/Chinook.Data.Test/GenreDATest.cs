using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Chinook.Data.Test
{
    [TestClass]
    public class GenreDATest
    {
        [TestMethod]
        public void GetCount()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new GenreDA();
            var cantidad = da.GetCount();

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(cantidad > 0);
        }

        [TestMethod]
        public void GetsGenre()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new GenreDA();
            var listado = da.GetsGenre();

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void GetsGenreWithParam()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new GenreDA();
            var listado = da.GetsGenreWithParam("a%");

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void GetsGenreWithParamSP()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new GenreDA();
            var listado = da.GetsGenreWithParamSP("a%");

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(listado.Count() > 0);
        }
        [TestMethod]
        public void InsertGenre()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new GenreDA();
            var objGenre = new Genre();
            objGenre.Name = "Amén2";
            int codParámetro = da.InsertGenre(objGenre);

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(codParámetro != 0);
        }
        [TestMethod]
        public void UpdateGenre()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new GenreDA();
            var objGenre = new Genre();
            objGenre.GenreId = 26;
            objGenre.Name = "Amén3";
            int codParámetro = da.UpdateGenre(objGenre);

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(codParámetro != 0);
        }
        [TestMethod]
        public void DeleteGenre()
        {
            //Instanciamos del ArtistDA de la Capa Data
            var da = new GenreDA();
            var objGenre = new Genre();
            objGenre.GenreId = 26;
            int codParámetro = da.DeleteGenre(objGenre);

            //validamos que la cantidad sea mayor a 0
            Assert.IsTrue(codParámetro != 0);
        }
    }
}
