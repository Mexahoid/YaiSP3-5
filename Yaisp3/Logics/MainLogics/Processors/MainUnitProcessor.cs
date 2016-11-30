using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Главный класс-процессор.
    /// </summary>
    public sealed class MainUnitProcessor
    {
        #region Поля

        /// <summary>
        /// Экземпляр агентства.
        /// </summary>
        private static Agency Agency = null;

        /// <summary>
        /// Экземпляр города.
        /// </summary>
        private static City City = null;

        /// <summary>
        /// Экземпляр даты.
        /// </summary>
        private static DateTime CurrentDate = new DateTime(1970, 1, 1);


        /// <summary>
        /// Экземпляр стратегии.
        /// </summary>
        private static TemplateStrategy Strategy;

        /// <summary>
        /// Экземпляр очереди клиентов.
        /// </summary>
        private static QueueClass Queue;

        #endregion

        #region Главные методы

        /// <summary>
        /// Полный сброс всей программы.
        /// </summary>
        public static void MainReset()
        {
            Agency = null;
            City = null;
            CurrentDate = new DateTime(1970, 1, 1);
        }
/*
        /// <summary>
        /// Проходит один день.
        /// </summary>
        public static void PassDay()
        {
            AgencyPassDay();
            Strategy.Action();
            DateNewDay();
        }
        */
        #endregion

        #region Город
            
        #endregion

        #region Стратегия

        /// <summary>
        /// Возвращает тип стратегии агентства.
        /// </summary>
        /// <returns>Возвращает тип стратегии.</returns>
        public static TemplateStrategy.StrategyType StrategyGetType()
        {
            return Strategy.ReturnStrategyType();
        }

        #endregion

        #region Агентство  
        /*
        /// <summary>
        /// Создает новый экземпляр агентства.
        /// </summary>
        /// <param name="Name">Название агентства.</param>
        /// <param name="Money">Начальный депозит.</param>
        /// <param name="Billboards">Количество рекламных щитов.</param>
        /// <param name="StrategyType">Стратегия агентства</param>
        /// <returns>Возвращает логическое значение.</returns>
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
        /// Возвращает True, если агентство создано.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public static bool AgencyIsPresent()
        {
            return Agency != null;
        }

        /// <summary>
        /// Уничтожает агентство.
        /// </summary>
        public static void AgencyDestroy()
        {
            City.DeleteBillboards();
            Agency = null;
        }

        /// <summary>
        /// Возвращает кортеж данных агентства/
        /// </summary>
        /// <returns>Возвращает кортеж из строки и двух целочисленных значений.</returns>
        public static Tuple<string, int, int> AgencyGetData()
        {
            return Agency.GetData();
        }

        /// <summary>
        /// Меняет название агентства.
        /// </summary>
        /// <param name="Name">Новое название агентства.</param>
        public static void AgencyChangeName(string Name)
        {
            Agency.ChangeName(Name);
        }

        /// <summary>
        /// Проводит один день работы агентства.
        /// </summary>
        public static void AgencyPassDay()
        {
            Agency.PassDay();
        }

        /// <summary>
        /// Возвращает список-отчет роста бюджета.
        /// </summary>
        /// <returns>Возвращает кортеж вещественных чисел.</returns>
        public static List<Tuple<double, double>> AgencyGetSummary()
        {
            return Agency.GetAgencySummary();
        }

        /// <summary>
        /// Устанавливает биллборд.
        /// </summary>
        public static void AgencyPlaceRandBillboard()
        {
            Agency.PlaceBillboardRnd();
        }

        /// <summary>
        /// Возвращает число возможных к установке биллбордов.
        /// </summary>
        /// <param name="Count">Максимальное количество устанавливаемых биллбордов.</param>
        /// <returns>Возвращает целочисленное значение.</returns>
        public static int AgencyCanAffordBillboards(int Count)
        {
            return Agency.HowMuchCanWeAfford(Count);
        }

        /// <summary>
        /// Возвращает количество свободных построенных биллбордов.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public static int AgencyFreeCount()
        {
            return Agency.GetFreeBillboardsCount();
        }
        */
        #endregion

        #region Дата

        /// <summary>
        /// Добавляет один день к дате.
        /// </summary>
        private static void DateNewDay()
        {
            CurrentDate = CurrentDate.AddDays(1);
        }

        /// <summary>
        /// Возвращает дату строкой вида DD.MM.YYYY.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public static string DateGetAsString()
        {
            return CurrentDate.ToShortDateString();
        }


        #endregion

        #region Очередь клиентов
        
        #endregion
    }
}
