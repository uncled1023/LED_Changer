using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Drawing.Imaging;
using System.Windows;
using System.Web;
using SlimDX.Direct3D9;
using SlimDX;

namespace WindowsFormsApplication1
{
    public partial class Backlight_Changer : Form
    {
        SerialPort _serialPort = new SerialPort();
        Thread _thread; 
        
        DxScreenCapture sc = new DxScreenCapture();

        int Bpp = Screen.PrimaryScreen.BitsPerPixel / 8;
        private string selected_color_mode = "Average";
        private string cur_custom_color = "#000000";
        private string cur_custom_color_2 = "#000000";
        private string selected_pattern = "Solid";
        private Screen selected_screen = Screen.PrimaryScreen;
        private int cur_speed = 50;
        private int cur_delay = 50;
        private bool connected = false;

        private List<Color> rainbow_colors = new List<Color>()
        {
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Blue,
            Color.Indigo,
            Color.Violet
        };

        public Backlight_Changer()
        {
            InitializeComponent();
            if (Bpp != 4)
            {
                throw new Exception("Screen must be 32 bit color depth");
            }
        }

        private void Backlight_Changer_Load(object sender, EventArgs e)
        {
            start_stop.Text = "Start";
            start_stop.Enabled = false;
            string[] ports = SerialPort.GetPortNames();
            com_port.Items.AddRange(ports);
            com_port.SelectedIndex = 0;
            color_mode.SelectedIndex = 0;
            pattern_select.SelectedIndex = 0;
            pictureBox1.BackColor = Color.Black;

            screen_select.ValueMember = null;
            screen_select.DisplayMember = "DeviceName";
            screen_select.DataSource = Screen.AllScreens;

            _thread = new Thread(new ThreadStart(set_color));
            _serialPort.ErrorReceived += _serialPort_ErrorReceived;

            pattern_select.SelectedIndexChanged += new System.EventHandler(this.pattern_select_SelectedIndexChanged);
            color_mode.SelectedIndexChanged += new System.EventHandler(this.color_mode_SelectedIndexChanged);
            custom_color.TextChanged += new System.EventHandler(this.custom_color_TextChanged);
            screen_select.SelectedIndexChanged += new System.EventHandler(this.screen_select_SelectedIndexChanged);
            speed_track.Scroll += new System.EventHandler(this.speed_track_Scroll);
            //this.WindowState = FormWindowState.Minimized;
        }

        Color CalculateAverageColor(DataStream gs)
        {
            int nBytes = Screen.PrimaryScreen.Bounds.Width * Screen.PrimaryScreen.Bounds.Height * 4;
            byte[] bu = new byte[nBytes];
            int r = 0;
            int g = 0;
            int b = 0;
            int i = 0;
            gs.Position = 0;
            gs.Read(bu, 0, nBytes);
            while (i < nBytes)
            {
                // Note: pixel format is BGR
                b += bu[i];
                g += bu[i + 1];
                r += bu[i + 2];

                i += 4;
            }

            int nPixels = i / 4;
            return Color.FromArgb(r / nPixels, g / nPixels, b / nPixels);
        }

        private Color get_avg()
        {
            Surface s = sc.CaptureScreen(selected_screen);
            DataRectangle dr = s.LockRectangle(LockFlags.None);
            DataStream gs = dr.Data;

            Color avg = CalculateAverageColor(gs);
            s.UnlockRectangle();
            s.Dispose();
            return avg;
        }
        
        private void set_color()
        {
            Color color = new Color();
            Color color_1 = new Color();
            Color color_2 = new Color();
            switch (selected_color_mode)
            {
                case "Custom":
                    color_1 = ColorTranslator.FromHtml(cur_custom_color);
                    color_2 = ColorTranslator.FromHtml(cur_custom_color_2);
                    break;
                default:
                    color_1 = Color.Black;
                    color_2 = Color.Black;
                    break;
            }
            bool up = true;
            int index = 0;
            int delay_index = 0;
            int color_index = 0;
            int log_delay = 0;
            float percentage = 1;
            float h = color_1.GetHue();
            float s = color_1.GetSaturation();
            float v = color_1.GetBrightness();
            IEnumerable<double> logs = logspace(0.1, 1000, 100);
            while (true)
            {
                /*
                Solid
                Pulse
                Blink
                Gradiant
                Rainbow
                 */
                log_delay = (int)logs.ElementAt(cur_delay - 1);
                switch (selected_color_mode)
                {
                    case "Average":
                        color_1 = get_avg();
                        break;
                    default:
                        break;
                }
                byte Red = new byte();
                byte Green = new byte();
                byte Blue = new byte();
                switch(selected_pattern)
                {
                    case "Solid":
                        System.Threading.Thread.Sleep(10);
                        Red = (byte)color_1.R;
                        Green = (byte)color_1.G;
                        Blue = (byte)color_1.B;
                        break;
                    case "Pulse":
                        if (index >= cur_speed)
                        {
                            if (percentage == 1)
                            {
                                up = false;
                            }
                            if (percentage == 0)
                            {
                                if (delay_index >= log_delay)
                                {
                                    up = true;
                                    delay_index = 0;
                                }
                                else
                                {
                                    delay_index++;
                                }
                            }
                            if (up)
                            {
                                percentage += (float)(0.01 * (speed_track.Maximum / cur_speed));
                                if (percentage > 1)
                                {
                                    percentage = 1;
                                }

                                color = LerpColor(color_1, Color.Black, percentage);
                            }
                            else
                            {
                                percentage -= (float)(0.01 * (speed_track.Maximum / cur_speed));

                                if (percentage < 0)
                                {
                                    percentage = 0;
                                }

                                color = LerpColor(color_1, Color.Black, percentage);
                            }
                            index = 0;
                        }
                        else
                        {
                            index++;
                        }
                        Red = (byte)color.R;
                        Green = (byte)color.G;
                        Blue = (byte)color.B;
                        break;
                    case "Blink":
                        if (index >= cur_speed)
                        {
                            if (up)
                            {
                                color = color_1;
                            }
                            else
                            {
                                if (delay_index >= log_delay)
                                {
                                    color = Color.Black;
                                    delay_index = 0;
                                }
                                else
                                {
                                    delay_index++;
                                }
                            }
                            index = 0;
                            up = !up;
                        }
                        else
                        {
                            index++;
                        }
                        Red = (byte)color.R;
                        Green = (byte)color.G;
                        Blue = (byte)color.B;
                        break;
                    case "Gradiant":
                        if (index >= cur_speed)
                        {
                            if (percentage == 1)
                            {
                                up = false;
                            }
                            if (percentage == 0)
                            {
                                up = true;
                            }
                            if (up)
                            {
                                if (delay_index >= log_delay)
                                {
                                    percentage += (float)(0.01 * (speed_track.Maximum / cur_speed));
                                    if (percentage > 1)
                                    {
                                        percentage = 1;
                                    }
                                    color = LerpColor(color_1, color_2, percentage);
                                    delay_index = 0;
                                }
                                else
                                {
                                    delay_index++;
                                }
                            }
                            else
                            {
                                if (delay_index >= cur_delay)
                                {
                                    percentage -= (float)(0.01 * (speed_track.Maximum / cur_speed));

                                    if (percentage < 0)
                                    {
                                        percentage = 0;
                                    }
                                    color = LerpColor(color_1, color_2, percentage);
                                    delay_index = 0;
                                }
                                else
                                {
                                    delay_index++;
                                }
                            }
                            index = 0;
                        }
                        else
                        {
                            index++;
                        }
                        Red = (byte)color.R;
                        Green = (byte)color.G;
                        Blue = (byte)color.B;
                        break;
                    case "Rainbow":
                        if (index >= cur_speed)
                        {
                            if (percentage == 1)
                            {
                                color_1 = color_2;
                                if (delay_index >= log_delay)
                                {
                                    if (rainbow_colors.Count > color_index)
                                    {
                                        color_2 = rainbow_colors[color_index];
                                    }
                                    else
                                    {
                                        color_2 = rainbow_colors[0];
                                        color_index = 0;
                                    }
                                    color_index++;
                                    percentage = 0;
                                    delay_index = 0;
                                }
                                else
                                {
                                    delay_index++;
                                }
                            }
                            percentage += (float)(0.01 * (speed_track.Maximum / cur_speed));
                            if (percentage > 1)
                            {
                                percentage = 1;
                            }
                            color = LerpColor(color_1, color_2, percentage);
                            index = 0;
                        }
                        else
                        {
                            index++;
                        }
                        Red = (byte)color.R;
                        Green = (byte)color.G;
                        Blue = (byte)color.B;
                        break;
                    case "Random":
                        if (index >= cur_speed)
                        {
                            if (percentage == 1)
                            {
                                color_1 = color_2;
                                if (delay_index >= log_delay)
                                {
                                    Random rand = new Random();
                                    int rand_R = rand.Next(255);
                                    int rand_G = rand.Next(255);
                                    int rand_B = rand.Next(255);
                                    color_2 = Color.FromArgb(0, rand_R, rand_G, rand_B);
                                    percentage = 0;
                                }
                                else
                                {
                                    delay_index++;
                                }
                            }
                            percentage += (float)(0.01 * (speed_track.Maximum / cur_speed));
                            if (percentage > 1)
                            {
                                percentage = 1;
                            }
                            color = LerpColor(color_1, color_2, percentage);
                            index = 0;
                        }
                        else
                        {
                            index++;
                        }
                        Red = (byte)color.R;
                        Green = (byte)color.G;
                        Blue = (byte)color.B;
                        break;
                    default:
                        System.Threading.Thread.Sleep(10);
                        Red = (byte)color_1.R;
                        Green = (byte)color_1.G;
                        Blue = (byte)color_1.B;
                        break;
                }
                _serialPort.Write(new byte[] { 0xFF, Red, Green, Blue }, 0, 4);

                string htmlHexColorValueTwo = ColorTranslator.ToHtml(Color.FromArgb(0, Red, Green, Blue));
                pictureBox1.BackColor = ColorTranslator.FromHtml(htmlHexColorValueTwo);
                AppDomain.CurrentDomain.ProcessExit += new EventHandler (OnProcessExit); 
            }
        }

        public IEnumerable<double> logspace(double start, double end, int count)
        {
            double d = (double)count, p = end / start;
            return Enumerable.Range(0, count).Select(i => start * Math.Pow(p, i / d));
        }

        private Color LerpColor(Color a, Color b, float percentage)
        {
            byte A = new byte();
            byte R = new byte();
            byte G = new byte();
            byte B = new byte();
            A = (byte)(a.A + (b.A - a.A) * percentage);
            R = (byte)(a.R + (b.R - a.R) * percentage);
            G = (byte)(a.G + (b.G - a.G) * percentage);
            B = (byte)(a.B + (b.B - a.B) * percentage);
            return Color.FromArgb(A, R, G, B);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            set_color();
        }

        private void start_stop_Click(object sender, EventArgs e)
        {
            if (_thread.IsAlive)
            {
                _thread.Abort();
                _serialPort.Write(new byte[] { 0xFF, 0, 0, 0 }, 0, 4);
                string htmlHexColorValueTwo = ColorTranslator.ToHtml(Color.FromArgb(0, 0, 0,0));
                pictureBox1.BackColor = ColorTranslator.FromHtml(htmlHexColorValueTwo);
                start_stop.Text = "Start";
            }
            else
            {
                _thread = new Thread(new ThreadStart(set_color));
                _thread.IsBackground = true;
                _thread.Start();
                start_stop.Text = "Stop";
            }
            
        }

        private void start(object sender, EventArgs e)
        {
            if (!_thread.IsAlive)
            {
                _thread = new Thread(new ThreadStart(set_color));
                _thread.IsBackground = true;
                _thread.Start();
                start_stop.Text = "Stop";
            }
        }

        private void stop(object sender, EventArgs e)
        {
            if (_thread.IsAlive)
            {
                _thread.Abort();
                start_stop.Text = "Start";
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Backlight_Changer_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void Backlight_Changer_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }

        private void Backlight_Changer_Shown(object sender, EventArgs e)
        {
            //this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thread.Abort();
            if (_serialPort.IsOpen == false)
            {
                _serialPort = new SerialPort();
                _serialPort.PortName = com_port.SelectedItem.ToString();
                _serialPort.BaudRate = 9600;

                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;
                _serialPort.Open();
            }
            _serialPort.Write(new byte[] { 0xFF, 0, 0, 0 }, 0, 4);
            _serialPort.Close();
            Application.Exit();
        }
        private void OnProcessExit(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                custom_color_2.Text = ColorTranslator.ToHtml(colorDialog1.Color);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                custom_color.Text = ColorTranslator.ToHtml(colorDialog1.Color);
            }
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen == false)
            {
                try
                {
                    _serialPort.PortName = com_port.SelectedItem.ToString();
                    _serialPort.BaudRate = 9600;

                    _serialPort.ReadTimeout = 500;
                    _serialPort.WriteTimeout = 500;

                    _serialPort.Open();
                    start_stop.Enabled = true;
                    connect_button.Text = "Disconnect";
                    com_port.Enabled = false;
                    connected = true;
                }
                catch
                {
                    start_stop.Enabled = false;
                }
            }
            else
            {
                stop(sender, e);
                start_stop.Enabled = false;
                connect_button.Text = "Connect";
                com_port.Enabled = true;
                connected = false;
                try
                {
                    _serialPort.Close();
                }
                catch { }
            }
        }

        void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            stop(sender, e);
            start_stop.Enabled = false;
            connect_button.Text = "Connect";
            com_port.Enabled = true;
            connected = false;
            try
            {
                _serialPort.Close();
            }
            catch { }
        }

        private void color_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool stopped = false;
            if (connected && _thread.IsAlive)
            {
                stop(sender, e);
                stopped = true;
            }
            selected_color_mode = color_mode.SelectedItem.ToString();
            if(color_mode.SelectedItem.ToString().Equals("Custom"))
            {
                screen_select.Enabled = false;
                custom_color.Enabled = true;
                button2.Enabled = true;
                if (selected_pattern.Equals("Gradiant"))
                {
                    button1.Enabled = true;
                    custom_color_2.Enabled = true;
                }
                if (pattern_select.Items.Count <= 2)
                {
                    pattern_select.Items.Add("Gradiant");
                    pattern_select.Items.Add("Rainbow");
                    pattern_select.Items.Add("Random");
                }
            }
            else
            {
                screen_select.Enabled = true;
                custom_color.Enabled = false;
                button2.Enabled = false;
                custom_color_2.Enabled = false;
                button1.Enabled = false;
                if (selected_pattern.Equals("Gradiant") || selected_pattern.Equals("Rainbow") || selected_pattern.Equals("Random"))
                {
                    pattern_select.SelectedIndex = 0;
                }
                if (pattern_select.Items.Count > 3)
                {
                    pattern_select.Items.RemoveAt(5);
                    pattern_select.Items.RemoveAt(4);
                    pattern_select.Items.RemoveAt(3);
                }
            }
            if (connected && stopped)
            {
                start(sender, e);
            }
        }

        private void custom_color_TextChanged(object sender, EventArgs e)
        {
            bool stopped = false;
            if (connected && _thread.IsAlive)
            {
                stop(sender, e);
                stopped = true;
            }
            cur_custom_color = custom_color.Text;
            if (connected && stopped)
            {
                start(sender, e);
            }
        }

        private void custom_color_2_TextChanged(object sender, EventArgs e)
        {
            bool stopped = false;
            if (connected && _thread.IsAlive)
            {
                stop(sender, e);
                stopped = true;
            }
            cur_custom_color_2 = custom_color_2.Text;
            if (connected && stopped)
            {
                start(sender, e);
            }
        }

        private void pattern_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool stopped = false;
            if (connected && _thread.IsAlive)
            {
                stop(sender, e);
                stopped = true;
            }
            selected_pattern = pattern_select.SelectedItem.ToString();
            if (selected_pattern.Equals("Gradiant"))
            {
                if (selected_color_mode.Equals("Custom"))
                {
                    button2.Enabled = true;
                    custom_color.Enabled = true;
                    button1.Enabled = true;
                    custom_color_2.Enabled = true;
                }
            }
            else if(selected_pattern.Equals("Rainbow"))
            {
                button2.Enabled = false;
                custom_color.Enabled = false;
                button1.Enabled = false;
                custom_color_2.Enabled = false;
            }
            else if (selected_pattern.Equals("Random"))
            {
                button2.Enabled = false;
                custom_color.Enabled = false;
                button1.Enabled = false;
                custom_color_2.Enabled = false;
            }
            else
            {
                if (selected_color_mode.Equals("Custom"))
                {
                    button2.Enabled = true;
                    custom_color.Enabled = true;
                    button1.Enabled = false;
                    custom_color_2.Enabled = false;
                }
            }
            if (connected && stopped)
            {
                start(sender, e);
            }
        }

        private void screen_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool stopped = false;
            if (connected && _thread.IsAlive)
            {
                stop(sender, e);
                stopped = true;
            }
            selected_screen = (Screen)screen_select.SelectedValue;
            if (connected && stopped)
            {
                start(sender, e);
            }
        }

        private void speed_track_Scroll(object sender, EventArgs e)
        {
            cur_speed = speed_track.Value;
        }

        private void color_delay_track_Scroll(object sender, EventArgs e)
        {
            cur_delay = color_delay_track.Value;
        }
    }

    public class DxScreenCapture
    {
        Device d;

        public DxScreenCapture()
        {
            PresentParameters present_params = new PresentParameters();
            present_params.Windowed = true;
            present_params.SwapEffect = SwapEffect.Discard;
            d = new Device(new Direct3D(), 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.SoftwareVertexProcessing, present_params);
        }

        public Surface CaptureScreen(Screen selected_screen)
        {
            Surface s = Surface.CreateOffscreenPlain(d, selected_screen.Bounds.Width, selected_screen.Bounds.Height, Format.A8R8G8B8, Pool.Scratch);
            d.GetFrontBufferData(0, s);
            return s;
        }
    }
}
