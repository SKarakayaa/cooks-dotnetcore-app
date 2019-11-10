using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CooksProjectCore.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        public CommentController(ICommentService _commentService)
        {
            this._commentService = _commentService;
        }

        [HttpGet]
        [Route("foods/{foodId}/comments")]
        public IActionResult GetCommets(Guid foodId)
        {
            var result = _commentService.GetComments(foodId);
            if (result.Succes)
                return Ok(result.Data);
            return NotFound(result.Message);
        }

        [HttpPost]
        [Route("foods/{foodId}/comments")]
        [Authorize]
        public IActionResult AddComment(Comment comment)
        {
            comment.ID = Guid.NewGuid();
            comment.AddedDate = DateTime.Now;
            var result = _commentService.AddComment(comment);
            if (result.Succes)
                return Ok(result.Message);
            return NotFound(result.Message);
        }

        [HttpPost]
        [Route("foods/{foodId}/comment-reply")]
        [Authorize]
        public IActionResult AddCommentReply(CommentReply commentReply)
        {
            commentReply.ID = Guid.NewGuid();
            commentReply.AddedDate = DateTime.Now;
            var result = _commentService.AddCommentReply(commentReply);
            if (result.Succes)
                return Ok(result.Message);
            return NotFound(result.Message);
        }

        [HttpDelete]
        [Route("foods/comments/{commentId}")]
        [Authorize]
        public IActionResult DeleteComment(Guid commentId)
        {
            var result = _commentService.DeleteComment(commentId);
            if (result.Succes)
                return Ok();
            return NotFound();
        }

        [HttpDelete]
        [Route("foods/comments/reply/{replyId}")]
        [Authorize]
        public IActionResult DeleteCommentReply(Guid replyId)
        {
            var result = _commentService.DeleteCommentReply(replyId);
            if (result.Succes)
                return Ok();
            return NotFound();
        }
    }
}