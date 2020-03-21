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

        public LivrosMOD BuscarLivroPorId(string id)
        {
            try
            {
                if (livrosDAL == null)
                {
                    livrosDAL = new LivrosDAL();
                }

                //retorna o livro filtrando por Id
                return livrosDAL.GetBooksById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SalvarLivro(LivrosMOD livro)
        {
            //Variavel para controle de retorno
            bool resultado = false;
            try
            {
                if (livrosDAL == null)
                {
                    livrosDAL = new LivrosDAL();
                }
                //Vamos validar os campos recebidos
                if (ValidarInfoLivro(livro))
                {
                    //Se a validação for ok, atualizamos o banco de dados
                    resultado = livrosDAL.UpdateBook(livro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public bool ExcluirLivro(string Id)
        {
            //Variavel para controle de retorno
            bool resultado = false;
            try
            {
                if (livrosDAL == null)
                {
                    livrosDAL = new LivrosDAL();
                }

                resultado = livrosDAL.DeleteBookById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public bool ValidarInfoLivro(LivrosMOD livro)
        {
            if (string.IsNullOrEmpty(livro.Titulo))
            {
                throw new Exception("O título não deve ser vazio");
            }
            else if (string.IsNullOrEmpty(livro.Categoria))
            {
                throw new Exception("A categoria do livro não deve ser vazia");
            }
            else if (livro.Preco <= 0 || livro.Preco == null || livro.Resenha.Length > 200)
            {
                throw new Exception("O preço do livro não deve ser vazio ou zero");
            }
            else if (string.IsNullOrEmpty(livro.Resenha))
            {
                throw new Exception("A resenha não pode ser vazia e deve ter até 200 caracteres");
            }

            //Se passou por todas as verificações acima, retornaremos true
            return true;
        }
    }
}
