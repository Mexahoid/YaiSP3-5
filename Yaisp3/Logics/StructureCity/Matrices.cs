using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Класс матриц
    /// </summary>
    static class Matrices
    {
        /// <summary>
        /// Родительский класс матрицы
        /// </summary>
        internal class Matrix
        {
            /// <summary>
            /// Кол-во строк матрицы
            /// </summary>
            protected int rows;
            /// <summary>
            /// Кол-во столбцов матрицы
            /// </summary>
            protected int cols;

            /// <summary>
            /// Сама матрица
            /// </summary>
            protected object matrix;

            /// <summary>
            /// Конструктор матрицы
            /// </summary>
            /// <param name="Rows">Кол-во строк матрицы</param>
            /// <param name="Cols">Кол-во столбцов матрицы</param>
            protected Matrix(int Rows, int Cols)
            {
                rows = Rows;
                cols = Cols;
            }
        }

        /// <summary>
        /// Класс матрицы элементов города
        /// </summary>
        public class MatrixElements : Matrix
        {
            /// <summary>
            /// Нынешняя группа добавляемого дома
            /// </summary>
            private int currentHouseGroup;

            /// <summary>
            /// Матрица города для расчетов эпицентров и волн коэффициентов удаления
            /// </summary>
            private MatrixCoefficients cityMatrixProximity;

            /// <summary>
            /// Конструктор матрицы элементов
            /// </summary>
            /// <param name="Rows">Кол-во строк</param>
            /// <param name="Cols">Кол-во столбцов</param>
            public MatrixElements(int Rows, int Cols)
                : base(Rows, Cols)
            {
                currentHouseGroup = 0;
                matrix = new Element[rows, cols];
                cityMatrixProximity = new MatrixCoefficients(Rows, Cols);
            }

            /// <summary>
            /// Проверяет возможность установки элемента.
            /// </summary>
            /// <param name="Row">Х верхней левой точки элемента</param>
            /// <param name="Col">Y верхней левой точки элемента</param>
            /// <param name="RightWidth">Ширина элемента</param>
            /// <param name="DownDepth">Высота (вниз) элемента</param>
            /// <returns>Возвращает логическое значение</returns>
            private bool TryToPlaceElement(int Row, int Col, int RightWidth, int DownDepth)
            {
                if (Row + DownDepth > rows || Col + RightWidth > cols)
                    return false;
                for (int i = Row; i < DownDepth + Row; i++)
                    for (int j = Col; j < RightWidth + Col; j++)
                        if (((Element[,])matrix)[i, j] != null)
                            return false;
                return true;
            }

            /// <summary>
            /// Возвращает массив с элементами, заполненными определённым цветом
            /// </summary>
            /// <returns>Возвращает массив цветов</returns>
            public System.Drawing.Color[,] GetDrawingData()
            {
                System.Drawing.Color[,] Colors = new System.Drawing.Color[rows, cols];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (((Element[,])matrix)[i, j] != null)
                            if (((Element[,])matrix)[i, j].ReturnType())
                                Colors[i, j] = System.Drawing.Color.Gray;
                            else
                                Colors[i, j] = ((Billboard)((Element[,])matrix)[i, j]).BillboardGetColor();
                return Colors;
            }

            /// <summary>
            /// Устанавливает новый дом
            /// </summary>
            /// <param name="Row">Строка верхнего левого квадрата дома</param>
            /// <param name="Col">Столбец верхнего левого квадрата дома</param>
            /// <param name="RightWidth">Ширина дома</param>
            /// <param name="DownDepth">Высота дома</param>
            public void PlaceHouse(int Row, int Col, int RightWidth, int DownDepth)
            {
                House NewHouse = new House(++currentHouseGroup, RightWidth, DownDepth);
                if (TryToPlaceElement(Row, Col, RightWidth, DownDepth))
                    for (int i = Row; i < DownDepth + Row; i++)
                        for (int j = Col; j < RightWidth + Col; j++)
                        {
                            ((Element[,])matrix)[i, j] = NewHouse;
                            cityMatrixProximity.PlaceCityElement(i, j);
                        }
            }

            /// <summary>
            /// Устанавливает биллборд на случайном месте
            /// </summary>
            /// <param name="Billboard">Соответствующий биллборд</param>
            public void PlaceBillboard(Billboard Billboard)
            {
                int[] Position = cityMatrixProximity.GetRandomFreeSpace();
                ((Element[,])matrix)[Position[0], Position[1]] = Billboard;
                cityMatrixProximity.PlaceBillboard(Position[0], Position[1]);
            }

            /// <summary>
            /// Заканчивает строительство всех недостроенных биллбордов
            /// </summary>
            public int BuildAllBillboardsToEnd()
            {
                int Count = 0;
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (((Element[,])matrix)[i, j] != null &&
                            ((Billboard)((Element[,])matrix)[i, j]).BillboardIsBuilding())
                        {
                            ((Billboard)((Element[,])matrix)[i, j]).BillboardBuildToEnd();
                            Count++;
                        }
                return Count;
            }

            /// <summary>
            /// Заполняет биллборд заказом клиента
            /// </summary>
            /// <param name="ClientDesire">Кортеж из текста рекламы, цены за аренду и уровня заказчика</param>
            public bool FillRandomBillboard(Tuple<string, int, byte> ClientDesire)
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (((Element[,])matrix)[i, j] != null &&
                            ((Billboard)((Element[,])matrix)[i, j]).BillboardIsFilled())
                        {
                            ((Billboard)((Element[,])matrix)[i, j]).BillboardFill(ClientDesire);
                            return true;
                        }
                return false;
            }

            /// <summary>
            /// Возвращает карту коэффициентов
            /// </summary>
            /// <returns></returns>
            public System.Drawing.Color[,] GetCoeffMapColors()
            {
                return cityMatrixProximity.GetCoeffMap();
            }

            /// <summary>
            /// Удаляет все биллборды с карты
            /// </summary>
            public void DeleteBillboards()
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (((Element[,])matrix)[i, j] != null &&
                            ((Element[,])matrix)[i, j].GetType() == typeof(Billboard))
                            ((Element[,])matrix)[i, j] = null;
                cityMatrixProximity.DeleteBillboardCoefficients();
            }
        }

        /// <summary>
        /// Класс матрицы коэффициентов
        /// </summary>
        public class MatrixCoefficients : Matrix
        {
            /// <summary>
            /// Конструктор, создающий матрицу из нулей
            /// </summary>
            /// <param name="Rows">Высота матрицы</param>
            /// <param name="Cols">Ширина матрицы</param>
            public MatrixCoefficients(int Rows, int Cols)
                : base(Rows, Cols)
            {
                matrix = new int[rows, cols];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        ((int[,])matrix)[i, j] = 0;
            }

            /// <summary>
            /// Возвращает случайную позицию с минимальным коэффициентом
            /// </summary>
            /// <returns>Возвращает массив целочисленных значений</returns>
            public int[] GetRandomFreeSpace()
            {
                int minCoeff = GetCoeff(true);

                List<int[]> FreeSpaces = new List<int[]>();

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (((int[,])matrix)[i, j] == minCoeff)  //Если находим точку с минимальным коэффициентом...
                            FreeSpaces.Add(new int[] { i, j });     //Добавляем ее в список

                return FreeSpaces[MainUnitProcessor.GetRandomValue(0, FreeSpaces.Count - 1)];
            }

            /// <summary>
            /// Устанавливает биллборд с расчетом коэффициентов
            /// </summary>
            /// <param name="Row">Ряд матрицы</param>
            /// <param name="Col">Столбец матрицы</param>
            public void PlaceBillboard(int Row, int Col)
            {
                RecursionCoefficients(Row, Col, 10);
            }

            /// <summary>
            /// Устанавливает элемент дома с большим числом коэффициента
            /// </summary>
            /// <param name="Row">Ряд матрицы</param>
            /// <param name="Col">Столбец матрицы</param>
            /// <param name="Height">Высота дома</param>
            /// <param name="Width">Ширина дома</param>
            public void PlaceCityElement(int Row, int Col)
            {
                ((int[,])matrix)[Row, Col] = 1000;
            }

            /// <summary>
            /// Возвращает необходимое значение коэффициента.
            /// </summary>
            /// <param name="Min">True - поиск минимального, False - поиск максимального</param>
            /// <returns></returns>
            private int GetCoeff(bool Min)
            {
                int neededCoeff = Min ? int.MaxValue : int.MinValue;
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (Min)
                        {
                            if (neededCoeff > ((int[,])matrix)[i, j])
                                neededCoeff = ((int[,])matrix)[i, j];
                        }
                        else
                        {
                            if (((int[,])matrix)[i, j] < 1000 && neededCoeff < ((int[,])matrix)[i, j])
                                neededCoeff = ((int[,])matrix)[i, j];
                        }
                return neededCoeff;
            }

            /// <summary>
            /// Рекурсивный перерасчет коэффициентов
            /// </summary>
            /// <param name="Row">Рабочий ряд матрицы</param>
            /// <param name="Col">Рабочий столбец матрицы</param>
            /// <param name="Coeff">Добавляемый в ячейку коэффициент</param>
            /// <param name="Dest">Направление предыдущего хода</param>
            private void RecursionCoefficients(int Row, int Col, int Coeff)
            {
                if (Row != rows && Row >= 0 && Col != cols && Col >= 0)
                {
                    if (Coeff > 0)
                    {
                        if (((int[,])matrix)[Row, Col] < Coeff)
                        {
                            ((int[,])matrix)[Row, Col] = Coeff;
                        }

                        RecursionCoefficients(Row - 1, Col, Coeff - 1);
                        RecursionCoefficients(Row, Col - 1, Coeff - 1);
                        RecursionCoefficients(Row + 1, Col, Coeff - 1);
                        RecursionCoefficients(Row, Col + 1, Coeff - 1);

                    }
                }
            }

            /// <summary>
            /// Удаляет коэффициенты биллбордов
            /// </summary>
            public void DeleteBillboardCoefficients()
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (((int[,])matrix)[i, j] < 1000)
                            ((int[,])matrix)[i, j] = 0;
            }

            /// <summary>
            /// Возвращает карту цветов коэффициентов
            /// </summary>
            /// <returns>Возвращает массив цветов</returns>
            public System.Drawing.Color[,] GetCoeffMap()
            {
                System.Drawing.Color[,] Out = new System.Drawing.Color[rows, cols];
                int MaxCoeff = GetCoeff(false);
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (((int[,])matrix)[i, j] < 1000)
                        {
                            if (((int[,])matrix)[i, j] > 0)
                                Out[i, j] = System.Drawing.Color.FromArgb(
                                    255 * ((int[,])matrix)[i, j] / MaxCoeff,
                                    165 * ((int[,])matrix)[i, j] / MaxCoeff,
                                    0);
                            else
                                Out[i, j] = System.Drawing.Color.Black;
                        }
                        else
                            Out[i, j] = System.Drawing.Color.Red;
                return Out;
            }
        }
    }
}
