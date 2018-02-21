namespace Utilities
{
    internal class Point
    {
        private bool isEmpty;
        public int X { get; set; }
        public int Y { get; set; }
        
        //IsEmpty if x or y is null
        public bool IsEmpty { get => isEmpty; }

        public Point() {
            X = 0;
            Y = 0;
            isEmpty = true;
        }

        public Point (int x, int y)
        {
            X = x;
            Y = y;
            isEmpty = false;
        }

        public override bool Equals(object obj)
        {
            Point that = (Point)obj;
            return X == that.X && Y == that.Y || IsEmpty && that.IsEmpty;
        }
        public override int GetHashCode()
        {
            return X ^ Y;
        }
    }
}