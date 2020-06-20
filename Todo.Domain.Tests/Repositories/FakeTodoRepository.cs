using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {

        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("Título Aqui","Carlos Soares",DateTime.Now);
        }

        public void Update(TodoItem todo)
        {

        }
    }
}
