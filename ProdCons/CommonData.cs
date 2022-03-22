using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCons
{
    public class CommonData
    {
        private int[] data = {-1, -1, -1};
        public void PutData(int partialData, ProdType type)
        {
            lock (data)
            {
                data[(int)type] = partialData;
                Monitor.PulseAll(data);
            }
        }

        public int[] GetData()
        {
            int[]? res;
            lock (data)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    while (data[i] < 0) Monitor.Wait(data);
                }
                res = (int[])data.Clone();
            }
            return res;
        }
    }
}
