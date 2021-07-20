using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BantrAPI.Models;
using BantrAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BantrAPI.Controllers
{
    [ApiController]
    [Route("api/conversations")]
    public class ConversationController : Controller
    {
        private readonly ConversationService _conversationService;
        public ConversationController(ConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<List<Conversation>> Get() =>
            _conversationService.Get();
        // Need to test this and see if this actually does what I need for it to do.

        // GET api/values/5
        [HttpGet("{id}")]
        // Need to add return function here

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
    };
}
