using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.DAL.Database.Models
{
    public class Author
    {
        public int AuthorID { get; set; } // PK
        public string name { get; set; }
        public int age { get; set; }
        public string password { get; set; }
        public bool isAlive { get; set; }
    }
}
