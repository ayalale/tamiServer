using Microsoft.EntityFrameworkCore;
using Models.Models;
using ProjectChanuka.Models;

namespace ProjectChanuka.Classes_and_Interfaces
{
    public class PostClass:IPost
    {
        private readonly ProjectContext _context;
        public PostClass(ProjectContext context)
        {
            _context = context;
        }
        public async Task<List<PostTable>> Get()
        {
            return await _context.Posts.ToListAsync();
        }
        public async Task<bool> Post(PostTable p)
        {
            await _context.Posts.AddAsync(p);
            bool isOk = _context.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> Delete(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(t => t.Id == id);
            if (post == null) { return false; }
            _context.Posts.Remove(post);
            bool isOk = _context.SaveChanges() > 0;
            return isOk;
        }
        public async Task<bool> Put(int id, PostTable t)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null) { return false; }
            post.Name = t.Name;
            bool isOk = _context.SaveChanges() > 0;
            return isOk;
        }

        
        
    }
}
