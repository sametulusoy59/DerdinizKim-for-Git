using DerdinizKimComWeb.DataAccessLayer;
using DerdinizKimComWeb.DataAccessLayer.Abstract;
using DerdinizKimComWeb.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DerdinizKimComWeb.DataAccessLayer.EntityFramework
{
   public class Repository<T>:IRepository<T> where T:class
    {
        private DatabaseContext db;
        private DbSet<T> _objectset;

        public Repository()
        {
            db = RepositoryBase.CreateContext();
            _objectset = db.Set<T>();
        }


        public List<T> List()
        {
            return _objectset.ToList();
        }


        public List<T> List(Expression<Func<T,bool>>where)
        {
            return _objectset.Where(where).ToList();
        }

        public int Insert(T obj)
        {

            _objectset.Add(obj);

            if(obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;
                DateTime now = DateTime.Now;
                o.olusturulduguzaman = now;
                o.duzenlendigitarih = now;
                o.duzenleyenkullanici = "system";
            }
            return Save();
        }


        public int Update(T obj)
        {
            if (obj is EntityBase)
            {
                EntityBase o = obj as EntityBase;
               
                o.duzenlendigitarih = DateTime.Now;
                o.duzenleyenkullanici = "system";
            }
            return Save();
        }

        public int Delete(T obj)
        {
            _objectset.Remove(obj);
            return Save();
        }


        public int Save()
        {
            return db.SaveChanges();
        }

        public T Find(Expression<Func<T,bool >>where)
        {
            return _objectset.FirstOrDefault(where);
        }
       


    }
}
