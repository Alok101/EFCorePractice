using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace EFGetStarted.Practice
{
    public class ConnectionResiliency
    {
        public void ManualInvoke()
        {
            using (var db = new BloggingContext())
            {
                var strategy = db.Database.CreateExecutionStrategy();

                strategy.Execute(() =>
                {
                    using (var context = new BloggingContext())
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });
                            context.SaveChanges();

                            context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/visualstudio" });
                            context.SaveChanges();

                            transaction.Commit();
                        }
                    }
                });
            }
        }
        public void AmbientTransaction()
        {
            using (var context1 = new BloggingContext())
            {
                context1.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/visualstudio" });

                var strategy = context1.Database.CreateExecutionStrategy();

                strategy.Execute(() =>
                {
                    using (var context2 = new BloggingContext())
                    {
                        using (var transaction = new TransactionScope())
                        {
                            context2.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });
                            context2.SaveChanges();

                            context1.SaveChanges();

                            transaction.Complete();
                        }
                    }
                });
            }
        }
        public void AddStateVerification()
        {
            using (var db = new BloggingContext())
            {
                var strategy = db.Database.CreateExecutionStrategy();

                var blogToAdd = new Blog { Url = "http://blogs.msdn.com/dotnet" };
                db.Blogs.Add(blogToAdd);

                strategy.ExecuteInTransaction(db,
                    operation: context =>
                    {
                        context.SaveChanges(acceptAllChangesOnSuccess: false);
                    },
                    verifySucceeded: context => context.Blogs.AsNoTracking().Any(b => b.BlogId == blogToAdd.BlogId));

                db.ChangeTracker.AcceptAllChanges();
            }
        }

        public void ManualTrackTheTransaction()
        {
            using (var db = new BloggingContext())
            {
                var strategy = db.Database.CreateExecutionStrategy();

                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });

                var transaction = new TransactionRow { GUID = Guid.NewGuid() };
                db.Transactions.Add(transaction);

                strategy.ExecuteInTransaction(db,
                    operation: context =>
                    {
                        context.SaveChanges(acceptAllChangesOnSuccess: false);
                    },
                    verifySucceeded: context => context.Transactions.AsNoTracking().Any(t => t.GUID == transaction.GUID));

                db.ChangeTracker.AcceptAllChanges();
                //db.Transactions.Remove(transaction);
                db.SaveChanges();
            }
        }
    }
}
