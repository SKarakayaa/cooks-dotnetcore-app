using CooksProjectCore.Core.Utilities.Results;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Abstract
{
    public interface IFoodService
    {
        IDataResult<List<Food>> GetList();
        IDataResult<List<Food>> GetList(int userId);
        IDataResult<List<Food>> GetListByType(int typeId);
        IDataResult<Food> Get(Guid foodId);
        IResult Add(Food food);
        IResult Remove(Food food);
        IResult Update(Food food);
        IDataResult<List<FoodEquipment>> GetEquipments(Guid foodId);
        IResult AddEquipment(Guid foodId, string equipments);

        IDataResult<List<Like>> GetLikes(Guid foodId);
        IResult AddLike(Like like);
        IResult DeleteLike(Like like);
    }
}
