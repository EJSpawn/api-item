namespace teste_api.Controllers
{
    using item_api.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using teste_api.Infrastructure;

    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private MemoryContext _context;

        public ItemController(MemoryContext context){
            _context = context;
            var firstItem = context.Item.OrderByDescending(i => i.Id).Take(1).FirstOrDefault();
            var auxId = firstItem == null ? 1 : firstItem.Id+1;
            var maxId = auxId + 10;
            if(auxId <= 10) { 
                for(var i = auxId; i <= maxId; i++)
                {
                    var item = new Item()
                    {
                        Id = i,
                        Code = "Code " + i,
                        Description = "Desc " + i
                    };
                    context.Item.Add(item);
                
                    if(i % 10 == 0){
                        context.SaveChanges();
                    }
                }
            }
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {            
            return _context.Item.ToList();
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
