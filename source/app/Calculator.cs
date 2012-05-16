using System;
using System.Data;
using System.Linq;
using System.Security;
using System.Threading;

namespace app
{
    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection)
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
            ensure_has_role("anything");
        }

        static void ensure_has_role(string role)
        {
            if (!Thread.CurrentPrincipal.IsInRole(role))
                throw new SecurityException();
        }
    }
}