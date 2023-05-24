using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_App.Managers.Implementation;
using Hotel_App.Managers.Interface;
using Hotel_App.Models.enums;

namespace Hotel_App.Menu
{
    public class BookingMenu
    {
        IBookingManager bookingManager = new BookingManager();
        CustomerMenu customerMenu = new CustomerMenu();
        IRoomManager roomManager = new RoomManager();
        public void Main()
        {
            System.Console.WriteLine("Enter 1 to book\nEnter 2 to checkin\nEnter 3 to checkout\nEnter 4 to terminate booking\nEnter 5 to logout");
            int opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                MainBooking();
                Main();

            }
            else if (opt == 2)
            {
                CheckIn();
                Main();

            }
            else if (opt == 3)
            {
                Checkout();
                Main();

            }
            else if (opt == 4)
            {
                Terminate();

            }
            else if (opt == 5)
            {
                MainMenu main = new MainMenu();
                main.Main();
            }
            else
            {
                System.Console.WriteLine("Invalid input");
                Main();
            }
        }
        public void MainBooking()
        {
            var rooms = roomManager.GetAll();
            foreach (var item in roomManager.GetAll())
            {
                Console.WriteLine($"{item.Id}, {item.RoomType.ToString()}, {item.Quantity}");
            }
            System.Console.WriteLine("Enter the the type of room you want to book");
            var roomType = int.Parse(Console.ReadLine());
            var room = roomManager.Get(roomType);
            if (room == null)
            {
                System.Console.WriteLine("The room is not found");
                MainMenu main = new MainMenu();
                main.Main();
            }
            System.Console.WriteLine("enter the number of days you want lodge");
            int days = int.Parse(Console.ReadLine());

            var books = bookingManager.CreateBooking(room.RoomType, days);
            if (books == null)
            {
                System.Console.WriteLine("not exist");
            }
            else
            {
                System.Console.WriteLine($"Your room number is {room.RoomNumber}");
                System.Console.WriteLine($"Your booking number is {books.BooKingNumber}");
                System.Console.WriteLine();

            }
            customerMenu.MakePayment(room, days);
            RoomManager.roomDb.Remove(room);

        }
        public void CheckIn()
        {
            System.Console.Write("Enter your booking number to check in: ");
            int bookingNumber = int.Parse(Console.ReadLine());

            var getCheck = bookingManager.CheckIn(bookingNumber);
            if (getCheck == null)
            {
                System.Console.WriteLine("The booking number doesnt exist or you have checkedin before");
                BookingMenu bookingMenu = new BookingMenu();
                bookingMenu.Main();
            }
            else
            {
                System.Console.WriteLine($"You have successful checked in {DateTime.Now} ");
            }
        }
        public void Checkout()
        {
            System.Console.Write("Enter your booking number to terminatebooking : ");
            int booking = int.Parse(Console.ReadLine());
            var getOut = bookingManager.CheckOut(booking);
            if (getOut == null)
            {
                System.Console.WriteLine("The booking number doesnt exist");
                BookingMenu bookingMenu = new BookingMenu();
                bookingMenu.Main();

            }
            else
            {
                System.Console.WriteLine($"You Have successfully Checked Out {DateTime.Now}");
                System.Console.WriteLine("Thanks for patronizing us We appericiate you");
                 BookingManager.bookingDb.Remove(getOut);

            }
       
        }
        public void Terminate()
        {
            System.Console.Write("Enter your booking number to check out : ");
            int booking = int.Parse(Console.ReadLine());
            var terminate = bookingManager.Terminate(booking);
            if (terminate == null)
            {
                System.Console.WriteLine("You have not terminate your booking");
            }
            System.Console.WriteLine("Are you sure you want to terminate your booking press 1 if yes press 2 if no");
            int opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                System.Console.WriteLine($"You have sucessfully terminate your booking {DateTime.Now}");
            }
            else if (opt == 2)
            {
                CheckIn();
            }
            else
            {
                BookingMenu bookingMenu = new BookingMenu();
                bookingMenu.MainBooking();
            }
            BookingManager.bookingDb.Remove(terminate);
        }
    

    }
}