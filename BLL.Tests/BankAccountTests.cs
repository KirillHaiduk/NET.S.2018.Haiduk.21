using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Services;
using DAL.Fake;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void CreatingBankAccount_WithWrongArguments_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new BaseBankAccount(null, 100m, new StandartAccountNumberGenerator()));
            Assert.Throws<ArgumentException>(() => new GoldBankAccount(new Client("firstname", "lastname", "password", "email"), -100m, new StandartAccountNumberGenerator()));
            Assert.Throws<ArgumentNullException>(() => new PlatinumBankAccount(new Client("firstname", "lastname", "password", "email"), 10000m, null));
        }

        [Test]
        public void CreatingNewClient_WithWrongArguments_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Client("firstname", string.Empty, "password", "email"));
            Assert.Throws<ArgumentException>(() => new Client("firstname", "lastname", null, "email"));            
        }

        [Test]
        public void ClientTest()
        {
            var client1 = new Client("firstname1", "lastname1", "password1", "email1");
            var client2 = new Client("firstname1", "lastname1", "password1", "email1");
            var client3 = new Client("firstname1", "lastname1", "password1", "email1");
            Assert.IsTrue(client1 == client2);
            Assert.IsTrue(client1.Equals(client3));
        }

        [Test]
        public void BankServiceTest()
        {
            var client1 = new Client("firstname1", "lastname1", "password1", "email1");
            var client2 = new Client("firstname2", "lastname2", "password2", "email2");

            var accountService = new AccountWorkingService();
            var fakeRepository = new ListRepository();
            var accountNumberGenerator = new StandartAccountNumberGenerator();

            accountService.CreateAccount(fakeRepository, client1, 8500m, accountNumberGenerator);
            accountService.CreateAccount(fakeRepository, client2, 50m, accountNumberGenerator);

            Assert.That(fakeRepository.Read(client1) is GoldBankAccount);
            Assert.That(fakeRepository.Read(client2) is BaseBankAccount);

            accountService.Deposit(fakeRepository.Read(client1), 1500m, new StandartBonusCalculator());

            Assert.AreEqual(10000m, fakeRepository.Read(client1).Amount);
            Assert.AreEqual(100d, fakeRepository.Read(client1).BonusPoints);

            Assert.Throws<ArgumentException>(() => accountService.Withdraw(fakeRepository.Read(client2), 100m, new StandartBonusCalculator()));

            accountService.Withdraw(fakeRepository.Read(client2), 20m, new StandartBonusCalculator());

            Assert.AreEqual(30m, fakeRepository.Read(client2).Amount);
            Assert.AreEqual(-0.007, fakeRepository.Read(client2).BonusPoints);

            accountService.Withdraw(fakeRepository.Read(client1), 1000m, new StandartBonusCalculator());

            Assert.AreEqual(9000m, fakeRepository.Read(client1).Amount);
            Assert.AreEqual(-10d, fakeRepository.Read(client1).BonusPoints);
        }
    }
}
