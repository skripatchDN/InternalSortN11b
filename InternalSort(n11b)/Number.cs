using System.Drawing;

namespace InternalSort_n11b_
{
    public class Number
    {
        public int Value { get; private set; }

        public Font Font { get; private set; }

        public SolidBrush Brush { get; private set; }

        public Number(int value, Color color, Font font)
        {
            Value = value;
            Font = font;
            Brush = new SolidBrush(color);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

    }
}
