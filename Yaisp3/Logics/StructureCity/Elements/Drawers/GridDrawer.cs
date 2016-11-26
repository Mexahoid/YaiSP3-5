using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    class GridDrawer : DrawingWrapperTemplate
    {
        int cityHeight;
        int cityWidth;

        public GridDrawer(int Width, int Height)
        {
            cityHeight = Height;
            cityWidth = Width;
        }
        
        public override void Draw(Graphics Graphics)
        {
            for (int i = 0; i <= cityHeight; i++)
                Graphics.DrawLine(Pens.Black, GetScreenX(0), GetScreenY(i * -5),
                  GetScreenX(cityWidth * 5), GetScreenY(i * -5));
            for (int i = 0; i <= cityWidth; i++)
                Graphics.DrawLine(Pens.Black, GetScreenX(i * 5), GetScreenY(0),
                  GetScreenX(i * 5), GetScreenY(cityHeight * -5));
        }
    }
}
