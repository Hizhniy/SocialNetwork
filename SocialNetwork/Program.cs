//Домашним заданием будет реализовать логику добавления в друзья в нашей социальной сети.
//В нашем проекте на уровне DAL (Data Access Layer) уже реализована логика по работе с друзьями. Поэтому уровня DAL вам нет смысла касаться.

//Вашей же задачей становится добавление логики на уровень PLL и BLL. Процесс добавления пользователя в друзья должен быть следующим:
//Пользователь вводит почтовый адрес друга.
//Если почтовый адрес существует, то выполняем добавление.
//Если почтового адреса не существует, то выбрасываем исключение UserNotFoundException.
//На уровне PLL по аналогии с другими классами View создайте новую View, в которую поместите основную логику представления для добавления в друзья.

//0 баллов – задание решено неверно;
//1 балл – есть попытки решить задачу, но функциональности нет;
//2 балла – есть решение задачи, функциональность по добавлению в друзья работает, но студент сильно отошел от исходной архитектуры проекта;
//3 балла – есть решение задачи, функциональность по добавлению в друзья работает, студент правильно выбрал архитектуру проекта;
//4 балла – 3 + добавил проект модульного теста и написал хотя бы один юнит-тест.


using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL;
using SocialNetwork.PLL.Views;
using System;
using System.Linq;

namespace SocialNetwork
{
    class Program
    {
        static MessageService messageService;
        static UserService userService;        
        static FriendService friendService;
        
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;

        public static FriendCreateView friendCreateView;

        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();            
            friendService = new FriendService();

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService, userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();
            friendCreateView = new FriendCreateView(friendService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}