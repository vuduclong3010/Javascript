using BookApi.Data.Service;
using BookApi.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherService _publisherService;

        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddAuthor([FromBody] PublisherVM publisher)
        {
            _publisherService.AddAuthor(publisher);
            return Ok();
        }

        [HttpGet("get-publisher-with-author")]
        public IActionResult GetPuslisherDataAll()
        {
            var response = _publisherService.GetPublisherDataAll();
            return Ok(response);
        }

        [HttpGet("get-publisher-books-with-authors/{publisherid}")]
        public IActionResult GetPublisherData(int publisherid)
        {
            var response = _publisherService.GetPublisherData(publisherid);
            return Ok(response);
        }

        [HttpPut("put-publisher-by-id/{id}")]
        public IActionResult UpdatePublisherById(int id, [FromBody] PublisherVM publisher)
        {
            var updatePublisher = _publisherService.UpdatePublisherById(id, publisher);
            return Ok(updatePublisher);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publisherService.DeletePublisherById(id);
            return Ok();
        }
    }
}
