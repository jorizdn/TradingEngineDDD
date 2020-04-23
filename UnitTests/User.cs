using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using TradingEngine.Domains.Entities;

namespace UnitTests
{
    [TestFixture]
    public class UserTest
    {
        private const int _userId = 1;
        private Guid _guid = new Guid();

        [TestCase]
        public void WhenUserCheckTheAccount_ThenItShouldReturnCorrectData()
        {
            var account = new Account(_guid, 5000, _userId);
            account.Check().Should().Be(5000);
        }

        [TestCase]
        public void WhenUserStoreMoneyToTheAccount_ThenItShouldAddUp()
        {
            var account = new Account(_guid, 5000, _userId);

            account.Store(200);
            account.Check().Should().Be(5200);
        }

        [TestCase]
        public void WhenUserSendMoneyToAnotherUser_ThenUserMoneyWouldBeDeducted()
        {
            var account = new Account(_guid, 5000, _userId);

            account.Send(200);
            account.Check().Should().Be(4800);
        }
    }
}
