using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CompareWithListInParallel
    {
        public List<Entity> _changedPrice = new List<Entity>();
        public List<Entity> _removedEntity = new List<Entity>();
        public List<Entity> _newEntity = new List<Entity>();

        public void Compare(ListBuilder builder)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            Parallel.ForEach(builder.Yesterday, item =>
            {
                var sameEntity = builder.Today.Where(e => e.Name == item.Name).FirstOrDefault();
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

            Console.WriteLine("Compare with List in parallel: " + st.ElapsedMilliseconds);
        }
    }
}
