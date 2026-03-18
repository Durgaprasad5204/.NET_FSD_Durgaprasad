using System;

namespace ConsoleApp1
{
    class StackUndo
    {
        string[] stack;
        int top;
        int size;

        public StackUndo(int size)
        {
            this.size = size;
            stack = new string[size];
            top = -1;
        }

        // PUSH Operation (Add Action)
        public void Push(string action)
        {
            if (top == size - 1)
            {
                Console.WriteLine("Stack Overflow (No more actions can be stored)");
                return;
            }

            top++;
            stack[top] = action;
            Console.WriteLine("Action Added: " + action);
            Display();
        }

        // POP Operation (Undo Action)
        public void Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow (Nothing to undo)");
                return;
            }

            Console.WriteLine("Undo Action: " + stack[top]);
            top--;
            Display();
        }

        // Display Current State
        public void Display()
        {
            if (top == -1)
            {
                Console.WriteLine("Current State: Empty");
                return;
            }

            Console.WriteLine("Current State After Operation:");
            for (int i = 0; i <= top; i++)
            {
                Console.WriteLine(stack[i]);
            }
            Console.WriteLine();
        }
    }



    class Program
    {

        static void Main(string[] args)
        {
            StackUndo editor = new StackUndo(5);

            editor.Push("Type A");
            editor.Push("Type B");
            editor.Push("Type C");

            editor.Pop();
            editor.Pop();

            Console.ReadLine();
        }


    }
}