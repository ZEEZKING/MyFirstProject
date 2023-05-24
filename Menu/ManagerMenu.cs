using Hotel_App.Managers.Implementation;
using Hotel_App.Managers.Interface;

namespace Hotel_App.Menu
{
    public class ManagerMenu
    {
        IRoomManager roomManager = new RoomManager();
        ICustomerManager customerManager = new CustomerManager();
        public void ManagerMainMenu()
        {
            System.Console.WriteLine("Enter 1 to Add room \nEnter 2 to  view customer \nEnter 3 to delete customer \nEnter 4 to logout");
            int opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                AddRoom();
                ManagerMainMenu();
            }
            else if(opt == 2)
            {
                viewCustomer();
                ManagerMainMenu();
            }
            else if(opt == 3)
            {
                Delete();
                ManagerMainMenu();
            }
            else if(opt == 4)
            {
                MainMenu mainMenu =new MainMenu();
                mainMenu.Main();
            }
            else
            {
                System.Console.WriteLine("Wrong input");
            }
        }
        // RoomType roomType, int roomNumber 
        public void AddRoom()
        {
            System.Console.Write("Enter the room type of your choice 1-3 : ");
            int room = int.Parse(Console.ReadLine());
            if (room == 1 || room == 2 || room == 3)
            {
                
            }
            else
            {
                System.Console.WriteLine("Invalid input please enter btw 1-3");
                MainMenu mainMenu =new MainMenu();
                mainMenu.Main();
            }
            System.Console.WriteLine("Enter the quantity of the room you want");
            int quan = int.Parse(Console.ReadLine());
         
            var addroom = roomManager.Create((Models.enums.RoomType)room,quan);
            if (addroom == null )
            {
                System.Console.WriteLine("Room already");
            }
            else
            {
                System.Console.WriteLine($"You have sucessful add a room {addroom.RoomType} {addroom.RoomNumber} and the quantity of the room available is {addroom.Quantity} ");
            }
        }
        public void viewCustomer()
        {
            var customerViews = customerManager.GetAll();
            if (customerViews.Count == 0)
            {
                System.Console.WriteLine("Customer not exist");
            }
            foreach (var item in CustomerManager.customerDb)
            {
                System.Console.WriteLine($"The customer email {item.UserEmail} customer sucessfully added");
            }
        }
        public void Delete()
        {
            System.Console.WriteLine("Enter the customer email : ");
            var email = Console.ReadLine();
            var customerEmail = customerManager.Get(email);
            if (customerEmail != null)
            {
                customerEmail.isDeleted = true;
                System.Console.WriteLine("customer doesnt exist");
            }
            else
            {
                System.Console.WriteLine("Customer sucessfully Deleted");
            }
        }
    }
}