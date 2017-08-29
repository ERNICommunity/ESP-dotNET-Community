using System;
using System.Collections.Generic;
using WarColors.Data.Repositories;

namespace WarColors.Data.Entities
{
    public class Project : IEntity<string>
    {
        public string Title { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }

        public IList<Model> Models { get; set; }
        public string Id { get; set; }
    }
}