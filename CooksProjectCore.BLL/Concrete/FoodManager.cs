using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.BLL.Validation.FluentValidation;
using CooksProjectCore.Core.Aspects.Validation;
using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class FoodManager : IFoodService
    {
        private IFoodDAL _foodDAL;
        public FoodManager(IFoodDAL _foodDAL)
        {
            this._foodDAL = _foodDAL;
        }
        [ValidationAspect(typeof(FoodValidation),Priority = 1)]
        public IResult Add(Food food)
        {
            _foodDAL.Add(food);
            return new SuccessResult("Yemek Tarifi Başarıyla Eklendi !...");
        }

        public IResult AddEquipment(Guid foodId, string equipments)
        {
            _foodDAL.AddEquipment(foodId, equipments);
            return new SuccessResult("Tarifler Başarıyla Eklendi !...");
        }

        public IDataResult<Food> Get(Guid foodId)
        {
            return new SuccessDataResult<Food>(_foodDAL.Get(f => f.ID == foodId));
        }

        public IDataResult<List<FoodEquipment>> GetEquipments(Guid foodId)
        {
            return new SuccessDataResult<List<FoodEquipment>>(_foodDAL.GetEquipments(foodId));
        }

        public IDataResult<List<Food>> GetList()
        {
            return new SuccessDataResult<List<Food>>(_foodDAL.GetList().ToList());
        }

        public IDataResult<List<Food>> GetList(int userId)
        {
            return new SuccessDataResult<List<Food>>(_foodDAL.GetList(w => w.UserID == userId).ToList());
        }

        public IDataResult<List<Food>> GetListByType(int typeId)
        {
            return new SuccessDataResult<List<Food>>(_foodDAL.GetList(w => w.FoodType == typeId).ToList());
        }

        public IResult Remove(Food food)
        {
            _foodDAL.Remove(food);
            return new SuccessResult("Yemek Tarifi Başarıyla Silindi !...");
        }

        public IResult Update(Food food)
        {
            _foodDAL.Update(food);
            return new SuccessResult("Yemek Tarifi Başarıyla Güncellendi !...");
        }

        public IDataResult<List<Like>> GetLikes(Guid foodId)
        {
            return new SuccessDataResult<List<Like>>(_foodDAL.GetLikes(foodId));
        }
        public IResult AddLike(Like like)
        {
            _foodDAL.AddLike(like.FoodID, like.UserID);
            return new SuccessResult();
        }
        public IResult DeleteLike(Like like)
        {
            _foodDAL.DeleteLike(like.FoodID, like.UserID);
            return new SuccessResult();
        }
    }
}
