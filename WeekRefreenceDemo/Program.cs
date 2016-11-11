#region

using System;
using System.Collections.Generic;

#endregion

namespace WeekRefreenceDemo {

    internal class Program {

        public static void Main() {
            const int cacheSize = 5;
            const int LoopTimes = 100;
            Random r = new Random();
            Cache c = new Cache(cacheSize);
            //string DataName = "";
            GC.Collect(0);
            // Randomly access objects in the cache.
            for (int i = 0; i < LoopTimes; i++) {
                int index = r.Next(c.Count);
                // Access the object by getting a property value.
                string dataName = c[index].Name;
                if (index % 3 == 0) {
                    Console.WriteLine("GC.Collect()");
                    GC.Collect();
                }
            }
            // Show results.
            double regenPercent = c.RegenerationCount / (double)LoopTimes;
            Console.WriteLine("Cache size: {0}, Regenerated: {1:P2}", c.Count, regenPercent);
            Console.ReadKey();
        }

    }

    public class Cache {

        // Dictionary to contain the cache.
        private static Dictionary<int, WeakReference> _cache;

        // Track the number of times an object is regenerated.
        private int regenCount = 0;

        public Cache(int count) {
            _cache = new Dictionary<int, WeakReference>();

            // Add objects with a short weak reference to the cache.
            for (int i = 0; i < count; i++) {
                _cache.Add(i, new WeakReference(new Data(i), false));
            }
        }

        // Number of items in the cache.
        public int Count {
            get {
                return _cache.Count;
            }
        }

        // Number of times an object needs to be regenerated.
        public int RegenerationCount {
            get {
                return regenCount;
            }
        }

        // Retrieve a data object from the cache.
        public Data this[int index] {
            get {
                Data d = _cache[index].Target as Data;
                if (d == null) {
                    // If the object was reclaimed, generate a new one.
                    Console.WriteLine("Regenerate object at {0}: Yes", index);
                    d = new Data(index);
                    _cache[index].Target = d;
                    regenCount++;
                } else {
                    // Object was obtained with the weak reference.
                    Console.WriteLine("Regenerate object at {0}: No", index);
                }
                return d;
            }
        }

    }

    // This class creates byte arrays to simulate data.
    public class Data {

        private byte[] _data;
        private string _name;

        public Data(int size) {
            _data = new byte[size * 1024];
            _name = "Cache_" + size;
        }

        // Simple property.
        public string Name {
            get {
                return _name;
            }
        }

    }

}