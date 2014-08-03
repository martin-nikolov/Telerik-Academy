namespace Phonebook.Tests.PhoneRepositoryTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook.Data.Repositories;

    [TestClass]
    public class AddPhoneTest
    {
        [TestMethod]
        public void AddNonExistingPhoneEntryShouldReturnTrue()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            var isEntryAdded = phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            Assert.AreEqual(true, isEntryAdded);
        }

        [TestMethod]
        public void AddExistingPhonebookEntryShouldReturnFalse()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            var isEntryAdded = phonebookRepository.AddPhone("John", new List<string>() { "333" });
            Assert.AreEqual(false, isEntryAdded);
        }

        [TestMethod]
        public void AddExistingPhonebookEntryWithDifferentNameCasesShouldReturnFalse()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            var isEntryAdded = phonebookRepository.AddPhone("joHN", new List<string>() { "333" });
            var mergedEntry = phonebookRepository.ListEntries(0, 1).First();
            Assert.AreEqual(false, isEntryAdded);
            Assert.AreEqual(3, mergedEntry.PhoneNumbers.Count);
        }

        [TestMethod]
        public void AddPhoneShouldMergePhoneNumbers()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            var isEntryAdded = phonebookRepository.AddPhone("John", new List<string>() { "333" });
            var mergedEntry = phonebookRepository.ListEntries(0, 1).First();
            Assert.AreEqual(false, isEntryAdded);
            Assert.AreEqual(3, mergedEntry.PhoneNumbers.Count);
            Assert.AreEqual("333", mergedEntry.PhoneNumbers.Skip(2).First());
        }

        [TestMethod]
        public void AddPhonesShouldMergeAndKeepOnlyUniquePhoneNumbers()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            var isEntryAdded = phonebookRepository.AddPhone("John", new List<string>() { "111", "222", "333" });
            var mergedEntry = phonebookRepository.ListEntries(0, 1).First();
            Assert.AreEqual(false, isEntryAdded);
            Assert.AreEqual(3, mergedEntry.PhoneNumbers.Count);
            Assert.AreEqual("333", mergedEntry.PhoneNumbers.Skip(2).First());
        }
        
        [TestMethod]
        public void ChangePhoneWithMergeAndDuplicates()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            phonebookRepository.AddPhone("John1", new List<string>() { "333", "444" });
            phonebookRepository.AddPhone("John2", new List<string>() { "555", "666" });

            phonebookRepository.ChangePhone("111", "333");
            Assert.AreEqual(2, phonebookRepository.ListEntries(0, 3).Where(a => a.PhoneNumbers.Contains("333")).Count());
            Assert.AreEqual(0, phonebookRepository.ListEntries(0, 3).Where(a => a.PhoneNumbers.Contains("111")).Count());
            Assert.AreEqual(1, phonebookRepository.ListEntries(0, 3).Where(a => a.Name == "John").Count());
            Assert.AreEqual(1, phonebookRepository.ListEntries(0, 3).Where(a => a.Name == "John1").Count());
        }
           
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPhoneToEmptyNameShouldThrowException()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("", new List<string>() { "111", "222" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPhoneToNullNameShouldThrowException()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone(null, new List<string>() { "111", "222" });
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddPhoneToValidEntryNameButNullPhoneNumbersCollectionShouldThrowException()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", null);
        }
    }
}