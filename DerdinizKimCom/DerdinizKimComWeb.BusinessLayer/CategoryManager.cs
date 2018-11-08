using DerdinizKimComWeb.Entities;
using DerdinizKimComWeb.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerdinizKimComWeb.BusinessLayer
{
    public class CategoryManager
    {
        private Repository<Kategori> repo_kategori = new Repository<Kategori>();
        public List<Kategori> GetKategoriler()
        {
            return repo_kategori.List();
        }
        public Kategori GetCategoriById(int id)
        {
            return repo_kategori.Find(x => x.id == id);

        }
    }
}
