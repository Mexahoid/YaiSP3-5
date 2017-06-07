using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Класс правительственной организации
    /// </summary>
    class ClientGovernment : TemplateClient
    {
        /// <summary>
        /// Конструктор правительственного заказчика
        /// </summary>
        /// <param name="Data">Кортеж из названия и желания правительственной компании.</param>
        public ClientGovernment((string name, string desire) Data)
        {
            clientName = Data.name;
            clientDesire = Data.desire;
        }

        /// <summary>
        /// Возвращает информацию о гос. организации.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public override string GetTextData() => 
            "Гос. организация: " + clientName + Environment.NewLine +
                    "Текст: " + clientDesire + Environment.NewLine;

        /// <summary>
        /// Платит свою цену.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public override int Pay() => 0;
    }
}
