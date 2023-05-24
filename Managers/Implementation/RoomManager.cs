using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Managers.Interface;
using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Implementation
{
    public class RoomManager : IRoomManager
    {
        public static List<Room> roomDb = new List<Room>();
        public Room Create(RoomType roomType,int quantity)
        {
            Random rand = new Random();
            var generate = rand.Next(1,100);
      
            var roomCheck = Check(generate);
            if (roomCheck == false)
            {
                System.Console.WriteLine("Room is found");
            }
            var price = 0;
           if (roomType == RoomType.PlantiniumRoom )
           {
            price = 20000;
           }
           else if (roomType == RoomType.SilverRoom)
           {
            price = 15000;
           }
           else if (roomType == RoomType.BronzeRoom)
           {
            price = 10000;
           }
           roomType -= quantity;
            Room room = new Room(RoomManager.roomDb.Count+1,roomType,price,generate,quantity,false,false);
            roomDb.Add(room);
            return room;
        }

    

        public List<Room> GetAll()
        {
            return roomDb;
        }

        public Room GetRoom(int roomNumber)
        {
            foreach (var room in roomDb)
            {
                if (room.RoomNumber == roomNumber)
                {
                    return room;
                }
            }
            return null;
        }

        public Room GetRoomType(RoomType roomType)
        {
            foreach (var item in roomDb)
            {
                if (item.RoomType == roomType)
                {
                    return item;
                }
            }
            return null;
        }
        private bool Check(int RoomNumber)
        {
            foreach (var room in roomDb)
            {
                if (room.RoomNumber == RoomNumber)
                {
                    return false;
                }
            }
            return true;
        }
        public Room Get(int id)
        {
            foreach (var item in roomDb)
            {
               if (item.Id == id)
               {
                return item;
               } 
            }
            return null;
        }
      
    }
}