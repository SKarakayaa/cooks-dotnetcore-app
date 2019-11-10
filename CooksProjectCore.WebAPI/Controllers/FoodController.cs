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
    public class FoodController : ControllerBase
    {
        private IFoodService _foodService;
        public FoodController(IFoodService _foodService)
        {
            this._foodService = _foodService;
        }
        [HttpGet]
        [Route("foods/")]
        public IActionResult GetFoods()
        {
            var result = _foodService.GetList();
            if (result.Succes)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("foods/user/{userId}")]
        public IActionResult GetFoods(int userId)
        {
            var result = _foodService.GetList(userId);
            if (result.Succes)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("foods/type/{typeId}")]
        public IActionResult GetFoodsByType(int typeId)
        {
            var result = _foodService.GetListByType(typeId);
            if (result.Succes)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
        [HttpGet]
        [Route("foods/{foodId}")]
        public IActionResult GetFood(Guid foodId)
        {
            var result = _foodService.Get(foodId);
            if (result.Succes)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
        [HttpPost]
        [Route("foods/")]
        [Authorize(Roles ="Product.Add")]
        public IActionResult AddFood(Food food)
        {
            var result = _foodService.Add(food);
            if (result.Succes)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPut]
        [Route("foods/")]
        [Authorize(Roles ="Product.Update")]
        public IActionResult UpdateFood(Food food)
        {
            var result = _foodService.Update(food);
            if (result.Succes)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpDelete]
        [Route("foods/")]
        [Authorize(Roles ="Product.Delete")]
        public IActionResult DeleteFood(Food food)
        {
            var result = _foodService.Remove(food);
            if (result.Succes)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpGet]
        [Route("foods/{foodId}/equipments")]
        public IActionResult GetEquipments(Guid foodId)
        {
            var result = _foodService.GetEquipments(foodId);
            if (result.Succes)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
        [HttpPost]
        [Route("foods/{foodId}/equipments")]
        [Authorize]
        public IActionResult AddEquipment(Guid foodId, [FromBody]string equipments)
        {
            var result = _foodService.AddEquipment(foodId, equipments);
            if (result.Succes)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpGet]
        [Route("foods/{foodId}/likes")]
        public IActionResult GetLikes(Guid foodId)
        {
            var result = _foodService.GetLikes(foodId);
            if (result.Succes)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
        [HttpPost]
        [Route("foods/add-like")]
        [Authorize]
        public IActionResult AddLike(Like like)
        {
            var result = _foodService.AddLike(like);
            if (result.Succes)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpDelete]
        [Route("foods/add-like")]
        [Authorize]
        public IActionResult DeleteLike(Like like)
        {
            var result = _foodService.DeleteLike(like);
            if (result.Succes)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}