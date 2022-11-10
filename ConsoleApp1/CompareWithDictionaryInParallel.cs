using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CompareWithDictionaryInParallel
    {
        public List<Entity> _changedPrice = new List<Entity>();
        public List<Entity> _removedEntity = new List<Entity>();
        public List<Entity> _newEntity = new List<Entity>();

        Dictionary<string, Entity> TodayDictionary = new Dictionary<string, Entity>();
        public void Compare(ListBuilder builder)
        {
            Stopwatch st = new Stopwatch();
            st.Start();

            foreach (var item in builder.Today)
            {
                TodayDictionary.Add(item.Name, item);
            }
          
            Parallel.ForEach(builder.Yesterday, item =>
            {
                Entity sameEntity = new Entity();
                TodayDictionary.TryGetValue(item.Name, out sameEntity);
                if (sameEntity == null)
                    _removedEntity.Add(item);
                else if (sameEntity.Price != item.Price)
                {
                    _changedPrice.Add(item);
                }
            });
            var newEntityKeys = builder.Today.Select(e => e.Name)
                   .Except(builder.Yesterday.Select(e => e.Name));
            Parallel.ForEach(newEntityKeys, item =>
            {
                _newEntity.Add(builder.Today.Where(k => k.Name == item).First());
            });
            st.Stop();
            Console.WriteLine("Compare with Dictionary in parallel: " + st.ElapsedMilliseconds);
        }
    }
}
