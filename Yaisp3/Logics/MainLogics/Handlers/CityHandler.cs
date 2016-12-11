using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Обработчик города.
    /// </summary>
    public class CityHandler
    {
        /// <summary>
        /// Экземпляр города.
        /// </summary>
        private City City;

        /// <summary>
        /// Создает новый экземпляр города.
        /// </summary>
        /// <param name="Name">Название города.</param>
        /// <param name="Width">Ширина города.</param>
        /// <param name="Height">Высота города.</param>
        public void CreateCity(string Name, int Height, int Width)
        {
            City = new City(Name, Width, Height);
        }

        /// <summary>
        /// Возвращает размеры города.
        /// </summary>
        /// <returns>Возвращает кортеж из двух целочисленных значений.</returns>
        public Tuple<int, int> CityGetSize()
        {
            return City.GetSize();
        }

        /// <summary>
        /// Возвращает название города.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public string CityGetName()
        {
            return City.GetName();
        }

        /// <summary>
        /// Возвращает Тrue, Если город создан и False, Если нет.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool CityIsPresent()
        {
            return City != null;
        }

        /// <summary>
        /// Уничтожает экземпляр города.
        /// </summary>
        public void CityDestroy()
        {
            City = null;
        }
        
        /// <summary>
        /// Устанавливает новый дом.
        /// </summary>
        /// <param name="Row">Строка верхнего левого квадрата дома.</param>
        /// <param name="Col">Столбец верхнего левого квадрата дома.</param>
        /// <param name="Width">Ширина дома.</param>
        /// <param name="Heigth">Высота дома.</param>
        public HouseDrawer CityHousePlace(int X, int Y, int Width, int Height)
        {
            return City.PlaceHouse(X, Y, Width, Height);
        }

        /// <summary>
        /// Возвращает ссылку на отрисовщика установленного биллборда.
        /// </summary>
        /// <param name="Billboard">Устанавливаемый биллборд.</param>
        /// <returns>Возвращает экземпляр отрисовщика биллборда.</returns>
        public BillboardDrawer CityBillboardPlace(Billboard Billboard)
        {
            return City.PlaceBillboard(Billboard);
        }

        /// <summary>
        /// Удаляет биллборды.
        /// </summary>
        public void DeleteBillboards()
        {
            City.DeleteBillboards();
        }

        /// <summary>
        /// Возвращает отрисовщика матрицы.
        /// </summary>
        /// <returns>Возвращает экземпляр отрисовщика матрицы.</returns>
        public MatrixDrawer CityGetCoeffsMap()
        {
            return City.GetProximityDrawer();
        }

        /// <summary>
        /// Возвращает ссылку на город.
        /// </summary>
        /// <returns>Возвращает экземпляр города.</returns>
        public City GetCityLink()
        {
            return City;
        }
    }
}
