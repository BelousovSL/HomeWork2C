using System;
using Microsoft.Extensions.Configuration;
using Otus2.Blocks;
using Otus2.Data;

namespace Otus2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new OtusDbContext())
            {
                var manager = new ManagerBlock(context);

                var res = "";
                do
                {
                    manager.ShowSelect();
                    res = Console.ReadLine();

                    manager.Action(res);
                }
                while (res != "1");

            }

        }
    }
}
