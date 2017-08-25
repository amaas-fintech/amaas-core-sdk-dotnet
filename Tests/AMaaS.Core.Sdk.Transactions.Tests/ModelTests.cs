using AMaaS.Core.Sdk.Models.Utils;
using AMaaS.Core.Sdk.Transactions.Enums;
using AMaaS.Core.Sdk.Transactions.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AMaaS.Core.Sdk.Transactions.Tests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void EqualityTests()
        {
            var transaction1 = new Transaction
            {
                AssetManagerId = 123,
                TransactionId = "Tran123",
                AssetBookId = "Book123",
                SettlementCurrency = "USD",
                TransactionCurrency = "USD",
                TransactionAction = TransactionAction.ShortSell
            };
            var transaction2 = transaction1;
            Assert.AreEqual(transaction1, transaction2);
            Assert.AreEqual(transaction1.GetHashCode(), transaction2.GetHashCode());
            transaction2 = new Transaction
            {
                AssetManagerId = 123,
                TransactionId = "Tran123",
                AssetBookId = "Book123",
                SettlementCurrency = "USD",
                TransactionCurrency = "USD",
                TransactionAction = TransactionAction.ShortSell
            };
            Assert.AreEqual(transaction1, transaction2);
            Assert.AreEqual(transaction1.GetHashCode(), transaction2.GetHashCode());
            //these should be ignored by equality check
            transaction2.CreatedBy = "John";
            transaction2.UpdatedBy = "Watson";
            transaction2.CreatedTime = DateTime.Now;
            transaction2.UpdatedTime = DateTime.Now;
            Assert.AreEqual(transaction1, transaction2);
            Assert.AreEqual(transaction1.GetHashCode(), transaction2.GetHashCode());
            transaction2.ExecutionTime = DateTime.Now;
            transaction2.TransactionAction = TransactionAction.Sell;
            //TODO: Need to implement equality from AMaaSModel and have it work for all subclasses
            Assert.AreNotEqual(transaction1, transaction2);
            Assert.AreNotEqual(transaction1.GetHashCode(), transaction2.GetHashCode());
        }

        [TestMethod]
        public void TestJsonSerialization()
        {
            var transaction1 = new Transaction
            {
                AssetManagerId = 123,
                TransactionId = "Tran123",
                AssetBookId = "Book123",
                SettlementCurrency = "USD",
                TransactionCurrency = "USD",
                TransactionAction = TransactionAction.ShortSell,
                Parties = new System.Collections.Generic.Dictionary<string, Party> { { "CounterParty", new Party { PartyId = "P123", Version = 2 } } }
            };
            var jsonTransaction = SerializationUtils.ToJson(transaction1);
            var transaction2    = SerializationUtils.FromJson<Transaction>(jsonTransaction);
            Assert.AreEqual(transaction1, transaction2);
        }
    }
}
