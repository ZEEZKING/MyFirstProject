using Hotel_App.Models.enums;

namespace Hotel_App.Models.entities
{
    public class Room : BaseEntity
    {
        public RoomType RoomType;
        public double Price;
        public int RoomNumber;
        public int Quantity;
        public bool booked;

        public Room(int id, RoomType roomType, double price, int roomNumber,int quantity,bool Booked,bool isDeleted) : base(id,isDeleted)
        {
            RoomType = roomType;
            Price = price;
            RoomNumber = roomNumber;
            booked = Booked;
            Quantity = quantity;
            
        }
    }
}