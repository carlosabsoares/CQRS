using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody]CreateTodoCommand command,
            [FromServices]TodoHandler handler
            )
        {
            command.User = "Carlos Soares";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll (
            [FromServices] ITodoRepository repository
            )
        {
            return repository.GetAll("Carlos Soares");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
            [FromServices] ITodoRepository repository
            )
        {
            //var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            var user = "Carlos Soares";
            return repository.GetAllDone(user);
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDone(
            [FromServices] ITodoRepository repository
            )
        {
            //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var user = "Carlos Soares";
            return repository.GetAllUnDone(user);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday(
            [FromServices] ITodoRepository repository
            )
        {
            return repository.GetByPeriod(
                    "Carlos Soares",
                    DateTime.Now.Date,
                    true
                );
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
            [FromServices] ITodoRepository repository
            )
        {
            return repository.GetByPeriod(
                    "Carlos Soares",
                    DateTime.Now.Date.AddDays(1),
                    true
                );
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UpdateTodoCommand command,
            [FromServices] TodoHandler handler
            )
        {
            command.User = "Carlos Soares";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkTodoAsDoneCommand command,
            [FromServices] TodoHandler handler
            )
        {
            command.User = "Carlos Soares";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        public GenericCommandResult MarkAsUnDone(
            [FromBody] MarkTodoAsUndoneCommand command,
            [FromServices] TodoHandler handler
            )
        {
            command.User = "Carlos Soares";
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}
