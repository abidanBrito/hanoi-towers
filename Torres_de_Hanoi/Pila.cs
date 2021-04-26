using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Pila
    {
        public int Size { get; set; } = 0;
        public int Top { get; set; } = 0;

        // List over array for variable-length 1D vectors.
        // You "can't repeat elements" in a list.
        public List<Disco> Elementos { get; set; }

        public Pila() 
        {
            Elementos = new List<Disco>();
        }

        public Pila(uint n) 
        {
            Elementos = new List<Disco>();

            Disco iter;
            for (int i = (int) n; i >= 1; --i) 
            {
                iter = new Disco(i);
                Elementos.Add(iter);
                Top = iter.Valor;
                Size++;
            }
        }

        public void push(Disco d)
        {
            Elementos.Add(d);
            Top = d.Valor;
            Size++;
        }

        public Disco pop()
        {
            if (!isEmpty())
            {
                Disco last = Elementos[--Size];
                Elementos.RemoveAt(Size);
                Top = !isEmpty() ? Elementos[Size - 1].Valor : 0;

                return last;
            }

            return null;
        }

        public bool isEmpty()
        {
            return (Elementos.Count == 0 || Size <= 0);
        }
    }
}
