using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAbsolut.Model
{
    internal class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string TelNumber { get; set; }
        public string Email { get; set; }
        public Adress AdressRegId { get; set; }
        public Adress AdressFactId { get; set; }
        public List<Doc> Docs { get; set; }

    }
}
