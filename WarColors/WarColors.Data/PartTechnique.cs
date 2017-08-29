using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarColors.Data
{
    public class PartTechnique : RealmObject
    {
        public string Technique { get; set; }

        public Paint Paint { get; set; }

    }
}
