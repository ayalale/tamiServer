using Microsoft.AspNetCore.Mvc;
using ProjectChanuka.Models;

namespace ProjectChanuka.Classes_and_Interfaces
{
    public interface IUser
    {
        Task<List<UserTable>> Get();
        Task<bool> Post(UserTable user);
        Task<bool> Delete(int id);
        Task<bool> Put(int id, UserTable t);
    }
}
