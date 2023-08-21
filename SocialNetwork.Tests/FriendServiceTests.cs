using NUnit.Framework;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.PLL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class FriendServiceTests
    {
        [Test]
        public void Additional_MustReturnCorrectValue()
        {
            var friendService = new FriendService();

            var friendEntity = new FriendManageData()
            {
                UserId = 2,
                FriendEmail = "drug@mail.com"
            };

            NUnit.Framework.Assert.That(friendService.CreateFriend(friendEntity) == true);
        }
    }
}