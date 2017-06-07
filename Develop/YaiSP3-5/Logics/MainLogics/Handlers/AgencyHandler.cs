using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Обработчик агентства.
    /// </summary>
    public class AgencyHandler
    {
        #region Поля

        /// <summary>
        /// Обрабатываемое агентство.
        /// </summary>
        Agency Agency;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор обработчика.
        /// </summary>
        public AgencyHandler() => Agency = null;

        /// <summary>
        /// Создает новый экземпляр агентства.
        /// </summary>
        /// <param name="Name">Название агентства.</param>
        /// <param name="Money">Начальный депозит.</param>
        /// <param name="Billboards">Количество рекламных щитов.</param>
        /// <returns>Возвращает логическое значение.</returns>
        public bool AgencyCreate(string Name, int Money, int Billboards, int AgencyGroup)
        {
            if (Name != null && Name != "")
            {
                Agency = new Agency(Name, Money, Billboards, AgencyGroup);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Заносит в агентство ссылки на город, очередь и отрисовщики.
        /// </summary>
        /// <param name="City">Ссылка на город.</param>
        /// <param name="Queue">Ссылка на очередь.</param>
        /// <param name="Drawers">Ссылка на отрисовщики.</param>
        public void AgencySetLink(City City, QueueClass Queue, MainDrawingProcessor Drawers) =>
            Agency.SetLinks(City, Queue, Drawers);
        
        /// <summary>
        /// Возвращает ссылку на агентство.
        /// </summary>
        /// <returns>Возвращает экземпляр агентства.</returns>
        public Agency GetAgencyLink() => Agency;

        /// <summary>
        /// Возвращает кортеж данных агентства.
        /// </summary>
        /// <returns>Возвращает кортеж из двух целочисленных значений.</returns>
        public (int deposit, int billboards) AgencyGetData() => Agency.GetData();

        /// <summary>
        /// Возвращает название агенства.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public override string ToString() => Agency.ToString();

        /// <summary>
        /// Возвращает True, если агентство создано.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool AgencyIsPresent() => Agency != null;

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
        public void AgencyChangeName(string Name) => Agency.ChangeName(Name);

        /// <summary>
        /// Возвращает список-отчет роста бюджета.
        /// </summary>
        /// <returns>Возвращает кортеж вещественных чисел.</returns>
        public List<(double, double)> AgencyGetSummary() => Agency.GetAgencySummary();

        #endregion
    }
}