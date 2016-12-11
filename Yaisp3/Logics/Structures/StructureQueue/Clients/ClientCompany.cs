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
        public ClientCompany(Tuple<string, string> Data)
        {
            clientName = Data.Item1;
            clientDesire = Data.Item2;
        }

        /// <summary>
        /// Возвращает информацию о компании.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public override string GetTextData()
        {
            return "Компания: " + clientName + Environment.NewLine +
                    "Текст: " + clientDesire + Environment.NewLine +
                    "Предложение: " + 1000 + Environment.NewLine;
        }

        /// <summary>
        /// Платит свою цену.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public override int Pay()
        {
            return 1000;
        }
    }
}
