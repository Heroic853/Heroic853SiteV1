using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dto
{
    public class Dragon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Element { get; set; }

        public string Class { get; set; }

        public int Defence { get; set; }
        public string Map { get; set; }
    }
}
