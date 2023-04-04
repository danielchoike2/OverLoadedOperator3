using System;
using System.Net.NetworkInformation;

namespace Assignment3OverLoading
{
    public class Inventory
    {
        public int number { get; set; }
        public string ProductName { get; set; }
        public double UnitAmount { get; set; }
        public string Type { get; set; }

        // overloaded operator ++ and operator --

        public static Inventory operator ++(Inventory obj)
        {
            //obj.number++;
            ++obj.number;

            return obj;
        }

        public static Inventory operator --(Inventory obj)
        {
            {
                //obj.number--;
                --obj.number;

                return obj;
            }
        }



        // overloaded operator + and operator -

        public static Inventory operator +(Inventory lhs1, int n)
        {

            Inventory inv1 = new Inventory();
            inv1.number = inv1.number + n;
            return inv1;


        }

        public static Inventory operator -(Inventory lhs2, int n)
        {

            Inventory inv2 = new Inventory();
            inv2.number = inv2.number - n;
            return inv2;
        }

        // overloaded operator > and operator <

        public static bool operator >(Inventory left, Inventory right)
        {
            bool larger = false;
            if (left.number > right.number)
                larger = true;
            return larger;
        }
        public static bool operator <(Inventory left, Inventory right)
        {
            bool smaller = false;
            if (left.number < right.number)
                smaller = true;
            return smaller;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory[] myInventory = new Inventory[100];
            for (int i = 0; i < myInventory.Length; i++)
            {
                myInventory[i] = new Inventory();  // creates objects
            }
            int selection = Menu();
            int index = 0, entry = 0;
            string ans = "";
            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        if (index < 100)
                        {
                            Console.Write("Enter Product Type (Office, Farm, Misc): ");
                            myInventory[index].Type = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Product Name: ");
                            myInventory[index].ProductName = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Unit Amount: ");
                            myInventory[index].UnitAmount = double.Parse(Console.ReadLine());
                            Console.WriteLine();
                            index++;
                        }
                        else
                            Console.WriteLine("You have too many inventory entries - see programming");
                        break;
                    case 2:
                        for (int i = 0; i < myInventory.Length; i++)
                        {
                            if (myInventory[i].ProductName != "" && myInventory[i].ProductName != null)
                            {
                                Console.WriteLine($"Type: {myInventory[i].Type}");
                                Console.WriteLine($"Product Name: {myInventory[i].ProductName}");
                                Console.WriteLine($"Unit Amount: {myInventory[i].UnitAmount}");
                            }
                        }
                        break;
                    case 3:
                        entry = pickEntry(index);
                        Console.Write("Change Product Type (Office, Farm, Misc) Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Type? ");
                            myInventory[entry].Type = Console.ReadLine();
                        }
                        Console.WriteLine();
                        Console.Write("Change Product Name Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Product Name: ");
                            myInventory[entry].ProductName = Console.ReadLine();
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        entry = pickEntry(index);

                        Console.Write("Increase unit amount by 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            myInventory[entry]++;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Decrease unit amount by 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            myInventory[entry]--;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Increase unit amount by > 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Enter the unit amount: ");
                            int hr;
                            while (!int.TryParse(Console.ReadLine(), out hr))
                                Console.WriteLine($"Please enter a number");
                            myInventory[entry] += hr;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Decrease unit amount by > 1?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Enter the unit amount: ");
                            int hr;
                            while (!int.TryParse(Console.ReadLine(), out hr))
                                Console.WriteLine($"Please enter a number");
                            myInventory[entry] -= hr;
                            Console.WriteLine();
                            break;
                        }

                        break;
                    case 5:
                        Inventory totalOffice = new Inventory();
                        totalOffice.Type = "Office Product Type";
                        totalOffice.ProductName = "Total Office Product Units";
                        Inventory totalFarm = new Inventory();
                        totalFarm.Type = "Farm Type";
                        totalFarm.ProductName = "Total Farm Product Units";
                        Inventory totalMisc = new Inventory();
                        totalMisc.Type = "Misc Type";
                        totalMisc.ProductName = "Total Misc Units";
                        for (int i = 0; i < myInventory.Length; i++)
                        {
                            switch (myInventory[i].Type)
                            {
                                case "Office":
                                    totalOffice.UnitAmount += myInventory[i].UnitAmount;
                                    break;
                                case "Farm":
                                    totalFarm.UnitAmount += myInventory[i].UnitAmount;
                                    break;
                                case "Other":
                                    totalMisc.UnitAmount += myInventory[i].UnitAmount;
                                    break;
                            }
                        }
                        Console.WriteLine("Total unit amount by Product Type");
                        if (totalOffice > totalFarm && totalOffice > totalMisc)
                        {
                            Console.WriteLine("The largest number of units in stock are for Office type products.");
                            Console.WriteLine($"Your total office product units = {totalOffice.UnitAmount}");
                            Console.WriteLine($"Your total farm product units = {totalFarm.UnitAmount}");
                            Console.WriteLine($"Your total misc units = {totalMisc.UnitAmount}");
                        }
                        else if (totalFarm > totalOffice && totalFarm > totalMisc)
                        {
                            Console.WriteLine("The largest number of units in stock are for Farm type products.");
                            Console.WriteLine($"Your total farm units = {totalFarm.UnitAmount}");
                            Console.WriteLine($"Your total office units = {totalOffice.UnitAmount}");
                            Console.WriteLine($"Your total misc units = {totalMisc.UnitAmount}");
                        }
                        else
                        {
                            Console.WriteLine("The largest number of units in stock are for Misc product types.");
                            Console.WriteLine($"Your total misc units = {totalMisc.UnitAmount}");
                            Console.WriteLine($"Your total farm units = {totalFarm.UnitAmount}");
                            Console.WriteLine($"Your total office product units = {totalOffice.UnitAmount}");
                        }
                        break;
                    default:
                        Console.WriteLine("You made an invalid selection, please try again");
                        break;
                }
                selection = Menu();

            }
        }
        public static int Menu()
        {
            int choice = 0;
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1 - Add an entry");
            Console.WriteLine("2 - Print All");
            Console.WriteLine("3 - Change product type or product name");
            Console.WriteLine("4 - Adjust unit amount");
            Console.WriteLine("5 - Total categories and compare");
            Console.WriteLine("6 - Enter product's price");
            Console.WriteLine("7 - Quit");
            while (!int.TryParse(Console.ReadLine(), out choice))
                Console.WriteLine("Please select 1 - 7");
            return choice;
        }
        public static int pickEntry(int index)
        {
            Console.WriteLine("What entry would you like to change?");
            Console.WriteLine($"1 through {index}");
            int entry;
            while (!int.TryParse(Console.ReadLine(), out entry))
                Console.WriteLine($"Please select 1 - {index}");
            entry -= 1;  // subtract 1 to begin index at 0
            return entry;
        }
    }
}