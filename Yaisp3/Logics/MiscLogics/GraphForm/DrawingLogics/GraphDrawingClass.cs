﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Yaisp3
{
    /// <summary>
    /// Класс рисования графика роста бюджета.
    /// </summary>
    class GraphDrawingClass : MainDrawingTemplate
    {
        #region Поля

        /// <summary>
        /// Точки на графике.
        /// </summary>
        private List<Tuple<double, double>> graphPoints;

        #endregion

        #region Методы

        /// <summary>
        /// Создает новый экземпляр отрисовщика графика.
        /// </summary>
        /// <param name="Control">Элемент управления, на котором производится рисование.</param>
        /// <param name="graphPoints">Список точек графика.</param>
        public GraphDrawingClass(Control Control, List<Tuple<double, double>> graphPoints)
        {
            x1p = -3; y1p = -10; x2p = 10; y2p = 3;
            x1old = -3; y1old = -10; x2old = 10; y2old = 3;
            CanvasControl = Control.CreateGraphics();
            _CanvasImage = new Bitmap(Control.Width, Control.Height);
            I2 = Control.Width;
            J2 = Control.Height;
            _CanvasLogics = Graphics.FromImage(_CanvasImage);
            this.graphPoints = graphPoints;
        }

        /// <summary>
        /// Рисует график роста бюджета.
        /// </summary>
        public void DrawGraph()
        {
            int L = graphPoints.Count;

            _CanvasLogics.DrawLine(Pens.Red, GetScreenX(0), GetScreenY(-500), GetScreenX(0), GetScreenY(500));
            _CanvasLogics.DrawLine(Pens.Blue, GetScreenX(-500), GetScreenY(0), GetScreenX(500), GetScreenY(0));
            if (L != 0)
            {
                _CanvasLogics.DrawLine(Pens.Green, new Point(GetScreenX(0), GetScreenY(0)),
                  new Point(GetScreenX(graphPoints[0].Item1), GetScreenY(-graphPoints[0].Item2)));
                Pen P;
                for (int i = 1; i < L; i++)
                {
                    P = graphPoints[i - 1].Item2 < graphPoints[i].Item2 ? Pens.Green : Pens.Red;
                    _CanvasLogics.DrawLine(P,
                        new Point(GetScreenX(graphPoints[i - 1].Item1), GetScreenY(-graphPoints[i - 1].Item2)),
                         new Point(GetScreenX(graphPoints[i].Item1), GetScreenY(-graphPoints[i].Item2)));
                }
            }
            DrawImage();
        }

        #endregion
    }
}