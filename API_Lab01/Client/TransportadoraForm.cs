using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class TransportadoraForm : Form
    {
        public TransportadoraForm()
        {
            InitializeComponent();
        }

        private int transportadoraId = 0;

        public void ExibirTransportadora(Transportadora transp)
        {
            txtNome.Text = transp.Nome;
            txtTelefone.Text = transp.Telefone;
            transportadoraId = transp.TransportadoraId;
        }

        public Transportadora ObterTransportadora()
        {
            var transp = new Transportadora();
            transp.TransportadoraId = transportadoraId;
            transp.Nome = txtNome.Text;
            transp.Telefone = txtTelefone.Text;
            return transp;
        }
    }
}
