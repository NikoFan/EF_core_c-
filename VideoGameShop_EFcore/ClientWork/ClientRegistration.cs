using System;

namespace VideoGameShop.ClientWork
{
    public class RegistrationProcess
    {
        public bool GetAccountInfo()
        {
            Console.Clear();
            System.Console.WriteLine("РЕГИСТРАЦИЯ ПОЛЬЗОВАТЕЛЯ");
            System.Console.WriteLine("Введите Логин");
            System.Console.Write(">> ");
            string login = Console.ReadLine();

            System.Console.WriteLine("Введите Пароль");
            System.Console.Write(">> ");
            string password = Console.ReadLine();

            System.Console.WriteLine("Введите Электронную почту");
            System.Console.Write(">> ");
            string email = Console.ReadLine();

            SetAccountInDb([login, password, email]);
            return false;
        }

        // Получение точного ID для регистрации пользователя
        private int TakeRegId()
        {
            int id = 1;

            using (Database.HTTP db = new Database.HTTP())
            {
                var tables = db.client.ToList();
                foreach (Client t in tables)
                {
                    id++;
                }
            }
            return id;
        }

        private void SetAccountInDb(string[] accountInfo)
        {
            int newClientAccountId = TakeRegId();
            // Добавление данных
            using (Database.HTTP db = new Database.HTTP())
            {
                // создаем два объекта User
                Client clientAccount = new Client {
                    client_id=newClientAccountId,
                    client_login=accountInfo[0],
                    client_password=accountInfo[1],
                    client_email=accountInfo[2]};
 
                // добавляем их в бд
                db.client.Add(clientAccount);
                db.SaveChanges();
                Memory.setAccountId(newClientAccountId);
            }
        }
    }
}