using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASPAP.constrains;

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
                Road.getRoad().TRAFFICLIGHTS.AddLast(new TrafficLight((int) redLightNumericUpDown.Value, (int) greenLightNumericUpDown.Value));// добавление наверное в другом месте. а моет и вообще контроллеры реализовывать(
            }
            else
            {
                TrafficLight tl = Road.getRoad().TRAFFICLIGHTS.Last.Value;
                tl.GREENLIGHTTIME = (int)greenLightNumericUpDown.Value;
                tl.REDLIGHTTIME = (int) redLightNumericUpDown.Value;
            }
            this.Close();
        }

        private void SetTrafficLightForm_Load(object sender, EventArgs e)
        {
            greenLightNumericUpDown.Minimum = ConstrainsHolder.getConstrainsHolder().MINGREENLIGHTTIME;
            greenLightNumericUpDown.Value = greenLightNumericUpDown.Minimum;
            greenLightNumericUpDown.Maximum = ConstrainsHolder.getConstrainsHolder().MAXGREENLIGHTTIME;
            redLightNumericUpDown.Minimum = ConstrainsHolder.getConstrainsHolder().MINREDLIGHTTIME;
            redLightNumericUpDown.Value = redLightNumericUpDown.Minimum;
            redLightNumericUpDown.Maximum = ConstrainsHolder.getConstrainsHolder().MAXREDLIGHTTIME;
        }
    }
}
