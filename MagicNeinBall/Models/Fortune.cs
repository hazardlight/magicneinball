using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagicNeinBall.Models
{
    public class Fortune
    {
        public int Id { get; set; }
        public string fortuneText { get; set; }
        public int rIndex { get; set; }
    }
    public class FortuneDBContext: DbContext
    {
        public FortuneDBContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Fortune> Fortunes { get; set; }
    }
}