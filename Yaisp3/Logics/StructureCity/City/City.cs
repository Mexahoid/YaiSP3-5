using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Класс города.
    /// </summary>
    public sealed class City
    {
        #region Поля

        /// <summary>
        /// Название города.
        /// </summary>
        private string cityName;

        /// <summary>
        /// Ширина города.
        /// </summary>
        private int cityWidth;

        /// <summary>
        /// Высота города.
        /// </summary>
        private int cityHeight;

        /// <summary>
        /// Список элементов города.
        /// </summary>
        private List<TemplateElement> cityElements;

        /// <summary>
        /// Карта зон покрытия.
        /// </summary>
        private MatrixCoefficients cityMatrixProximity;

        /// <summary>
        /// Последняя группа установленного дома.
        /// </summary>
        private int currentHouseGroup;

        #endregion

        #region Методы

        /// <summary>
        /// Главный конструктор города.
        /// </summary>
        /// <param name="Name">Название города.</param>
        /// <param name="Width">Ширина города.</param>
        /// <param name="Height">Высота города.</param>
        public City(string Name, int Width, int Height)
        {
            cityMatrixProximity = new MatrixCoefficients(Height, Width);
            cityHeight = Height;
            cityWidth = Width;
            cityElements = new List<TemplateElement>();
            cityName = Name;
        }

        #region Обмен информацией

        /// <summary>
        /// Возвращает размер города.
        /// </summary>
        /// <returns>Возвращает кортеж из двух целочисленных значений.</returns>
        public Tuple<int, int> GetSize()
        {
            return Tuple.Create(cityWidth, cityHeight);
        }

        /// <summary>
        /// Возвращает название города.
        /// </summary>
        /// <returns>Возвращает строку с названием города.</returns>
        public string GetName()
        {
            return cityName;
        }

        #endregion

        #region Установка элементов

        /// <summary>
        /// Проверяет возможность установки элемента.
        /// </summary>
        /// <param name="Row">Х верхней левой точки элемента.</param>
        /// <param name="Col">Y верхней левой точки элемента.</param>
        /// <param name="RightWidth">Ширина элемента.</param>
        /// <param name="DownDepth">Высота элемента.</param>
        /// <returns>Возвращает логическое значение.</returns>
        private bool TryToPlaceElement(int Row, int Col, int RightWidth, int DownDepth)
        {
            if (Row + DownDepth > cityHeight || Col + RightWidth > cityWidth)
                return false;
            foreach (TemplateElement el in cityElements)
                if (el.ContainsPosition(Row, Col, RightWidth, DownDepth))
                    return false;
            return true;
        }

        /// <summary>
        /// Устанавливает новый дом.
        /// </summary>
        /// <param name="Row">Строка верхнего левого квадрата дома.</param>
        /// <param name="Col">Столбец верхнего левого квадрата дома.</param>
        /// <param name="RightWidth">Ширина дома.</param>
        /// <param name="DownDepth">Высота дома.</param>
        public void PlaceHouse(int Row, int Col, int RightWidth, int DownDepth)
        {
            if (TryToPlaceElement(Row, Col, RightWidth, DownDepth))
            {
                House NewHouse = new House(++currentHouseGroup, RightWidth, DownDepth);
                NewHouse.SetPosition(Row, Col);
                cityMatrixProximity.PlaceCityElement(Row, Col, RightWidth, DownDepth);
                cityElements.Add(NewHouse);
            }
        }

        /// <summary>
        /// Устанавливает биллборд на случайной локации.
        /// </summary>
        /// <param name="Billboard">Устанавливаемый биллборд.</param>
        public void PlaceBillboard(Billboard Billboard)
        {
            Tuple<int, int> Position = cityMatrixProximity.GetRandomFreeSpace();
            cityMatrixProximity.PlaceBillboard(Position.Item1, Position.Item2);
            Billboard.SetPosition(Position.Item1, Position.Item2);
            cityElements.Add(Billboard);
        }

        #endregion

        /// <summary>
        /// Удаляет все биллборды.
        /// </summary>
        public void DeleteBillboards()
        {
            int L = cityElements.Count;
            for (int i = 0; i < L; i++)
                if (cityElements[i].GetType() == typeof(Billboard))
                {
                    cityElements[i] = null;
                    cityElements.RemoveAt(i);
                    L--;
                    i--;
                }
            cityMatrixProximity.DeleteBillboardCoefficients();
        }
        
        #endregion
    }
}
