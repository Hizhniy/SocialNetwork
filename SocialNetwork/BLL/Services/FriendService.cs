using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public bool CreateFriend(FriendManageData friendCreateData)
        {
            if (String.IsNullOrEmpty(friendCreateData.FriendEmail))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(friendCreateData.FriendEmail))
                throw new ArgumentNullException();

            var findUserEntity = this.userRepository.FindByEmail(friendCreateData.FriendEmail) ?? throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendCreateData.UserId,
                friend_id = findUserEntity.id
            };            

            // проверяем наличие указанного пользователя в друзьях (и сразу понимаем, что нет, если возвратный список пустой)
            var userFriends = this.friendRepository.FindAllByUserId(friendCreateData.UserId).ToArray();
            if ((userFriends != null || userFriends.Length != 0) && userFriends.Contains(friendEntity))
            {
                throw new FriendAlreadyExistsException();
            }            

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();

            return true;
        }

        public void DeleteFriend(FriendManageData friendDeleteData) // не реализовано - не было в условии задания
        {
            throw new NotImplementedException();
        }
        public void FindAllFriends(int id) // не реализовано - не было в условии задания
        {
            throw new NotImplementedException();
        }
    }
}