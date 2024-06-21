using System;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;


namespace VideoGameShop
{
    public class StartProgram
    {
        public static void Main(string[] args)
        {
            // Начало работы программы
            // Магазин видеоигр
            string[] startActions = 
            { 
                "1. Аккаунт", 
                "2. Магазин", 
                "3. Выйти"
            };
            do
            {
                Thread.Sleep(1000);
                Console.Clear();
                System.Console.WriteLine("Аккаунт: " + Memory.getAccountId());
                System.Console.WriteLine("Выберите действие!");
                foreach(var actionsArrayElement in startActions)
                {
                    System.Console.WriteLine(actionsArrayElement);
                }
                System.Console.Write("Действие: ");
                switch(Console.ReadLine().ToLower())
                {
                    case "аккаунт":
                        Console.Clear();
                        System.Console.WriteLine("Проверка аккаунта!");
                        System.Console.WriteLine("Наличие аккаунта: " + !IsEmptyAccount());
                        Registration();
                        break;
                    case "магазин":
                        System.Console.WriteLine("Проверка наличия аккаунта!");
                        if(!IsEmptyAccount())
                        {
                            new OrderCreate.Shop().ShowAssortment();
                        }
                        
                        break;
                    case "выйти":
                        System.Console.WriteLine("Выход!");
                        CloseApp();
                        break;
                    default:
                        System.Console.WriteLine("Проверьте ввод!");
                        
                        break;
                }
            } while (true);

        }


        // Проверка наличия аккаунта
        static private bool IsEmptyAccount() => Memory.getAccountId() == -1;

        static private void Registration()
        {
            
            while (true)
            {
                Thread.Sleep(2000);
                Console.Clear();
                System.Console.WriteLine("1. Создать\n2. Войти\n3. Обратно");
                System.Console.Write("Действие: ");
                switch(Console.ReadLine().ToLower())
                {
                    case "создать":
                        new ClientWork.RegistrationProcess().GetAccountInfo();
                        return;
                    case "войти":
                        new ClientWork.ClientAuthorization().GetAuthInfo();
                        return;
                    case "обратно":
                        return;
                    default:
                        System.Console.WriteLine("Проверьте ввод!");
                        break;
                }
            }
        }
        // Закрытие приложения
        static private void CloseApp() => Environment.Exit(0);


    }
}
