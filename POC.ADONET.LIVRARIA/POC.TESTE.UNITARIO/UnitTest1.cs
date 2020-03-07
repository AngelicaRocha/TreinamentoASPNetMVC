using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.ADONET.DAL;

namespace POC.TESTE.UNITARIO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestarInsertNaTabelaCliente()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            clienteDAL.Add("Mariana Ribeiro", "marianaribeiro@yahoo.com.br", "Não tem residência fixa");
        }
    }
}
