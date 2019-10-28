using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
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
        public IResult Add(Food food)
        {
            _foodDAL.Add(food);
            return new SuccessResult("Yemek Tarifi Başarıyla Eklendi !...");
        }

        public IDataResult<Food> Get(Guid foodId)
        {
            return new SuccessDataResult<Food>(_foodDAL.Get(f => f.ID == foodId));
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
    }
}
