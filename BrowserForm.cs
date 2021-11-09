namespace CustomBrowser
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    using CefSharp;
    using CefSharp.WinForms;

    using CustomBrowser.Controls;
    #endregion

    public partial class BrowserForm : Form
    {
        /// <summary>
        /// Needed for moving window (borderless).
        /// </summary>
        private const int WM_NCLBUTTONDOWN = 0xA1;

        /// <summary>
        /// Needed for moving window (borderless).
        /// </summary>
        private const int HT_CAPTION = 0x2;

        private readonly ChromiumWebBrowser browser;

#if DEBUG
        private const string Build = "Debug";
#else
        private const string Build = "Release";
#endif

        private readonly string title;

        #region Constructor

        public BrowserForm()
        {
            InitializeComponent();

            // The following two lines are to prevent a junior developer from breaking the application while editing the form in design view.
            this.FormBorderStyle = FormBorderStyle.None;
            this.title = $"{this.Text} ({Build})";
            this.Padding = new Padding(5);
            
            
            // Next line included in case we ever add back the standard title bar.
            this.Text = title;
            this.FormCaptionLabel.Text = this.title;
            this.browser = new ChromiumWebBrowser(Properties.Settings.Default.StartUrl);
            this.ToolStripContainer.ContentPanel.Controls.Add(browser);
            this.MainMenuStrip.Renderer = new CustomSystemRenderer(); // Custom styling for "title bar."
            this.SetStyle(ControlStyles.ResizeRedraw, true); // Fixes visual abnormalities while resizing.

            this.browser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
            this.browser.LoadingStateChanged += OnLoadingStateChanged;
            this.browser.ConsoleMessage += OnBrowserConsoleMessage;
            this.browser.StatusMessage += OnBrowserStatusMessage;

            var version = string.Format(
                "Chromium: {0}, CEF: {1}, CefSharp: {2}",
                Cef.ChromiumVersion,
                Cef.CefVersion,
                Cef.CefSharpVersion);

#if NETCOREAPP
            // .NET Core
            var environment = string.Format(
                "Environment: {0}, Runtime: {1}",
                System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString().ToLowerInvariant(),
                System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
#else
            // .NET Framework
            var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            var environment = String.Format("Environment: {0}", bitness);
#endif

            DisplayOutput(string.Format("{0}, {1}", version, environment));
        }

        #endregion

        #region External Functions
        // TODO: Replace Win API call with intrinsic code.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        protected static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // TODO: Replace Win API call with intrinsic code.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        protected static extern bool ReleaseCapture();
        #endregion

        #region Overrides
        /// <summary>
        /// Handles form resizing.
        /// </summary>
        /// <param name="m">The message.</param>
        protected override void WndProc(ref Message m)
        {
            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;

            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;

            const int RESIZE_HANDLE_SIZE = 10;
            bool handled = false;
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>() {
                                                              {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                                                              {HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                                                              {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                                                              {HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE)},
                                                              {HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                                                              {HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                                                              {HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                                                              {HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE) }
                                                          };

                foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
                {
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }

            if (!handled)
                base.WndProc(ref m);
        }
        #endregion

        #region Events

        #region Chromium Stuff
        private void OnIsBrowserInitializedChanged(object sender, EventArgs e)
        {
            var b = ((ChromiumWebBrowser)sender);

            this.InvokeOnUiThreadIfRequired(() => b.Focus());
        }

        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            DisplayOutput(string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message));
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => StatusLabel.Text = args.Value);
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => SetIsLoading(!args.CanReload));
        }
        
        private void DisplayOutput(string output)
        {
            this.InvokeOnUiThreadIfRequired(() => OutputLabel.Text = output);
        }

        private void SetIsLoading(bool isLoading)
        {
            // You would use this subroutine to interact with the UI when a page is loading.
        }
        #endregion

        #region "Toolbar" Handlers
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MaximizeWindowButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void RestoreWindowButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void toolStrip1_DoubleClick(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.WindowState = FormWindowState.Normal;
                    break;
                case FormWindowState.Normal:
                    this.WindowState = FormWindowState.Maximized;
                    break;
            }
        }

        private void BrowserForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.RestoreWindowButton.Visible = true;
                this.MaximizeWindowButton.Visible = false;
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                this.RestoreWindowButton.Visible = false;
                this.MaximizeWindowButton.Visible = true;
            }
        }

        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
        
        #region NotifyIcon Stuff
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.WindowState = FormWindowState.Normal;
                this.Show();
                this.BringToFront();
                this.Activate();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion
    }
}