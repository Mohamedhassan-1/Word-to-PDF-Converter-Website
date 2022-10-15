using converterWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrapeCity.Documents.Word;
using System.IO;
namespace converterWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ConverterVM converterVM)
        {
            string docPath = Directory.GetCurrentDirectory() + "/wwwroot/";
            string Name=Guid.NewGuid()+Path.GetFileName(converterVM.document.FileName);
            docPath += Name;
            using(var strem=new FileStream(docPath,FileMode.Create))
            {
                converterVM.document.CopyTo(strem);
            }

            var doc = new GcWordDocument();
            doc.Load(docPath);
            System.IO.File.Delete(docPath);
            docPath +=".pdf";
            doc.SaveAsPdf(docPath);
            ViewBag.loctaion = Name+".pdf";
            return View();
        }
    }
}
