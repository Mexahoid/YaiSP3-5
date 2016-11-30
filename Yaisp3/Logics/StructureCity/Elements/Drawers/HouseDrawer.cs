using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    public class HouseDrawer : DrawingWrapperTemplate
    {
        House house;
        int cityHeight;

        public HouseDrawer(House House, int CityHeight)
        {
            house = House;
            cityHeight = CityHeight;
        }

        public override void Draw(Graphics Graphics)
        {
            Tuple<int, int> Position = house.GetPosition();
            Tuple<int, int> Size = house.GetElementSize();
            
            int ScrX = GetScreenX(5 * Position.Item2);
            int LastX = GetScreenX(5 * Position.Item2 + 5 * Size.Item1);

            int ScrY = GetScreenY(-cityHeight * 5 + 5 * Position.Item1);
            int LastY = GetScreenY(-cityHeight * 5 + 5 * Position.Item1 + 5 * Size.Item2);

            Graphics.FillRectangle(Brushes.LightGray, ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
        }
    }
}
