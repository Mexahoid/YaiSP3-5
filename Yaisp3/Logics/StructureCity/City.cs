using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    public class City
    {
        /// <summary>
        /// Название города
        /// </summary>
        private string cityName;
        /// <summary>
        /// Главная матрица элементов
        /// </summary>
        private Matrices.MatrixElements cityMatrix;

        /// <summary>
        /// Главный конструктор города
        /// </summary>
        /// <param name="Name">Название города</param>
        /// <param name="Width">Ширина города</param>
        /// <param name="Height">Высота города</param>
        public City(string Name, int Width, int Height)
        {
            cityMatrix = new Matrices.MatrixElements(Height, Width);
            cityName = Name;
        }

        /// <summary>
        /// Возвращает название города
        /// </summary>
        /// <returns>Возвращает строку с названием города</returns>
        public string GetName()
        {
            return cityName;
        }

        public void PlaceHouse(int Row, int Col, int RightWidth, int DownDepth)
        {
            cityMatrix.PlaceHouse(Row, Col, RightWidth, DownDepth);
        }

        /// <summary>
        /// Возвращает массив с элементами, заполненными определённым цветом
        /// </summary>
        /// <returns>Возвращает массив цветов</returns>
        public System.Drawing.Color[,] GetDrawingData()
        {
            return cityMatrix.GetDrawingData();
        }

        /// <summary>
        /// Возвращает массив из значения строки и столбца места с минимальным коэффициентом
        /// </summary>
        /// <returns>Возвращает массив целочисленных значений</returns>
        public int[] GetFreeSpace()
        {
            return cityMatrixProximity.GetRandomFreeSpace();
        }
        
    }
}
