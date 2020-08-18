using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefInteropControl.Helpers
{
    public static class ZoomCalculator
    {
        public static int ZoomLevelToPercentage(double zoomlevel)
        {
            return (int)(zoomlevel * 25.0 + 100.0);
        }

        public static double PercentageToZoomLevel(int percent)
        {
            return (double)(percent - 100) / 25.0;
        }
    }
}
