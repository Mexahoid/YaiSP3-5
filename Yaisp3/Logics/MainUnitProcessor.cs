using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  public static class MainUnitProcessor
  {
    private static Agency Agency = null;
    private static City City = null;
    private static DateTime CurrentDate = new DateTime(1970, 1, 1);

    public static void MainReset()
    {
      Agency = null;
      City = null;
      CurrentDate = new DateTime(1970, 1, 1);
    }

    /// <summary>
    /// Возвращает Тrue, Если город создан и False, Если нет
    /// </summary>
    /// <returns>Возвращает логическое значение</returns>
    public static bool CityIsPresent()
    {
      return City != null;
    }

    /// <summary>
    /// Создает новый экземпляр города
    /// </summary>
    /// <param name="Matrix">Матрица города</param>
    /// <param name="Name">Название города</param>
    public static void CityCreate(int[,] Matrix, string Name)
    {
      City = new City(Name, Matrix);
    }

    /// <summary>
    /// Возвращает матрицу города для дальнейших операций
    /// </summary>
    /// <returns>Возвращает матрицу целочисленных значений</returns>
    public static int[,] CityGetDrawingData()
    {
      return City.GetDrawingData();
    }

    /// <summary>
    /// Оценивает возможность установки элемента в городе
    /// </summary>
    /// <param name="X00">Строка установки левого верхнего угла</param>
    /// <param name="Y00">Столбец установки левого верхнего угла</param>
    /// <param name="RightWidth">Ширина элемента</param>
    /// <param name="DownDepth">Высота элемента</param>
    /// <returns></returns>
    public static bool CityIsHouseCanBePlaced(int X00, int Y00, int RightWidth, int DownDepth)
    {
      return City.TryToPlaceHouse(X00, Y00, RightWidth, DownDepth);
    }

    /// <summary>
    /// Возвращает название города
    /// </summary>
    /// <returns>Возвращает строку</returns>
    public static string CityGetName()
    {
      return City.GetName();
    }

    /// <summary>
    /// Уничтожает экземпляр города
    /// </summary>
    public static void CityDestroy()
    {
      City = null;
    }

    /// <summary>
    /// Изменяет матрицу города
    /// </summary>
    /// <param name="Matrix">Целочисленная матрица города</param>
    public static void CityRecreateMatrix(int[,] Matrix)
    {
      
    }

    /// <summary>
    /// Создает новый экземпляр агентства
    /// </summary>
    /// <param name="Name">Название агентства</param>
    /// <param name="Money">Начальный депозит</param>
    /// <param name="Billboards">Количество рекламных щитов</param>
    /// <param name="Strategy">Стратегия агентства</param>
    /// <returns></returns>
    public static bool AgencyCreate(string Name, string Money, string Billboards, int Strategy)
    {
      int Mon = 0, Bb = 0;
      if (Name != null && Name != "")
        if (int.TryParse(Money, out Mon) && int.TryParse(Billboards, out Bb) && Mon > 0 && Bb > 0)
        {
          Agency = new Agency(Name, Mon, Bb, (Agency.Strategies)Strategy);
          return true;
        }
        else
          return false;
      return false;
    }
    public static bool AgencyIsPresent()
    {
      return Agency != null;
    }
    public static void AgencyDestroy()
    {
      Agency = null;
    }
    public static void AgencyGetData(out string Name, out int Money, out int Billboards, out int Strategy)
    {
      Agency.Strategies Strat;
      Agency.GetData(out Name, out Money, out Billboards, out Strat);
      Strategy = (int)Strat;
    }
    public static void AgencyChangeData(string Name, int Strategy)
    {
      Agency.ChangeMainData(Name, (Agency.Strategies)Strategy);
    }

    public static void DateNewDay()
    {
      CurrentDate = CurrentDate.AddDays(1);
    }
    public static string DateGetAsString()
    {
      return CurrentDate.ToShortDateString();
    }
  }
}
