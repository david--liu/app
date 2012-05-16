using System;
using System.Data;
using System.Linq;
using System.Security;
using System.Threading;

namespace app
{
    public interface ICalculate
    {
        int add(int first, int second);
        void turn_off();
    }

    public class Calculator : ICalculate
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection,int number,Action item2,Action item3)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            ensure_all_are_positive(first, second);

            using(connection)
            using (var command = connection.CreateCommand())
            {
                
                connection.Open();
                command.ExecuteNonQuery();
            }
            return first + second;
        }

        static void ensure_all_are_positive(params int[] numbers)
        {
            if (numbers.Any(x => x < 0)) throw new ArgumentException("we cant handle negatives");
        }

        public void turn_off()
        {
            if (! Thread.CurrentPrincipal.IsInRole("sdfsdfd")) throw new SecurityException();
        }

    }
}