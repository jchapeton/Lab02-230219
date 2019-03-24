using System;
using App.Data.DataAccess;
using App.Data.Repository.Interface;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace App.Data.Repository.Test
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        [TestMethod]
        public void Count()
        {
            int count = 0;
            using (var unitOfWork = new AppUnitOfWork())
            {
                count = unitOfWork.ArtistRepository.Count();
            }

            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void Insert()
        {
            int result = 0;
            using (var unitOfWOrk = new AppUnitOfWork())
            {
                Artist objArtist = new Artist();
                objArtist.Name = "Artist" + Guid.NewGuid();
                unitOfWOrk.ArtistRepository.Add(objArtist);
                result = unitOfWOrk.Complete();
            }
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Update()
        {
            int result = 0;
            using (var unitOfWOrk = new AppUnitOfWork())
            {

                Artist objArtist = new Artist();
                objArtist.ArtistId = 291;
                objArtist.Name = "Artist2";
                unitOfWOrk.ArtistRepository.Update(objArtist);
                result = unitOfWOrk.Complete();
            }
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void Remove()
        {
            int result = 0;
            using (var unitOfWOrk = new AppUnitOfWork())
            {

                Artist objArtist = new Artist();
                objArtist.ArtistId = 291;
                unitOfWOrk.ArtistRepository.Remove(objArtist);
                result = unitOfWOrk.Complete();
            }
            Assert.IsTrue(result > 0);
        }
        [TestMethod]
        public void Get()
        {
            Artist result = null;
            using (var unitOfWOrk = new AppUnitOfWork())
            {
                result = unitOfWOrk.ArtistRepository.GetById(291);
            }
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAll()
        {
            List<Artist> result = new List<Artist>();
            using (var unitOfWOrk = new AppUnitOfWork())
            {
                result = unitOfWOrk.ArtistRepository.GetAll();
            }
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetAllFilters()
        {
            List<Artist> result = new List<Artist>();
            using (var unitOfWOrk = new AppUnitOfWork())
            {
                result = unitOfWOrk.ArtistRepository.GetAll(
                    item => item.Name.StartsWith("A") && item.ArtistId >= 13,
                    items => items.OrderBy(itemsOrder => itemsOrder.Name),
                    //item => new Artist() { ArtistId = item.ArtistId },
                    null,
                    "Album"
                    );
            }
            Assert.IsTrue(result.Count > 0);
        }
    }
}
