using System;
using System.Threading;
using System.Threading.Tasks;

namespace RaceConditionSample
{
    public class Solution
    {
        public static void Show()
        {
            // Here, we try to "GetOrCreateRow" with Id 3. (1 and 2 are already taken)
            // We invoke 3 such operations in parallel
            // Since there *IS* a lock on this shared resource, only the first thread creates, and the others simply read it.
            
            var id = 3;
            var op = new LockedOperation();

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