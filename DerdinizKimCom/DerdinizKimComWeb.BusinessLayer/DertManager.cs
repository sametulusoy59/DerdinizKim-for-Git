using DerdinizKimComWeb.DataAccessLayer.EntityFramework;
using DerdinizKimComWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerdinizKimComWeb.BusinessLayer
{
    public class DertManager
    {
        private Repository<Dert> repo_dert = new Repository<Dert>();
        public List<Dert> GetDerts()
        {
            return repo_dert.List();
        }
    }
}
