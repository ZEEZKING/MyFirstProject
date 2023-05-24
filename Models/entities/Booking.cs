using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Models.enums;

namespace Hotel_App.Models.entities
{
    public class Booking : BaseEntity
    {
        public RoomType RoomType;
        public DateTime CheckIn;
        public DateTime CheckOut;
        public BookingStatus Status = BookingStatus.pending;
        public int Duration;
        public int BooKingNumber;

        public Booking(int id, RoomType roomType,int duration,int bookingNumber,bool isDeleted) : base(id,isDeleted)
        {
            RoomType = roomType;
            Duration = duration;
            BooKingNumber = bookingNumber;
        }
    }
}