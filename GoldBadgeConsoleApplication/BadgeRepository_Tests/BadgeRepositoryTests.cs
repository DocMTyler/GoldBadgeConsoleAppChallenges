using System;
using System.Collections.Generic;
using BadgeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeRepository_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        BadgeRepositoryDictionary testRepositoryDict = new BadgeRepositoryDictionary();

        [TestMethod]
        public void GetValuesTest()
        {
            
            //Arrange
            
            Dictionary<int, List<String>> badgeAccess = new Dictionary<int, List<string>>();
            Badge badge = new Badge();

            //ACT
            int testValue = 1;
            List<string> listOrNot = typeof
           
            //Assert
        }
    }
}
