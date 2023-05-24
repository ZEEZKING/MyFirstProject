using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Interface
{
    public interface IBookingManager
    {
        Booking CreateBooking(RoomType RoomType,int duration);
        Booking CheckIn(int bookingNumber);
        Booking CheckOut(int bookingNumber);
        Booking Get(int bookingNumber);
        Booking Terminate(int bookingNumber);
        List<Booking> GetAll();
       

    }
}