using System;

namespace Yaisp3
{
  /// <summary>
  /// Базовый класс клиента
  /// </summary>
  class Client
  {
    /// <summary>
    /// Уровень заказчика
    /// </summary>
    protected enum Rank : byte
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
    /// Высокий ли приоритет у заказчика
    /// </summary>
    protected bool clientHighPriority;

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


    /// <summary>
    /// Конструктор клиента
    /// </summary>
    /// <param name="Name">Имя клиента</param>
    /// <param name="Desire">Желание клиента</param>
    protected Client(string Name, string Desire)
    {
      clientName = Name;
      clientHighPriority = false;
      clientDesire = Desire;
    }

    /// <summary>
    /// Возвращает заказ клиента
    /// </summary>
    /// <returns>Возвращает кортеж из текста рекламы, цены за аренду и уровня</returns>
    public Tuple<string, int, byte> GetOrder()
    {
      return Tuple.Create(clientDesire, clientOffering, (byte)clientRank);
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
    public ClientPerson(string Name, string Desire) : base(Name, Desire)
    {
      clientOffering = MainUnitProcessor.GetRandomValue(1, 100);
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
    public ClientCompany(string Name, string Desire) : base(Name, Desire)
    {
      clientOffering = MainUnitProcessor.GetRandomValue(50, 5000);
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
    public ClientGovernment(string Name, string Desire) : base(Name, Desire)
    {
      clientHighPriority = true;
      clientOffering = 0;
      clientRank = Rank.Government;
    }
  }
}
