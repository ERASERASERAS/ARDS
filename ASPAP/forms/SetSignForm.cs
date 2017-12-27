using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASPAP.drawingclasses;
using ASPAP.constrains;

namespace ASPAP.forms
{
    public partial class SetSignForm : Form
    {
        private SignDrawing sd;
        public SetSignForm(SignDrawing sd)
        {
            InitializeComponent();
            this.sd = sd;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            sd.SIGN = new Sign((int) chooseSpeedNumericUpDown.Value);
            this.Close();
        }

        private void SetSignForm_Load(object sender, EventArgs e)
        {
            
            chooseSpeedNumericUpDown.Minimum = ConstrainsHolder.getConstrainsHolder().MINSPEED;
            chooseSpeedNumericUpDown.Value = chooseSpeedNumericUpDown.Minimum;
            chooseSpeedNumericUpDown.Maximum = ConstrainsHolder.getConstrainsHolder().MAXSPEED - 10;
        }
    }
}
