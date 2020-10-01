using System;
using System.Collections.Generic;
using KomodoCafeMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafeMenu_RepositoryTests
{
    [TestClass]
    public class CafeMenuRepositoryTests

    {
        [TestMethod]
        public void AddToMenuTest()
        {
            //Arrange
            CafeMenu menuItem = new CafeMenu();
            CafeMenuRepository cafeMenuRepository = new CafeMenuRepository();

            //ACT
            bool addedToMenu = cafeMenuRepository.AddMenuItem(menuItem);

            //Assert
            Assert.IsTrue(addedToMenu);
            //Console.WriteLine(addedToMenu);
        }

        [TestMethod]
        public void ReadEntireMenuTest()
        {
            //Arrange
            CafeMenu cafeMenu = new CafeMenu();
            CafeMenuRepository cafeMenuItems = new CafeMenuRepository();

            cafeMenuItems.AddMenuItem(cafeMenu);

            //ACT
            List<CafeMenu> listMenuItems = cafeMenuItems.ReadMenu();

            //Assert
            bool menuHasItems = listMenuItems.Contains(cafeMenu);
            Assert.IsTrue(menuHasItems);
            //Console.WriteLine(menuHasItems);
        }

        [TestMethod]
        public void RemoveFromMenuTest()
        {
            //Arrange
            CafeMenu cafeMenu = new CafeMenu();
            CafeMenuRepository cafeMenuRepository = new CafeMenuRepository();

            cafeMenuRepository.AddMenuItem(cafeMenu);

            //ACT
            bool wasItemRemoved = cafeMenuRepository.RemoveMenuItem(cafeMenu);

            //Assert
            Assert.IsTrue(wasItemRemoved);
            Console.WriteLine(wasItemRemoved);
        }
    }
}
