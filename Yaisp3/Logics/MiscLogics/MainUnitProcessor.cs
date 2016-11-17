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

        public static void MainReset()
        {
            Agency = null;
            City = null;
            CurrentDate = new DateTime(1970, 1, 1);
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
        /// Возвращает случайное целое число от Min до Max
        /// </summary>
        /// <param name="Min">Минимальное случайное число</param>
        /// <param name="Max">Максимальное случайное число</param>
        /// <returns></returns>
        public static int GetRandomValue(int Min, int Max)
        {
            return Sychev.Next(Min, Max);
        }

        /// <summary>
        /// Возвращает матрицу города для дальнейших операций
        /// </summary>
        /// <returns>Возвращает матрицу целочисленных значений</returns>
        public static System.Drawing.Color[,] CityGetDrawingData()
        {
            return City.GetDrawingData();
        }

        public static System.Drawing.Color[,] CityGetProximityMap()
        {
            return City.GetProximityMap();
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

        public static void CityBillboardsBuildToEnd()
        {
            City.BuildBillboardsToEnd();
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
        /// Создает новый экземпляр агентства
        /// </summary>
        /// <param name="Name">Название агентства</param>
        /// <param name="Money">Начальный депозит</param>
        /// <param name="Billboards">Количество рекламных щитов</param>
        /// <param name="Strategy">Стратегия агентства</param>
        /// <returns></returns>
        public static bool AgencyCreate(string Name, int Money, int Billboards, int Strategy)
        {
            if (Name != null && Name != "")
            {
                Agency = new Agency(Name, Money, Billboards, (Agency.Strategies)Strategy);
                return true;
            }
            else
                return false;
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
            Agency = null;
        }
        /// <summary>
        /// Возвращает кортеж данных агентства
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, int, int, Agency.Strategies> AgencyGetData()
        {
            return Agency.GetData();
        }
        /// <summary>
        /// Меняет данные агентства
        /// </summary>
        /// <param name="Name">Новое название агентства</param>
        /// <param name="Strategy">Новая стратегия агентства</param>
        public static void AgencyChangeData(string Name, int Strategy)
        {
            Agency.ChangeMainData(Name, (Agency.Strategies)Strategy);
        }

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
    }
}
