using System;

namespace VideoGameShop.OrderCreate
{
    public class Payment
    {
        public void paymentProcess()
        {
            Console.Clear();
            Console.WriteLine("Цена игры: " + Memory.getVideoGameCost());
            int cost;
            do
            {
                System.Console.WriteLine("Введите сумму к оплате!");
                System.Console.Write(">> ");
            }while(!(Int32.TryParse(Console.ReadLine(), out cost) && cost >=  Memory.getVideoGameCost()));
            cost = cost - Memory.getVideoGameCost();
            System.Console.WriteLine("Сдача: " + cost);
            int selectedVideoGameId_FK = Memory.getVideoGameId();
            int clientAccountId_FK = Memory.getAccountId();
            int userOrderId = takeCorrectOrderTableId();
            System.Console.WriteLine(DateTime.Now.ToString());
            using (Database.HTTP db = new Database.HTTP())
            {
                // создаем два объекта User
                UserOrder createUserOrder = new UserOrder(){
                    order_id=userOrderId,
                    order_date=returnUTCDateTime(),
                    order_cost=Memory.getVideoGameCost(),
                    fk_client_id=clientAccountId_FK,
                    fk_product_id=selectedVideoGameId_FK
                };
 
                // добавляем их в бд
                db.user_order.Add(createUserOrder);
                db.SaveChanges();
            }
        }

        // Получение даты
        public DateTime returnUTCDateTime() => DateTime.Now.ToUniversalTime();

        
        // Получение ID таблицы заказов
        private int takeCorrectOrderTableId()
        {
            int correctOrderTableId = 1;
            using (Database.HTTP db = new Database.HTTP())
            {
                var tables = db.user_order.ToList();
                foreach (UserOrder t in tables)
                {
                    correctOrderTableId++;
                }
            }
            return correctOrderTableId;
        }
    }
}