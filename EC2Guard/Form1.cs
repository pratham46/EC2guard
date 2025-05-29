using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Win32;

namespace OTPVerificationApp
{
    public partial class MainForm : Form
    {

        private string generatedOTP;
        private System.Windows.Forms.Timer reverifyTimer;
        private bool otpVerified = false;

        [DllImport("user32.dll")]
        private static extern bool BlockInput(bool fBlockIt);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        private const int SC_CLOSE = 0xF060;
        private const int MF_ENABLED = 0x00000000;
        private const int MF_GRAYED = 0x00000001;

        public MainForm()
        {
            InitializeComponent();
            InitializeForm();
            // Initialize Timer
            reverifyTimer = new System.Windows.Forms.Timer();
            reverifyTimer.Interval = 30 * 60 * 1000;
            reverifyTimer.Tick += ReverifyTimer_Tick;

            DisableCloseButton();

            DisableMinimizeButton();

            TopMost = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!IsAppSetToRunOnStartup())
            {
                SetAppToRunOnStartup();
            }

            reverifyTimer.Start();

            BlockInput(true);
        }

        private void InitializeForm()
        { 
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            this.TopMost = true;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point((screenWidth - this.Width) / 2, (screenHeight - this.Height) / 2);
        }

        private void DisableCloseButton()
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            EnableMenuItem(hMenu, SC_CLOSE, MF_GRAYED);
        }

        private void EnableCloseButton()
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            EnableMenuItem(hMenu, SC_CLOSE, MF_ENABLED);
        }

        private void DisableMinimizeButton()
        {
            this.MinimizeBox = false;
        }

        private void ReverifyTimer_Tick(object sender, EventArgs e)
        {
            reverifyTimer.Stop();

            generatedOTP = GenerateOTP();
            txtOTP.Clear();
            txtPhoneNumber.Clear();

            Show();
            WindowState = FormWindowState.Normal;

            BlockInput(true);

            DisableCloseButton();

            DisableMinimizeButton();

            TopMost = true;
        }


        private bool IsAppSetToRunOnStartup()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string appName = Application.ProductName;
            string exePath = Application.ExecutablePath;
            object existingValue = regKey.GetValue(appName);

            if (existingValue != null && existingValue.ToString() == exePath)
            {
                return true;
            }
            return false;
        }

        private void SetAppToRunOnStartup()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string appName = Application.ProductName;
            string exePath = Application.ExecutablePath;
            regKey.SetValue(appName, exePath);
        }

        private void btnGenerateOTP_Click(object sender, EventArgs e)
        {
            generatedOTP = GenerateOTP();

            SendOTPviaSNS(generatedOTP, txtPhoneNumber.Text);
            btnGenerateOTP.Enabled = false;
            btnVerifyOTP.Enabled = true;
            otpVerified = false;
            DisableCloseButton();
            DisableMinimizeButton();
            TopMost = true;
        }

        private void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            string enteredOTP = txtOTP.Text;
            if (enteredOTP == generatedOTP)
            {
                MessageBox.Show("OTP verification successful!");
                otpVerified = true;
                btnGenerateOTP.Enabled = true;
                btnVerifyOTP.Enabled = false;
                txtOTP.Clear();
                txtPhoneNumber.Clear();
                Hide();
                reverifyTimer.Start();
                BlockInput(false);
                EnableCloseButton();
                DisableMinimizeButton();
                this.TopMost = false;
                this.Enabled = true;
            }
            else
            {
                MessageBox.Show("OTP verification failed. Please try again.");
            }
        }

        private string GenerateOTP()
        {
            Random rand = new Random();
            return rand.Next(100000, 999999).ToString(); 
        }

        private async Task SendOTPviaSNS(string otp, string phoneNumber)
        {
            try
            {
                using (var snsClient = new AmazonSimpleNotificationServiceClient
                {
                    var request = new PublishRequest
                    {
                        Message = $"Your OTP is: {otp}",
                        PhoneNumber = phoneNumber
                    };
                    var response = await snsClient.PublishAsync(request);
                    MessageBox.Show("OTP sent successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending OTP: {ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!otpVerified)
            {
                e.Cancel = true;
                MessageBox.Show("Please verify OTP to close the application.");
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
    }
}
