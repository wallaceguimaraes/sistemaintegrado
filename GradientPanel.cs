using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIntegrado.Util
{
    //Sistem.Out.Println("");

    class GradientPanel : Panel
    {
        public Color ColorTop { get; set; }
        public Color ColorBottom { get; set; }

       
                
        protected override void OnPaint(PaintEventArgs e)
        {
            
           
                //string hx = "#186591";

            this.ColorTop = Color.FromArgb(24, 101, 145);
            //this.ColorTop = Color.FromName("#186591");

            // int x = int.Parse(hx, System.Globalization.NumberStyles.HexNumber);
            // Color cor = ColorTranslator.FromOle(x);
            // this.ColorTop= cor;                


            //string hx2 = "#58a8d5";

            //int x2 = int.Parse(hx2, System.Globalization.NumberStyles.HexNumber);
            //Color cor2 = ColorTranslator.FromOle(x2);
            this.ColorBottom = Color.FromArgb(88, 168, 213);
            //this.ColorBottom = Color.FromName("#58a8d5");        
            
            

            LinearGradientBrush lgb = new
            LinearGradientBrush(this.ClientRectangle, this.ColorTop,
            this.ColorBottom, 90F);
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}
