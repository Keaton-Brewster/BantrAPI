using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using BantrAPI.Models;
using BantrAPI.Services;
using System.Text.Json;

namespace BantrAPI.Controllers
{
    [ApiController]
    [Route("api/conversations")]
    public class ConversationController
    {
        private readonly ConversationService _conversationService;
        public ConversationController(ConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        [HttpGet]
        public ActionResult<List<Conversation>> Get() =>
            _conversationService.Get();

        // Route for getting the list of conversations a user is a member of
        [HttpGet("{id}")]
        public ActionResult<List<Conversation>> Get(string id) =>
            _conversationService.Get(id);

        [HttpGet("getInfo/{convoId}")]
        public ActionResult<TempConversation> GetConversationInformation(string convoId) =>
            _conversationService.GetConversationInformation(convoId);

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    };
}
