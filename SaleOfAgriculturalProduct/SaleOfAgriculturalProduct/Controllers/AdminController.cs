using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaleOfAgriculturalProduct.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            return this.CustomView("");
        }

        [HttpPost]
        public ActionResult PickPdf()
        {
            var files = Request.Form.Files;

            if (files != null && files.Count > 0)
            {
                IFormFile selectedFile = files[0];
                return this.CustomView(selectedFile.FileName, selectedFile);
            }

            return this.CustomView("File could not be processed");
        }

        //private ActionResult CustomView(string message, IFormFile formFile = null)
        //{
        //    var returnView = View("Index");
        //    returnView.ViewData["Message"] = message;

        //    if (formFile != null)
        //    {
        //        var readStream = formFile.OpenReadStream();
        //        byte[] bytes = new byte[readStream.Length];
        //        readStream.Read(bytes, 0, Convert.ToInt32(readStream.Length));
        //        returnView.ViewData["FormFile"] = bytes;
        //    }

        //    return returnView;
        //}
        private ActionResult CustomView(string message, IFormFile formFile = null)
        {
            var returnView = View("Contact");
            returnView.ViewData["Message"] = message;

            if (formFile != null)
            {
                var readStream = formFile.OpenReadStream();
                byte[] bytes = new byte[readStream.Length];
                readStream.Read(bytes, 0, Convert.ToInt32(readStream.Length));
                var strBase64 = Convert.ToBase64String(bytes);
                var content = string.Format("data:application/pdf;base64,{0}", strBase64);
                ViewData["FormFile"] = content;
            }

            return returnView;
        }
    }
}