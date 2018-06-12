using System;
using System.Linq;
using Xunit;
using Yanyitec.Unittest.Entities;
using Yanyitec.Accessor;
using System.Collections.Generic;

namespace Yanyitec.Unittest
{
    public class RepositoryUnittest
    {
        
        [Fact]
        public async void Basic()
        {
            using (var context = new BlogRepository()) {
                var id1 = Guid.NewGuid();
                var id2 = Guid.NewGuid();
                var list = context.DbSet.ToList();
                foreach (var e in list) {
                    //context.DbSet.Attach(e);
                    context.DbSet.Remove(e);
                }
                context.DbContext.SaveChanges();
            }

            using (var context = new BlogRepository())
            {
                var ids = new List<Guid>();
                for (var i = 0; i < 15; i++) {
                    var id = Guid.NewGuid();
                    await context.CreateAsync(new Blog(id)
                    {
                        Url = i%2==0?"http://"+i.ToString()+".test": "ftp://" + i.ToString() + ".test"
                    });

                    ids.Add(id);
                }

                
                
                var entity =await context.GetByIdAsync(ids[0].ToString());
                Assert.Equal(entity.Id,ids[0].ToString());
                Assert.Equal(entity.Url, "http://0.test");

                entity.Url = "http://x.test";
                await context.ModifyAsync(entity);
                entity = await context.GetByIdAsync(entity.Id);
                Assert.Equal(entity.Url, "http://x.test");

                var pageable = new Pageable<Blog>();
                pageable.AndAlso(p=>p.Url.StartsWith("http://"));
                pageable.Desc = p => p.Url;
                pageable.PageSize = 3;
                pageable.PageIndex = 2;

                await context.ListAsync(pageable);
                Assert.Equal(pageable.RecordCount,8);
                Assert.Equal(pageable.PageCount,3);
                Assert.Equal("http://4.test",pageable.Items[0].Url);
                Assert.Equal("http://2.test", pageable.Items[1].Url);
                Assert.Equal("http://14.test", pageable.Items[2].Url);

                await context.DeleteAsync(entity);
                entity = await context.GetByIdAsync(entity.Id);
                Assert.Null(entity);
            }

        }
        
    }
}
