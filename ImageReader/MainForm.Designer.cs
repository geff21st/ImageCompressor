namespace ImageReader
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
            this.panel = new System.Windows.Forms.Panel();
            this.av_step_bar = new System.Windows.Forms.TrackBar();
            this.list_panel = new System.Windows.Forms.Panel();
            this.listSortBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imgCompressMode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.av_step_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(456, 456);
            this.panel.TabIndex = 0;
            this.panel.Click += new System.EventHandler(this.panel_Click);
            // 
            // av_step_bar
            // 
            this.av_step_bar.LargeChange = 10;
            this.av_step_bar.Location = new System.Drawing.Point(501, 12);
            this.av_step_bar.Maximum = 256;
            this.av_step_bar.Minimum = 2;
            this.av_step_bar.Name = "av_step_bar";
            this.av_step_bar.Size = new System.Drawing.Size(230, 45);
            this.av_step_bar.TabIndex = 1;
            this.av_step_bar.TickFrequency = 10;
            this.av_step_bar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.av_step_bar.Value = 10;
            this.av_step_bar.Scroll += new System.EventHandler(this.av_step_bar_Scroll);
            // 
            // list_panel
            // 
            this.list_panel.BackColor = System.Drawing.Color.White;
            this.list_panel.Location = new System.Drawing.Point(501, 63);
            this.list_panel.Name = "list_panel";
            this.list_panel.Size = new System.Drawing.Size(230, 405);
            this.list_panel.TabIndex = 3;
            // 
            // listSortBox
            // 
            this.listSortBox.FormattingEnabled = true;
            this.listSortBox.Items.AddRange(new object[] {
            "По частоте",
            "По цветности",
            "По насыщенности",
            "По яркости",
            "По красной составляющей",
            "По зеленой составляющей",
            "По синей составляющей"});
            this.listSortBox.Location = new System.Drawing.Point(777, 446);
            this.listSortBox.Name = "listSortBox";
            this.listSortBox.Size = new System.Drawing.Size(181, 21);
            this.listSortBox.TabIndex = 6;
            this.listSortBox.SelectedIndexChanged += new System.EventHandler(this.listSortBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(777, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Сортировка списка:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(774, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Режим уменьшения цветов:";
            // 
            // imgCompressMode
            // 
            this.imgCompressMode.FormattingEnabled = true;
            this.imgCompressMode.Items.AddRange(new object[] {
            "Среднее арифметическое",
            "Первый пиксель",
            "Округление цветов",
            "Округление с учётом значения"});
            this.imgCompressMode.Location = new System.Drawing.Point(774, 31);
            this.imgCompressMode.Name = "imgCompressMode";
            this.imgCompressMode.Size = new System.Drawing.Size(181, 21);
            this.imgCompressMode.TabIndex = 8;
            this.imgCompressMode.SelectedIndexChanged += new System.EventHandler(this.imgCompressMode_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 488);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imgCompressMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listSortBox);
            this.Controls.Add(this.list_panel);
            this.Controls.Add(this.av_step_bar);
            this.Controls.Add(this.panel);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.av_step_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TrackBar av_step_bar;
        private System.Windows.Forms.Panel list_panel;
        private System.Windows.Forms.ComboBox listSortBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox imgCompressMode;
    }
}

