using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CooksProjectCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        [Route("comments/add-comment")]
        public IActionResult AddComment(Comment comment)
        {
            comment.ID = Guid.NewGuid();
            comment.AddedDate = DateTime.Now;
            var result = _commentService.AddComment(comment);
            if (!result.Succes)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }
        [HttpPut]
        [Route("comments/update-comment")]
        public IActionResult UpdateComment(Comment comment)
        {
            var result = _commentService.DeleteComment(comment.ID);
            if (!result.Succes)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }
    }
}