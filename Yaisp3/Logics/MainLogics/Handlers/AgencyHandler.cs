using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    public class AgencyHandler
    {
        Agency Agency;

        public AgencyHandler()
        {
            Agency = null;
        }

        /// <summary>
        /// Создает новый экземпляр агентства.
        /// </summary>
        /// <param name="Name">Название агентства.</param>
        /// <param name="Money">Начальный депозит.</param>
        /// <param name="Billboards">Количество рекламных щитов.</param>
        /// <returns>Возвращает логическое значение.</returns>
        public bool AgencyCreate(string Name, int Money, int Billboards)
        {
            if (Name != null && Name != "")
            {
                Agency = new Agency(Name, Money, Billboards);
                return true;
            }
            else
                return false;
        }

        public void AgencySetLink(CityHandler City, QueueClass Queue, MainDrawingProcessor Drawers)
        {
            Agency.SetLinks(City, Queue, Drawers);
        }

        public void AgencyPassDay()
        {
            Agency.PassDay();
        }

        public Agency GetAgencyLink()
        {
            return Agency;
        }

        /// <summary>
        /// Возвращает кортеж данных агентства/
        /// </summary>
        /// <returns>Возвращает кортеж из строки и двух целочисленных значений.</returns>
        public Tuple<string, int, int> AgencyGetData()
        {
            return Agency.GetData();
        }

        /// <summary>
        /// Возвращает True, если агентство создано.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool AgencyIsPresent()
        {
            return Agency != null;
        }

        /// <summary>
        /// Уничтожает агентство.
        /// </summary>
        public void AgencyDestroy()
        {
            Agency.DeleteBillboards();
            Agency = null;
        }

        /// <summary>
        /// Меняет название агентства.
        /// </summary>
        /// <param name="Name">Новое название агентства.</param>
        public void AgencyChangeName(string Name)
        {
            Agency.ChangeName(Name);
        }

        /// <summary>
        /// Возвращает список-отчет роста бюджета.
        /// </summary>
        /// <returns>Возвращает кортеж вещественных чисел.</returns>
        public List<Tuple<double, double>> AgencyGetSummary()
        {
            return Agency.GetAgencySummary();
        }

    }
}
