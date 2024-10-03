namespace MtGuiController
{
    partial class Form1
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
            this.button_submit = new System.Windows.Forms.Button();
            this.Picker_DateStart = new System.Windows.Forms.DateTimePicker();
            this.Picker_DateEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.b_year = new System.Windows.Forms.Button();
            this.b_month = new System.Windows.Forms.Button();
            this.b_week = new System.Windows.Forms.Button();
            this.b_today = new System.Windows.Forms.Button();
            this.listBox_symbols = new System.Windows.Forms.ListBox();
            this.listBox_magics = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.check_shutdown = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_profit = new System.Windows.Forms.Label();
            this.label_deals = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.check_unclosed = new System.Windows.Forms.CheckBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_submit
            // 
            this.button_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button_submit.Location = new System.Drawing.Point(478, 303);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(104, 29);
            this.button_submit.TabIndex = 0;
            this.button_submit.Text = "Calculate";
            this.button_submit.UseVisualStyleBackColor = true;
            // 
            // Picker_DateStart
            // 
            this.Picker_DateStart.AccessibleDescription = "";
            this.Picker_DateStart.AccessibleName = "";
            this.Picker_DateStart.AllowDrop = true;
            this.Picker_DateStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Picker_DateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Picker_DateStart.Location = new System.Drawing.Point(141, 25);
            this.Picker_DateStart.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.Picker_DateStart.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.Picker_DateStart.Name = "Picker_DateStart";
            this.Picker_DateStart.Size = new System.Drawing.Size(173, 23);
            this.Picker_DateStart.TabIndex = 1;
            this.Picker_DateStart.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.Picker_DateStart.ValueChanged += new System.EventHandler(this.Piсker_DateStart_ValueChanged);
            // 
            // Picker_DateEnd
            // 
            this.Picker_DateEnd.AllowDrop = true;
            this.Picker_DateEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Picker_DateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Picker_DateEnd.Location = new System.Drawing.Point(141, 65);
            this.Picker_DateEnd.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.Picker_DateEnd.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.Picker_DateEnd.Name = "Picker_DateEnd";
            this.Picker_DateEnd.Size = new System.Drawing.Size(173, 23);
            this.Picker_DateEnd.TabIndex = 2;
            this.Picker_DateEnd.Value = new System.DateTime(2024, 12, 31, 23, 59, 0, 0);
            this.Picker_DateEnd.ValueChanged += new System.EventHandler(this.Piсker_DateEnd_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(57, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(62, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(28, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Magic Numbers Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(222, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Symbol Filter";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.b_year);
            this.groupBox.Controls.Add(this.b_month);
            this.groupBox.Controls.Add(this.b_week);
            this.groupBox.Controls.Add(this.b_today);
            this.groupBox.Controls.Add(this.listBox_symbols);
            this.groupBox.Controls.Add(this.listBox_magics);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.Picker_DateEnd);
            this.groupBox.Controls.Add(this.Picker_DateStart);
            this.groupBox.Location = new System.Drawing.Point(16, 21);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(384, 333);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Settings";
            // 
            // b_year
            // 
            this.b_year.BackColor = System.Drawing.Color.Thistle;
            this.b_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.b_year.Location = new System.Drawing.Point(285, 108);
            this.b_year.Name = "b_year";
            this.b_year.Size = new System.Drawing.Size(68, 28);
            this.b_year.TabIndex = 14;
            this.b_year.Text = "Year";
            this.b_year.UseVisualStyleBackColor = false;
            // 
            // b_month
            // 
            this.b_month.BackColor = System.Drawing.Color.Aquamarine;
            this.b_month.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.b_month.Location = new System.Drawing.Point(200, 108);
            this.b_month.Name = "b_month";
            this.b_month.Size = new System.Drawing.Size(68, 28);
            this.b_month.TabIndex = 13;
            this.b_month.Text = "Month";
            this.b_month.UseVisualStyleBackColor = false;
            // 
            // b_week
            // 
            this.b_week.BackColor = System.Drawing.Color.LightGreen;
            this.b_week.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.b_week.Location = new System.Drawing.Point(115, 108);
            this.b_week.Name = "b_week";
            this.b_week.Size = new System.Drawing.Size(68, 28);
            this.b_week.TabIndex = 12;
            this.b_week.Text = "Week";
            this.b_week.UseVisualStyleBackColor = false;
            // 
            // b_today
            // 
            this.b_today.BackColor = System.Drawing.Color.Khaki;
            this.b_today.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.b_today.Location = new System.Drawing.Point(30, 108);
            this.b_today.Name = "b_today";
            this.b_today.Size = new System.Drawing.Size(68, 28);
            this.b_today.TabIndex = 11;
            this.b_today.Text = "Today";
            this.b_today.UseVisualStyleBackColor = false;
            // 
            // listBox_symbols
            // 
            this.listBox_symbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.listBox_symbols.FormattingEnabled = true;
            this.listBox_symbols.ItemHeight = 15;
            this.listBox_symbols.Items.AddRange(new object[] {
            "All",
            "EURUSD",
            "XAUUSD"});
            this.listBox_symbols.Location = new System.Drawing.Point(214, 187);
            this.listBox_symbols.Name = "listBox_symbols";
            this.listBox_symbols.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_symbols.Size = new System.Drawing.Size(105, 124);
            this.listBox_symbols.TabIndex = 10;
            // 
            // listBox_magics
            // 
            this.listBox_magics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.listBox_magics.ItemHeight = 15;
            this.listBox_magics.Items.AddRange(new object[] {
            "All",
            "Empty",
            "More"});
            this.listBox_magics.Location = new System.Drawing.Point(48, 187);
            this.listBox_magics.Name = "listBox_magics";
            this.listBox_magics.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_magics.Size = new System.Drawing.Size(100, 124);
            this.listBox_magics.TabIndex = 9;
            this.listBox_magics.SelectedIndexChanged += new System.EventHandler(this.listBox_magics_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(437, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Calculated Profit:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.Location = new System.Drawing.Point(433, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Number of Deals:";
            // 
            // check_shutdown
            // 
            this.check_shutdown.AutoSize = true;
            this.check_shutdown.Location = new System.Drawing.Point(628, 21);
            this.check_shutdown.Name = "check_shutdown";
            this.check_shutdown.Size = new System.Drawing.Size(15, 14);
            this.check_shutdown.TabIndex = 9;
            this.check_shutdown.UseVisualStyleBackColor = false;
            this.check_shutdown.Visible = false;
            this.check_shutdown.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.textBox1.Location = new System.Drawing.Point(421, 118);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(223, 148);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "chose parameters\r\nand press Calculate";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_profit
            // 
            this.label_profit.AutoSize = true;
            this.label_profit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label_profit.Location = new System.Drawing.Point(558, 59);
            this.label_profit.Name = "label_profit";
            this.label_profit.Size = new System.Drawing.Size(41, 18);
            this.label_profit.TabIndex = 14;
            this.label_profit.Text = "none";
            // 
            // label_deals
            // 
            this.label_deals.AutoSize = true;
            this.label_deals.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label_deals.Location = new System.Drawing.Point(558, 86);
            this.label_deals.Name = "label_deals";
            this.label_deals.Size = new System.Drawing.Size(41, 18);
            this.label_deals.TabIndex = 15;
            this.label_deals.Text = "none";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label7.Location = new System.Drawing.Point(457, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Unclosed Positions";
            this.label7.Visible = false;
            // 
            // check_unclosed
            // 
            this.check_unclosed.AutoSize = true;
            this.check_unclosed.Location = new System.Drawing.Point(438, 276);
            this.check_unclosed.Name = "check_unclosed";
            this.check_unclosed.Size = new System.Drawing.Size(15, 14);
            this.check_unclosed.TabIndex = 17;
            this.check_unclosed.UseVisualStyleBackColor = true;
            this.check_unclosed.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 376);
            this.Controls.Add(this.check_unclosed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_deals);
            this.Controls.Add(this.label_profit);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.check_shutdown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.groupBox);
            this.Name = "Form1";
            this.Text = "Profit Calculator";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.DateTimePicker Picker_DateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox check_shutdown;
        public System.Windows.Forms.DateTimePicker Picker_DateStart;
        private System.Windows.Forms.ListBox listBox_symbols;
        private System.Windows.Forms.ListBox listBox_magics;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_profit;
        private System.Windows.Forms.Label label_deals;
        private System.Windows.Forms.Button b_year;
        private System.Windows.Forms.Button b_month;
        private System.Windows.Forms.Button b_week;
        private System.Windows.Forms.Button b_today;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox check_unclosed;
    }
}