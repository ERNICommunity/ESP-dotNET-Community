using System;

namespace WarColors.Models
{
    public class MasterViewMenuItem
    {
        public MasterViewMenuItem()
        {
            // TargetType = typeof(MasterViewDetail);
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
