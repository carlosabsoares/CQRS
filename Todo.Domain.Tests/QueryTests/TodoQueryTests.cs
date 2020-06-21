using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _itens;

        public TodoQueryTests()
        {
            _itens = new List<TodoItem>();
            _itens.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _itens.Add(new TodoItem("Tarefa 2", "usuarioB", DateTime.Now));
            _itens.Add(new TodoItem("Tarefa 3", "Carlos Soares", DateTime.Now));
            _itens.Add(new TodoItem("Tarefa 4", "usuarioC", DateTime.Now));
            _itens.Add(new TodoItem("Tarefa 5", "Carlos Soares", DateTime.Now));
        }

        [TestMethod]
        public void Dada_consulta_deve_retornar_tarefas_apenas_do_usuario()
        {
            var result = _itens.AsQueryable().Where(TodoQueries.GetAll("Carlos Soares"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Dada_consulta_deve_retornar_tarefas_nao_concluidas()
        {
            var result = _itens.AsQueryable().Where(TodoQueries.GetAllUnDone("Carlos Soares"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Dada_consulta_deve_retornar_tarefas_concluidas()
        {
            var result = _itens.AsQueryable().Where(TodoQueries.GetAllDone("Carlos Soares"));
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Dada_consulta_deve_retornar_tarefas_por_periodo_false()
        {
            var result = _itens.AsQueryable().Where(TodoQueries.GetByPeriod("Carlos Soares", DateTime.Now, false));
            Assert.AreEqual(2, result.Count());
        }
    }
}