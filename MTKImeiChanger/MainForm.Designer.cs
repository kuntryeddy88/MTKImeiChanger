namespace MTKImeiChanger
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.imei1Field = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.isDualSim = new MaterialSkin.Controls.MaterialCheckBox();
            this.imei2Field = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label2 = new System.Windows.Forms.Label();
            this.secondImeiPanel = new System.Windows.Forms.Panel();
            this.button1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.secondImeiPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IMEI1";
            // 
            // textBox1
            // 
            this.imei1Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.imei1Field.Depth = 0;
            this.imei1Field.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.imei1Field.Hint = "";
            this.imei1Field.Location = new System.Drawing.Point(54, 30);
            this.imei1Field.MouseState = MaterialSkin.MouseState.HOVER;
            this.imei1Field.Name = "textBox1";
            this.imei1Field.PasswordChar = '\0';
            this.imei1Field.SelectedText = "";
            this.imei1Field.SelectionLength = 0;
            this.imei1Field.SelectionStart = 0;
            this.imei1Field.Size = new System.Drawing.Size(229, 23);
            this.imei1Field.TabIndex = 1;
            this.imei1Field.TabStop = false;
            this.imei1Field.UseSystemPasswordChar = false;
            this.imei1Field.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKeyPress);
            // 
            // checkBox1
            // 
            this.isDualSim.AutoSize = true;
            this.isDualSim.Depth = 0;
            this.isDualSim.Font = new System.Drawing.Font("Roboto", 10F);
            this.isDualSim.Location = new System.Drawing.Point(48, 56);
            this.isDualSim.Margin = new System.Windows.Forms.Padding(0);
            this.isDualSim.MouseLocation = new System.Drawing.Point(-1, -1);
            this.isDualSim.MouseState = MaterialSkin.MouseState.HOVER;
            this.isDualSim.Name = "checkBox1";
            this.isDualSim.Ripple = true;
            this.isDualSim.Size = new System.Drawing.Size(234, 30);
            this.isDualSim.TabIndex = 2;
            this.isDualSim.Text = "My device has two sim card slots";
            this.isDualSim.UseVisualStyleBackColor = true;
            this.isDualSim.CheckedChanged += new System.EventHandler(this.dualSimChecked);
            // 
            // textBox2
            // 
            this.imei2Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.imei2Field.Depth = 0;
            this.imei2Field.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.imei2Field.Hint = "";
            this.imei2Field.Location = new System.Drawing.Point(38, 4);
            this.imei2Field.MouseState = MaterialSkin.MouseState.HOVER;
            this.imei2Field.Name = "textBox2";
            this.imei2Field.PasswordChar = '\0';
            this.imei2Field.SelectedText = "";
            this.imei2Field.SelectionLength = 0;
            this.imei2Field.SelectionStart = 0;
            this.imei2Field.Size = new System.Drawing.Size(229, 23);
            this.imei2Field.TabIndex = 4;
            this.imei2Field.TabStop = false;
            this.imei2Field.UseSystemPasswordChar = false;
            this.imei2Field.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "IMEI2";
            // 
            // panel1
            // 
            this.secondImeiPanel.Controls.Add(this.imei2Field);
            this.secondImeiPanel.Controls.Add(this.label2);
            this.secondImeiPanel.Location = new System.Drawing.Point(16, 89);
            this.secondImeiPanel.Name = "panel1";
            this.secondImeiPanel.Size = new System.Drawing.Size(292, 30);
            this.secondImeiPanel.TabIndex = 5;
            this.secondImeiPanel.Visible = false;
            // 
            // button1
            // 
            this.button1.Depth = 0;
            this.button1.Location = new System.Drawing.Point(314, 89);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.Primary = true;
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Write!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DoWorkClicked);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 235);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(433, 147);
            this.listBox1.TabIndex = 7;
            // 
            // panel2
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.imei1Field);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.button1);
            this.mainPanel.Controls.Add(this.isDualSim);
            this.mainPanel.Controls.Add(this.secondImeiPanel);
            this.mainPanel.Location = new System.Drawing.Point(12, 74);
            this.mainPanel.Name = "panel2";
            this.mainPanel.Size = new System.Drawing.Size(433, 130);
            this.mainPanel.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Designed for Lenovo A806, but may works on other MTK devices.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Written by leszczu8023";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(385, 385);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(60, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "My website";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(12, 210);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(433, 26);
            this.panel3.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Console";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(342, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 24);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clean";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 408);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTK IMEI Changer";
            this.Load += new System.EventHandler(this.formLoad);
            this.secondImeiPanel.ResumeLayout(false);
            this.secondImeiPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialSingleLineTextField imei1Field;
        private MaterialSkin.Controls.MaterialCheckBox isDualSim;
        private MaterialSkin.Controls.MaterialSingleLineTextField imei2Field;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel secondImeiPanel;
        private MaterialSkin.Controls.MaterialRaisedButton button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
    }
}

