using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Managers.Interface;
using Hotel_App.Models.entities;
using Hotel_App.Models.enums;

namespace Hotel_App.Managers.Implementation
{
    public class BookingManager : IBookingManager
    {
        public static List<Booking> bookingDb = new List<Booking>();

        public Booking CreateBooking(RoomType RoomType, int duration)
        {
            Random rand = new Random();
            int genBooking = rand.Next(200, 796);
            var booking = new Booking(BookingManager.bookingDb.Count + 1, RoomType, duration, genBooking,false);
            BookingManager.bookingDb.Add(booking);
            return booking;
        }

        public List<Booking> GetAll()
        {
            return bookingDb;
        }

        public Booking CheckIn(int bookingNumber)
        {
            var booking = Get(bookingNumber);
            if (booking == null)
            {
                return null;
            }
            if (booking.Status == BookingStatus.checkedIn)
            {
                System.Console.WriteLine("You have already checkedin before");
                return null;
            }
            booking.CheckIn = DateTime.Now;
            booking.Status = BookingStatus.checkedIn;
            return booking;
        }
        public void CheckBookingDuration()
        {
            foreach (var booking in bookingDb)
            {
                if (booking.Status == BookingStatus.checkedIn && booking.CheckIn.AddDays(booking.Duration) >= DateTime.Now)
                {
                    booking.CheckOut = DateTime.Now;
                    booking.Status = BookingStatus.checkedOut;
                }

            }
        }

        public Booking CheckOut(int bookingNumber)
        {
            var booking = Get(bookingNumber);
            if (booking == null)
            {
                return null;
            }
            if (booking.Status == BookingStatus.checkedOut)
            {
                System.Console.WriteLine("You have checkout before");
                return null;
            }
           
            booking.CheckOut = DateTime.Now;
            booking.Status = BookingStatus.checkedOut;

            return booking;
        }

        public Booking Get(int bookingNumber)
        {
            foreach (var item in bookingDb)
            {
                if (item.BooKingNumber == bookingNumber)
                {
                    return item;
                }
            }
            return null;
        }

        public Booking Terminate(int bookingNumber)
        {
            var bookingT = Get(bookingNumber);
             if (bookingT == null)
            {
                return null;
            }
            bookingT.Status = BookingStatus.Terminate;
            return bookingT;

        }
        
    

    }

}


