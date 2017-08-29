using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarColors.Data
{
    public class Part : RealmObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<PartTechnique> Techniques { get; set; }

    }
}
