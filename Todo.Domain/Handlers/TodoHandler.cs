﻿using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Criar um todo
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                            false,
                            "Ops, parece que sua tarefa está errada!",
                            command.Notifications);
            //Gerar TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            //Salva no banco
            _repository.Create(todo);

            //retorna o resultado
            return new GenericCommandResult(
                        true,
                        "Operação Salva!",
                        todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                            false,
                            "Ops, parece que sua tarefa está errada!",
                            command.Notifications);

            //Recupera o TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            //Altera o título
            todo.UpdateTitle(command.Title);

            //Salva o banco
            _repository.Update(todo);

            //retorna o resultado
            return new GenericCommandResult(
                        true,
                        "Operação Salva!",
                        todo);

        }
    }
}