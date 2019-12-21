using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CooksProjectCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService,IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
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
        [HttpGet]
        [Route("comments/{foodId}")]
        public IActionResult GetCommentsByMenu(string foodId)
        {
            var result = _commentService.GetCommentsByMenu(Guid.Parse(foodId));
            if (!result.Succes)
                return BadRequest(result.Message);
            var commentDTO = _mapper.Map<List<CommentDTO>>(result.Data); 
            return Ok(commentDTO);
        }
    }
}