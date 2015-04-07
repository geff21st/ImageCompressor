using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageReader
{
    public partial class MainForm : Form
    {
        private ImgProcessor img_proc;
        public MainForm()
        {
            InitializeComponent();
            //ClientSize = new Size(512, 512);
            Init();
        }

        void Init()
        {
            img_proc = new ImgProcessor(panel, list_panel);
            av_step_bar.Maximum = img_proc.size.Width;
        }

        private void panel_Click(object sender, EventArgs e)
        {
            HsvColor hsv = new HsvColor(10, 20, 30);
            Color    rgb = HsvColor.ToRgb(hsv);
        }

        //private void averg_button_Click(object sender, EventArgs e)
        //{
        //    Text = img_proc.av_dst.ToString();
        //    img_proc.AvrgShow();
        //    img_proc.av_dst+=5;
        //}

        private void av_step_bar_Scroll(object sender, EventArgs e)
        {
            var bar = (TrackBar) sender;
            perform_averg(bar.Value);
        }

        void perform_averg(int av_dst)
        {
            img_proc.AvrgShow(av_dst);
        }

    }
}
