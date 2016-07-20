using System;
using System.Collections.Generic;
using System.Threading;

namespace RaceConditionSample
{
    public class MutexOperation
    {
        static List<Row> rows { get; set; }
        private readonly Mutex mutex;
        public MutexOperation()
        {
            rows = new List<Row>()
            {
                new Row(1, "Row-1"),
                new Row(2, "Row-2")
            };
            mutex = new Mutex();
        }
        public Row GetOrCreateRow(int id)
        {
            var currentThread = Thread.CurrentThread;
            Console.WriteLine("In GetOrCreateRow(" + id + ") | Thread Id : " + currentThread.ManagedThreadId);
            mutex.WaitOne();
            var exists = rows.Exists(e => e.Id == id);
            if (!exists)
            {
                rows.Add(new Row(id, "Row-" + id));
            }
            var firstMatch = rows.Find(e => e.Id == id);
            mutex.ReleaseMutex();
            return firstMatch;
        }
        public void List()
        {
            string csv = "";
            for (int i = 0; i < rows.Count; i++)
            {
                csv += rows[i].Id + ",";
            }
            csv = csv.TrimEnd(',');
            Console.WriteLine("Current state of rows : " + csv);
        }
    }
}