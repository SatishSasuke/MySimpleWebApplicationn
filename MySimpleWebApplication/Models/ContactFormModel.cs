using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySimpleWebApplication.Models
{
    public class ContactFormModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int? Age { get; set; }
        public string ContactNumber { get; set; }
    }
}
