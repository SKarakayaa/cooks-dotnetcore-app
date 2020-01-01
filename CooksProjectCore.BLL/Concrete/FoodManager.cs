using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.BLL.Constants;
using CooksProjectCore.BLL.Validation.FluentValidation;
using CooksProjectCore.Core.Aspects.Validation;
using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class FoodManager : IFoodService
    {
        private readonly IFoodDAL _foodDAL;
        public FoodManager(IFoodDAL foodDAL)
        {
            _foodDAL = foodDAL;
        }
        [AspectValidation(typeof(FoodValidation),Priority = 1)]
        public IResult Add(Food food)
        {
            _foodDAL.Add(food);
            return new SuccessResult();
        }

        public IResult AddEquipment(Guid foodId, string equipments)
        {
            _foodDAL.AddEquipment(foodId, equipments);
            return new SuccessResult();
        }

        public IDataResult<Food> Get(Guid foodId)
        {
            var food = _foodDAL.Get(x => x.ID == foodId, new string[] { "User","FoodEquipments" });
            return new SuccessDataResult<Food>(food);
        }

        public IDataResult<List<Food>> GetList()
        {
            var foods = _foodDAL.GetList(null , new string[] { "User" });
            return new SuccessDataResult<List<Food>>(foods);
        }

        public IDataResult<List<Food>> GetListByUser(int userId)
        {
            var foods = _foodDAL.GetList(x => x.UserID == userId, new string[] { "User" });
            return new SuccessDataResult<List<Food>>(foods);
        }

        public IResult Remove(Food food)
        {
            _foodDAL.Remove(food);
            return new SuccessResult();
        }
        [AspectValidation(typeof(FoodValidation),Priority = 1)]
        public IResult Update(Food food)
        {
            _foodDAL.Update(food);
            return new SuccessResult();
        }
    }
}
