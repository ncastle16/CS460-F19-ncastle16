using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS460HW4.Controllers
{
   
    public class InterporlatorController : Controller
    {
        // GET: Interporlator
        public ActionResult Interporlator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Interporlator(string FirstColor, string SecondColor, int? Amount)
        {

            void ColorToHSV(Color color, out double hue, out double saturation, out double value)
            {
                int max = Math.Max(color.R, Math.Max(color.G, color.B));
                int min = Math.Min(color.R, Math.Min(color.G, color.B));

                hue = color.GetHue();
                saturation = (max == 0) ? 0 : 1d - (1d * min / max);
                value = max / 255d;
            }

            Color ColorFromHSV(double hue, double saturation, double value)
            {
                int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
                double f = hue / 60 - Math.Floor(hue / 60);

                value = value * 255;
                int v = Convert.ToInt32(value);
                int p = Convert.ToInt32(value * (1 - saturation));
                int q = Convert.ToInt32(value * (1 - f * saturation));
                int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

                if (hi == 0)
                    return Color.FromArgb(255, v, t, p);
                else if (hi == 1)
                    return Color.FromArgb(255, q, v, p);
                else if (hi == 2)
                    return Color.FromArgb(255, p, v, t);
                else if (hi == 3)
                    return Color.FromArgb(255, p, q, v);
                else if (hi == 4)
                    return Color.FromArgb(255, t, p, v);
                else
                    return Color.FromArgb(255, v, p, q);
            }
            Color F = ColorTranslator.FromHtml(FirstColor);
            Color S = ColorTranslator.FromHtml(SecondColor);
            float FHue = F.GetHue();
            float SHue = S.GetHue();
            float D = (FHue - SHue)/(float)Amount;
            D = Math.Abs(D);
            List<Color> Inter = new List<Color>();

            for(int i = 0; i < Amount; i++)
            {
                Inter.Add();
            }

            ViewBag.test = D;
            ViewBag.FC = F;
            ViewBag.SC = S;
            ViewBag.Amount = Amount;



            return View();
        }
    }
}