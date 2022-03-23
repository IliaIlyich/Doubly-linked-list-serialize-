using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Kudashev
{
    public class ListRandom 
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;
            public void Add (string data) //добавление нового элемента
        {
            if (Count == 0)
            {
                Head = new ListNode();
                Tail = Head;
                Head.Next = null;
                Head.Previous = null;
                Head.Random = Head;
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
            public void AddFirst (string data) // добавление элемнта первым 
            {
            ListNode current = new ListNode();
            ListNode second = Head;
            current.Next = second;
            Head = current;
            if (Count == 0)
                Tail = Head;
            else
                second.Previous = current;
            current.Data = data;
            Count++;
        }
        public string Get (int index) // получение элемента по его положению (индексу) в списке
        {
            ListNode current = Head;
            int item = 1;
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
            ListNode current = this.Head;
            var writer = new BinaryWriter(s, Encoding.UTF8, false);
            {
                writer.Write(current.Data);
                while (current != null)
                {
                    writer.Write(current.Data);
                    current = current.Next;
                }
            }
        }
        public void Deserialize(Stream s)
        {
               var reader = new BinaryReader(s, Encoding.UTF8, false);
                int Count = 0;
                while (reader.PeekChar()>-1)
                {
                if (Count == 0)
                {
                    Head = new ListNode();
                    Tail = Head;
                    Head.Next = null;
                    Head.Previous = null;
                    Head.Random = Head;
                    Head.Data = reader.ReadString();
                    Count++;
                }
                else
                {
                    ListNode current = new ListNode();
                    current.Next = null;
                    current.Previous = Tail;
                    Tail.Next = current;
                    Tail = current;
                    current.Data = reader.ReadString();
                    Count++;
                }
            }
        }
    }
}
