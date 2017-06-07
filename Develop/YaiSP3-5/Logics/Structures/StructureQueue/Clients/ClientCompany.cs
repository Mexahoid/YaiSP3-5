using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Класс компании.
    /// </summary>
    class ClientCompany : TemplateClient
    {
        /// <summary>
        /// Конструктор компании-заказчика.
        /// </summary>
        /// <param name="Data">Кортеж названия и желания компании.</param>
        public ClientCompany((string name, string desire) Data)
        {
            clientName = Data.name;
            clientDesire = Data.desire;
        }

        /// <summary>
        /// Возвращает информацию о компании.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public override string GetTextData() =>
            "Компания: " + clientName + Environment.NewLine +
                    "Текст: " + clientDesire + Environment.NewLine +
                    "Предложение: " + 1000 + Environment.NewLine;

        /// <summary>
        /// Платит свою цену.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public override int Pay() => 1000;
    }
}
