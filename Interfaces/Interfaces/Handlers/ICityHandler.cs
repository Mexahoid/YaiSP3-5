using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator.Interfaces
{
    public interface ICityHandler
    {
        void CreateCity(string Name, int Height, int Width);

        IDrawable CityHousePlace(int X, int Y, int Width, int Height);

        IDrawable CityBillboardPlace(IBillboard Billboard);

        Tuple<int, int> CityGetSize();

        string CityGetName();
    }
}
