using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Yaisp3
{
    class HoveringDrawer : DrawingWrapperTemplate
    {
        double xPos;
        double yPos;
        int width;
        int height;
        Tuple<int, int> CitySize;

        public HoveringDrawer(Tuple<int, int> CitySize, int Width, int Height)
        {
            this.CitySize = CitySize;
            xPos = yPos = 1000;
            width = Width;
            height = Height;
        }

        public void MoveTo(int X, int Y)
        {
            xPos = x1p + (X - I1) * (x2p - x1p) / (I2 - I1);
            yPos = y1p + (Y - J1) * (y2p - y1p) / (J2 - J1);
        }
        
        public override void Draw(Graphics Graphics)
        {
            int ScrX = GetScreenX(xPos - 2.5);
            int LastX = GetScreenX(xPos - 2.5 + 5 * width);

            int ScrY = GetScreenY(yPos - 2.5);
            int LastY = GetScreenY(yPos - 2.5 + 5 * height);

            Graphics.FillRectangle(Brushes.Crimson, 
                ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
        }

        public bool FindPlaceInMatrix(out int Row, out int Col)
        {
            Row = Col = 0;
            int PapX = (int)xPos;
            int PapY = (int)yPos;
            Col = PapX / 5;
            Row = CitySize.Item2 - Math.Abs(PapY / 5) - 1;
            return !(Col >= CitySize.Item1 || Row >= CitySize.Item1 || Row < 0 || Col < 0);
        }
    }
}
