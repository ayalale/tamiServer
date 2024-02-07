using Microsoft.EntityFrameworkCore;
using Models.Models;
using ProjectChanuka.Models;

namespace ProjectChanuka.Classes_and_Interfaces
{
    public class User:IUser
    {
        private readonly ProjectContext _context;
        public User(ProjectContext context)
        {
            _context = context;
        }
        public async Task<List<UserTable>> Get()
        {
            var res = await _context.User.ToListAsync();
            return res;
        }
        public async Task<bool> Post(UserTable user)
        {
            //await _context.User.AddAsync(user);
            //bool isOK = _context.SaveChanges() > 0;
            //return isOK;
            UserTable exLog = new UserTable();
            exLog.Id = user.Id;
            exLog.Name = user.Name;

            _context.User.Add(exLog);

            try
            {
                var isOK = _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }
        public async Task<bool> Delete(int id)
        {
            var user = _context.User.FirstOrDefault(t => t.Id == id);
            if (user == null) { return false; }
            _context.User.Remove(user);
            bool isOk = _context.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> Put(int id, UserTable t)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) { return false; }
            user.Name = t.Name;
            try
            {
                var isOK = _context.SaveChanges() > 0;

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

    }
}
