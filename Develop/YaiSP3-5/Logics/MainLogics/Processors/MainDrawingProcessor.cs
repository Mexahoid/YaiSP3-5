using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AgencySimulator
{
    /// <summary>
    /// Главный класс-отрисовщик.
    /// </summary>
    public class MainDrawingProcessor : IDisposable
    {
        #region Поля

        /// <summary>
        /// Делегат для события перерисовки.
        /// </summary>
        /// <param name="e">Рабочая графика.</param>
        public delegate void DelegateReDraw(PaintEventArgs e);

        /// <summary>
        /// Событие для перерисовки графики.
        /// </summary>
        private event DelegateReDraw EventReDraw;

        /// <summary>
        /// Список рисовальщиков.
        /// </summary>
        private List<IDrawable> Drawers;
        
        /// <summary>
        /// Главный экземпляр графики.
        /// </summary>
        private PaintEventArgs TempCanv;

        /// <summary>
        /// Канва, связанная с изображением.
        /// </summary>
        private Graphics CanvasDrawing;

        /// <summary>
        /// Изображение, которым оперируют рисовальщики.
        /// </summary>
        private Bitmap Bitmap;

        /// <summary>
        /// Координаты изображения окна.
        /// </summary>
        protected int I1 = 0, I2 = 0, J1 = 0, J2 = 0;

        /// <summary>
        /// Координаты сиюминутного видимого куска графика.
        /// </summary>
        protected double x1p = -10, y1p = -100, x2p = 100, y2p = 10;

        /// <summary>
        /// Координаты изначального видимого куска графика.
        /// </summary>
        protected const double x1old = -10, y1old = -100, x2old = 100, y2old = 10;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор процессора рисовальщиков.
        /// </summary>
        public MainDrawingProcessor() => Drawers = new List<IDrawable>();

        /// <summary>
        /// Устанавливает метод, вызываемый при необходимости отрисовки.
        /// </summary>
        /// <param name="Del"></param>
        public void SetRedrawEvent(DelegateReDraw Del) => EventReDraw += Del;

        //VS сказала реализовать интерфейс IDisposable, потому здесь стоит очистка канваса.
        /// <summary>
        /// Очистка битмапа.
        /// </summary>
        public void Dispose() => Bitmap.Dispose();

        /// <summary>
        /// Очистка списка рисовальщиков.
        /// </summary>
        public void CleanDrawers() => Drawers = new List<IDrawable>();

        /// <summary>
        /// Добавляет рисовальщик в лист.
        /// </summary>
        /// <param name="Drawer">Рисовальщик.</param>
        public void AddDrawer(IDrawable Drawer)
        {
            Drawer.SetDims((I2, J2, x1p, y1p, x2p, y2p));
            Drawers.Add(Drawer);
        }

        /// <summary>
        /// Задает канву рисования.
        /// </summary>
        /// <param name="Control">Элемент управления, на котором осуществляется рисование.</param>
        public void SetCanvas(Control Control)
        {
            Bitmap = new Bitmap(Control.Width, Control.Height);
            CanvasDrawing = Graphics.FromImage(Bitmap);
            TempCanv = new PaintEventArgs(Control.CreateGraphics(), Control.ClientRectangle);
            SetNormalZoom();
            I2 = Control.Width;
            J2 = Control.Height;
        }

        /// <summary>
        /// Рисует всеми рисовальщиками на канве.
        /// </summary>
        public void Draw()
        {
            CanvasDrawing.Clear(Color.White);
            int C = Drawers.Count;

            for (int i = C; i > 0; i--)     //Т.к. Grid должен рисоваться последним
            {
                Drawers[i - 1].SetDims((I2, J2, x1p, y1p, x2p, y2p));
                Drawers[i - 1].Draw(CanvasDrawing);
            }
            TempCanv.Graphics.DrawImage(Bitmap, 0, 0);
        }

        /// <summary>
        /// Проверяет все рисовальщики на валидность.
        /// </summary>
        public void CheckList()
        {
            int C = Drawers.Count;

            for (int i = 0; i < C; i++)       //проверка на пустоту
                if (Drawers[i] == null)
                {
                    Drawers.RemoveAt(i--);
                    C--;
                }
        }

        /// <summary>
        /// Удаляет отрисовщики определённого типа.
        /// </summary>
        /// <param name="type">Тип удаляемых отрисовщиков.</param>
        public void DeleteDrawers(Type type)
        {
            int C = Drawers.Count;
            for (int i = 0; i < C; i++)       //проверка на пустоту
                if (Drawers[i].GetType() == type)
                {
                    Drawers.RemoveAt(i--);
                    C--;
                }
        }

        /// <summary>
        /// Удалить первый отрисовщик биллборда.
        /// </summary>
        public void DeleteInvalidBillboardDrawers()
        {
            int C = Drawers.Count;
            for (int i = 0; i < C; i++)       //проверка на пустоту
                if (Drawers[i].GetType() == typeof(BillboardDrawer) &&
                    !((BillboardDrawer)Drawers[i]).IsValid())
                {
                    Drawers.RemoveAt(i--);
                    C--;
                }
            EventReDraw(TempCanv);
        }

        /// <summary>
        /// В общем случае заменяет рисовальщик добавляемого дома реальным домом.
        /// </summary>
        /// <param name="Drawer">Рисовальщик дома.</param>
        public bool SetLastDrawer(CityHandler CityLink, int Width, int Height)
        {
            if ((Drawers[Drawers.Count - 1] as HoveringDrawer).FindPlaceInMatrix(out int Row, out int Col))
            {
                Drawers[Drawers.Count - 1] = CityLink.CityHousePlace(Row, Col, Width, Height);
                CheckList();
                EventReDraw(TempCanv);
                return true;
            }
            else
            {
                EventReDraw(TempCanv);
                return false;
            }
        }

        public void MoveHovering(int X, int Y)
        {
            (Drawers[Drawers.Count - 1] as HoveringDrawer).MoveTo(X, Y);
            EventReDraw(TempCanv);
        }

        //========================== Набор команд линейных преобразований.

        /// <summary>
        /// Превращает Х экрана в Х графика.
        /// </summary>
        /// <param name="I">Х экрана.</param>
        /// <returns>Возвращает вещественное значение.</returns>
        protected double GetGraphX(int I) => x1p + (I - I1) * (x2p - x1p) / (I2 - I1);

        /// <summary>
        /// Превращает Y экрана в Y графика.
        /// </summary>
        /// <param name="J">Y экрана.</param>
        /// <returns>Возвращает вещественное значение.</returns>
        protected double GetGraphY(int J) => y1p + (J - J1) * (y2p - y1p) / (J2 - J1);

        /// <summary>
        /// Двигает изображение из одной точки в другую.
        /// </summary>
        /// <param name="MouseX">Х конечной точки.</param>
        /// <param name="MouseY">Y конечной точки.</param>
        /// <param name="OldCoordsX">Х первичной точки.</param>
        /// <param name="OldCoordsY">Y первичной точки.</param>
        public void Move(int MouseX, int MouseY, int OldCoordsX, int OldCoordsY)
        {
            double dx = GetGraphX(MouseX) - GetGraphX(OldCoordsX);
            double dy = GetGraphY(MouseY) - GetGraphY(OldCoordsY);

            x1p -= dx;
            x2p -= dx;
            y1p -= dy;
            y2p -= dy;
            EventReDraw(TempCanv);
        }

        /// <summary>
        /// Восстанавливает изначальный масштаб.
        /// </summary>
        public void SetNormalZoom()
        {
            x1p = x1old;
            x2p = x2old;
            y1p = y1old;
            y2p = y2old;
            EventReDraw(TempCanv);
        }

        /// <summary>
        /// Увеличение масштаба в точке Х, Y.
        /// </summary>
        /// <param name="IX">X точки масштаба.</param>
        /// <param name="IY">Y точки масштаба.</param>
        /// <param name="Delta">Меньше 0 - увеличение, больше - уменьшение.</param>
        public void Zoom(int IX, int IY, int Delta)
        {
            double x = GetGraphX(IX);
            double y = GetGraphY(IY);
            double coeff = 0;
            if (Delta < 0)
                coeff = 1.03;
            else
                coeff = 0.97;
            x1p = x - (x - x1p) * coeff;  //x1 > x
            x2p = x + (x2p - x) * coeff;
            y1p = y - (y - y1p) * coeff;
            y2p = y + (y2p - y) * coeff;
            EventReDraw(TempCanv);
        }

        #endregion
    }
}
