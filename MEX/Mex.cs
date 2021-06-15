
using System;
using System.Collections.Generic;
namespace MEX
{
    public class Mex
    {
        public static int FindMex(IEnumerable<int> collection)
        {
            SortedDictionary<int, LinkedList<int>> roots = new SortedDictionary<int, LinkedList<int>>();
            Dictionary<int, LinkedList<int>> apex = new Dictionary<int, LinkedList<int>>();
            foreach (int i in collection)
            {
                int n = i + 1;
                int k = i - 1;
                //-- If the number is less than one of the previously found series,
                //-- add it to the beginning of the series.
                if (roots.ContainsKey(n))
                {
                    var chain = roots[n];
                    chain.AddFirst(i);      //-- O(1)
                    ChangeKey(n, i, roots); //-- O(log(roots.Count))
                    //-- merge two chains
                    if (apex.ContainsKey(k)) //-- O(1)
                    {
                        apex.Remove(chain.Last.Value);  //--O(1)
                        apex[k].AppendToLast(chain);    //-- O(1)
                        ChangeKey(k, chain.Last.Value, apex); //-- O(1)
                        roots.Remove(i); //-- O(1)
                    }
                }
                //-- If the number is less than one of the previously found series,
                //-- add it to the beginning of the series.
                else if (apex.ContainsKey(k))
                {
                    var chain = apex[k];
                    chain.AddLast(i);
                    ChangeKey(k, i, apex);
                }
                //-- If there are no series where you can add a number, create a new series from this number
                else
                {
                    var chain = new LinkedList<int>();
                    chain.AddLast(i);
                    roots.Add(i, chain);
                    apex.Add(i, chain);
                }
            }
            //-- The missing number is either zero or following the first series.
            foreach (var kvp in roots)
            {
                var firstChain = kvp.Value;
                if (firstChain.First.Value != 0)
                    return 0;
                return firstChain.Last.Value + 1;
            }
            throw new Exception("empty collection");
        }
        /// <summary>
        /// Changes the value key to a new one
        /// </summary>
        private static void ChangeKey<TKey, TValue>(TKey oldKey, TKey newKey, IDictionary<TKey, TValue> dictionary)
        {
            TValue chain = dictionary[oldKey];
            dictionary.Remove(oldKey);
            dictionary.Add(newKey, chain);
        }
    }

    public static class LinkedListExtension
    {
        /// <summary>
        /// Merge two LinkedLists by attaching the last LinkedList to the end of the first one
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="appendList"></param>
        public static void AppendToLast<T>(this LinkedList<T> list, LinkedList<T> appendList)
        {
            //-- Yes, LinkedList is sucks! Yes, append operation requires full enumerated
            for (LinkedListNode<T> node = appendList.First; node != null; node = node.Next)
            {
                list.AddLast(node.Value);
            }
        }
    }
    public class MainListNode<T>
    {
        public MainListNode<T> Next { get; set; }
        public MainListNode<T> Preview { get; set; }
        public T Value { get; set; }
        public MainListNode(T value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $"Node<{Value}>";
        }
    }

    
}
