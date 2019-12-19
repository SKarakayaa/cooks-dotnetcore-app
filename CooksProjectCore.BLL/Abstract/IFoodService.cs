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
        IDataResult<List<Food>> GetList();
        IDataResult<List<Food>> GetListByUser(int userId);
        IDataResult<Food> Get(Guid foodId);
        IResult Add(Food food);
        IResult Remove(Food food);
        IResult Update(Food food);
        IResult AddEquipment(Guid foodId, string equipments);
    }
}
