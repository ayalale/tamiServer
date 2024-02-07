using ProjectChanuka.Models;

namespace ProjectChanuka.Classes_and_Interfaces
{
    public interface ITodo
    {
        Task<List<TodoTable>> Get();
        Task<bool> Post(TodoTable toDo);
        Task<bool> Delete(int id);
        Task<bool> Put(int id, TodoTable t);
    }
}
