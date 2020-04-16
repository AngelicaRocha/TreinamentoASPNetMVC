using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestaoPessoas.Web.Models;

namespace GestaoPessoas.Web.Context
{
    public class DataAccessHelper
    {
        //Instancio a classe GestaoPessoasContext para usar o banco de dados aqui nesse helper
        readonly GestaoPessoasContext _dbContext = new GestaoPessoasContext();

        public List<Empregado> BuscarEmpregados()
        {
            /* Select * from Empregado*/
            return _dbContext.Empregado.ToList();
        }

        public List<Departamento> BuscarDepastamentos()
        {
            /* Select * from Departamento */
            return _dbContext.Departamento.ToList();
        }

        public int AddEmpregado(Empregado empregado)
        {
            //depois do . o contexto mostra as tabelas do banco de dados
            _dbContext.Empregado.Add(empregado);
            _dbContext.SaveChanges();
            return empregado.Id;
        }

        public int AddDepartamento (Departamento departamento)
        {
            _dbContext.Departamento.Add(departamento);
            _dbContext.SaveChanges();
            return departamento.Id;
        }
    }
}