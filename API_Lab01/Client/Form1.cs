using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private HttpClient ObterHttClient()
        {
            var formato = new MediaTypeWithQualityHeaderValue("application/json");
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50090/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(formato);
            return client;
        }

        private void verificarResposta(HttpResponseMessage resposta)
        {
            if (!resposta.IsSuccessStatusCode)
            {
                MessageBox.Show("Erro no servidor: " + resposta.StatusCode);
            }
        }

        private async void CarregarGrid()
        {
            using (var client = ObterHttClient())
            {
                var resposta = await client.GetAsync("api/Transportadoras");
                var conteudo = await resposta.Content.ReadAsAsync<Transportadora[]>();
                dataGridView1.DataSource = conteudo;
                dataGridView1.ReadOnly = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }
    }
}
