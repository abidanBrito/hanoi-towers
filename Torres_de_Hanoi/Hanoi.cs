using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Hanoi
    {
        private uint movements = 0;

        public void mover_disco(Pila a, Pila b)
        {
            if (a.Top == b.Top) // Edge case (both are empty)
            {
                return; 
            }
            else if (a.Top > b.Top)
            {
                if (b.isEmpty()) { b.push(a.pop()); }
                else { a.push(b.pop()); }

            }
            else
            {
                if (a.isEmpty()) { a.push(b.pop()); }
                else { b.push(a.pop()); }
            }

            movements++;
        }

        public uint iterativo(uint n, Pila ini, Pila fin, Pila aux)
        {
            if (n == 0) { return movements; }   // Edge case
            
            else if (!isEven(n))
            {
                while (!isSolved(fin, n))
                {
                    mover_disco(ini, fin);
                    if (isSolved(fin, n)) { break; }
                    mover_disco(ini, aux);
                    mover_disco(aux, fin);
                    if (isSolved(fin, n)) { break; }
                }
            }
            else
            {
                while (!isSolved(fin, n))
                {
                    mover_disco(ini, aux);
                    mover_disco(ini, fin);
                    if (isSolved(fin, n)) { break; }
                    mover_disco(aux, fin);
                    if (isSolved(fin, n)) { break; }
                }
            }

            return movements;
        }

        public uint recursivo(uint n, Pila ini, Pila fin, Pila aux) 
        {
            if (n == 0) { return movements; }       // Edge case
            if (n == 1) { mover_disco(ini, fin); }  // Base case
            else
            {
                recursivo(n - 1, ini, aux, fin);
                mover_disco(ini, fin);
                recursivo(n - 1, aux, fin, ini);
            }

            return movements;
        }

        public bool isSolved(Pila p, uint n)
        {
            return (p.Size == n);
        }

        public bool isEven(uint val)
        {
            return (val % 2 == 0);
        }
    }
}