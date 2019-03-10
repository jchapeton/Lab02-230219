using Chinook.Data.EF.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinoook.Data.EF.Test
{
    [TestClass]
    public class TrackRepositoryTest
    {
        TrackRepository repository = new TrackRepository();

        [TestMethod]
        public void GetAll()
        {
            var listado = repository.GetAll();
            Assert.IsTrue(listado.Count() > 0);
        }
    }
}
