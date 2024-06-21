using System;

namespace VideoGameShop.ClientWork
{
    public class ClientAuthorization
    {
        public bool GetAuthInfo()
        {
            Console.Clear();
            System.Console.WriteLine("АВТОРИЗАЦИЯ ПОЛЬЗОВАТЕЛЯ");
            System.Console.WriteLine("Введите Логин");
            System.Console.Write(">> ");
            string login = Console.ReadLine();

            System.Console.WriteLine("Введите Пароль");
            System.Console.Write(">> ");
            string password = Console.ReadLine();

            FindClientAccount([login, password]);
            return false;
        }

        // Авторизация пользователя
        private void FindClientAccount(string[] userAccountInfo)
        {

            using (Database.HTTP db = new Database.HTTP())
            {
                var tables = db.client.ToList();
                foreach (Client t in tables)
                {
                    if (t.client_password.ToString().Trim() == userAccountInfo[1] &&
                    t.client_login.ToString().Trim() == userAccountInfo[0])
                    {
                        Memory.setAccountId(t.client_id);
                        break;
                    }
                }
            }
        }

    }
}