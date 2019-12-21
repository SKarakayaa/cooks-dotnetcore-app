using AutoMapper;
using CooksProjectCore.Entities.Concrete;
using CooksProjectCore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.BLL.Mapping.Automapper
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Comment, CommentReplyDTO>().ReverseMap();
            CreateMap<FoodEquipment, FoodEquipmentDTO>().ReverseMap();
            CreateMap<Food, FoodsDTO_ForDetail>().ReverseMap();
            CreateMap<Food, FoodsDTO_ForList>().ReverseMap();
            CreateMap<User, UserDTO_ForEntities>().ReverseMap();
            CreateMap<User, UserDTO_ForView>().ReverseMap();
            CreateMap<FollowTable, FollowTableDTO>().ReverseMap();
            CreateMap<FollowTable, FollowerTableDTO>().ReverseMap();
        }
    }
}
