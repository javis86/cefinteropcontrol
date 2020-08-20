namespace CefInteropControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Windows.Forms;
    using CefInteropControl.Handlers;
    using CefInteropControl.Helpers;
    using CefSharp;
    using CefSharp.WinForms;

    #region Interfaces

    /// <summary>
    /// This interface is used as the COM Source interface for the InteropUserControl class.
    /// </summary>
    /// <remarks>
    /// <para>The COM source interface allows for use of the COM connection points protocol.</para>
    /// <para>All events that this control needs to expose should be defined in this
    /// interface as VB6 only supports its WithEvents syntax for a single interface.</para>
    /// <para>Each method defined in this interface must match up to an event in the user
    /// control having the same name; the method signatures here must match the signature of
    /// the corresponding event's delegate.</para>
    /// <para>Interface is defined as a dispinterface (IDispatch) because VB6 requires it
    /// for source interfaces.</para>
    /// <para>Each method must be marked with a unique DispId value greater than 0. Without proper
    /// DispIds, raising an event may cause a COMException to be thrown if the VB6 client does not
    /// handle all defined events.</para>
    /// </remarks>
    [Guid(CefUserControl.EventsId), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IInteropUserControlEvents
    {
        [DispId(1)]
        void Click();
        [DispId(2)]
        void DblClick();

        // add additional events visible in VB6

        [DispId(3)]
        void FrameLoadEndEvent();
        [DispId(4)]
        void JavascriptMessageReceivedEvent(string message);
        [DispId(5)]
        void LoadingStateChangedEvent();
        [DispId(6)]
        void BrowserInitializedEvent();
        [DispId(7)]
        void AddressChangedEvent(string address);
        [DispId(8)]
        void AddressChangedWithSpecificKeywordEvent(string address);
    }

    /// <summary>
    /// This is the default interface implemented by the user control, and should
    /// contain all the methods and properties that will be exposed to COM.
    /// </summary>
    [Guid(CefUserControl.InterfaceId)]
    public interface IInteropUserControl
    {
        /// <summary>
        /// Gets or sets a value indicating whether the user control is visible.
        /// </summary>
        [DispId(1)]
        bool Visible { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user control is enabled.
        /// </summary>
        [DispId(2)]
        bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of the user control.
        /// </summary>
        [DispId(3)]
        int ForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets the background color of the user control.
        /// </summary>
        [DispId(4)]
        int BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the background image of the user control.
        /// </summary>
        [DispId(5)]
        Image BackgroundImage { get; set; }

        [DispId(6)]
        int InitialZoomPercentage { get; set; }

        /// <summary>
        /// Forces the control to invalidate its client area and immediately redraw 
        /// itself and any child controls.
        /// </summary>
        [DispId(7)]
        void Refresh();

        // add additional properties and methods visible in VB6
        [DispId(8)]
        void Navigate(string url);

        [DispId(9)]
        void DisposeBrowser();

        [DispId(10)]
        void ExecuteScript(string script);

        [DispId(11)]
        void AddSpecificKeywordForAddressChangedEvent(string keyword);
    }
    #endregion

    [Guid(ClassId), ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IInteropUserControlEvents))]
    public partial class CefUserControl : UserControl, IInteropUserControl
    {
        #region VB6 Interop Code

#if COM_INTEROP_ENABLED

        #region "COM Registration"

        // These  GUIDs provide the COM identity for this class 
        // and its COM interfaces. If you change them, existing 
        // clients will no longer be able to access the class.

        public const string ClassId = "0df2f426-547c-4c33-9e05-6c446c8bb994";
        public const string InterfaceId = "d2ab306d-37ad-41ff-b5d5-eb5150244229";
        public const string EventsId = "e5bd2f05-a854-4211-a41b-598e519dbae8";

        // These routines perform the additional COM registration needed by ActiveX controls
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComRegisterFunction]
        private static void Register(System.Type t)
        {
            ComRegistration.RegisterControl(t);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComUnregisterFunction]
        private static void Unregister(System.Type t)
        {
            ComRegistration.UnregisterControl(t);
        }


        #endregion

        #region "VB6 Events"

        // This section shows some examples of exposing a UserControl's events to VB6.  Typically, you just
        // 1) Declare the event as you want it to be shown in VB6
        // 2) Raise the event in the appropriate UserControl event.
        public delegate void ClickEventHandler();
        public delegate void DblClickEventHandler();
        public new event ClickEventHandler Click; // Event must be marked as new since .NET UserControls have the same name.
        public event DblClickEventHandler DblClick;


        // Specific CefSharp Event Handlers
        public delegate void FrameLoadEndEventHandler();
        public delegate void LoadingStateChangedEventHandler();
        public delegate void JavascriptMessageReceivedEventHandler(string message);
        public delegate void BrowserInitializedEventHandler();
        public delegate void AddressChangedEventHandler(string address);
        public delegate void AddressChangedWithSpecificKeywordHandler(string address);


        public event FrameLoadEndEventHandler FrameLoadEndEvent;
        public event LoadingStateChangedEventHandler LoadingStateChangedEvent;
        public event JavascriptMessageReceivedEventHandler JavascriptMessageReceivedEvent;
        public event BrowserInitializedEventHandler BrowserInitializedEvent;
        public event AddressChangedEventHandler AddressChangedEvent;
        public event AddressChangedWithSpecificKeywordHandler AddressChangedWithSpecificKeywordEvent;

        private void InteropUserControl_Click(object sender, System.EventArgs e)
        {
            if (null != Click)
                Click();
        }

        private void InteropUserControl_DblClick(object sender, System.EventArgs e)
        {
            if (null != DblClick)
                DblClick();
        }


        #endregion

        #region "VB6 Properties"

        // The following are examples of how to expose typical form properties to VB6.  
        // You can also use these as examples on how to add additional properties.

        // Must declare this property as new as it exists in Windows.Forms and is not overridable
        public new bool Visible
        {
            get { return base.Visible; }
            set { base.Visible = value; }
        }

        public new bool Enabled
        {
            get { return base.Enabled; }
            set { base.Enabled = value; }
        }

        public int ForegroundColor
        {
            get
            {
                return ActiveXControlHelpers.GetOleColorFromColor(base.ForeColor);
            }
            set
            {
                base.ForeColor = ActiveXControlHelpers.GetColorFromOleColor(value);
            }
        }

        public int BackgroundColor
        {
            get
            {
                return ActiveXControlHelpers.GetOleColorFromColor(base.BackColor);
            }
            set
            {
                base.BackColor = ActiveXControlHelpers.GetColorFromOleColor(value);
            }
        }

        public override Image BackgroundImage
        {
            get { return null; }
            set
            {
                if (null != value)
                {
                    MessageBox.Show("Setting the background image of an Interop UserControl is not supported, please use a PictureBox instead.", "Information");
                }
                base.BackgroundImage = null;
            }
        }

        private int _initialZoomPercentage = 100;
        public int InitialZoomPercentage { get => this._initialZoomPercentage; set => this._initialZoomPercentage = value; }

        #endregion

        #region "VB6 Methods"

        // Ensures that tabbing across VB6 and .NET controls works as expected
        private void InteropUserControl_LostFocus(object sender, System.EventArgs e)
        {
            ActiveXControlHelpers.HandleFocus(this);
        }

        public CefUserControl()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            this.DoubleClick += (this.InteropUserControl_DblClick);
            base.Click += (this.InteropUserControl_Click);
            this.LostFocus += (InteropUserControl_LostFocus);
            this.ControlAdded += (InteropUserControl_ControlAdded);

            // Raise custom Load event
            this.OnCreateControl();
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {

            const int WM_SETFOCUS = 0x7;
            const int WM_PARENTNOTIFY = 0x210;
            const int WM_DESTROY = 0x2;
            const int WM_LBUTTONDOWN = 0x201;
            const int WM_RBUTTONDOWN = 0x204;

            if (m.Msg == WM_SETFOCUS)
            {
                // Raise Enter event
                this.OnEnter(System.EventArgs.Empty);
            }
            else if (m.Msg == WM_PARENTNOTIFY && (m.WParam.ToInt32() == WM_LBUTTONDOWN || m.WParam.ToInt32() == WM_RBUTTONDOWN))
            {

                if (!this.ContainsFocus)
                {
                    // Raise Enter event
                    this.OnEnter(System.EventArgs.Empty);
                }
            }
            else if (m.Msg == WM_DESTROY && !this.IsDisposed && !this.Disposing)
            {
                // Used to ensure that VB6 will cleanup control properly
                this.Dispose();
            }

            base.WndProc(ref m);
        }



        // This event will hook up the necessary handlers
        private void InteropUserControl_ControlAdded(object sender, ControlEventArgs e)
        {
            ActiveXControlHelpers.WireUpHandlers(e.Control, ValidationHandler);
        }

        // Ensures that the Validating and Validated events fire appropriately
        internal void ValidationHandler(object sender, System.EventArgs e)
        {
            if (this.ContainsFocus) return;

            // Raise Leave event
            this.OnLeave(e);

            if (this.CausesValidation)
            {
                CancelEventArgs validationArgs = new CancelEventArgs();
                this.OnValidating(validationArgs);

                if (validationArgs.Cancel && this.ActiveControl != null)
                    this.ActiveControl.Focus();
                else
                {
                    // Raise Validated event
                    this.OnValidated(e);
                }
            }

        }

        #endregion           

#endif

        #endregion

        // Please enter any new code here, below the Interop code
        private ChromiumWebBrowser chromeBrowser;
        private List<string> addressChangedSpecificKeywords;


        private void CefUserControl_Load(object sender, System.EventArgs e)
        {
            InitializeChromium();
            addressChangedSpecificKeywords = new List<string>();
        }

        public void InitializeChromium()
        {
            // Try-Catch prevent two time or more calls in a not nice way
            try
            {
                CefSettings settings = new CefSettings();
                Cef.Initialize(settings);
            }
            catch (System.Exception)
            {
            }
        }

        public void Navigate(string url)
        {
            if (chromeBrowser == null)
            {
                chromeBrowser = new ChromiumWebBrowser(url, new RequestContext());

                AddHandlers();

                this.Controls.Add(chromeBrowser);
                chromeBrowser.Dock = DockStyle.Fill;
            }
            else
            {
                chromeBrowser.Load(url);
            }

        }

        private void AddHandlers()
        {
            //Wait for the MainFrame to finish loading
            chromeBrowser.FrameLoadEnd += FrameLoadEventHandler;
            //Wait for the page to finish loading (all resources will have been loaded, rendering is likely still happening)
            chromeBrowser.LoadingStateChanged += LoadingStateChangedHandler;
            chromeBrowser.JavascriptMessageReceived += JavascriptMessageReceivedHandler;
            chromeBrowser.IsBrowserInitializedChanged += IsBrowserInitializedChangedHandler;
            chromeBrowser.AddressChanged += AddressChangedHandler;
            
            chromeBrowser.DownloadHandler = new DownloadHandler();
        }

        private void AddressChangedHandler(object sender, AddressChangedEventArgs e)
        {
            AddressChangedEvent(e.Address);
            if (this.addressChangedSpecificKeywords.Where(x => e.Address.Contains(x)).Any())
                AddressChangedWithSpecificKeywordEvent(e.Address);
        }

        private void IsBrowserInitializedChangedHandler(object sender, EventArgs e)
        {
            if (chromeBrowser.IsBrowserInitialized)
                BrowserInitializedEvent();
        }

        private void JavascriptMessageReceivedHandler(object sender, JavascriptMessageReceivedEventArgs e)
        {
            var message = (string)e.Message;
            JavascriptMessageReceivedEvent(message);
        }

        private void LoadingStateChangedHandler(object sender, LoadingStateChangedEventArgs e)
        {
            //Wait for the Page to finish loading
            if (e.IsLoading == false)
            {
                this.chromeBrowser.SetZoomLevel(ZoomCalculator.PercentageToZoomLevel(this._initialZoomPercentage));
                LoadingStateChangedEvent();
            }
        }

        private void FrameLoadEventHandler(object sender, FrameLoadEndEventArgs e)
        {
            //Wait for the MainFrame to finish loading
            if (e.Frame.IsMain)
                FrameLoadEndEvent();
        }

        public void ExecuteScript(string script)
        {
            // Javascript must have CefSharp.PostMessage(string message); to fire JavascriptMessageReceivedCallback
            // You can bind any Javascript event to fire the callback is needed
            chromeBrowser.EvaluateScriptAsync(script);
        }

        public void DisposeBrowser()
        {
            try
            {
                chromeBrowser.Dispose();
            }
            catch (System.Exception)
            {

            }
        }

        public void AddSpecificKeywordForAddressChangedEvent(string keyword)
        {
            this.addressChangedSpecificKeywords.Add(keyword);
        }
    }
}
