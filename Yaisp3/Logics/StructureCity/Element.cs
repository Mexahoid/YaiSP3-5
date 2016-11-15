using System;

namespace Yaisp3
{
  /// <summary>
  /// Класс базового элемента города
  /// </summary>
  class Element
  {
    /// <summary>
    /// Позиция элемента в матрице города
    /// </summary>
    //protected City.Position Position;


   /* /// <summary>
    /// Базовый конструктор элемента
    /// </summary>
    /// <param name="Position">Позиция элемента</param>
    protected Element(City.Position Position)
    {
      this.Position = Position;
    }*/

  }

  /// <summary>
  /// Класс элемента дома
  /// </summary>
  class House : Element
  {
    /// <summary>
    /// Группа, к которой принадлежит город
    /// </summary>
    private int houseElementGroup;


    /// <summary>
    /// Создает элемент города заданной группы элементов
    /// </summary>
    /// <param name="Position">Позиция, на которую устанавливается элемент</param>
    /// <param name="Group">Группа элементов</param>
    public House(int Group)
    {
      houseElementGroup = Group;
    }
  }

  /// <summary>
  /// Класс биллборда
  /// </summary>
  class Billboard : Element
  {
    /// <summary>
    /// Состояние города
    /// </summary>
    enum State : byte
    {
      /// <summary>
      /// Биллборд строится
      /// </summary>
      Building,
      /// <summary>
      /// Биллборд построен, но не заполнен
      /// </summary>
      Free,
      /// <summary>
      /// На биллборде размещена реклама частного лица
      /// </summary>
      Personal,
      /// <summary>
      /// На биллборде размещена реклама компании
      /// </summary>
      Company,
      /// <summary>
      /// На биллборде размещена социальная реклама
      /// </summary>
      Government
    }

    /// <summary>
    /// Сумма, которую стоит обслуживание этого биллборда
    /// </summary>
    private int billboardCostPerDay;

    /// <summary>
    /// Сумма, которую приносит этот биллборд в день
    /// </summary>
    private int billboardProfitPerDay;

    /// <summary>
    /// Текст рекламы, записанной на биллборде
    /// </summary>
    private string billboardText;

    /// <summary>
    /// Тип рекламы, размещённой на биллборде
    /// </summary>
    private State billboardType;

    /// <summary>
    /// Закончено ли строительство биллборда
    /// </summary>
    private bool billboardBuilded;
    
    
    /// <summary>
    /// Создает новый биллборд
    /// </summary>
    /// <param name="Position">Позиция установки</param>
    /// <param name="AllCost">Ощая цена постройки биллборда</param>
    public Billboard(City.Position Position, int AllCost) : base(Position)
    {
      billboardBuilded = false;
      billboardProfitPerDay = 0;
      billboardCostPerDay = AllCost / 100;
      billboardType = State.Building;
    }

    /// <summary>
    /// Активирует биллборд как готовый к заполнению
    /// </summary>
    public void BuildBillboardToEnd()
    {
      billboardBuilded = true;
      billboardType = State.Free;
    }

    /// <summary>
    /// Заполняет биллборд заказом клиента
    /// </summary>
    /// <param name="ClientDesire">Кортеж из текста рекламы, цены за аренду и уровня заказчика</param>
    public void FillBillboard(Tuple<string, int, byte> ClientDesire)
    {
      billboardText = ClientDesire.Item1;
      billboardCostPerDay = ClientDesire.Item2;
      billboardType = (State)ClientDesire.Item3;   //Значения Rank и State для заказов совпадают
    }

    /// <summary>
    /// Возвращает соответствующий цвет для отрисовки биллборда на карте
    /// </summary>
    /// <returns></returns>
    public System.Drawing.Color GetBillboardColor()
    {
      switch (billboardType)
      {
        case State.Building:
          return System.Drawing.Color.DarkGoldenrod;
        case State.Free:
          return System.Drawing.Color.Aquamarine;
        case State.Personal:
          return System.Drawing.Color.Green;
        case State.Company:
          return System.Drawing.Color.Orange;
        default: // State.Government:
          return System.Drawing.Color.Crimson;
      }
    } 
  }
}
