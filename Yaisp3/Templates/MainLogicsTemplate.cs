using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  class MainLogicsTemplate
  {
    protected MapDrawingClass drawingKit;

    /// <summary>
    /// Очищает канвас
    /// </summary>
    protected void ClearImage()
    {
      drawingKit.ClearCanvas();
    }
    /// <summary>
    /// Выгружает все канвасы из памяти
    /// </summary>
    public void DestroyCreator()
    {
      drawingKit.ClearCanvas();
      drawingKit.DrawImage();
      drawingKit.DisposeBitmap();
    }
    /// <summary>
    /// Полная отрисовка изображения на канвас
    /// </summary>
    protected virtual void MainDraw()
    {
      drawingKit.DrawImage();
    }

    //===============================   Доступный интерфейс
    /// <summary>
    /// Двигает изображение из одной точки в другую
    /// </summary>
    /// <param name="XN">Х конечной точки</param>
    /// <param name="YN">Y конечной точки</param>
    /// <param name="XO">Х первичной точки</param>
    /// <param name="YO">Y первичной точки</param>
    public void MoveImage(int XN, int YN, int XO, int YO)
    {
      drawingKit.ClearCanvas();
      drawingKit.Move(XN, YN, XO, YO);
      MainDraw();
    }
    /// <summary>
    /// Восстанавливает изначальный масштаб
    /// </summary>
    public void SetNormalZoom()
    {
      ClearImage();
      drawingKit.SetNormalZoom();
      MainDraw();
    }
    /// <summary>
    /// Увеличение масштаба в точке X, Y
    /// </summary>
    /// <param name="X">Х точки масштаба</param>
    /// <param name="Y">Y точки масштаба</param>
    /// <param name="Delta">Меньше 0 - увеличение, больше - уменьшение</param>
    public void ZoomImage(int X, int Y, int Delta)
    {
      drawingKit.ClearCanvas();
      drawingKit.Zoom(X, Y, Delta);
      MainDraw();
    }
  }
}
