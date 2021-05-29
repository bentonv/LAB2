using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LAB2
{
    public class DynamicArray<T>  : IDisposable, IEnumerable<T>  where T : new()
    {
        private bool _Disposed = false;
        private T[] _Items;

        public DynamicArray(int size)
        {
            _Items = new T[size];
            Console.WriteLine($"Create DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        }

        public T this[int index]
        {
            get { return _Items[index]; }
            set { _Items[index] = value; }
        }
        public DynamicArray(IEnumerable<T> items)
        {
            _Items = items.ToArray();
            Console.WriteLine($"Create DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        }
        public void Resize(int size)
        {
            T[] items = new T[size];

            for(int i = 0; i< size; i++)
            {
                items[i] = new T();
            }

            for(int i = 0; (i < items.Length) && (i< _Items.Length); i++)
            {
                items[i] = _Items[i];
            }
            _Items = items;

        }
       

       public IEnumerator<T> GetEnumerator()
        {
            return (_Items as IEnumerable<T>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Items.GetEnumerator();
        }

       

        public void Dispose()
        {
            //throw new NotImplementedException();
            Console.WriteLine($"Disposing DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(_Disposed == true)
            {
                return;
            }

            _Disposed = true;
        }

        ~DynamicArray()
        {
            Console.WriteLine($"Finalize DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
