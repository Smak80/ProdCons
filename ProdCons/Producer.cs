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
            t = new Thread(() => {
                Thread.Sleep(r.Next(1000, 15000));
                int partialData = r.Next(255);
                data.PutData(partialData, Type);
            });
            t.Start();
        }
    }
}
