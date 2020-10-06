
using KomodoCafeMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeMenu_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create new menu repository entry 
            CafeMenuRepository _cafeMenuRepository = new CafeMenuRepository();

            //create a list to hold menu items
            List<CafeMenu> cafeMenuEntries = _cafeMenuRepository.ReadMenu();

            //seed some content
            SeedContent();

            //Main menu
            bool menuRunning = true;
            while (menuRunning)
            {
                Console.WriteLine("  __________Menu___________");
                Console.WriteLine("Please enter an option number");
                Console.WriteLine("1. Add Menu Item");
                Console.WriteLine("2. View Entire Menu");
                Console.WriteLine("3. Delete a Menu Item");
                Console.WriteLine("4. Exit");


                int menuInputResponse = Convert.ToInt32(Console.ReadLine());
                if (menuInputResponse == 4)
                {
                    menuRunning = false;
                    Console.WriteLine("Hit any key to continue");
                    Console.ReadLine();
                    break;
                }
                else if (menuInputResponse < 1 && menuInputResponse > 4)
                {
                    Console.WriteLine("Please enter a valid response");
                    menuRunning = true;
                }
                else
                {
                    switch (menuInputResponse)
                    {
                        case 1:
                            AddAMenuItem();
                            break;

                        case 2:
                            ReadTheEntireMenu();
                            break;

                        case 3:
                            RemoveAMenuItem();
                            break;
                    }
                }
            }
            
            void AddAMenuItem()
                {
                    //having a problem updating the count when a new menu item is added

                    //Add new item to menu
                    CafeMenu newMenuItem = new CafeMenu();

                    Console.WriteLine("Please choose a number for the meal");
                    newMenuItem.Number = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("What is the name of your meal?");
                    newMenuItem.Name = Console.ReadLine();

                    Console.WriteLine("How would you describe this meal?");
                    newMenuItem.Description = Console.ReadLine();

                    Console.WriteLine("What ingredients does your meal have?");
                    newMenuItem.IngredientList = Console.ReadLine();

                    Console.WriteLine("How much does your meal cost?");
                    string priceInput = Console.ReadLine();
                    newMenuItem.Price = double.Parse(priceInput);

                    _cafeMenuRepository.AddMenuItem(newMenuItem);
                    return;
                }
            void ReadTheEntireMenu()
                {
                    //Read entire List of menu items
                    List<CafeMenu> menuEntry = _cafeMenuRepository.ReadMenu();
                    foreach (CafeMenu cafeMenuEntry in menuEntry)
                    {
                        Console.WriteLine(cafeMenuEntry.Number.ToString() + "\t" + cafeMenuEntry.Name + "\t" + cafeMenuEntry.Description + "\t" + cafeMenuEntry.IngredientList + "\t" + cafeMenuEntry.Price.ToString());
                    }

                    Console.WriteLine("Please enter any key to continue");
                    Console.ReadLine();
                }
            void RemoveAMenuItem()
                {
                    List<CafeMenu> menuEntry = _cafeMenuRepository.ReadMenu();

                    //prompt user input
                    Console.WriteLine("Which item would you like to remove? Please enter the name of the menu item");
                    string removeFromMenuInput = Console.ReadLine();
                    //cafeMenuEntries.ToString();
                    
                    //having problem with handling cases where the user input is not contained in the list
                    //if(cafeMenuEntries.Contains(removeFromMenuInput))
                    
                    foreach (CafeMenu menuEntryName in menuEntry)
                    {
                        if (removeFromMenuInput == menuEntryName.Name)
                        {
                            _cafeMenuRepository.RemoveMenuItem(menuEntryName);
                        }
                        Console.WriteLine("Please enter a valid menu item");
                    }
                Console.WriteLine("Please enter any key to continue");
                Console.ReadLine();
                }
            void SeedContent()
            {
                //Seed content in a fake menu
                CafeMenu latinMeal = new CafeMenu(1, "Latin American Meal", "Meal from Central or South America", "Rice, Beans, Yummy Spices", 10d);
                CafeMenu europeanMeal = new CafeMenu(2, "European Meal", "Meal from Europe", "Hearty stuff for hearty folk", 30d);
                CafeMenu africanMeal = new CafeMenu(3, "African Meal", "Meal from Africa", "Stuff that I will cook later this week", 10d);
                CafeMenu eastAsianMeal = new CafeMenu(4, "EastAsian Meal", "Meal from East Asia", "Ingredients from China, South Korea, or Japan", 15d);
                CafeMenu southEastAsianMeal = new CafeMenu(5, "South East Asian Meal", "Meal from elsewhere in Asia", "Lots of herbs, spices, and coconut milk", 10d);
                CafeMenu hamburger = new CafeMenu(6, "Hamburger", "Sandwich not made of Ham", "Ground beef, bread, and whatever else", 5d);

                _cafeMenuRepository.AddMenuItem(latinMeal);
                _cafeMenuRepository.AddMenuItem(europeanMeal);
                _cafeMenuRepository.AddMenuItem(africanMeal);
                _cafeMenuRepository.AddMenuItem(eastAsianMeal);
                _cafeMenuRepository.AddMenuItem(southEastAsianMeal);
                _cafeMenuRepository.AddMenuItem(hamburger);

            }
        }
    }
}
