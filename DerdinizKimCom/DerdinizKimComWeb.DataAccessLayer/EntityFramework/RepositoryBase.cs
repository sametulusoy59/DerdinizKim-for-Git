﻿using DerdinizKimComWeb.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerdinizKimComWeb.DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        private static DatabaseContext _db;
        private static object _lockSync = new object(); 
        protected RepositoryBase()
        {

        }
        public static DatabaseContext CreateContext()
        {
            if (_db == null)
            {
                lock (_lockSync)
                {
                    if (_db == null)
                    {
                        _db = new DatabaseContext();
                    }
                }
                
            }
            return _db;
        }
        


        
    }
}
