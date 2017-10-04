using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SerializersComparison.DAL;
using SerializersComparison.Models;

namespace SerializersComparison.Controllers
{
    public class RecordsController : ApiController
    {
        private readonly ILarRepository _lar;
        public RecordsController(ILarRepository lar)
        {
            _lar = lar;
        }
        // GET api/records
        public IEnumerable<HmdfEntity> Get()
        {
            return _lar.GetHmdfRows(1000).ToList();

        }

        // GET api/records/5
        public List<HmdfEntity> Get(int id)
        {

            return _lar.GetHmdfRows(id).ToList();
        }

        // POST api/records
        public void Post([FromBody]List<HmdfEntity> value)
        {
        }
       
    }
}
