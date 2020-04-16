using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity_Lab01.Models;

namespace Entity_Lab01.DAL
{
    public class CategoriaDb
    {
        public List<Categoria> ListarCategorias()
        {
            using (var db = new NorthwindContext())
            {
                return db.Categorias.ToList();
            }
        }

        public List<Produto> ListarProdutosPorCategoria(int idCategoria)
        {
            using (var db = new NorthwindContext())
            {
                var query = from c in db.Produtos where c.IdCategoria == idCategoria select c;
                var lista = query.ToList();
                return lista;
            }
        }

        public Categoria SelecionaCategoriaPorId (int id)
        {
            using (var db = new NorthwindContext())
            {
                return db.Categorias.Where(m => m.IdCategoria == id).FirstOrDefault();
            }
        }
    }
}