using System;
using System.Text;


namespace Test_Kudashev
{
    public class ListRandom 
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;
        public string SResult;// вывод резульатат Сериализации
        public string DResult;// вывод резульатат Десериализации

        Random r = new Random();
       
        public void Add (string data) //добавление нового элемента
        {
            if (Count == 0)
            {
                Head = new ListNode();
                Tail = Head;
                Head.Next = null;
                Head.Previous = null;
                Head.Data = data;
                Count++;
            }
            else
            {
                ListNode current = new ListNode();
                current.Next = null;
                current.Previous = Tail;
                Tail.Next = current;
                Tail = current;
                current.Data = data;
                Count++;
            }   
        }
            public void GetRandomLinks() // создаем ссылки на случайные ноды
        {
            ListNode current = new ListNode();
            current = Head;
            while (current!=null)
            {   
                ListNode RandomNode = new ListNode();
                int index = r.Next(0, Count);
                RandomNode = Head;
                int i = 0;
                while (i < index)
                {
                    RandomNode = RandomNode.Next;
                    i++;
                }
                current.Random = RandomNode;
                current = current.Next;
            }
        }
        public string Get (int index) // получение Data элемента по индексу
        {
            List<ListNode> G = new List<ListNode>(); //список нод
            ListNode current = Head;
            int item = 0;
            while (current != null)
            {
                if (item == index)
                    return current.Data;
                item++;
                current = current.Next;
            }
            return null;
        }
            public void Serialize(Stream s)
        {
            List<ListNode> S = new List<ListNode>(); //список нод
            ListNode current = new ListNode();
            current = Head;
            while (current != null) // собираем ноды в список
            {
                S.Add(current);
                current = current.Next;
            }
            var writer = new BinaryWriter(s, Encoding.UTF8, false);
            {
                foreach (ListNode node in S) // сериализуем только Data и Random
                {
                    writer.Write(node.Data + "-" + S.IndexOf(node.Random).ToString());
                    SResult = SResult + "List node: "+ S.IndexOf(node).ToString() + " " + 
                        "Data: " + node.Data+ " " + 
                        "Random: " + S.IndexOf(node.Random).ToString()+"\n";
                }
            }
        }
        public void Deserialize(Stream s)
        {
            var reader = new BinaryReader(s, Encoding.UTF8, false);
            List<ListNode> D = new List<ListNode>();
            ListNode current = new ListNode();
            Count = 0;
            Head = current;
            Head.Previous= null;
                while (reader.PeekChar()>-1)//построение списка, сохранение строки из потока
                {
                    current.Data = reader.ReadString();
                    Count++;
                    ListNode next = new ListNode();
                    current.Next = next;
                    D.Add(current);
                    next.Previous = current;
                    current = next;
                }
            
            Tail = current; 
            Tail.Next = null;

            ListNode counter = new ListNode();
            counter = Head;
            string [] text;
            foreach (ListNode node in D)//преобразование строки в Data и Random
            {
                text = node.Data.Split('-');
                counter.Data = text[0];
                counter.Random = D[Convert.ToInt32(text[1])];
                DResult = DResult + "List node: " +
                    D.IndexOf(node).ToString() + " " +
                    "Data: " + counter.Data + " "+ 
                    "Random: " + Convert.ToInt32(text[1]) + "\n";
                counter = counter.Next;
            }
        }
    }
}
