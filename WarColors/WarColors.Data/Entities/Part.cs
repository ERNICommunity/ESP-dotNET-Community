using System.Collections.Generic;

namespace WarColors.Data.Entities
{
    public class Part
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<PartTechnique> Techniques { get; set; }
    }
}