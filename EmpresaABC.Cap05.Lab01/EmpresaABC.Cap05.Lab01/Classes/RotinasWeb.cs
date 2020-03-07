using EmpresaABC.Cap05.Lab01.Models;
using System.IO;
using System.Web;
using System.Text;

namespace EmpresaABC.Cap05.Lab01.Classes
{
    public static class RotinasWeb
    {
        public static void ContatoGravar(ContatoViewModel contato)
        {
            string arquivo = HttpContext.Current.Server.MapPath("~/App_Data/Contatos.txt");

            using (var sw = new StreamWriter(arquivo, true, Encoding.UTF8))
            {
                sw.WriteLine(System.DateTime.Now);
                sw.WriteLine(contato.Nome);
                sw.WriteLine(contato.Email);
                sw.WriteLine(contato.Assunto);
                sw.WriteLine(contato.Mensagem);
                sw.WriteLine(new string('-', 30));
            }
        }
    }
}