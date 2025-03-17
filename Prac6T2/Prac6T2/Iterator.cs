using System;
using System.Collections.Generic;
using System.Text;

namespace L7Ex2
{
    class WRAV201Iterator
    {
        public virtual bool HasMoreElements()
        //Post Condition: returns true if there are more elments in the list to visit. This method should be O(1)
        {
            WRAV201List ll = new WRAV201List();
            bool isEmpty = false;

            if (ll == null)
            {
                isEmpty = true;

                return isEmpty;
            }
            else
                return ll.GetFirst() != null;
        }

        public virtual Object GetNextElement()
        //Post Condition: returns the next element in the list. If the list contains no more elements then return null. This method should be O(1)
        {
            Object Item = new Object();
            WRAV201List list = new WRAV201List();

            int prev = 0;

            var nextIndex = list.GetAt(prev + 1);

            if(nextIndex == null)
            {
                return null;
            }
            else
            {
                return list.GetAt((int)nextIndex);
            }

            
        }
    }

    // Place the code for the two classes you have to write for Task 3 here. Or place each class in its own file if you prefer. 
}
