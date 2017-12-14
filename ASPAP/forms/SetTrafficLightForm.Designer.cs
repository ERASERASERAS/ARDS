namespace ASPAP.forms
{
    partial class SetTrafficLightForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.redLightTimeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.greenLightTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Время работы красного сигнала";
            // 
            // redLightTimeTextBox
            // 
            this.redLightTimeTextBox.Location = new System.Drawing.Point(15, 25);
            this.redLightTimeTextBox.Name = "redLightTimeTextBox";
            this.redLightTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.redLightTimeTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Время работы зелёного сигнала";
            // 
            // greenLightTextBox
            // 
            this.greenLightTextBox.Location = new System.Drawing.Point(15, 64);
            this.greenLightTextBox.Name = "greenLightTextBox";
            this.greenLightTextBox.Size = new System.Drawing.Size(100, 20);
            this.greenLightTextBox.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(15, 90);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(59, 21);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // SetTrafficLightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 117);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.greenLightTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.redLightTimeTextBox);
            this.Controls.Add(this.label1);
            this.Name = "SetTrafficLightForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SetTrafficLightForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox redLightTimeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox greenLightTextBox;
        private System.Windows.Forms.Button okButton;
    }
}