using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViagensOnline.Cap04.Lab1.Models;
using System.Data.Entity;

namespace ViagensOnline.Cap04.Lab1.Db
{
    public class ViagensOnlineDb : DbContext
    {
        private const string conexao =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Angelica\gitHub\TreinamentoASPNetMVC\ViagensOnline\ViagensOnline.Cap04.Lab1\ViagensOnline.Cap04.Lab1\App_Data\ViagensOnlineDb.mdf;Integrated Security=True";

        public ViagensOnlineDb() : base(conexao)
        {

        }
        
        public DbSet<Destino> Destinos { get; set; }
    }
}