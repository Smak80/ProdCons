// See https://aka.ms/new-console-template for more information

using ProdCons;

var d = new CommonData();

var c = new Consumer(d);
c.Start();
var p1 = new Producer(ProdType.Red, d);
var p2 = new Producer(ProdType.Green, d);
var p3 = new Producer(ProdType.Blue, d);
p1.Start();
p2.Start();
p3.Start();
