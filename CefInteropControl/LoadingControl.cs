using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefInteropControl
{
    public partial class LoadingControl : UserControl
    {
        private Dictionary<string, string> loadingTraduction = new Dictionary<string, string>()
        {
           { "pt",  "Carregando..." },
           { "es",  "Cargando..." },
           { "en",  "Loading..." },
           { "de",  "Wird geladen..." }
        };

        public LoadingControl()
        {
            InitializeComponent();
        }

        private void LoadingControl_Load(object sender, EventArgs e)
        {
        }

        internal void SetLocale(string locale)
        {
            try
            {
                var language = locale.Split('-')[0];
                this.lblLoading.Text = loadingTraduction[language];
            }
            catch (Exception)
            {
                this.lblLoading.Text = loadingTraduction["en"];
            }
        }
    }
}
