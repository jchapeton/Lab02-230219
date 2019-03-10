using System;
using Chinook.Data.EF.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Chinook.Entitites.Base;

namespace Chinoook.Data.EF.Test
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        ArtistRepository repository = new ArtistRepository();

        [TestMethod]
        public void Count()
        {
            var count = repository.Count();
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void GetAll()
        {
            var listado = repository.getAll();
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void getAllXFiltro()
        {
            var listado = repository.getAllXFiltro("AR");
            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var artist = new Artist();
            artist.Name = "Pedro Suarez";
            var id = repository.Insert(artist);

            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void Update()
        {
            var artist = new Artist();
            artist.Name = "Pedro Suarez Vertizz";
            artist.ArtistId = 290;
            var isSuccess = repository.Update(artist);
            Assert.IsTrue(isSuccess);
        }

        [TestMethod]
        public void Delete()
        {
            var artist = new Artist();
            artist.ArtistId = 290;
            var isSuccess = repository.Delete(artist);
            Assert.IsTrue(isSuccess);
        }

        [TestMethod]
        public void Get()
        {
            var entity = repository.Get(1);
            Assert.IsNotNull(entity);
        }
    }
}
