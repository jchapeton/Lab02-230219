using Chinook.Data.EF.Repositories;
using Chinook.Entitites.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinoook.Data.EF.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        CustomerRepository repository = new CustomerRepository();

        [TestMethod]
        public void Get()
        {
            var entity = repository.Get(1);

            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void GetAll()
        {
            var listado = repository.GetAll();

            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void GetAllXNombreApellido()
        {
            var listado = repository.GetXNombreApellido("Robert Brown").ToList();

            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void Insert()
        {
            Customer entity = new Customer();
            entity.FirstName = "Yozet";
            entity.LastName = "Sagasestegui";
            entity.Address = "Independencia";
            entity.City = "Lima";
            entity.Country = "Peru";
            entity.PostalCode = "01";
            entity.Phone = "999888777";
            entity.Email = "yozets@gmail.com";
            entity.SupportRepId = 3;
            var result = repository.Insert(entity);

            Assert.IsTrue(result > 0);
        }
    }
}
