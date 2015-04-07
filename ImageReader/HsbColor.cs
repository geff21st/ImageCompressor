using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageReader
{
    class HsvColor
    {
        public  int    H { get; private set; }
        public  int    S { get;         set; }
        public  int    V { get;         set; }
        public  int    num;

        public HsvColor() : this(0, 0, 0)
        {
        }

        public HsvColor(int h, int s, int v)
        {
            H = h;
            S = s;
            V = v;
        }
        public static HsvColor FromRgb (Color color)
        {
            return FromRgb(color.R, color.G, color.B);
        }
        public static HsvColor FromRgb (int R, int G, int B)
        {
            int max = Math.Max(Math.Max(R, G), B);
            int min = Math.Min(Math.Min(R, G), B);

            int    H = 0;
            int    V;
            int    S;

            if (max == 0)
                S = 0;
            else
                S = (int)((1 - 1.0*min/max)*100 + 0.5);
            
            V = (int)((max/255.0)*100 + 0.5);

            if (max == min)
            {
                H = 0;
            }

            else if (max == R)
            {
                H = (int) (60.0*(1.0*(G - B)/(max - min)));
                if (G < B) H += 360;
            }

            else if (max == G)
                H = (int) (60.0*(1.0*(B - R)/(max - min))) + 120;

            else if (max == B)
                H = (int) (60.0*(1.0*(R - G)/(max - min))) + 240;

            return new HsvColor(H%360, S, V);
        }
        public static Color    ToRgb   (HsvColor hsv)
        {
            return ToRgb(hsv.H, hsv.S, hsv.V);
        }
        public static Color    ToRgb   (int H, int S, int V)
        {
            double R = 0, G = 0, B = 0;
            double s = S/100d;
            double v = V/100d;

            double h_i   = H / 60d;
            int    i     = (int)Math.Floor(h_i);
            double f     = h_i - i;
            
            double v_min = v * (1 - s);
            double v_dec = v * (1 - s * f);
            double v_inc = v * (1 - s * (1 - f));

            if (V <= 0)
            {
                R = G = B = 0;
            }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else switch (i)
            {
                case 0: case 6:
                    R = v;
                    G = v_inc;
                    B = v_min;
                    break;
                case 1: 
                    R = v_dec;
                    G = v;
                    B = v_min;
                    break;
                case 2:
                    R = v_min;
                    G = v;
                    B = v_inc;
                    break;
                case 3:
                    R = v_min;
                    G = v_dec;
                    B = v;
                    break;
                case 4:
                    R = v_inc;
                    G = v_min;
                    B = v;
                    break;
                case 5: case -1:
                    R = v;
                    G = v_min;
                    B = v_dec;
                    break;
            }

            return Color.FromArgb(Clamp(R*255d), 
                                  Clamp(G*255d),
                                  Clamp(B*255d));
        }

        static int Clamp(double a)
        {
            return Clamp((int) a);
        }
        static int Clamp(int a)
        {
            if (a < 0)   return 0;
            if (a > 255) return 255;
            return a;
        }
    }
}
