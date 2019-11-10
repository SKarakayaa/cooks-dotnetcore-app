using CooksProjectCore.Core.DAL;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.DAL.Asbtract
{
    public interface IFoodDAL:IEntityRepository<Food>
    {
        List<FoodEquipment> GetEquipments(Guid foodId);
        void AddEquipment(Guid foodId, string equipments);

        List<Like> GetLikes(Guid foodId);
        void AddLike(Guid foodId, int userId);
        void DeleteLike(Guid foodId, int userId);
    }
}
