using System;
using System.Net.Http;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:8091/");

            HttpResponseMessage response = await client.GetAsync("api/sehir");

            string result = await response.Content.ReadAsStringAsync();

            label1.Text = result;
        }
    }
}
