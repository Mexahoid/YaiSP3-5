using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Класс отрисовщика сетки города.
    /// </summary>
    class GridDrawer : DrawingWrapperTemplate
    {
        #region Поля

        /// <summary>
        /// Кортеж ширины и высоты города.
        /// </summary>
        Tuple<int, int> citySize;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор отрисовщика сетки.
        /// </summary>
        /// <param name="Size">Кортеж размеров города.</param>
        public GridDrawer(Tuple<int, int> Size)
        {
            citySize = Size;
        }

        /// <summary>
        /// Отрисовывает сетку города.
        /// </summary>
        /// <param name="Graphics">Канва, на которой производится рисование.</param>
        public override void Draw(Graphics Graphics)
        {
            for (int i = 0; i <= citySize.Item2; i++)
                Graphics.DrawLine(Pens.Black, GetScreenX(0), GetScreenY(i * -5),
                  GetScreenX(citySize.Item1 * 5), GetScreenY(i * -5));
            for (int i = 0; i <= citySize.Item1; i++)
                Graphics.DrawLine(Pens.Black, GetScreenX(i * 5), GetScreenY(0),
                  GetScreenX(i * 5), GetScreenY(citySize.Item2 * -5));
        }

        #endregion
    }
}
