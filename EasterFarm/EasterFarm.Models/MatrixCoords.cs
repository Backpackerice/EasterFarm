namespace EasterFarm.Models
{
    using System;

    public struct MatrixCoords
    {
        public readonly int Row, Col;

        public MatrixCoords(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public static bool operator ==(MatrixCoords a, MatrixCoords b)
        {
            return a.Row == b.Row && a.Col == b.Col;
        }

        public static bool operator !=(MatrixCoords a, MatrixCoords b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is MatrixCoords && this == (MatrixCoords)obj;
        }

        public override int GetHashCode()
        {
            return (this.Row << 16) ^ this.Col;
        }
    }
}
