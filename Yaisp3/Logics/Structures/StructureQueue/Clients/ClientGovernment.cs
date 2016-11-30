using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
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
        public ClientGovernment(Tuple<string, string> Data)
        {
            clientName = Data.Item1;
            clientDesire = Data.Item2;
        }

        /// <summary>
        /// Возвращает информацию о гос. организации.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public override string GetTextData()
        {
            return "Гос. организация: " + clientName + Environment.NewLine +
                    "Текст: " + clientDesire + Environment.NewLine;
        }

        /// <summary>
        /// Платит свою цену.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public override int Pay()
        {
            return 0;
        }
    }
}
