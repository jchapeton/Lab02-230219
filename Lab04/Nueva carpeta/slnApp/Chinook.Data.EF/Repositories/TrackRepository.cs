using Chinook.Entitites.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.EF.Repositories
{
    public class TrackRepository
    {
        private readonly AppDataModel _context;
        public TrackRepository()
        {
            _context = new AppDataModel();
        }
        public int Insert(Track entity)
        {
            _context.Track.Add(entity);
            _context.SaveChanges();
            return entity.TrackId;
        }
        public bool Update(Track entity)
        {
            _context.Track.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result > 0;
        }
        public bool Delete(Track entity)
        {
            _context.Track.Attach(entity);
            _context.Track.Remove(entity);
            var result = _context.SaveChanges();
            return result > 0;
        }
        public IEnumerable<Track> GetXNombreApellido(string fullName)
        {
            //var listadoAlternativo = _context.Customer.Where(c => string.Concat(c.FirstName, " ", c.LastName).Contains(fullName)).OrderBy(c => c.LastName).ToList();//usando string.concat
            var listado = _context.Track.Where(c => (c.Name).Contains(fullName)).OrderBy(c => c.Name).ToList();
            return listado;
        }
        public IEnumerable<Track> GetAll()
        {
            //IQueryable<Track> query = _context.Track;
            //query = query.Include(item => item.Album);

            //Include Edger Loading
            var listado = _context.Track.Include(i=>i.Album).ToList();
            return listado;
        }
        public Track Get(int id)
        {
            Track entity = _context.Track.Find(id);
            return entity;
        }
    }
}
