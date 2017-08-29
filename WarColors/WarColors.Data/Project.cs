using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarColors.Data
{
    public class Project
    {
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }

        public IList<Model> Models { get; set; }

    }
}