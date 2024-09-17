using Google.Api.Gax.Grpc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DemoApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static class ClientHelper
        {
            public static HttpClient GetClientHeader(string apiKeyName, string apiKeyValue)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add(apiKeyName, apiKeyValue);
                return client;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consumir();
        }

        public async void Consumir()
        {
            try
            {
                var client = new HttpClient();
                string documento = "123";
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.wegrowcrm.com/v1/GetParqueadero/{documento}");
                request.Headers.Add("X-Api-Key", "A6RM1yofeA7faEt5mGYJ4u3bTfeme9rn");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
