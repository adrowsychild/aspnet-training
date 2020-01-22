using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day21Task2.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public string ThumbPath { get; set; }

        public string Description { get; set; }
    }
}