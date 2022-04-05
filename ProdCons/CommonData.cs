using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCons
{
    public class CommonData
    {
        private Queue<int>[] data = {new(), new(), new()};
        private int maxQueueLength = 3;
        public void PutData(int partialData, ProdType type)
        {
            lock (data)
            {
                while (data[(int)type].Count >= maxQueueLength - 1)
                    Monitor.Wait(data);
                data[(int)type].Enqueue(partialData);
                Monitor.PulseAll(data);
            }
        }

        public int[] GetData()
        {
            int[] res = new int[3];
            lock (data)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    while (data[i].Count == 0) Monitor.Wait(data);
                }
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = data[i].Dequeue();
                }
                Monitor.PulseAll(data);
            }
            return res;
        }
    }
}
