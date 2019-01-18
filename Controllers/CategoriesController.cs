using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DACIS_api.classes;
using Microsoft.AspNetCore.Mvc;

namespace DACIS_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            string url = "http://webservice.yaghin.org/Mainservice.asmx?op=GetCategories";
            string body = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\r\n  <soap:Body>\r\n    <GetCategories xmlns=\"http://tempuri.org/\">\r\n      <CourseID>1</CourseID>\r\n    </GetCategories>\r\n  </soap:Body>\r\n</soap:Envelope>";
            Xml2json _xml2json = new Xml2json(url,body);
            
            return _xml2json.xml2json();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
