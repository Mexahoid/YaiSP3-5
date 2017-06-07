using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Класс частного лица.
    /// </summary>
    class ClientPerson : TemplateClient
    {
        /// <summary>
        /// Конструктор частного лица.
        /// </summary>
        /// <param name="Data">Кортеж из названия и желания частного лица.</param>
        public ClientPerson((string name, string desire) Data)
        {
            clientName = Data.name;
            clientDesire = Data.desire;
        }

        /// <summary>
        /// Возвращает информацию о частном лице.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public override string GetTextData() =>
            "Клиент: " + clientName + Environment.NewLine +
                    "Текст: " + clientDesire + Environment.NewLine +
                    "Предложение: " + 200 + Environment.NewLine;

        /// <summary>
        /// Платит свою цену.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public override int Pay() => 200;
    }

}
