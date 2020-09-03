using System;
using System.Collections.Generic;

namespace Musical.Entity.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Type { get; set; }
        public string Stock { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
    }
}