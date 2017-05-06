using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string SC = @"Data Source=(localdb)\v11.0;Initial Catalog=TestCodeFirst;Integrated Security=True";
                 CarsContext db = new CarsContext();
                Console.WriteLine(db.Cars.Count());
             Console.ReadKey();
        }
    }

    class CarsContext : DbContext
    {
        public CarsContext()
        { }
        public CarsContext(string SC) : base  (SC)
        {
        }
        public DbSet<Car> Cars { get; set;}
    }
    class Car
    {
         public int id { get; set;}
         public string name{ get; set;}
    }
}
