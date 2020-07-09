using System.Web.Http;
using System.Web.Http.Cors;

namespace WorkingAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class SehirController : ApiController
    {
        string[] sehirler = {"Antalya","İzmir","Ankara"};

        //domainadresi/api/sehir 
        public string[] Get()
        {
            return sehirler;
        }
        public string Get(int id)
        {
            return sehirler[id];
        }
    }
}
