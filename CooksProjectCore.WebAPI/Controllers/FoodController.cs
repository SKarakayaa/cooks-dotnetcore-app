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
    [Route("api/")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly ILikeService _likeService;
        private readonly IMapper _mapper;
        public FoodController(IFoodService foodService,ILikeService likeService,IMapper mapper)
        {
            _foodService = foodService;
            _likeService = likeService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("foods/")]
        public IActionResult GetFoods()
        {
            var foods = _foodService.GetList();
            if (!foods.Succes)
                return BadRequest(foods.Message);
            var foodsDTO = _mapper.Map<List<FoodsDTO_ForList>>(foods.Data);
            return Ok(foodsDTO);
        }
        [HttpGet]
        [Route("foods/{userId}")]
        public IActionResult GetFoodsByUser(int userId)
        {
            var foods = _foodService.GetListByUser(userId);
            if (!foods.Succes)
                return BadRequest(foods.Message);
            var foodsDTO = _mapper.Map<List<FoodsDTO_ForList>>(foods.Data);
            return Ok(foodsDTO);
        }
        [HttpGet]
        [Route("foods/{foodId}")]
        public IActionResult GetFood(Guid foodId)
        {
            var food = _foodService.Get(foodId);
            if (!food.Succes)
                return BadRequest(food.Message);
            var foodDTO = _mapper.Map<FoodsDTO_ForDetail>(food.Data);
            return Ok(foodDTO);
        }
        [HttpPost]
        [Route("foods/")]
        public IActionResult Add(Food food)
        {
            food.ID = Guid.NewGuid();
            food.AddedDate = DateTime.Now;
            _foodService.Add(food);
            return Ok();
        }
        [HttpPut]
        [Route("foods/")]
        public IActionResult Update(Food food)
        {
            food.ModifiedDate = DateTime.Now;
            _foodService.Update(food);
            return Ok();
        }
        [HttpDelete]
        [Route("foods/{foodId}")]
        public IActionResult Delete(Guid foodId)
        {
            var food = _foodService.Get(foodId);
            _foodService.Remove(food.Data);
            return Ok();
        }
        [HttpPost]
        [Route("foods/equipments/{foodId}")]
        public IActionResult AddEquipments(Guid foodId,[FromBody]string equipments)
        {
            var result = _foodService.AddEquipment(foodId, equipments);
            if (!result.Succes)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }
        [HttpPost]
        [Route("foods/add-like/{foodId}")]
        public IActionResult AddLike(Like like)
        {
            _likeService.AddLike(like);
            return Ok();
        }
        [HttpPost]
        [Route("foods/delete-like/{foodId}")]
        public IActionResult DeleteLike(Like like)
        {
            _likeService.DeleteLike(like);
            return Ok();
        }
        [HttpGet]
        [Route("foods/likes/{foodId}")]
        public IActionResult Likes(Guid foodId)
        {
            var likes = _likeService.GetLikes(foodId);
            return Ok(likes);
        }
    }
}