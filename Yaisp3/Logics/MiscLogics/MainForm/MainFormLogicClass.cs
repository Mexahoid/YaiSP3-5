using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
  class MainFormLogicClass
  {
    private GraphLogicsClass graphLogics;
    private MapLogicsClass mapLogics;

    /// <summary>
    /// Конструктор для создания инструментария отрисовки города
    /// </summary>
    /// <param name="MapControl"></param>
    public MainFormLogicClass(Control MapControl, Control GraphControl)
    {
      mapLogics = new MapLogicsClass(MapControl);
      graphLogics = new GraphLogicsClass(GraphControl);
    }

    /// <summary>
    /// Двигает изображение из одной точки в другую
    /// </summary>
    /// <param name="MouseX">Х конечной точки</param>
    /// <param name="MouseY">Y конечной точки</param>
    /// <param name="OldCoordsX">Х первичной точки</param>
    /// <param name="OldCoordsY">Y первичной точки</param>
    public void MoveMap(int MouseX, int MouseY, int OldCoordsX, int OldCoordsY)
    {
      mapLogics.MoveImage(MouseX, MouseY, OldCoordsX, OldCoordsY);
    }
    /// <summary>
    /// Восстанавливает изначальный масштаб
    /// </summary>
    public void SetNormalZoomMap()
    {
      mapLogics.SetNormalZoom();
    }
    /// <summary>
    /// Увеличение масштаба в точке Х, Y
    /// </summary>
    /// <param name="IX">X точки масштаба</param>
    /// <param name="IY">Y точки масштаба</param>
    /// <param name="Delta">Меньше 0 - увеличение, больше - уменьшение</param>
    public void ZoomMap(int IX, int IY, int Delta)
    {
      mapLogics.ZoomImage(IX, IY, Delta);
    }
  }
}
