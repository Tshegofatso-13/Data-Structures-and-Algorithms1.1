using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace L7Ex2
{
    class WRAV201ArrayList : WRAV201List
    {
        private int MaxSize = 10;       //Initially the array will have space for 10 elements.
        private Object[] array;
        public WRAV201ArrayList() : base()
        {
            array = new Object[MaxSize];
        }

        public override Object GetFirst()
        {
            if (Size == 0) return null;
            else return array[0];
        }

        public override Object GetLast()
        {
            if (Size == 0) return null;
            else return array[Size - 1];
        }

        public override Object GetAt(int pos)
        {
            if (pos >= Size) return null;
            else return array[pos];
        }

        public override void InsertAtFirst(Object cargo)
        {
            if (Size == MaxSize) DoubleMaxSize();       //Make sure there is space for the new element

            for (int i = Size; i > 0; i--)          //Shift all elements one space down
            {
                array[i] = array[i - 1];
            }
            array[0] = cargo;
            Size++;
        }

        public override void InsertAtLast(Object cargo)
        {
            if (Size == MaxSize) DoubleMaxSize();       //Make sure there is space for the new element

            array[Size] = cargo;
            Size++;
        }

        public override bool InsertAt(int pos, Object cargo)
        {
            if (Size == MaxSize) DoubleMaxSize();       //Make sure there is space for the new element

            if (pos > Size) return false;               //There is not at least pos elements in the list
            else
            {
                for (int i = Size; i > pos; i--)        //Shift the appropriate number of elements to make space at pos
                {
                    array[i] = array[i - 1];
                }
                array[pos] = cargo;
                Size++;
                return true;
            }
        }

        public override Object Search(Object find)
        {
            for (int i = 0; i < Size; i++)
            {
                if (array[i].Equals(find)) return array[i];         //Use Cargo's Equals() method to check for equality
            }
            return null;
        }

        public override Object DeleteFirst()
        {
            if (Size == 0) return null;         //List is empty. Delete fails
            else
            {
                Object temp = array[0];
                for (int i = 0; i < Size - 1; i++)                 //Shift all the elements up one space
                {
                    array[i] = array[i + 1];
                }
                Size--;
                return temp;
            }
        }

        public override Object DeleteLast()
        {
            if (Size == 0) return null;         //List is empty. Delete fails
            {
                Size--;
                return array[Size];
            }
        }

        public override Object DeleteAt(int pos)
        {
            if (pos >= Size) return null;           //No element at pos. Delete fails
            else
            {
                Object temp = array[0];
                for (int i = pos; i < Size - 1; i++)            //Shift the appropriate number of elements up one space to fill the gap left at pos
                {
                    array[i] = array[i + 1];
                }
                Size--;
                return temp;
            }
        }

        private void DoubleMaxSize()
        // Post Condition: a new array that is double the size of the old array was created and the elements from the old array was copied across. 
        {
            Object[] oldarray = array;
            MaxSize = MaxSize * 2;              //Double the size of the array       
            array = new Object[MaxSize];

            for (int i = 0; i < Size; i++)       //Copy elements across. 
            {
                array[i] = oldarray[i];
            }
        }

        public WRAV201LinkedList GetLinkedListClone()
        // Post Condition: returns an WRAV201LinkedList object that contains the same elements as the current array
        {
            WRAV201ArrayList myAl = new WRAV201ArrayList();
            WRAV201LinkedList ll = new WRAV201LinkedList();
            WRAV201LinkedList temp;

            for(int i = 0; i < myAl.Size; i++)
            {
                temp = (WRAV201LinkedList)myAl.GetAt(i);
                ll.InsertAtLast(temp);
            }

            return ll;
        }
        
        public override WRAV201Iterator GetIterator()
        {
            ArrayList al = new ArrayList();

            // Iterating the elements of al
            foreach (var items in al)
            // Returning the element after every iteration
                yield return items;
            
        }
        public void WRAV201ArrayListIterator()
        {

        }
        
    }
}


