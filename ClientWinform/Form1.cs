using ClientWinform.Models;
using Newtonsoft.Json;
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

namespace ClientWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:54178/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public HttpClient _client;
        public HttpResponseMessage _response;

        public async Task<Products> GetAllProducts()
        {
            _response = await _client.GetAsync($"/api/Products/5");

            var json = await _response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Products>(json);
            return data;
        }
        

        private async void LoadData()
        {
            var listData = await GetAllProducts();
            label1.Text = $"id={listData.id}| name={listData.name}| Description= {listData.descripption}| price={listData.price}| " +
                $"unitsInStock={listData.unitInStock}| catId={listData.catId} ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
