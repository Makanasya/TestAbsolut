using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAbsolut.Model
{
    internal class Doc
    {
        public int Id { get; set; }
        public string Seria { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Person PersonDoc { get; set; }
    }
}
