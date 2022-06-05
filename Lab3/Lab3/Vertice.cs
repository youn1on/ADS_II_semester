using System;

namespace Lab3
{
    public class Vertice
    {
        public int MinDistance = Int32.MaxValue;
        public bool Passed = false;
        public int Previous;

        public Vertice()
        {
            Previous = -1;
        }
    }
}