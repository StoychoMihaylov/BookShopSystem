using System.Collections.Generic;
using System.Web.Http;

namespace BookShopSystem.Web.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        /// <summary>
        /// This gets all the values from the values controller which are static by now
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// This returns the value selected by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// This inserts a value in the database
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// This edits the value with the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// This delete the value with the given Id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
}
