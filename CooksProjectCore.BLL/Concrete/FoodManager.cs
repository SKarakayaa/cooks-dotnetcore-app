using AutoMapper;
using CooksProjectCore.BLL.Abstract;
using CooksProjectCore.BLL.Constants;
using CooksProjectCore.BLL.Validation.FluentValidation;
using CooksProjectCore.Core.Aspects.Caching;
using CooksProjectCore.Core.Aspects.Logging;
using CooksProjectCore.Core.Aspects.Validation;
using CooksProjectCore.Core.CrossCuttingConcerns.Logging.log4net.Loggers;
using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Concrete
{
    public class FoodManager : IFoodService
    {
        private readonly IFoodDAL _foodDAL;
        private readonly IMapper _mapper;
        public FoodManager(IFoodDAL foodDAL,IMapper mapper)
        {
            _foodDAL = foodDAL;
            _mapper = mapper;
        }
        [AspectValidation(typeof(FoodValidation),Priority = 1)]
        [RemoveCacheAspect(pattern:"IFoodService.Get",Priority = 2)]
        [LogAspect(typeof(RequestsFileLogger), Priority = 3)]
        public IResult Add(FoodDTO_ForSave food)
        {
            _foodDAL.Add(_mapper.Map<Food>(food));
            return new SuccessResult();
        }

        public IResult AddEquipment(Guid foodId, string equipments)
        {
            _foodDAL.AddEquipment(foodId, equipments);
            return new SuccessResult();
        }

        public IDataResult<FoodsDTO_ForDetail> Get(Guid foodId)
        {
            var food = _foodDAL.Get(x => x.ID == foodId, new string[] { "User","FoodEquipments" });
            return new SuccessDataResult<FoodsDTO_ForDetail>(_mapper.Map<FoodsDTO_ForDetail>(food));
        }
        [CacheAspect(30,Priority = 1)]
        public IDataResult<List<FoodsDTO_ForList>> GetList()
        {
            var foods = _foodDAL.GetList(null , new string[] { "User" });
            return new SuccessDataResult<List<FoodsDTO_ForList>>(_mapper.Map<List<FoodsDTO_ForList>>(foods));
        }
        [CacheAspect(30, Priority = 1)]
        public IDataResult<List<FoodsDTO_ForList>> GetListByUser(int userId)
        {
            var foods = _foodDAL.GetList(x => x.UserID == userId, new string[] { "User" });
            return new SuccessDataResult<List<FoodsDTO_ForList>>(_mapper.Map<List<FoodsDTO_ForList>>(foods));
        }
        [LogAspect(typeof(RequestsFileLogger), Priority = 1)]
        public IResult Remove(Guid foodId)
        {
            var food = _foodDAL.Get(x => x.ID == foodId);
            _foodDAL.Remove(food);
            return new SuccessResult();
        }
        [AspectValidation(typeof(FoodValidation),Priority = 1)]
        [RemoveCacheAspect(pattern: "IFoodService.Get", Priority = 2)]
        [LogAspect(typeof(RequestsFileLogger), Priority = 3)]
        public IResult Update(FoodDTO_ForSave food)
        {
            _foodDAL.Update(_mapper.Map<Food>(food));
            return new SuccessResult();
        }
    }
}
