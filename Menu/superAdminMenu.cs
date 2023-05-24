using Hotel_App.Managers.Implementation;
using Hotel_App.Managers.Interface;
using Hotel_App.Models.enums;

namespace Hotel_App.Menu
{
    public class superAdminMenu
    {
        IManagerManager managerManager = new ManagerManager();
        IAccountManager accountManager = new AccountManager();
        public void SuperMain()
        {
            System.Console.WriteLine("Enter 1 to register Manager\nEnter 2 view all manager\nEnter 3 to delete manager\nEnter 4 to check HotelAcctBalance\nEnter 5 to logout");
            int opt = int.Parse(Console.ReadLine());
            if (opt == 1)
            {
                RegisterManager();
                SuperMain();
            }
            else if (opt == 2)
            {
                viewManager();
                SuperMain();
            }
            else if (opt == 3)
            {
                Delete();
                SuperMain();
            }
            else if (opt == 4)
            {
                CheckHotelAcctBalance();
                SuperMain();
            }
            else if (opt == 5)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Main();
            }
            else
            {
                System.Console.WriteLine("Invalid input");
                SuperMain();
            }
        }
        public void RegisterManager()
        {
            Console.Write("Enter Your firstName : ");
            string fname = Console.ReadLine();
            Console.Write("Enter Your LastName : ");
            string lname = Console.ReadLine();
            Console.Write("Enter Your email  : ");
            string email = Console.ReadLine();
            Console.Write("Enter your password : ");
            string password = Console.ReadLine();
            Console.Write("Enter Your phonenumber : ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter your address :");
            string address = Console.ReadLine();
            Console.Write("Enter 1 for male and 2 for female : ");
            int gender;
            while(!int.TryParse(Console.ReadLine(), out gender))
            {
                Console.WriteLine("wrong input");
                SuperMain();
            }
        
            var manage = managerManager.Register(fname, lname, email, password, phoneNumber, address, (Gender)gender);
            if (manage == null)
            {
                System.Console.WriteLine("Manager doesnt exist");
            }
            else
            {
                System.Console.WriteLine($"The manager was successfully created {fname} {lname}");
            }
        }
        public void viewManager()
        {
            var manager = managerManager.GetAll();
            if (manager == null)
            {
                System.Console.WriteLine("Manager doesnt exist");
            }
            else
            {
                foreach (var item in ManagerManager.managersDb)
                {
                    System.Console.WriteLine($"The manager was successfully added {item.userEmail} ");
                }
            }


        }
        public void Delete()
        {
            Console.Write("Enter the manager email  : ");
            string email = Console.ReadLine();

            var manager = managerManager.Get(email);
            if (manager != null)
            {
                manager.isDeleted = true;
                System.Console.WriteLine("Manager is succesfully deleted");
            }
            else
            {
                System.Console.WriteLine("manager doesnt exist");
            }
        }
        public void CheckHotelAcctBalance()
        {
            System.Console.Write("Enter the hotel account Number : ");
            string balance = Console.ReadLine();
            var hotelAcctBalance = accountManager.Get(balance);
            if (hotelAcctBalance == null)
            {
                System.Console.WriteLine("Zero account");
            }
            else
            {
                System.Console.WriteLine($"Your account balance is {hotelAcctBalance.AccountBalance}");
            }
        }

    }
}