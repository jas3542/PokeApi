using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PokeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeController : ControllerBase
    {
        // GET api/poke
        [HttpGet]
        public async Task<ActionResult<Pokemon[]>> GetAsync()
        {
            HttpClient client = new HttpClient();
            
            return await getPokemonsAsync();
        }

        private async Task<Pokemon[]> getPokemonsAsync()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync("https://pokeapi.co/api/v2/pokemon"))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();

                Poke po = null;
                if (result != null && result.Length >= 50)
                {
                    po = JsonConvert.DeserializeObject<Poke>(result);
                }
                return po.results;
            }
        }

        // GET api/poke/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/poke
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/poke/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/poke/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
