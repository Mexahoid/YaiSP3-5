using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
  public partial class _FormCity : Form
  {
    bool moving = false;
    bool drawing = false;
    bool loaded = true;
    MouseEventArgs e0;
    CityCreatorLogicsClass CityCreationKit;
    public _FormCity()
    {
      InitializeComponent();
      MouseWheel += new MouseEventHandler(_ctrlPicBxMap_MouseScroll);
    }
    private void _ctrlPicBxMap_MouseScroll(object sender, MouseEventArgs e)
    {
      if (CityCreationKit != null)
        CityCreationKit.ZoomImage(e.X, e.Y, e.Delta);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      CityCreationKit = new CityCreatorLogicsClass((int)(_ctrlNumCityWidth.Value), (int)(_ctrlNumCityHeight.Value), _ctrlTxbCityName.Text, _ctrlPicBxCity);
    }

    private void _ctrlPicBxCity_MouseDown(object sender, MouseEventArgs e)
    {
      if (CityCreationKit != null)
      {
        if (e.Button == MouseButtons.Right)
        {
          moving = true;
          e0 = e;
        }
        if (e.Button == MouseButtons.Left && drawing)
        {
          CityCreationKit.AddElementToMatrix(e.X, e.Y, (int)(_ctrlNumHouseWidth.Value), (int)(_ctrlNumHouseHeigth.Value));
          drawing = false;
        }
      }
    }
    private void _ctrlPicBxCity_MouseUp(object sender, MouseEventArgs e)
    {
      moving = false;
    }
    private void _ctrlPicBxCity_MouseMove(object sender, MouseEventArgs e)
    {
      if (CityCreationKit != null)
      {
        if (moving)
        {
          CityCreationKit.MoveImage(e.X, e.Y, e0.X, e0.Y);
          e0 = e;
        }
        if (drawing)
          CityCreationKit.DrawCurrentObject(e.X, e.Y, (int)_ctrlNumHouseWidth.Value, (int)_ctrlNumHouseHeigth.Value);
      }
    }

    private void _ctrlButHouse_Click(object sender, EventArgs e)
    {
      drawing = true;
    }

    private void _ctrlReset_Click(object sender, EventArgs e)
    {
      CityCreationKit.DestroyCreator();
    }

    private void _ctrlButReady_Click(object sender, EventArgs e)
    {
      CityCreationKit.CreateCity();
      CityCreationKit.DestroyCreator();
      CityCreationKit = null;
      bool a = MainUnitProcessor.CityIsPresent();
      loaded = false;
      Close();
    }

    private void _FormCity_Load(object sender, EventArgs e)
    {
      if (MainUnitProcessor.CityIsPresent())
        if (!loaded)
        {
          CityCreationKit = new CityCreatorLogicsClass(_ctrlPicBxCity);
          loaded = true;
        }
    }
  }
}
