using EntityFrameworkSample.Dal.TableModel;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSample.Dal
{
    /// <summary>
    /// EntityFrameworkを使って実際にテーブルアクセスを行うクラス
    /// </summary>
    public class EfCoreAccessClass
    {
        public List<Blog> TestRead(int id)
        {
            using (var appDbContext = new AppDbContext())
            {
                var blogs = appDbContext.Blogs.Where(x => x.BlogId == id);

                if(!blogs.Any())
                {
                    return new List<Blog>();
                }

                return blogs.ToList();
            }
        }

        public async Task TestInsertAsync(int id, string url)
        {
            var blog = new Blog()
            {
                BlogId = id,
                Url = url
            };

            using (var appDbContext = new AppDbContext())
            {
                appDbContext.Add<Blog>(blog);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task TestUpdateAsync(int id, string url)
        {
            using (var appDbContext = new AppDbContext())
            {
                var blog = appDbContext.Blogs.Where(x => x.BlogId == id);

                if(!blog.Any())
                {
                    return;
                }

                appDbContext.Update<Blog>(blog.ToList()[0]);
                await appDbContext.SaveChangesAsync();
            }
        }

        public List<Blog> TestQuery()
        {
            using (var appDbContext = new AppDbContext())
            {
                var blog = appDbContext.Blogs.FromSqlRaw("ここにSQLを記述する");

                return blog.ToList();
            }
        }
    }
}
