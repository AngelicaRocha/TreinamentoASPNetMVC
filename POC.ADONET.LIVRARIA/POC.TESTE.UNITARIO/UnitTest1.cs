using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.ADONET.DAL;
using POC.ADONET.MODELS;

namespace POC.TESTE.UNITARIO
{
    [TestClass]
    public class UnitTest1
    {
        //CREATE
        [TestMethod]
        public void TestarInsertNaTabelaCliente()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            Assert.IsTrue(clienteDAL.Add("João da Silva", "joaosilva@hotmail.com", "NA"));
            //o assert é uma classe para testes
        }

        //READ
        [TestMethod]
        public void TestarBuscaDadosNaTabelaCliente()
        {
            ClienteDAL clienteDAL = new ClienteDAL();

            Assert.IsNotNull(clienteDAL.SelectAll());            
        }

        //READ by ID
        [TestMethod]
        public void TestarBuscaDadosNaTabelaPorID()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            ClienteMOD cliente = null;

            //Executa o select filtrando por ID
            cliente = clienteDAL.SelectByID(2);

            //Verifica se o resultado é diferente de nulo
            Assert.IsNotNull(cliente);
        }

        //UPDATE
        [TestMethod]
        public void TestarAlteracaoNaTabelaCliente()
        {
            //objetos para buscar e receber os dados
            ClienteDAL clienteDAL = new ClienteDAL();
            ClienteMOD cliente = null;
            int id = 7;

            //Executa o select filtrando por ID
            cliente = clienteDAL.SelectByID(id);

            cliente.Nome = "Fernando Fernades";
            cliente.Email = "fernando@hotmail.com";
            cliente.Observacao = "nononono";
            
            Assert.IsTrue(clienteDAL.Update(cliente));
        }

        //DELETE
        [TestMethod]
        public void TestarExclusaoNaTabelaCliente()
        {
            //objetos para buscar e receber os dados
            ClienteDAL clienteDAL = new ClienteDAL();
            int id = 3;
            Assert.IsTrue(clienteDAL.DeleteByID(id));
        }
    }
}
