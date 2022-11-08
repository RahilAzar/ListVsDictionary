using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ListBuilder
    {
        private int _listCounter = 100000;
        public List<Entity> Yesterday = new List<Entity>();
        public List<Entity> Today = new List<Entity>();
        public void GenerateList()
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            for (int i = 0; i < _listCounter; i++)
            {
                double fixedPrice = new Random().NextDouble() * (100 - 10) + 10;
                string description = "something";
                string entityName = "C-" + i.ToString();
                var todayEntity = new Entity(
                    Guid.NewGuid(),
                    entityName,
                    description,
                    fixedPrice,
                    DateTime.Now
                    );
                Today.Add(todayEntity);
                var yesterdayEntity = new Entity(
                   Guid.NewGuid(),
                   entityName,
                   description,
                   fixedPrice,
                   DateTime.Now.AddDays(-1)
                   );
                Yesterday.Add(yesterdayEntity);
            }
            var changedPrice = Today[100];
            if (changedPrice.Price != 20 &&
                Yesterday.Where(e => e.Name == changedPrice.Name).FirstOrDefault().Price != 20)
                changedPrice.Price = 20;
            else
                changedPrice.Price = 30;
            Yesterday.Remove(Yesterday.First());
            Today.Remove(Today.Last());
            st.Stop();
            Console.WriteLine("List generation time : " + st.ElapsedMilliseconds);
        }
    }
}
