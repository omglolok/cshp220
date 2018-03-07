using System;
using System.Linq;

namespace ExploreGenerics
{
    public class MyStack<T>
    {
        T[] stack = new T[10];
        int sp;

        public bool IsEmpty
        {
            get
            {
                return sp == 0;
            }
        }

        public void Push(T item)
        {
            stack[sp++] = item;
        }

        public T Pop()
        {
            return stack[--sp];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<object>();

            stack.Push(1);
            stack.Push(2);
            stack.Push("hihi");

            while (!stack.IsEmpty)
            {
                var number = stack.Pop();
                Console.WriteLine("Last value popped = {0}", number);
            }

            Console.ReadLine();
        }
    }
}
