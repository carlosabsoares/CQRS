using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTest
    {

        private readonly TodoItem _valideTodo = new TodoItem("Titulo aqui", "carlossoares", DateTime.Now);

        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.AreEqual(_valideTodo.Done, false);
        }
    }
}
