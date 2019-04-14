using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryViewModel()
        {

        }

        public CategoryViewModel(string name)
        {
            Name = name;
        }
    }
}