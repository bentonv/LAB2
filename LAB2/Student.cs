using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LAB2
{
    public class Student : IDisposable
    {
        private bool _Disposed = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DynamicArray<int> Scores { get; set; }
        
        
        public Student(string lastName, string firstName, int numScores)
        {
            LastName = lastName;
            FirstName = firstName;
            Scores = new DynamicArray<int>(numScores);
        }
        
        public override string ToString() 
        {
            //added Count Max, Min, Average
            return $"Last Name: {LastName,-8}, First Name: {FirstName,-3}, Count: {Scores.Count(),-1} Max Score: {Scores.Max()}, Min Score:{Scores.Min()}, Average Score:{Scores.Average(),-15:###.###}";
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
            Console.WriteLine($"Disposing Student from thread {Thread.CurrentThread.ManagedThreadId}");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            //if Disposed
            if (_Disposed == true)
            {
                //scores is nullable type then assign null to scores and return.
                Scores?.Dispose();
                Scores = null;
                return;
            }
            //else disposed is true
            _Disposed = true;
        }

        ~Student()
        {
            Console.WriteLine($"Finalize Student from thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
