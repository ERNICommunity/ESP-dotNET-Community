using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarColors.Data
{
    public class Paint
    {
        public string Name { get; set; }
        public PaintType PaintType { get; set; }

        public bool IsMetallic { get; set; }
    }
}
