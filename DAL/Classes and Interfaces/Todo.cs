using Microsoft.EntityFrameworkCore;
using Models.Models;
using ProjectChanuka.Models;

namespace ProjectChanuka.Classes_and_Interfaces
{
    public class Todo : ITodo
    {
        private readonly ProjectContext _context;

        public Todo(ProjectContext context)
        {
            _context = context;
        }

        public async Task<List<TodoTable>> Get()
        {
            return await _context.Todo.ToListAsync();
        }
        public async Task<bool> Post(TodoTable toDo)
        {

            await _context.Todo.AddAsync(toDo);

            bool isOK = _context.SaveChanges() > 0;
            return isOK;
         

        }

        public async Task<bool> Delete(int id)
        {
            var todo = await _context.Todo.FirstOrDefaultAsync(t => t.Id == id);
            if (todo == null) { return false; }
            _context.Todo.Remove(todo);
            bool isOk = _context.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> Put(int id, TodoTable t)
        {
            var todo = await _context.Todo.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null) { return false; }
            todo.Name = t.Name;
            todo.IsComplete = t.IsComplete;
            bool isOk = _context.SaveChanges() > 0;
            return isOk;
        }
    }
}
