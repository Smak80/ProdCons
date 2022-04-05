using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCons;

public enum ProdType
{
    Red, Green, Blue
}
public class Producer
{
    private Thread? t;
    private Random r = new ();
    private CommonData data;
    public ProdType Type { get; set; }

    public Producer(ProdType type, CommonData data)
    {
        Type = type;
        this.data = data;
    }

    public void Start()
    {
        if (!(t?.IsAlive ?? false))
        {
            t = new Thread(() =>
            {
                int i = 0;
                while (i < 10)
                {
                    var max = (Type == ProdType.Green) ? 2000 : 5000;
                    Thread.Sleep(r.Next(1000, max));
                    int partialData = r.Next(255);
                    Console.WriteLine("Type: {0}, ColorComponent: {1}", Type, partialData);
                    data.PutData(partialData, Type);
                    i++;
                }
            });
            t.Start();
        }
    }
}
