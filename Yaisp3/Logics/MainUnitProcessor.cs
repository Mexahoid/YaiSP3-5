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
    private static List<City.Position> FreeSpaces;
    private static Random Sychev = new Random();

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
      FreeSpaces = City.GetFreeSpaces();
    }
    /// <summary>
    /// Возвращает случайное целое число от Min до Max
    /// </summary>
    /// <param name="Min">Минимальное случайное число</param>
    /// <param name="Max">Максимальное случайное число</param>
    /// <returns></returns>
    public static int GetRandomValue(int Min, int Max)
    {
      return Sychev.Next(Min, Max);
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
      return City.TryToPlaceElement(X00, Y00, RightWidth, DownDepth);
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
      City.RecreateMatrix(Matrix);
    }

    /// <summary>
    /// Возвращает случайную свободную позицию на матрице города
    /// </summary>
    /// <returns>Возвращает экземпляр City.Position</returns>
    public static City.Position CityReturnFreePosition()
    {
      Random Sychev = new Random();
      int Pos = Sychev.Next(0, FreeSpaces.Count);
      City.Position Position = FreeSpaces[Pos];
      City.FillSpace(Position);
      FreeSpaces = City.GetFreeSpaces();
      return Position;
    }
    /// <summary>
    /// Пересоздает список пустых мест
    /// </summary>
    public static void CityGetFreePositions()
    {
      FreeSpaces = City.GetFreeSpaces();
    }

    public static void CityAddElement(int X, int Y, int Width, int Height)
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
    public static bool AgencyCreate(string Name, int Money, int Billboards, int Strategy)
    {
      int Mon = 0, Bb = 0;
      if (Name != null && Name != "")
      {
        Agency = new Agency(Name, Mon, Bb, (Agency.Strategies)Strategy);
        return true;
      }
      else
        return false;
    }
    /// <summary>
    /// Возвращает True, если агентство создано
    /// </summary>
    /// <returns></returns>
    public static bool AgencyIsPresent()
    {
      return Agency != null;
    }
    /// <summary>
    /// Уничтожает агентство
    /// </summary>
    public static void AgencyDestroy()
    {
      Agency = null;
    }
    /// <summary>
    /// Возвращает кортеж данных агентства
    /// </summary>
    /// <returns></returns>
    public static Tuple<string, int, int, Agency.Strategies> AgencyGetData()
    {
      return Agency.GetData();
    }
    /// <summary>
    /// Меняет данные агентства
    /// </summary>
    /// <param name="Name">Новое название агентства</param>
    /// <param name="Strategy">Новая стратегия агентства</param>
    public static void AgencyChangeData(string Name, int Strategy)
    {
      Agency.ChangeMainData(Name, (Agency.Strategies)Strategy);
    }

    /// <summary>
    /// Добавляет один день к дате
    /// </summary>
    public static void DateNewDay()
    {
      CurrentDate = CurrentDate.AddDays(1);
    }
    /// <summary>
    /// Возвращает дату строкой вида DD.MM.YYYY
    /// </summary>
    /// <returns></returns>
    public static string DateGetAsString()
    {
      return CurrentDate.ToShortDateString();
    }
    /// <summary>
    /// Возвращает True, если по дате будний день
    /// </summary>
    /// <returns></returns>
    public static bool DateIsWorkday()
    {
      return CurrentDate.DayOfWeek != DayOfWeek.Saturday &&
      CurrentDate.DayOfWeek != DayOfWeek.Sunday;
    }
  }
}
