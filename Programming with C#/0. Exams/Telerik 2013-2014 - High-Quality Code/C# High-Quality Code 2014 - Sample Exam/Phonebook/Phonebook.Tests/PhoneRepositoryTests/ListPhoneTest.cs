namespace Phonebook.Tests.PhoneRepositoryTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook.Data.Repositories;

    [TestClass]
    public class ListPhoneTest
    {
        [TestMethod]
        public void ListSingleEntry()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            var result = phonebookRepository.ListEntries(0, 1);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("John", result.First().Name);
            Assert.AreEqual(2, result.First().PhoneNumbers.Count);
            CollectionAssert.AreEqual(new List<string>() { "111", "222" }, result.First().PhoneNumbers.ToList());
        }

        [TestMethod]
        public void ListMultipleEntry()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            phonebookRepository.AddPhone("John1", new List<string>() { "333", "444", "4444" });
            phonebookRepository.AddPhone("John2", new List<string>() { "555", "666" });
            var result = phonebookRepository.ListEntries(0, 3);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("John", result.First().Name);
            Assert.AreEqual(2, result.First().PhoneNumbers.Count);
            CollectionAssert.AreEqual(new List<string>() { "333", "444", "4444" }, result.Skip(1).First().PhoneNumbers.ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntriesWithInvalidIndexShouldThrowException()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            phonebookRepository.ListEntries(-1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntriesWithNegativeCountShouldThrowException()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            phonebookRepository.ListEntries(0, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntriesWithCountBiggetThanMaxCountShouldThrowException()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            phonebookRepository.ListEntries(0, int.MaxValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntriesWithInvalidIndexAndCountShouldThrowException()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.ListEntries(1, 1);
        }
    }
}