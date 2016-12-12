using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgencySimulator.Interfaces
{
    public interface IMainDrawer
    {
        void AddDrawer(IDrawable Drawer);

        void DeleteDrawers(Type type);

        void Draw();

        void CheckList();

        void DeleteFirstBillboardDrawer();

        void SetLastDrawer(IDrawable Drawer);

        void SetCanvas(Control Control);

        void CleanDrawers();

        void Move(int MouseX, int MouseY, int OldCoordsX, int OldCoordsY);

        void SetNormalZoom();

        void Zoom(int IX, int IY, int Delta);
    }
}
