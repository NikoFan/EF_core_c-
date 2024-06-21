using System;

namespace VideoGameShop.OrderCreate
{
    public class Shop
    {
        public void ShowAssortment()
        {
            using (Database.HTTP db = new Database.HTTP())
            {
                Dictionary<int, int> gameId_x_gameCost = new Dictionary<int, int>();
                Dictionary<int, int> gameId_x_gameCount = new Dictionary<int, int>();
                Thread.Sleep(1000);
                Console.Clear();
                var assortmentFromTableShop_Assortment = db.shop_assortment.ToList();
                foreach (ShopAssortment assortment in assortmentFromTableShop_Assortment)
                {
                    System.Console.WriteLine("--------------------");
                    System.Console.WriteLine($"Номер: {assortment.product_id}\n"+
                    $"Название: {assortment.product_name}\n"+
                    $"Цена: {assortment.product_cost}\n"+
                    $"Осталось: {assortment.product_count}\n"+
                    $"Страна: {assortment.product_country}");
                    gameId_x_gameCost[assortment.product_id] = assortment.product_cost;
                    gameId_x_gameCount[assortment.product_id] = assortment.product_count;
                }
                System.Console.WriteLine("--------------------");
                System.Console.WriteLine("Введите номер интересующей игры!\nВведите '0', если хотите вернуться в главное меню.");
                bool stopNumberEnter = false;
                int videoGameNumber;
                do
                {
                    System.Console.Write("Номер: ");
                    stopNumberEnter = int.TryParse(Console.ReadLine(), out videoGameNumber);
                    if (!(videoGameNumber >=0 && videoGameNumber <=4) || (gameId_x_gameCount[videoGameNumber] == 0))
                    {
                        System.Console.WriteLine("Проверьте наличие игр с таким номером!");
                        stopNumberEnter = false;
                    }
                    
                        
                    Thread.Sleep(1000);
                } while(!stopNumberEnter);
                if (videoGameNumber == 0)
                {
                    System.Console.WriteLine("Возврат в главное меню!");
                    return;
                }
                Memory.setVideoGameId(videoGameNumber);
                Memory.setVideoGameCost(gameId_x_gameCost[videoGameNumber]);
                System.Console.WriteLine("Игра помещеня в корзину!");
                System.Console.WriteLine("Переход к оплате!");
                Thread.Sleep(1000);
                new Payment().paymentProcess();
            }
        }
    }
}