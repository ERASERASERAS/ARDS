using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASPAP.drawingclasses;

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
            sd.SIGN = new Sign(Int32.Parse(constrainTextBox.Text));
            this.Close();
        }
    }
}
