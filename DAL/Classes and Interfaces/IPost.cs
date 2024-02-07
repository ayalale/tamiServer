using ProjectChanuka.Models;

namespace ProjectChanuka.Classes_and_Interfaces
{
    public interface IPost
    {

        Task<List<PostTable>> Get();
        Task<bool> Post(PostTable p);
        Task<bool> Delete(int id);
        Task<bool> Put(int id, PostTable t);
    }
}
