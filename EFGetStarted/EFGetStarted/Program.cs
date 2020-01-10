using EFGetStarted.Practice;
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
            ConfiguringDbContext configuringDb = new ConfiguringDbContext();
            configuringDb.DbContextCheck();
        }
    }
}
