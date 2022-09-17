using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Movies.Core.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public int MovieId { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
    }
}
