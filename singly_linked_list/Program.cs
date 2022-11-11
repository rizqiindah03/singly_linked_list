using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace singly_linked_list
{
    //each node consist of the information part and link to the next node
    class node
    {
        public int rollNumber;
        public string name;
        public node next;
    }
    class list
    {
        node START;

        public list()
        {
            START = null;
        }
        public void addNote() // add a node in the list
        {
            int nim;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student : ");
            nm = Console.ReadLine();
            node newnode = new node();
            newnode.rollNumber = nim;
            newnode.name = nm;
            //if the node to be inserted is the first node
            if (START == null || nim <= START.rollNumber) ;
            {
                if ((START != null) && (nim == START.rollNumber)) ;
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            // locate the position of the new node in the list
            node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nim >= current.rollNumber))
            {
                if (nim == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            //*once the above for loop is executed, prev and current are positioned in such a Imanner that the position for the new node */
            newnode.next = current;
            previous.next = newnode;

        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nlist is empt.\n");
            else
            {
                Console.WriteLine("\nThe records in teh list are: ");
                node currentnode;
                for (currentnode = START; currentnode != null;
                    currentnode = currentnode.next)

                    Console.Write(currentnode.rollNumber + "" + currentnode.name + "\n");

                Console.WriteLine();

            }
        }
        public bool delNode(int nim)
        {
            node previous, current;
            previous = current = null;
            //check if the spesified node is present in the list or not
            if (Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        public bool Search(int rollNo, ref node previous, ref node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (rollNo != current.rollNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        class Program
        {
            // check wheter the specified node is present in the list or not 

            static void Main(string[] args)
            {
                list obj = new list();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMENU");
                        Console.WriteLine("1. Add a record to the list ");
                        Console.WriteLine("2. Delete a record form the list");
                        Console.WriteLine("3. View all the records in the list ");
                        Console.WriteLine("4. Search for a records in the list ");
                        Console.WriteLine("5. EXIT ");
                        Console.Write("\nEnter your choice ( 1- 5) : ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addNote();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.listEmpty())
                                    {
                                        Console.WriteLine("\nlist is empty");
                                        break;
                                    }
                                    Console.Write("\nEnter the roll number of" +
                                        " the student whose records is to be deleted :");
                                    int nim = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (obj.delNode(nim) == false)
                                        Console.WriteLine("\n Records not found.");
                                    else
                                        Console.WriteLine("Records with roll number "
                                            + nim + "Deleted");
                                }
                                break;
                            case '3':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '4':
                                {
                                    if (obj.listEmpty() == true )
                                    {
                                        Console.WriteLine("\nlist is empty");
                                        break;
                                    }
                                    node previous, current;
                                    previous = current = null;
                                    Console.Write("\nEnter the roll number of the " +
                                        "student whose record is to be searched: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref previous, ref current) == false)
                                        Console.WriteLine("\nRecord not found.");
                                    else
                                    {
                                        Console.WriteLine("\nRecord found");
                                        Console.WriteLine("\nRoll number: " + current.rollNumber);
                                        Console.WriteLine("\nname: " + current.name);
                                    }
                                }
                                break;
                        }
                    }
                    
                }
            }
        }

    }
}

