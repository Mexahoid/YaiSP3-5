using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Обработчик очереди.
    /// </summary>
    class QueueHandler
    {
        /// <summary>
        /// Экземпляр очереди.
        /// </summary>
        private QueueClass Queue;

        /// <summary>
        /// Создает очередь.
        /// </summary>
        public QueueHandler()
        {
            Queue = new QueueClass();
        }

        /// <summary>
        /// Возвращает ссылку на объект очереди.
        /// </summary>
        /// <returns>Возвращает экземпляр очереди.</returns>
        public QueueClass GetQueueLink()
        {
            return Queue;
        }
        
        /// <summary>
        /// Добавляет в очередь случайное количество случайных клиентов.
        /// </summary>
        /// <param name="Quantity">Максимальное количество клиентов.</param>
        /// <param name="Intensity">Частота появления клиентов.</param>
        public void QueueAddRand(int Quantity, int Intensity)
        {
            if (Intensity / 2 == MiscellaneousLogics.MainGetRandomValue(0, Intensity))
            {
                TemplateClient Cl = null;
                int Quant = MiscellaneousLogics.MainGetRandomValue(0, Quantity);

                for (int i = 0; i < Quant; i++)
                {
                    int Rnk = MiscellaneousLogics.MainGetRandomValue(0, 100);
                    if (Rnk < 50)
                        Cl = new ClientPerson(TextStorageClass.GetRandomData(2));
                    else
                    if (Rnk < 85)
                        Cl = new ClientCompany(TextStorageClass.GetRandomData(3));
                    else
                        Cl = new ClientGovernment(TextStorageClass.GetRandomData(4));
                    Queue.QueueAdd(Cl);
                }
            }
        }

        /// <summary>
        /// Возвращает желания всех клиентов.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public override string ToString()
        {
            return Queue.ToString();
        }
    }
}
