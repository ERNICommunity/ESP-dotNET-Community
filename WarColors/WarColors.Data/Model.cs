using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarColors.Data
{
    public class Model : RealmObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }

        public IList<Part> Parts { get; set; }

    }
}