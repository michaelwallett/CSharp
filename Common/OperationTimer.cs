using System;
using System.Diagnostics;

namespace Common
{
    public class OperationTimer : IDisposable
    {
        private readonly string _text;
        private readonly int _collectionCount;
        private readonly Stopwatch _stopwatch;

        public OperationTimer(string text)
        {
            PrepareForOperation();

            _text = text;
            _collectionCount = GC.CollectionCount(0);
            _stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _stopwatch.Stop();

            Console.WriteLine("{0} milliseconds (GCs = {1}) {2}", _stopwatch.ElapsedMilliseconds, GC.CollectionCount(0) - _collectionCount, _text);
        }

        private void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}