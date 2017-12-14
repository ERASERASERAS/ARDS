using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASPAP.forms
{
    public partial class SetTrafficLightForm : Form
    {
        private bool firstTime;
        public SetTrafficLightForm(bool firstTime)
        {
            this.firstTime = firstTime;
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (firstTime)
            {
                Road.getRoad().TRAFFICLIGHTS.AddLast(new TrafficLight(Int32.Parse(redLightTimeTextBox.Text),
                                                        Int32.Parse(greenLightTextBox.Text)));// добавление наверное в другом месте. а моет и вообще контроллеры реализовывать(
            }
            else
            {
                TrafficLight tl = Road.getRoad().TRAFFICLIGHTS.Last.Value;
                tl.GREENLIGHTTIME = Int32.Parse(greenLightTextBox.Text);
                tl.REDLIGHTTIME = Int32.Parse(redLightTimeTextBox.Text);
            }
            this.Close();
        }
    }
}
