using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccess.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("DefaultConnection")
        {
        }

        public virtual IDbSet<Product> Producs { get; set; }
    }
}
