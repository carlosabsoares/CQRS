﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAll(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUnDone(string user)
        {
            return _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllUnDone(user))
                .OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, string user)
        {
            //return _context.Todos
            //    .FirstOrDefault( x => x.Id == id && x.User == user);

            return _context.Todos.Where(TodoQueries.GetById(id, user)).FirstOrDefault();
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);
        }

        public void Update(TodoItem todo)
        {
            //_context.Todos.Update(todo);
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}