using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    public static class MainUnitProcessor
    {
        private static Agency Agency = null;
        private static City City = null;
        private static DateTime CurrentDate = new DateTime(1970, 1, 1);
        private static Random Sychev = new Random();
        private static Strategy Strategy;
        private static QueueClass Queue;

        #region Главные методы
        /// <summary>
        /// Полный сброс всей программы
        /// </summary>
        public static void MainReset()
        {
            Agency = null;
            City = null;
            CurrentDate = new DateTime(1970, 1, 1);
        }

        /// <summary>
        /// Считывает тексты в память
        /// </summary>
        public static void MainParseTexts()
        {
            TextStorageClass.ParseTextData();
        }

        /// <summary>
        /// Возвращает случайное целое число от Min до Max
        /// </summary>
        /// <param name="Min">Минимальное случайное число</param>
        /// <param name="Max">Максимальное случайное число</param>
        /// <returns></returns>
        public static int GetRandomValue(int Min, int Max)
        {
            return Sychev.Next(Min, Max);
        }
        #endregion

        #region Город
        /// <summary>
        /// Создает новый экземпляр города
        /// </summary>
        /// <param name="Name">Название города</param>
        /// <param name="Width">Ширина города</param>
        /// <param name="Height">Высота города</param>
        public static void CityCreate(string Name, int Height, int Width)
        {
            City = new City(Name, Width, Height);
            //FreeSpaces = City.GetFreeSpaces();
        }

        /// <summary>
        /// Возвращает Тrue, Если город создан и False, Если нет
        /// </summary>
        /// <returns>Возвращает логическое значение</returns>
        public static bool CityIsPresent()
        {
            return City != null;
        }

        /// <summary>
        /// Возвращает название города
        /// </summary>
        /// <returns>Возвращает строку</returns>
        public static string CityGetName()
        {
            return City.GetName();
        }

        /// <summary>
        /// Уничтожает экземпляр города
        /// </summary>
        public static void CityDestroy()
        {
            City = null;
        }

        /// <summary>
        /// Устанавливает новый дом
        /// </summary>
        /// <param name="Row">Строка верхнего левого квадрата дома</param>
        /// <param name="Col">Столбец верхнего левого квадрата дома</param>
        /// <param name="Width">Ширина дома</param>
        /// <param name="Heigth">Высота дома</param>
        public static void CityHousePlace(int X, int Y, int Width, int Height)
        {
            City.PlaceHouse(X, Y, Width, Height);
        }

        /// <summary>
        /// Устанавливает биллборд на карте города.
        /// </summary>
        /// <param name="Billboard">Устанавливаемый биллборд</param>
        public static void CityBillboardPlace(Billboard Billboard)
        {
            City.PlaceBillboard(Billboard);
        }

        /// <summary>
        /// Достраивает все биллборды на карте
        /// </summary>
        /// <returns>Возвращает число достроенных биллбордов</returns>
        public static int CityBillboardsBuildToEnd()
        {
            return City.BuildBillboardsToEnd();
        }

        /// <summary>
        /// Заполняет случайный пустой биллборд на карте
        /// </summary>
        /// <param name="Desire"></param>
        public static void CityBillboardFillRandom(Tuple<string, int, byte> Desire)
        {
            City.FillBillboard(Desire);
        }

        /// <summary>
        /// Возвращает матрицу цветов элементов города
        /// </summary>
        /// <returns>Возвращает матрицу цветовых значений</returns>
        public static System.Drawing.Color[,] CityGetDrawingData()
        {
            return City.GetDrawingData();
        }

        /// <summary>
        /// Возвращает цветовую матрицу коэффициентов
        /// </summary>
        /// <returns>Возвращает матрицу цветовых значений</returns>
        public static System.Drawing.Color[,] CityGetProximityMap()
        {
            return City.GetProximityMap();
        }
        #endregion

        #region Агентство  
        /// <summary>
        /// Создает новый экземпляр агентства
        /// </summary>
        /// <param name="Name">Название агентства</param>
        /// <param name="Money">Начальный депозит</param>
        /// <param name="Billboards">Количество рекламных щитов</param>
        /// <param name="Strategy">Стратегия агентства</param>
        /// <returns></returns>
        public static bool AgencyCreate(string Name, int Money, int Billboards, int StrategyType)
        {
            if (Name != null && Name != "")
            {
                Agency = new Agency(Name, Money, Billboards);
                switch (StrategyType)
                {
                    case 0:
                        Strategy = new StrategyNormal();
                        break;
                    case 1:
                        Strategy = new StrategyConservative();
                        break;
                    case 2:
                        Strategy = new StrategyAggressive();
                        break;
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Возвращает тип стратегии агентства
        /// </summary>
        /// <returns></returns>
        public static Strategy.StrategyType AgencyGetStrategy()
        {
            return Strategy.ReturnStrategyType();
        }

        /// <summary>
        /// Возвращает True, если агентство создано
        /// </summary>
        /// <returns></returns>
        public static bool AgencyIsPresent()
        {
            return Agency != null;
        }

        /// <summary>
        /// Уничтожает агентство
        /// </summary>
        public static void AgencyDestroy()
        {
            City.DeleteBillboards();
            Agency = null;
        }

        /// <summary>
        /// Возвращает кортеж данных агентства
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, int, int> AgencyGetData()
        {
            return Agency.GetData();
        }

        /// <summary>
        /// Меняет данные агентства
        /// </summary>
        /// <param name="Name">Новое название агентства</param>
        /// <param name="Strategy">Новая стратегия агентства</param>
        public static void AgencyChangeData(string Name)
        {
            Agency.ChangeName(Name);
        }

        /// <summary>
        /// Проводит один день работы агентства
        /// </summary>
        public static void AgencyPassDay()
        {
            Agency.PassDay();
        }

        /// <summary>
        /// Возвращает список-отчет роста бюджета
        /// </summary>
        /// <returns></returns>
        public static List<double[]> AgencyGetSummary()
        {
            return Agency.GetAgencySummary();
        }
        #endregion

        #region Дата
        /// <summary>
        /// Добавляет один день к дате.
        /// </summary>
        public static void DateNewDay()
        {
            CurrentDate = CurrentDate.AddDays(1);
        }

        /// <summary>
        /// Возвращает дату строкой вида DD.MM.YYYY.
        /// </summary>
        /// <returns>Возвращает строку</returns>
        public static string DateGetAsString()
        {
            return CurrentDate.ToShortDateString();
        }

        /// <summary>
        /// Возвращает True, если по дате будний день.
        /// </summary>
        /// <returns></returns>
        public static bool DateIsWorkday()
        {
            return CurrentDate.DayOfWeek != DayOfWeek.Saturday &&
            CurrentDate.DayOfWeek != DayOfWeek.Sunday;
        }
        #endregion

        #region Очередь клиентов
        /// <summary>
        /// Создает очередь
        /// </summary>
        public static void QueueCreate()
        {
            Queue = new QueueClass();
        }

        /// <summary>
        /// Возвращает желания всех клиентов
        /// </summary>
        /// <returns>Возвращает строку</returns>
        public static string QueueGetText()
        {
            return Queue.GetQueueOrders();
        }

        /// <summary>
        /// Возвращает кортеж заказчика
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, int, byte> QueueTakeOrder()
        {
            Client Cl;

            if (Queue.QueueHasHighPriority())
                Cl = Queue.QueuePushHighPriority();
            else
                Cl = Queue.QueuePushNormal();
            return Cl.GetOrder();
        }

        /// <summary>
        /// Возвращает True, если очередь пуста
        /// </summary>
        /// <returns></returns>
        public static bool QueueIsNull()
        {
            return Queue.QueueIsNull();
        }

        /// <summary>
        /// Добавляет в очередь случайное количество случайных клиентов
        /// </summary>
        /// <param name="Quantity">Максимальное количество клиентов</param>
        /// <param name="Intensity"></param>
        public static void QueueAddRand(int Quantity, int Intensity)
        {
            Client Cl = null;
            int Quant = GetRandomValue(0, Quantity);
            Client.Rank Rnk;

            for (int i = 0; i < Quant; i++)
            {
                Rnk = (Client.Rank)GetRandomValue(2, 4);
                switch (Rnk)
                {
                    case Client.Rank.Person:
                        Cl = new ClientPerson(TextStorageClass.GetRandomData((byte)Rnk));
                        break;
                    case Client.Rank.Company:
                        Cl = new ClientCompany(TextStorageClass.GetRandomData((byte)Rnk));
                        break;
                    case Client.Rank.Government:
                        Cl = new ClientGovernment(TextStorageClass.GetRandomData((byte)Rnk));
                        break;
                }
                Queue.QueueAdd(Cl);
            }

        }
        #endregion
    }
}
