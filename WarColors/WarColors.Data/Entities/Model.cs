using System.Collections.Generic;

namespace WarColors.Data.Entities
{
    public class Model
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }

        public IList<Part> Parts { get; set; }
    }
}