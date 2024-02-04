using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuresAvançades
{

    /// <summary>
    /// Exemple extret de https://tutorials.eu/binary-trees-in-c-sharp/
    /// </summary>
    public class ArbreBinari<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; } = null!;

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
            }
            else
            {
                Root.Add(value);
            }
        }
    }

    public class Node<T> where T : IComparable<T>
    {
        public T Value { get; private set; }
        public Node<T> Left { get; private set; } = null!;
        public Node<T> Right { get; private set; } = null!;

        public Node(T value) => Value = value;

        public void Add(T newValue)
        {
            if (newValue.CompareTo(Value) < 0)
            {
                if (Left == null)
                {
                    Left = new Node<T>(newValue);
                }
                else
                {
                    Left.Add(newValue);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new Node<T>(newValue);
                }
                else
                {
                    Right.Add(newValue);
                }
            }
        }
    }

}
