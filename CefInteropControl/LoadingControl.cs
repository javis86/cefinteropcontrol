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

            InitializeUiDpi();
        }

        private void InitializeUiDpi()
        {
            float dpiFactor = GetDPIFactor();

            switch (dpiFactor)
            {
                case 96:
                    set96DpiFactorMeasures();
                    break;
                case 120:
                    set120DpiFactorMeasures();
                    break;
                case 144:
                    set144DpiFactorMeasures();
                    break;
                default:
                    set96DpiFactorMeasures();
                    break;
            }

        }

        private void set96DpiFactorMeasures()
        {
            this.loadingCircle.NumberSpoke = 10;
            this.loadingCircle.OuterCircleRadius = 8;
            this.Height = 30;
        }

        private void set120DpiFactorMeasures()
        {
            this.loadingCircle.OuterCircleRadius = 10;
            this.loadingCircle.NumberSpoke = 12;
            this.loadingCircle.Top = 8;
            this.loadingCircle.Left = 0;

            this.lblLoading.Top = 13;
            this.lblLoading.Left = 35;
            this.Height = 28;
        }

        private void set144DpiFactorMeasures()
        {
            this.loadingCircle.OuterCircleRadius = 12;
            this.loadingCircle.NumberSpoke = 14;
            this.loadingCircle.Top = 13;
            this.loadingCircle.Left = 0;

            this.lblLoading.Top = 20;
            this.lblLoading.Left = 40;
            this.Height = 25;
        }

        private float GetDPIFactor()
        {
            float dpiX;
            Graphics graphics = this.CreateGraphics();
            dpiX = graphics.DpiX;
            return dpiX;
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

        private void loadingCircle_Click(object sender, EventArgs e)
        {

        }
    }
}
