using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Yaisp3
{
    public class MatrixDrawingWrapper : DrawingWrapperTemplate
    {
        MatrixCoefficients coeffs;

        public MatrixDrawingWrapper(MatrixCoefficients Coeffs)
        {
            coeffs = Coeffs;
        }

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
                    Br = new SolidBrush(Color.FromArgb(255 * matrix[i, j] / 10, 165 * matrix[i, j] / 10, 0));
                    ScrX = GetScreenX(5 * j);
                    LastX = GetScreenX(5 * j + 5);

                    ScrY = GetScreenY(-rows * 5 + 5 * i);
                    LastY = GetScreenY(-rows * 5 + 5 * i + 5);

                    Graphics.FillRectangle(Br, ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
                }
        }
    }
}
