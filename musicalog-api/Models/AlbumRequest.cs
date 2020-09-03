using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicalog_api.Model
{
    public class AlbumRequest
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
