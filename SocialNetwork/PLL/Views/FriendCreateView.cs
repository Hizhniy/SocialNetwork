using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendCreateView
    {
        FriendService friendService;
        public FriendCreateView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            var friendCreateData = new FriendManageData();

            Console.Write("Для добавления друга введите его почту: ");
            friendCreateData.FriendEmail = Console.ReadLine();
            friendCreateData.UserId = user.Id;

            // не проверяем на попытку добавить себя в качестве друга. У нас в соцсети можно дружить с собой -)

            try
            {
                this.friendService.CreateFriend(friendCreateData);
                SuccessMessage.Show("Добавлен новый друг!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Не все значения введены корректно! Попробуйте снова -)");
            }

            catch (FriendAlreadyExistsException)
            {
                AlertMessage.Show("Это и так ваш друг! Ищите новых -)");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении друга...");
            }
        }
    }
}