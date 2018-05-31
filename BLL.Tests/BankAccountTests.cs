using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Mappers;
using BLL.Services;
using DAL.Fake;
using DAL.Interface.DTO;
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

            var dalClient1 = client1.ToDalUser();
            var dalClient2 = client2.ToDalUser();

            var accountService = new AccountWorkingService();
            var fakeRepository = new ListRepository();
            var accountNumberGenerator = new StandartAccountNumberGenerator();

            accountService.CreateAccount(fakeRepository, client1, 8500m);
            accountService.CreateAccount(fakeRepository, client2, 50m);

            Assert.IsTrue(fakeRepository.Read(dalClient1).Type == BankAccountDTO.AccountType.Gold);
            Assert.IsTrue(fakeRepository.Read(dalClient2).Type == BankAccountDTO.AccountType.Base);

            accountService.Deposit(fakeRepository.Read(dalClient1).ToBllAccount(), 1500m, new StandartBonusCalculator());

            Assert.AreEqual(10000m, fakeRepository.Read(dalClient1).Amount);
            Assert.AreEqual(100d, fakeRepository.Read(dalClient1).BonusPoints);

            Assert.Throws<ArgumentException>(() => accountService.Withdraw(fakeRepository.Read(dalClient2).ToBllAccount(), 100m, new StandartBonusCalculator()));

            accountService.Withdraw(fakeRepository.Read(dalClient2).ToBllAccount(), 20m, new StandartBonusCalculator());

            Assert.AreEqual(30m, fakeRepository.Read(dalClient2).Amount);
            Assert.AreEqual(-0.007, fakeRepository.Read(dalClient2).BonusPoints);

            accountService.Withdraw(fakeRepository.Read(dalClient1).ToBllAccount(), 1000m, new StandartBonusCalculator());

            Assert.AreEqual(9000m, fakeRepository.Read(dalClient1).Amount);
            Assert.AreEqual(-10d, fakeRepository.Read(dalClient1).BonusPoints);
        }
    }
}
