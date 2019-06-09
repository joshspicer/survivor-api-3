using System;
using System.Collections.Generic;

namespace survivorapi3.Models
{

    public class Tribe
    {
   
        public long Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }


        // Members of the tribe
        public ICollection<Player> players { get; set; }

    }
}
