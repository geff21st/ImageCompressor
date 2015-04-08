using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ImageReader
{
    class ImgProcessor
    {
        private int exp = 8;

        private Bitmap      bmp; 
        private Color[,]    colors;
        private Color[,]    tmp_colors;
        public  Size        size;
        private Size        tmp_size;

        private int[]  hist;
        private List<HsvColor> hsvColors; 

        private Control     panel;
        private Control     list_panel;
        
        private BufferedGraphics            bg;
        private BufferedGraphicsContext     bc;
        private BufferedGraphics            lg;
        private BufferedGraphicsContext     lc;

        private int cell = 50;
        Size area = new Size(25,25);
        public int av_dst = 2;

        public ImgProcessor(Control panel, Control list_panel)
        {
            this.panel      = panel;
            this.list_panel = list_panel;
            Init();
            ReadImage();
            //AvrgImage();
            ShowImage();
        }

        void Init()
        {
            bc                          = BufferedGraphicsManager.Current;
            bc.MaximumBuffer            = panel.Size;
            bg                          = bc.Allocate(panel.CreateGraphics(), 
                                            new Rectangle(Point.Empty, panel.Size));

            lc                          = BufferedGraphicsManager.Current;
            lc.MaximumBuffer            = list_panel.Size;
            lg                          = lc.Allocate(list_panel.CreateGraphics(), 
                                            new Rectangle(Point.Empty, list_panel.Size));

            bg.Graphics.SmoothingMode   = SmoothingMode.HighSpeed;
            lg.Graphics.SmoothingMode   = SmoothingMode.HighSpeed;
            hsvColors = new List<HsvColor>();
            hist      = new int[360];
        }

        void ReadImage()
        {
            bmp = new Bitmap("1.bmp");
            size = bmp.Size;
            colors = new Color[size.Width, size.Height];
            tmp_colors = new Color[size.Width, size.Height];

            for (int y = 0; y < size.Height; y++)
            {
                for (int x = 0; x < size.Width; x++)
                {
                    colors[x, y] = bmp.GetPixel(x, y);
                }
            }
        }

        void AvrgImage()
        {
            AvrgImage(av_dst);
        }
        void AvrgImage(int av_dst, int action = 0)
        {
            int h;

            hsvColors.Clear();

            tmp_size         = new Size(size.Width/av_dst,size.Height/av_dst);
            tmp_size.Width  += size.Width%av_dst  == 0 ? 0 : 1;
            tmp_size.Height += size.Height%av_dst == 0 ? 0 : 1;
            //tmp_colors       = new Color[tmp_size.Width,tmp_size.Height];

            for (int y = 0; y < tmp_size.Height; y++)
            {
                for (int x = 0; x < tmp_size.Width; x++)
                {
                    switch (action)
                    {
                        case 0:
                            tmp_colors[x,y] = AvrgPixels(x, y, av_dst);
                            break;
                        case 1:
                            tmp_colors[x, y] = PixelsByFirst(x, y, av_dst);
                            break;
                    }
                  
                    hsvColors.Add(HsvColor.FromRgb(tmp_colors[x,y]));
                    h = hsvColors.Last().H;
                    hist[h]++;
                }
            }

            hsvColors.Clear();

            for (int i = 1; i < hist.Length - 1; i++)
            {
                if (hist[i] - hist[i - 1] >= 1 &&
                    hist[i] - hist[i + 1] >= 1)
                    hsvColors.Add(ColorByHue(i, hist[i]));
            }

          

            for (int i = 0; i < hist.Length; i++)
            {
                hist[i] = 0;
            }
        }

        void CompressImg(int exp, bool key)
        {
            tmp_size = size;
            for (int y = 0; y < tmp_size.Height; y++)
            {
                for (int x = 0; x < tmp_size.Width; x++)
                {
                    tmp_colors[x, y] = CompressPixel(exp, colors[x, y], key);
                }
            }
        }

        Color CompressPixel(int exp, Color color, bool key)
        {
            int d = key ? exp/2 : 0;
            return Color.FromArgb(
                color.R - (color.R - d) % exp,
                color.G - (color.G - d) % exp,
                color.B - (color.B - d) % exp
                );
        }

        HsvColor ColorByHue(int H, int num)
        {
            HsvColor hsv;
            
            for (int y = 0; y < tmp_size.Height; y++)
            {
                for (int x = 0; x < tmp_size.Width; x++)
                {
                    hsv = HsvColor.FromRgb(tmp_colors[x, y]);

                    if (hsv.H == H)
                    {
                        hsv.num = num;
                        return hsv;
                    }
                }
            }

            return new HsvColor();
        }

        Color AvrgPixels(int x, int y, int av_dst)
        {
            int r=0, g=0, b=0;

            for (int j = y * av_dst; j < y * av_dst + av_dst; j++)
            {
                for (int i = x * av_dst; i < x * av_dst + av_dst; i++)
                {
                    if (j >= size.Height || i >= size.Width) continue;
                    r = (r + colors[i, j].R) / 2;
                    g = (g + colors[i, j].G) / 2;
                    b = (b + colors[i, j].B) / 2;
                }
            }
            //int j = y*av_dst;
            //int i = x*av_dst;
            //r = colors[i, j].R;
            //g = colors[i, j].G;
            //b = colors[i, j].B;

            return Color.FromArgb(r, g, b);
        }

        Color PixelsByFirst(int x, int y, int av_dst)
        {
            int r = 0, g = 0, b = 0;

            int j = y * av_dst;
            int i = x * av_dst;
            r = colors[i, j].R;
            g = colors[i, j].G;
            b = colors[i, j].B;

            return Color.FromArgb(r, g, b);
        }

        Color PixelsByFreq(int x, int y, int av_dst)
        {
            int r = 0, g = 0, b = 0;

            for (int j = y * av_dst; j < y * av_dst + av_dst; j++)
            {
                for (int i = x * av_dst; i < x * av_dst + av_dst; i++)
                {
                    
                }
            }

            return Color.FromArgb(r, g, b);
        }

        void ShowImage()
        {
            SizeF pix_sz = new SizeF(
                                (float)panel.Width /tmp_size.Width,
                                (float)panel.Height/tmp_size.Height);
            //bg.Graphics.FillRectangle(Brushes.White, 0, 0, panel.Width, panel.Height);
            for (int y = 0; y < tmp_size.Height; y++)
            {
                for (int x = 0; x < tmp_size.Width; x++)
                {
                    bg.Graphics.FillRectangle(new SolidBrush(tmp_colors[x,y]), 
                                              x*pix_sz.Width, y*pix_sz.Height,
                                                pix_sz.Width,   pix_sz.Height);
                }
            }
            bg.Render();
        }

        void ShowList()
        {
            Color myColor;
            SizeF size = new SizeF (list_panel.Width,
                                    (float)1.0*list_panel.Height/hsvColors.Count);

            //SortList();

            for (int i = 0; i < hsvColors.Count; i++)
            {
                //hsvColors[i].V = 80;
                //hsvColors[i].S = 80;
                myColor = HsvColor.ToRgb(hsvColors[i]);
                lg.Graphics.FillRectangle (new SolidBrush(myColor), 
                                           new RectangleF(new PointF(0,size.Height*i), size));
            }
            lg.Render();
        }

        public void SortList(int mode = 0)
        {
            switch (mode)
            {
                case 0:  hsvColors.Sort((a, b) => a.num.CompareTo(b.num));  break;
                case 1:  hsvColors.Sort((a, b) => a.H.CompareTo(b.H));    break;
                case 2:  hsvColors.Sort((a, b) => a.S.CompareTo(b.S));    break;
                case 3:  hsvColors.Sort((a, b) => a.V.CompareTo(b.V));    break;

                case 4:  hsvColors.Sort((a, b) =>
                         HsvColor.ToRgb(a).R.CompareTo(HsvColor.ToRgb(b).R));  
                         break;

                case 5:  hsvColors.Sort((a, b) =>
                         HsvColor.ToRgb(a).G.CompareTo(HsvColor.ToRgb(b).G));  
                         break;

                case 6:  hsvColors.Sort((a, b) =>
                         HsvColor.ToRgb(a).B.CompareTo(HsvColor.ToRgb(b).B));  
                         break;
            }
            
            //hsvColors.Sort((a,b) => a.H.CompareTo(b.H));
            ShowList();
        }

        public void AvrgShow()
        {
            AvrgShow(2);
        }

        public void FirstPixShow(int av_dst)
        {
            
        }
        public void AvrgShow(int av_dst, int action=0)
        {
            switch (action)
            {
                case 0:
                case 1:
                    AvrgImage(av_dst, action);
                    break;
                case 2:
                    CompressImg(av_dst, false);
                    break;
                case 3:
                    CompressImg(av_dst, true);
                    break;
            }
            
            ShowImage();
            ShowList();
        }
    }
}
