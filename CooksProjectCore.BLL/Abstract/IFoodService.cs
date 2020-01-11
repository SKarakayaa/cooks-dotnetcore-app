using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Abstract
{
    public interface IFoodService
    {
        IDataResult<List<FoodsDTO_ForList>> GetList();
        IDataResult<List<FoodsDTO_ForList>> GetListByUser(int userId);
        IDataResult<FoodsDTO_ForDetail> Get(Guid foodId);
        IResult Add(FoodDTO_ForSave food);
        IResult Remove(Guid foodId);
        IResult Update(FoodDTO_ForSave food);
        IResult AddEquipment(Guid foodId, string equipments);
    }
}
