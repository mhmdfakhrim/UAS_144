using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_144
{
    class Node
    {
        public int NIM;
        public string name;
        public int kelas;
        public Node next;
        public Node prev;
    }

    class DoubleLinkedList
    {
        Node START;
        
        public DoubleLinkedList()
        {
            START = null;
        }

        public void addNode()
        {
            int nim;
            string nm;
            int kl;
            Console.Write("\nMasukkan NIM Murid: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Murid: ");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan Kelas Murid: ");
            kl = Convert.ToInt32(Console.ReadLine());
            Node newNode = new Node();
            newNode.name = nm;
            newNode.kelas = kl;
            newNode.NIM = nim;

            if (START == null || kl <= START.kelas)
            {
                if((START != null) && (kl == START.kelas))
                {
                    Console.WriteLine("\nDuplikasi kelas tidak diizinkan");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }

            Node previous, current;
            for(current = previous = START;
                current != null && kl >= current.kelas;
                previous = current, current = current.next)
            {
                if (kl == current.kelas)
                {
                    Console.WriteLine("\nDuplikasi kelas tidak diperbolehkan");
                    return;
                }
            }

            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                newNode.prev = newNode;
                return ;
            }

            current.prev = newNode;
            current.next = newNode;
        }

        public bool search(int rollno, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null && rollno != current.kelas; previous = current, current = current.next) { }
            return (current != null);
        }

        public bool dellNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (search(rollNo, ref previous, ref current) == false)
                return false;

            if (current == null)
            {
                previous.next = null;
                return true;
            }

            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }

            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "roll number are: \n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.kelas + "" + currentNode.name + "\n");
            }
        }

        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nData Kosong");
            else
            {
                Console.WriteLine("\nRecord in the Descending order of" + "Kelasnya adalah: \n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                { }

                while (currentNode != null)
                {
                    Console.Write(currentNode.kelas + "" + currentNode.name + "" + currentNode.NIM + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all records in the ascending order of roll numbers");
                    Console.WriteLine("4. View all records in the descending order of roll numbers");
                    Console.WriteLine("5. Search for a record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.Write("Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nData Kosong");
                                    break;
                                }
                                Console.Write("\nMasukkan Kelas Murid " + "Siapa yang akan dihapus: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.dellNode(rollNo) == false)
                                    Console.WriteLine("Data Tidak Ditemukan");
                                else
                                    Console.WriteLine("Data Kelas " + rollNo + " deleted \n");
                            }
                            break ;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nData Kosong");
                                    break ;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukkan Kelas Murid: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nKelas: " + curr.kelas);
                                    Console.WriteLine("\nName: " + curr.name);
                                    Console.WriteLine("\nNIM: " + curr.NIM);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("checkk for the values entered");
                }
            }
        }
    }
}
