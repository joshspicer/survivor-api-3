using System;
using System.ComponentModel.DataAnnotations;

namespace survivorapi3.Models
{
    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Major { get; set; }
        public string Hometown { get; set; }

    }
}
