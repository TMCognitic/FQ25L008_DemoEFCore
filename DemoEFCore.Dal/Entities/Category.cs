using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore.Dal.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Propriété de navigation
        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
