using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrewManTest.Models
{
    public class CrewChangeModel
    {
        public int Num { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string SignOnPort { get; set; }
        public string SignOffPort { set; get; }
        public string SignOnDate { set; get; }
        public string SignOffDate { set; get; }
    }
}
