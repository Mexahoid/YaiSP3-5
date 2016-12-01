using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Класс матрицы коэффициентов.
    /// </summary>
    public sealed class MatrixCoefficients
    {
        #region Поля

        /// <summary>
        /// Кол-во строк матрицы.
        /// </summary>
        private int rows;

        /// <summary>
        /// Кол-во столбцов матрицы.
        /// </summary>
        private int cols;

        /// <summary>
        /// Сама матрица.
        /// </summary>
        private int[,] matrix;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор, создающий матрицу из нулей.
        /// </summary>
        /// <param name="Rows">Высота матрицы.</param>
        /// <param name="Cols">Ширина матрицы.</param>
        public MatrixCoefficients(int Rows, int Cols)
        {
            rows = Rows;
            cols = Cols;
            matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = 0;
        }

        /// <summary>
        /// Возвращает случайную позицию с минимальным коэффициентом.
        /// </summary>
        /// <returns>Возвращает массив целочисленных значений.</returns>
        public Tuple<int, int> GetRandomFreeSpace()
        {
            int minCoeff = GetCoeff(true);

            List<Tuple<int, int>> FreeSpaces = new List<Tuple<int, int>>();

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] == minCoeff)  //Если находим точку с минимальным коэффициентом...
                        FreeSpaces.Add(Tuple.Create(i, j));     //Добавляем ее в список

            return FreeSpaces[MiscellaneousLogics.MainGetRandomValue(0, FreeSpaces.Count - 1)];
        }

        /// <summary>
        /// Устанавливает биллборд с расчетом коэффициентов.
        /// </summary>
        /// <param name="Row">Ряд матрицы.</param>
        /// <param name="Col">Столбец матрицы.</param>
        public void PlaceBillboard(Tuple<int, int> Position)
        {
            RecursionCoefficients(Position.Item1, Position.Item2, 10);
        }

        /// <summary>
        /// Устанавливает элемент дома с большим числом коэффициента.
        /// </summary>
        /// <param name="Row">Ряд матрицы.</param>
        /// <param name="Col">Столбец матрицы.</param>
        /// <param name="Height">Высота дома.</param>
        /// <param name="Width">Ширина дома.</param>
        public void PlaceCityElement(Tuple<int, int> Position, Tuple<int, int> Size)
        {
            for (int i = Position.Item1; i < Position.Item1 + Size.Item2; i++)
                for (int j = Position.Item2; j < Position.Item2 + Size.Item1; j++)
                    matrix[i, j] = 1000;
        }

        /// <summary>
        /// Возвращает необходимое значение коэффициента.
        /// </summary>
        /// <param name="Min">True - поиск минимального, False - поиск максимального</param>
        /// <returns>Возвращает целочисленное значение.</returns>
        private int GetCoeff(bool Min)
        {
            int neededCoeff = Min ? int.MaxValue : int.MinValue;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (Min)
                    {
                        if (neededCoeff > matrix[i, j])
                            neededCoeff = matrix[i, j];
                    }
                    else
                    {
                        if (matrix[i, j] < 1000 && neededCoeff < matrix[i, j])
                            neededCoeff = matrix[i, j];
                    }
            return neededCoeff;
        }

        /// <summary>
        /// Рекурсивный перерасчет коэффициентов.
        /// </summary>
        /// <param name="Row">Рабочий ряд матрицы.</param>
        /// <param name="Col">Рабочий столбец матрицы.</param>
        /// <param name="Coeff">Добавляемый в ячейку коэффициент.</param>
        /// <param name="Dest">Направление предыдущего хода.</param>
        private void RecursionCoefficients(int Row, int Col, int Coeff)
        {
            if (Row != rows && Row >= 0 && Col != cols && Col >= 0)
            {
                if (Coeff > 0)
                {
                    if (matrix[Row, Col] < Coeff)
                        matrix[Row, Col] = Coeff;
                    RecursionCoefficients(Row - 1, Col, Coeff - 1);
                    RecursionCoefficients(Row, Col - 1, Coeff - 1);
                    RecursionCoefficients(Row + 1, Col, Coeff - 1);
                    RecursionCoefficients(Row, Col + 1, Coeff - 1);

                }
            }
        }

        /// <summary>
        /// Удаляет коэффициенты биллбордов.
        /// </summary>
        public void DeleteBillboardCoefficients()
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] < 1000)
                        matrix[i, j] = 0;
        }

        /// <summary>
        /// Возвращает карту коэффициентов.
        /// </summary>
        /// <returns>Возвращает массив целочисленных значений.</returns>
        public int[,] GetCoeffMap()
        {
            return matrix;
        }

        #endregion
    }
}