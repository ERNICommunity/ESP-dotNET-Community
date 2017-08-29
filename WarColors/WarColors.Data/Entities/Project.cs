using System;
using System.Collections.Generic;

namespace WarColors.Data.Entities
{
    public class Project
    {
        public string Title { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }

        public IList<Model> Models { get; set; }
    }
}