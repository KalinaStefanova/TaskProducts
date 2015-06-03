using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProductsAndCategories.Controllers
{
    public class UploadController : ApiController
    {
        [HttpPost]
        public void UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), httpPostedFile.FileName);
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
        }

    }
}
