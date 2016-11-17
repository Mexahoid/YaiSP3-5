using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    static class Matrices
    {
        internal class Matrix
        {
            protected int rows;
            protected int cols;

            protected object matrix;

            protected Matrix(int Rows, int Cols)
            {
                rows = Rows;
                cols = Cols;
            }
        }
        public class MatrixElements : Matrix
        {
            private int currentHouseGroup;

            /// <summary>
            /// Матрица города для расчетов эпицентров и волн коэффициентов удаления
            /// </summary>
            private MatrixCoefficients cityMatrixProximity;

            public MatrixElements(int Rows, int Cols) : base(Rows, Cols)
            {
                currentHouseGroup = 0;
                matrix = new Element[rows, cols];
                cityMatrixProximity = new MatrixCoefficients(Rows, Cols);
            }

            /// <summary>
            /// Проверяет возможность установки элемента
            /// </summary>
            /// <param name="Row">Х верхней левой точки элемента</param>
            /// <param name="Col">Y верхней левой точки элемента</param>
            /// <param name="RightWidth">Ширина элемента</param>
            /// <param name="DownDepth">Высота (вниз) элемента</param>
            /// <returns></returns>
            private bool TryToPlaceElement(int Row, int Col, int RightWidth, int DownDepth)
            {
                for (int i = Col; i <= RightWidth + Col; i++)
                    for (int j = Row; j <= DownDepth + Row; j++)
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
                                Colors[i, j] = ((Billboard)((Element[,])matrix)[i, j]).GetBillboardColor();
                return Colors;
            }

            /// <summary>
            /// Устанавливает новый дом
            /// </summary>
            /// <param name="Row">Строка верхнего левого квадрата дома</param>
            /// <param name="Col">Столбец верхнего левого квадрата дома</param>
            /// <param name="RightWidth">Ширина дома</param>
            /// <param name="DownDepth">Высота дома</param>
            /// <returns></returns>
            public void PlaceHouse(int Row, int Col, int RightWidth, int DownDepth)
            {
                House NewHouse = new House(++currentHouseGroup, RightWidth, DownDepth);
                if (TryToPlaceElement(Row, Col, RightWidth, DownDepth))
                    for (int i = Col; i <= RightWidth + Col; i++)
                        for (int j = Row; j <= DownDepth + Row; j++)
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
            public void BuildAllBillboardsToEnd()
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (((Element[,])matrix)[i, j] != null &&
                            !((Billboard)((Element[,])matrix)[i, j]).GetBillboardBuildingState())
                            ((Billboard)((Element[,])matrix)[i, j]).BuildBillboardToEnd();
            }

            /// <summary>
            /// Заполняет биллборд заказом клиента
            /// </summary>
            /// <param name="ClientDesire">Кортеж из текста рекламы, цены за аренду и уровня заказчика</param>
            public void FillRandomBillboard(Tuple<string, int, byte> ClientDesire)
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (((Element[,])matrix)[i, j] != null &&
                            ((Billboard)((Element[,])matrix)[i, j]).GetBillboardFillState())
                            ((Billboard)((Element[,])matrix)[i, j]).FillBillboard(ClientDesire);
            }
        }
        public class MatrixCoefficients : Matrix
        {
            /// <summary>
            /// Направления обхода матрицы
            /// </summary>
            enum Destinations
            {
                /// <summary>
                /// Нет движения (начальная точка движения)
                /// </summary>
                None,
                /// <summary>
                /// 
                /// </summary>
                Up,
                /// <summary>
                /// 
                /// </summary>
                Down,
                /// <summary>
                /// 
                /// </summary>
                Left,
                /// <summary>
                /// 
                /// </summary>
                Right
            }

            public int[] GetRandomFreeSpace()
            {
                double minCoeff = double.MaxValue;
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (minCoeff > ((double[,])matrix)[i, j])
                            minCoeff = ((double[,])matrix)[i, j];   //Ищем по всей матрице значение минимального коэффициента

                List<int[]> FreeSpaces = new List<int[]>();

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (((double[,])matrix)[i, j] == minCoeff)  //Если находим точку с минимальным коэффициентом...
                            FreeSpaces.Add(new int[] { i, j });     //Добавляем ее в список

                return FreeSpaces[MainUnitProcessor.GetRandomValue(0, FreeSpaces.Count - 1)];
            }

            /// <summary>
            /// Конструктор, создающий матрицу из нулей
            /// </summary>
            /// <param name="Rows">Высота матрицы</param>
            /// <param name="Cols">Ширина матрицы</param>
            public MatrixCoefficients(int Rows, int Cols) : base(Rows, Cols)
            {
                matrix = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        ((double[,])matrix)[i, j] = 0;
            }

            /// <summary>
            /// Устанавливает биллборд с расчетом коэффициентов
            /// </summary>
            /// <param name="Row">Ряд матрицы</param>
            /// <param name="Col">Столбец матрицы</param>
            public void PlaceBillboard(int Row, int Col)
            {
                RecursionCoefficients(Row, Col, 1, Destinations.None);
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
                 ((double[,])matrix)[Row, Col] = 1000;
            }

            /// <summary>
            /// Рекурсивный перерасчет коэффициентов
            /// </summary>
            /// <param name="Row">Рабочий ряд матрицы</param>
            /// <param name="Col">Рабочий столбец матрицы</param>
            /// <param name="Coeff">Добавляемый в ячейку коэффициент</param>
            /// <param name="Dest">Направление предыдущего хода</param>
            private void RecursionCoefficients(int Row, int Col, double Coeff, Destinations Dest)
            {
                if (Row != rows && Col != cols && Coeff >= 0)
                {
                    ((double[,])matrix)[Row, Col] += Coeff;
                    switch (Dest)
                    {
                        case Destinations.None:
                            RecursionCoefficients(Row - 1, Col, Coeff - 0.1, Destinations.Up);
                            RecursionCoefficients(Row + 1, Col, Coeff - 0.1, Destinations.Down);
                            RecursionCoefficients(Row, Col - 1, Coeff - 0.1, Destinations.Left);
                            RecursionCoefficients(Row, Col + 1, Coeff - 0.1, Destinations.Right);
                            break;
                        case Destinations.Up:
                            RecursionCoefficients(Row - 1, Col, Coeff - 0.1, Destinations.Up);
                            RecursionCoefficients(Row, Col - 1, Coeff - 0.1, Destinations.Left);
                            RecursionCoefficients(Row, Col + 1, Coeff - 0.1, Destinations.Right);
                            break;
                        case Destinations.Down:
                            RecursionCoefficients(Row + 1, Col, Coeff - 0.1, Destinations.Down);
                            RecursionCoefficients(Row, Col - 1, Coeff - 0.1, Destinations.Left);
                            RecursionCoefficients(Row, Col + 1, Coeff - 0.1, Destinations.Right);
                            break;
                        case Destinations.Left:
                            RecursionCoefficients(Row - 1, Col, Coeff - 0.1, Destinations.Up);
                            RecursionCoefficients(Row + 1, Col, Coeff - 0.1, Destinations.Down);
                            RecursionCoefficients(Row, Col - 1, Coeff - 0.1, Destinations.Left);
                            break;
                        case Destinations.Right:
                            RecursionCoefficients(Row - 1, Col, Coeff - 0.1, Destinations.Up);
                            RecursionCoefficients(Row + 1, Col, Coeff - 0.1, Destinations.Down);
                            RecursionCoefficients(Row, Col + 1, Coeff - 0.1, Destinations.Right);
                            break;
                    }
                }
            }
        }
    }
}
