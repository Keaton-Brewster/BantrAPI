using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BantrAPI.Models;
using BantrAPI.Services;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BantrAPI.Controllers
{
    [ApiController]
    [Route("api/conversations")]
    public class ConversationController : ControllerBase
    {
        private readonly ConversationService _conversationService;
        public ConversationController(ConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<List<Conversation>> Get() =>
            _conversationService.GetAll();
        // Need to test this and see if this actually does what I need for it to do.

        // GET api/values/5
        [HttpGet("{id}")]
        // public ActionResult<List<Conversation>> Get(string id) =>
        public ActionResult<List<Conversation>> Get(string id) =>
            _conversationService.Get(id);

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
