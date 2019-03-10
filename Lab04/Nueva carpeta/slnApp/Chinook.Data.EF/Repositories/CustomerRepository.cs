using Chinook.Entitites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.EF.Repositories
{
    public class CustomerRepository
    {
        private readonly AppDataModel _context;
        public CustomerRepository()
        {
            _context = new AppDataModel();
        }
        public int Insert(Customer entity)
        {
            _context.Customer.Add(entity);
            _context.SaveChanges();
            return entity.CustomerId;
        }
        public bool Update(Customer entity)
        {
            _context.Customer.Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            var result = _context.SaveChanges();
            return result > 0;
        }
        public bool Delete(Customer entity)
        {
            _context.Customer.Attach(entity);
            _context.Customer.Remove(entity);
            var result = _context.SaveChanges();
            return result > 0;
        }
        public IEnumerable<Customer> GetXNombreApellido(string fullName)
        {
            //var listadoAlternativo = _context.Customer.Where(c => string.Concat(c.FirstName, " ", c.LastName).Contains(fullName)).OrderBy(c => c.LastName).ToList();//usando string.concat
            var listado = _context.Customer.Where(c => (c.FirstName + " " + c.LastName).Contains(fullName)).OrderBy(c => c.LastName).ToList();
            return listado;
        }
        public IEnumerable<Customer> GetAll()
        {
            var listado = _context.Customer.ToList();
            return listado;
        }
        public Customer Get(int id)
        {
            Customer entity = _context.Customer.Find(id);
            return entity;
        }
    }
}
