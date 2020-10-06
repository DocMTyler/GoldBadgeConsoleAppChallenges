using System;
using System.Collections;
using ClaimRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimRepository_Tests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]
        public void AddClaimToQueueTest()
        {
            //Arrange
            Claim claim = new Claim();
            ClaimRepositoryQueue claimRepositoryQueue = new ClaimRepositoryQueue();

            //ACT
            bool addedToQueue = claimRepositoryQueue.AddClaimToQueue(claim);

            //Assert
            Assert.IsTrue(addedToQueue);
            Console.WriteLine(addedToQueue);
        }
        [TestMethod]
        public void ReadClaimsTest()
        {
            //Arrange
            Claim claim = new Claim();
            ClaimRepositoryQueue claimRepositoryQueue = new ClaimRepositoryQueue();
            claimRepositoryQueue.AddClaimToQueue(claim);

            //ACT
            var claimQueue = claimRepositoryQueue.ReadClaims();

            //Assert
            bool queueHasClaims = claimQueue.Contains(claim);
            Assert.IsTrue(queueHasClaims);
            Console.WriteLine(queueHasClaims);
        }
        [TestMethod]
        public void RemoveClaimFromQueueTest()
        {
            //Arrange
            Claim claim = new Claim();
            ClaimRepositoryQueue claimRepositoryQueue = new ClaimRepositoryQueue();
            claimRepositoryQueue.AddClaimToQueue(claim);
            var claimQueue = claimRepositoryQueue.ReadClaims();

            //ACT
            var beforeDequeue = claimQueue;
            claimRepositoryQueue.RemoveClaimFromQueue();
            bool wasClaimDequeued = claimQueue.Contains(claim);

            //Assert
            Assert.IsFalse(wasClaimDequeued);
            Console.WriteLine(wasClaimDequeued);
        }
        [TestMethod]
        public void TestClaimValidityTest()
        {
            //Arrange
            DateTime timeGreaterTest = new DateTime(2020, 10, 1);
            DateTime timeLesserTestFail = new DateTime(2020, 8, 1);
            DateTime timeLesserTestPass = new DateTime(2020, 9, 26);
            ClaimRepositoryQueue claimRepositoryQueue = new ClaimRepositoryQueue();

            //ACT
            bool invalidClaim = claimRepositoryQueue.TestClaimValidity(timeLesserTestFail, timeGreaterTest);
            bool validClaim = claimRepositoryQueue.TestClaimValidity(timeLesserTestPass, timeGreaterTest);

            //Assert
            Assert.IsFalse(invalidClaim);
            Assert.IsTrue(validClaim);
            Console.WriteLine(invalidClaim);
            Console.WriteLine(validClaim);
        }
    }
}
