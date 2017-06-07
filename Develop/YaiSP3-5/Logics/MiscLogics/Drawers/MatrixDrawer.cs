using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AgencySimulator
{
    /// <summary>
    /// Класс отрисовщика матрицы коэффициентов.
    /// </summary>
    public class MatrixDrawer : DrawingWrapperTemplate
    {
        #region Поля

        /// <summary>
        /// Матрица коэффициентов.
        /// </summary>
        MatrixCoefficients coeffs;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор отрисовщика матрицы.
        /// </summary>
        /// <param name="Coeffs">Матрица коэффициентов.</param>
        public MatrixDrawer(MatrixCoefficients Coeffs) => coeffs = Coeffs;

        /// <summary>
        /// Отрисовывает матрицу коэффициентов.
        /// </summary>
        /// <param name="Graphics">Канва, на которой производится рисование.</param>
        public override void Draw(Graphics Graphics)
        {
            int[,] matrix = coeffs.GetCoeffMap();
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int ScrX, ScrY, LastX, LastY;
            SolidBrush Br;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 1000)
                        Br = new SolidBrush(Color.Red);
                    else
                        Br = new SolidBrush(Color.FromArgb(255 * matrix[i, j] / 10, 165 * matrix[i, j] / 10, 0));
                    ScrX = GetScreenX(5 * j);
                    LastX = GetScreenX(5 * j + 5);

                    ScrY = GetScreenY(-rows * 5 + 5 * i);
                    LastY = GetScreenY(-rows * 5 + 5 * i + 5);

                    Graphics.FillRectangle(Br, ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
                }
        }
        
        #endregion
    }
}
