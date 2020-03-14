using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.ADONET.MODELS;
using POC.ADONET.DAL;

namespace POC.ADONET.BLL
{
    public class LivrosBLL
    {
        //vamos criar uma variável do tipo DAL
        LivrosDAL livrosDAL;

        public List<LivrosMOD> BuscarTodosLivros()
        {
            try
            {
                if (livrosDAL == null)
                {
                    livrosDAL = new LivrosDAL();
                }

                //retorna o resultado do método que ja definimos ser uma lista
                return livrosDAL.GetBooks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
