using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GenList
{
    public class GenList<T>
    {

        public int Count { get; set; } = 0;
        public int Capacity { get; set; } = 0;

        public T[] items;


        public GenList(int capacity, int count)
        {
            Capacity = capacity;

            items = new T[0];
            Count = count;


        }

        public void Add(T item)
        {
            if (Count == Capacity)
            {
                if (Capacity == 0) Capacity = 4;
                else Capacity = Capacity * 2;

                T[] newItems = new T[Capacity];
                for (int i = 0; i < Count; i++)
                {

                    newItems[i] = items[i];
                }
                items = newItems;
            }

            items[Count] = item;
            Count++;

        }
        public GenList<T> FindAll(Predicate<T> match)
        {
            Array.FindAll(items, match);
            return this;

        }
        public bool Contains(T item)
        {
            return items.Contains(item);
        }
        public T? Find(Predicate<T> predicate) { 
        
        return Array.Find(items, predicate);
        }

        public bool Exists(Predicate<T> match)
        {
            if (Array.Exists(items, match))
            {
                return true;

            }
            return false;

        }

        public void Remove(Predicate<T> match)
        {

            int newIndex = 0;
            for (int i = 0; i < Count; i++)
            {
                if (!match(items[i]))
                {
                    items[newIndex++] = items[i];
                    newIndex++;
                }
            }
            Count = newIndex;

        }
    }
}
            

       

