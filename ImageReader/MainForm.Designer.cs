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
            this.label1 = new System.Windows.Forms.Label();
            this.list_panel = new System.Windows.Forms.Panel();
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
            this.av_step_bar.Location = new System.Drawing.Point(657, 12);
            this.av_step_bar.Maximum = 256;
            this.av_step_bar.Minimum = 2;
            this.av_step_bar.Name = "av_step_bar";
            this.av_step_bar.Size = new System.Drawing.Size(284, 45);
            this.av_step_bar.TabIndex = 1;
            this.av_step_bar.TickFrequency = 10;
            this.av_step_bar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.av_step_bar.Value = 10;
            this.av_step_bar.Scroll += new System.EventHandler(this.av_step_bar_Scroll);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(530, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Шаг усреднения:";
            // 
            // list_panel
            // 
            this.list_panel.BackColor = System.Drawing.Color.White;
            this.list_panel.Location = new System.Drawing.Point(657, 63);
            this.list_panel.Name = "list_panel";
            this.list_panel.Size = new System.Drawing.Size(284, 461);
            this.list_panel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 536);
            this.Controls.Add(this.list_panel);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel list_panel;
    }
}

