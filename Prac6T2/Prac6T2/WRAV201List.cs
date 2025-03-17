using System;
using System.Collections.Generic;
using System.Text;

namespace L7Ex2
{
    class WRAV201List
    {
        public static int NumberOfInstances = 0;    //This counter will store the number of times this class (or its descendants) were instantiated
        protected int Size = 0;     //The number of items currently in the list

        public WRAV201List()
        {
            NumberOfInstances++;    //A new instance was created
        }
        public virtual Object GetFirst()
        //Post Condition:  The first element in the list is returned. If the list is empty, null is returned
        {
            return null;
        }

        public virtual Object GetLast()
        //Post Condition:  The last element in the list is returned. If the list is empty, null is returned
        {
            return null;
        }

        public virtual Object GetAt(int pos)
        //Post Condition:  The element at position pos in the list is returned. If there are fewer than pos+1 elements in the list then null is returned
        {
            return null;
        }

        public virtual void InsertAtFirst(Object cargo)
        //Post Condition: The object cargo is inserted in the front of the list (all other elements are shifted one position down the list)
        {
        }

        public virtual void InsertAtLast(Object cargo)
        //Post Condition: The object cargo is inserted at the end of the list
        {
        }

        public virtual bool InsertAt(int pos, Object cargo)
        //Post Condition: The object cargo is inserted at position pos in the list. All existing elements from pos are shifted one position down the list).  True is returned if successful.
        //There must be at least pos elements in the list otherwise false is returned. 
        {
            return false;
        }

        public virtual Object Search(Object find)
        //Post Condition: The list is traversed and the first object for which .Equals(find) is true is returned. If no such object is found then null is returned.
        {
            return null;
        }

        public virtual Object DeleteFirst()
        //Post Condition: The first object in the list is removed and returned. If the list is empty then null is returned.
        {
            return null;
        }

        public virtual Object DeleteLast()
        //Post Condition: The last object in the list is removed and returned. If the list is empty then null is returned.
        {
            return null;
        }

        public virtual Object DeleteAt(int pos)
        //Post Condition: The object at position pos in the list is removed and returned. If there is no object at pos then null is returned.
        {
            return null;
        }

        public int Count()
        //Post Condition: The number of elments in the list is returned.    
        {
            return Size;
        }

        public virtual WRAV201Iterator GetIterator()
        //Post Condition: Returns a WRAV201Iterator that can be used to traverse the list
        {
            return null;
        }
    }
}
