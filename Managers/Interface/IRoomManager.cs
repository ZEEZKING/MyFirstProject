using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Interface
{
    public interface IRoomManager
    {
         Room GetRoomType(RoomType roomType);
         Room GetRoom(int roomNumber); 
         Room Get(int id);   
         List<Room> GetAll();
         Room Create(RoomType roomType,int quantity);
     
    }
}