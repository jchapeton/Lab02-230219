using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        //No se definen los modificadores de alcance(Private,public,)
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
        int Count();
        TEntity GetById<TId>(TId id);

        /// <summary>
        /// Permite obtener un lista de Artistas
        /// </summary>
        /// <param name="filters">Especifica los filtros de la consulta</param>
        /// <param name="orders">Especifica los campos a ordenar</param>
        /// <param name="include">Se indica las entidades que se van a relacionar</param>
        /// <returns></returns>
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filters = null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orders = null,
            Expression<Func<TEntity, TEntity>> selects = null,
            string include = ""
            );

        TEntity FindEntity(Expression<Func<TEntity, bool>> filter);
    }
}
