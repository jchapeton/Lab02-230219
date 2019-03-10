using Chinook.Entitites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.EF.Repositories
{
    public class ArtistRepository
    {
        private readonly AppDataModel _context;
        public ArtistRepository()
        {
            _context = new AppDataModel();
        }

        public int Count()
        {
            return _context.Artist.Count();
        }

        public IEnumerable<Artist> getAll()
        {
            return _context.Artist.ToList();
        }

        public IEnumerable<Artist> getAllXFiltro(string nombre)
        {
            return _context.Artist.Where(i => i.Name.Contains(nombre)).OrderBy(o => o.Name).ThenByDescending(o => o.ArtistId).ToList();
        }
        public int Insert(Artist entity)
        {
            //Se agrega la información al contextode EF
            _context.Artist.Add(entity);
            //Confirma la transacción
            _context.SaveChanges();

            return entity.ArtistId;
        }
        public bool Update(Artist entity)
        {
            //Atachando en memoria el objeto que se quiere actualizar
            _context.Artist.Attach(entity);

            //Cambiando el estado de Unchanged a Modified
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            //Confirmando la operación
            var result = _context.SaveChanges();

            return result > 0;
        }

        public bool Delete(Artist entity)
        {
            //Atachando en memoria el objeto que se quiere actualizar
            _context.Artist.Attach(entity);

            _context.Artist.Remove(entity);

            //Confirmando la operación
            var result = _context.SaveChanges();

            return result > 0;
        }
        public Artist Get(int id)
        {
            var entity = _context.Artist.Find(id);

            return entity;
        }
    }
}
