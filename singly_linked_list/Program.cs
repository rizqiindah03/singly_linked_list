﻿using System;
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

        

    }
}

