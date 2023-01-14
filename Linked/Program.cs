
var list = new MyLinkedList<int>();
list.AddLast(20);
list.AddLast(30);
list.AddLast(40);
list.AddLast(100);
list.AddLast(105);
list.AddLast(110);
var m = new MyLinkedList<int>();
m.AddLast(12);
m.AddLast(13);
m.AddLast(14);
list.AddListAsElement(m);

list.PrintList();