using System.Collections.Generic;
using System.Linq;

namespace code_kata.integer_stack
{
    public class IntegerStack : IStack
    {
        List<int> stacks;

        public IntegerStack() : this(new List<int>())
        {
            
        }

        public IntegerStack(List<int> stacks)
        {
            this.stacks = stacks;
        }

        public int pop()
        {
            if (stacks.Count > 0)
            {
                var value = stacks[stacks.Count - 1];
                stacks.RemoveAt(stacks.Count -1);
                return value;
            }
            else return 0;
        }

        public void push(int value)
        {
            stacks.Add(value);
        }

        public int count()
        {
            return stacks.Count;
        }
    }
}