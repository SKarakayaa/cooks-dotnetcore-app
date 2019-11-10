using CooksProjectCore.Core.DAL.EntityFramework;
using CooksProjectCore.DAL.Asbtract;
using CooksProjectCore.DAL.Concrete.EntityFramework.Context;
using CooksProjectCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooksProjectCore.DAL.Concrete.EntityFramework
{
    public class EFFoodDAL : EFEntityRepositoryBase<Food, CooksContext>, IFoodDAL
    {
        public void AddEquipment(Guid foodId, string equipments)
        {
            using (var db = new CooksContext())
            {
                string[] _equipments = equipments.Split(',');
                foreach (var equipment in _equipments)
                {
                    var food_equipment = new FoodEquipment { FoodID = foodId, EquipmentName=equipment };
                    db.Entry(food_equipment).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    db.SaveChanges();
                }
            }
        }

        public List<FoodEquipment> GetEquipments(Guid foodId)
        {
            using (var db = new CooksContext())
            {
                var foodEquipments = from food_equipment in db.FoodEquipments
                                     where food_equipment.FoodID == foodId
                                     select food_equipment;
                return foodEquipments.ToList();
            }

        }
        public List<Like> GetLikes(Guid foodId)
        {
            using (var db = new CooksContext())
            {
                var likes = db.Likes.Where(w => w.FoodID == foodId).ToList();
                return likes;
            }
        }
        public void AddLike(Guid foodId, int userId)
        {
            using (var db = new CooksContext())
            {
                var newLike = new Like
                {
                    FoodID = foodId,
                    UserID = userId
                };
                db.Entry(newLike).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                db.SaveChanges();
            }
        }
        public void DeleteLike(Guid foodId, int userId)
        {
            using (var db = new CooksContext())
            {
                var newLike = new Like
                {
                    FoodID = foodId,
                    UserID = userId
                };
                db.Entry(newLike).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
