using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Specian.Models
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
