using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCons
{
    public class Consumer
    {
        private CommonData data;
        private Thread? t;
        public Consumer(CommonData data)
        {
            this.data = data;
        }

        public void Start()
        {
            if (!(t?.IsAlive ?? false))
            {
                t = new Thread(() =>
                {
                    var fullData = data.GetData();
                    var resultColor = Color.FromArgb(fullData[0], fullData[1], fullData[2]);
                    Console.WriteLine("R={0}, G={1}, B={2}", resultColor.R, resultColor.G, resultColor.B);
                });
                t.Start();
            }
        }
    }
}
