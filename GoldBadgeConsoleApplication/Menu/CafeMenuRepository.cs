using KomodoCafeMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeMenu
{
    public class CafeMenuRepository
    {
        List<CafeMenu> _menuItems = new List<CafeMenu>();
        

        //Add a menu object to the menu list
        public bool AddMenuItem(CafeMenu menuItem)
        {
            
            int beforeAdded = _menuItems.Count;
            _menuItems.Add(menuItem);
            bool wasAdded = (_menuItems.Count > beforeAdded) ? true : false;
           
            return wasAdded;
        }
        
        //Read the entire list of menu objects
        public List<CafeMenu> ReadMenu()
        {
            return _menuItems;
        }
        
        //Delete a menu object
        public bool RemoveMenuItem(CafeMenu menuItem)
        {
            int beforeRemoval = _menuItems.Count;
            _menuItems.Remove(menuItem);
            bool wasRemoved = (_menuItems.Count < beforeRemoval) ? true : false;
            return wasRemoved;
        }
    }
}
