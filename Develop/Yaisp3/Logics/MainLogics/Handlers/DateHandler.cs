using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Обработчик даты.
    /// </summary>
    class DateHandler
    {
        /// <summary>
        /// Экземпляр даты.
        /// </summary>
        private DateTime CurrentDate = new DateTime(1970, 1, 1);

        /// <summary>
        /// Добавляет один день к дате.
        /// </summary>
        public void DateNewDay() => CurrentDate = CurrentDate.AddDays(1);

        /// <summary>
        /// Возвращает дату строкой вида DD.MM.YYYY.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public string DateGetAsString() => CurrentDate.ToShortDateString();
    }
}
