using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.DAL.Database.Models
{
    public class book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public double Wordcount{ get; set; }
        public bool Binding { get; set; }
        public DateTime Year { get; set; }

    }
}
