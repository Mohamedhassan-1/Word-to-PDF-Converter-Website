using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace converterWebsite.Models
{
    public class ConverterVM
    {
        public IFormFile document { get; set; }
    }
}
