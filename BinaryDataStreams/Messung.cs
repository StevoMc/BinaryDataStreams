using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDataStreams
{
    public class Messung
    {
        private long messwert1;
        private double messwert2;
        private ushort messwert3;
        private bool messwert4;

        public long Messwert1 { get => messwert1; set => messwert1 = value; }
        public double Messwert2 { get => messwert2; set => messwert2 = value; }
        public ushort Messwert3 { get => messwert3; set => messwert3 = value; }
        public bool Messwert4 { get => messwert4; set => messwert4 = value; }

        public override string ToString()
        {
            return $"{messwert1};{messwert2};{messwert3};{messwert4}";
        }
    }
}
