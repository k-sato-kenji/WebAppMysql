using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebAppMysql.Models
{
    
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MyDbContext : DbContext
    {
      public MyDbContext() : base("MyCon")
        {

        }

        public DbSet<Student> Students { get; set; } // Student単数形で書く

    }
}