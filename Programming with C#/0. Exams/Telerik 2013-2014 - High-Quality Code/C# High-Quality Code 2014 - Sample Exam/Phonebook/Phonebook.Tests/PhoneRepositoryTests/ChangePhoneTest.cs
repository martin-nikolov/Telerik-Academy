namespace Phonebook.Tests.PhoneRepositoryTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook.Data.Repositories;

    [TestClass]
    public class ChangePhoneTest
    {
        [TestMethod]
        public void ChangeExistingPhoneNumberShouldRemoveOldAndAddNewPhoneNumber()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            var matchedPhoneEntries = phonebookRepository.ChangePhone("111", "333");

            Assert.AreEqual(1, matchedPhoneEntries);
            Assert.AreEqual(2, phonebookRepository.ListEntries(0, 1).First().PhoneNumbers.Count);
            Assert.IsTrue(phonebookRepository.ListEntries(0, 1).First().PhoneNumbers.Contains("333"));
            Assert.IsFalse(phonebookRepository.ListEntries(0, 1).First().PhoneNumbers.Contains("111"));
        }

        [TestMethod]
        public void ChangeNonExistingPhoneNumberShouldNotAffectToTheRepository()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            var matchedPhoneEntries = phonebookRepository.ChangePhone("333", "444");

            Assert.AreEqual(0, matchedPhoneEntries);
            Assert.AreEqual(2, phonebookRepository.ListEntries(0, 1).First().PhoneNumbers.Count);
            CollectionAssert.AreEqual(new List<string>() { "111", "222" }, phonebookRepository.ListEntries(0, 1).First().PhoneNumbers.ToList());
        }

        [TestMethod]
        public void ChangedSharedPhoneNumber()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.AddPhone("John", new List<string>() { "111", "222" });
            phonebookRepository.AddPhone("Smith", new List<string>() { "222", "333" });
            var matchedPhoneEntries = phonebookRepository.ChangePhone("222", "444");

            Assert.AreEqual(2, matchedPhoneEntries);
            Assert.AreEqual(2, phonebookRepository.ListEntries(0, 2).First().PhoneNumbers.Count);
            Assert.AreEqual(2, phonebookRepository.ListEntries(0, 2).Skip(1).First().PhoneNumbers.Count);

            Assert.IsTrue(phonebookRepository.ListEntries(0, 2).First().PhoneNumbers.Contains("444"));
            Assert.IsFalse(phonebookRepository.ListEntries(0, 2).First().PhoneNumbers.Contains("222"));

            Assert.IsTrue(phonebookRepository.ListEntries(0, 2).Skip(1).First().PhoneNumbers.Contains("444"));
            Assert.IsFalse(phonebookRepository.ListEntries(0, 2).Skip(1).First().PhoneNumbers.Contains("222"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePhoneOnNullOldPhoneNumberShouldThrowException()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.ChangePhone(null, "111");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePhoneOnEmptyOldPhoneNumberShouldThrowException()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.ChangePhone(null, "111");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePhoneOnNullNewPhoneNumberShouldThrowException()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.ChangePhone("", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangePhoneOnEmptyNewPhoneNumberShouldThrowException()
        {
            var phonebookRepository = new PhonebookRepositoryFast();
            phonebookRepository.ChangePhone("", null);
        }
    }
}