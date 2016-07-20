using System;
using System.Threading;
using System.Threading.Tasks;

namespace RaceConditionSample
{
    public class Problem
    {
        public static void Describe()
        {
            // Here, we try to "GetOrCreateRow" with Id 3. (1 and 2 are already taken)
            // We invoke 3 such operations in parallel
            // Since there is no lock on this shared resource, each thread creates the Row with Id 3; cause the data to be duplicated (well, triplicate in this case)
            
            var id = 3;
            var op = new NoLockOperation();

            Parallel.Invoke(
                () =>
                    {
                        op.GetOrCreateRow(id);
                    },
                () =>
                    {
                        op.GetOrCreateRow(id);
                    },
                () =>
                    {
                        op.GetOrCreateRow(id);
                    });

            Console.WriteLine("Sleeping for 5 seconds..");
            Thread.Sleep(5000); // Wait for all operations to complete and then display all the rows
            op.List();
        }
    }
}
