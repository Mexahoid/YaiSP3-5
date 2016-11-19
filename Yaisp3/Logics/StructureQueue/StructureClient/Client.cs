using System;

namespace Yaisp3
{
    /// <summary>
    /// Базовый класс клиента
    /// </summary>
    class Client
    {
        #region Переменные
        /// <summary>
        /// Уровень заказчика
        /// </summary>
        public enum Rank : byte
        {
            /// <summary>
            /// Частное лицо
            /// </summary>
            Person = 2,
            /// <summary>
            /// Компания
            /// </summary>
            Company,
            /// <summary>
            /// Правительство
            /// </summary>
            Government
        }
        
        /// <summary>
        /// Имя заказчика
        /// </summary>
        protected string clientName;

        /// <summary>
        /// Желание заказчика (текст рекламы)
        /// </summary>
        protected string clientDesire;

        /// <summary>
        /// Предложенная цена за аренду биллборда
        /// </summary>
        protected int clientOffering;

        /// <summary>
        /// Уровень клиента
        /// </summary>
        protected Rank clientRank;
        #endregion
        
        /// <summary>
        /// Конструктор клиента
        /// </summary>
        /// <param name="Name">Имя клиента</param>
        /// <param name="Desire">Желание клиента</param>
        protected Client(string Name, string Desire)
        {
            clientName = Name;
            clientDesire = Desire;
            clientOffering = MainUnitProcessor.GetRandomValue(100, 2000);
        }

        /// <summary>
        /// Возвращает заказ клиента
        /// </summary>
        /// <returns>Возвращает кортеж из текста рекламы, цены за аренду и уровня</returns>
        public Tuple<string, int, byte> GetOrder()
        {
            return Tuple.Create(clientDesire, clientOffering, (byte)clientRank);
        }

        public string GetTextData()
        {
            string Out = "";
            Out += "Клиент: " + clientName + 
                ", Текст: " + clientDesire + 
                ". Уровень: " + (clientRank == Rank.Person ? "Частное лицо. " :
                clientRank == Rank.Company ? "Компания. " : "Гос. организация. ") + 
                "Предложение: " + clientOffering.ToString();
            return Out;
        }

        public bool IsHighPriority()
        {
            return clientRank == Rank.Government;
        }
    }

    /// <summary>
    /// Класс частного лица
    /// </summary>
    class ClientPerson : Client
    {
        /// <summary>
        /// Конструктор частного лица
        /// </summary>
        /// <param name="Name">Имя частного лица</param>
        /// <param name="Desire">Желание частного лица</param>
        public ClientPerson(string[] Data) : base(Data[0], Data[1])
        {
            clientRank = Rank.Person;
        }
    }

    /// <summary>
    /// Класс компании
    /// </summary>
    class ClientCompany : Client
    {
        /// <summary>
        /// Конструктор компании-заказчика
        /// </summary>
        /// <param name="Name">Название компании</param>
        /// <param name="Desire">Желание компании</param>
        public ClientCompany(string[] Data) : base(Data[0], Data[1])
        {
            clientRank = Rank.Company;
        }
    }

    /// <summary>
    /// Класс правительственной организации
    /// </summary>
    class ClientGovernment : Client
    {
        /// <summary>
        /// Конструктор правительственного заказчика
        /// </summary>
        /// <param name="Name">Название госструктуры</param>
        /// <param name="Desire">Текст социальной рекламы</param>
        public ClientGovernment(string[] Data) : base(Data[0], Data[1])
        {
            clientOffering = 0;
            clientRank = Rank.Government;
        }
    }
}
