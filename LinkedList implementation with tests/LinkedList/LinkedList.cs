using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }

    private Node head;
    private Node tail;

    public void AddFirst(T item)
    {
        Node oldHead = this.head;

        this.head = new Node(item);
        this.head.Next = oldHead;

        if(this.Count == 0)
        {
            this.tail = this.head;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node oldTail = this.tail;

        this.tail = new Node(item);

        if (this.Count == 0)
        {
            this.head = this.tail;
        }
        else
        {
            oldTail.Next = this.tail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if(this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        Node oldHead = this.head;

        this.head = this.head.Next;
        this.Count--;

        if(this.Count == 0)
        {
            this.tail = null;
        }

        return oldHead.Value; 
    }

    public T RemoveLast()
    {
        if(this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        Node oldTail = this.tail;

        if(this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            Node newTail = this.SecondToLastNode();
            newTail.Next = null;
            this.tail = newTail;
        }

        this.Count--;

        return oldTail.Value;
    }

    private Node SecondToLastNode()
    {
        Node current = this.head;

        while(current.Next != this.tail)
        {
            current = current.Next;
        }

        return current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node currnet = this.head;

        while(currnet != null)
        {
            yield return currnet.Value;
            currnet = currnet.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value; 
        }
    }
}
