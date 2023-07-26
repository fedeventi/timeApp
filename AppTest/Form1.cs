using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace AppTest
{

    public partial class Form1 : Form
    {
        //
        public Label[] days;
        public Label[] temperature;
        public PictureBox[] images;
        
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            days = new Label[5]
            {
                day1,
                day2,
                day3,
                day4,
                day5
            };
            temperature = new Label[5]
            {
                label1,
                label4,
                label6,
                label8,
                label10
            };
            images = new PictureBox[5]
            {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5
            };

            GetWeather();
           // Design();
        }
        public async void GetWeather()
        {
            HttpClient Client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                "https://api.openweathermap.org/data/2.5/forecast?lat=34&lon=58&appid=c79704f3754bff6163aa126fc6de2111");
            

            var response = await Client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                
                return;
            }
            
            var body = response.Content;
            var result = await body.ReadAsStringAsync();

            dynamic weatherResult = JsonConvert.DeserializeObject(result);

            // weatherResult.weather[0].main;
            //weatherResult.list[0].weather[0].main;
            temperature[0].Text = weatherResult.list[0].main.temp;



        }
        public void Design()
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("AppTest.Assets.346161.png");
            Bitmap bmp = new Bitmap(myStream);
            pictureBox1.Image= bmp;
            pictureBox1.BackColor = Color.Transparent;
            days[0].Text= DateTime.Today.DayOfWeek.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr one, int two,int three, int four);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 274, 61458, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void textBoxTransparent1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxTransparent1_Load_1(object sender, EventArgs e)
        {

        }

        private void textBoxTransparent2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
  
    
}
public enum weatherType
{
    clear,
    rainy,

}
