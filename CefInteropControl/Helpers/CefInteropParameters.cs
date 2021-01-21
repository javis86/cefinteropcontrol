using System.Collections.Generic;

namespace CefInteropControl.Helpers
{
    public class CefInteropParameters
    {
        public string Locale { get; set; }
        public ICollection<string> CommandLineParameters { get; set; }
    }
}