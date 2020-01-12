using EFGetStarted.Practice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConnectionResiliency cR = new ConnectionResiliency();
            //cR.ManualTrackTheTransaction();
            //ConfiguringDbContext configuringDb = new ConfiguringDbContext();
            //configuringDb.DbContextCheck();
            using(var db=new BloggingContext())
            {
                var userInfo = db.Users
                    .Include(ap=>ap.AuthoredPosts)
                    .Include(cp=>cp.ContributedToPosts)
                    .Where(x => x.UserId == 1);
            }
        }
    }
}
