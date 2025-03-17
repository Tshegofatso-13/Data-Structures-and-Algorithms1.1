using System;
namespace Prac2T2
{
    public class Cell
    {
        private Object Element;
        private Cell Link;

        public Cell(Object theElement, Cell theLink)
        {
            Element = theElement;
            Link = theLink;
        }

        public Cell(Object theElement)
        {
            Element = theElement;
            Link = null;
        }

        public Cell()
        {
            Element = null;
            Link = null;
        }

        public Cell next()
        {
            return Link;
        }

        public void setNext(Cell theLink)
        {
            Link = theLink;
        }

        public Object value()
        {
            return Element;
        }

        public void setValue(Object theElement)
        {
            Element = theElement;
        }

        internal void setNext(Node head)
        {
            throw new NotImplementedException();
        }

        internal void setPrevious(Node tail)
        {
            throw new NotImplementedException();
        }
    }
}
