using System;
using System.Drawing;

namespace InternalSort_n11b_
{
    public class Circle
    {
        public int Radius { get; private set; }
        public SolidBrush Brush { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Number Number { get; private set; }
        public Graphics Graphics { get; private set; }
        public Color DEFAULT_COLOR = Color.BurlyWood;

        public Circle(int r, int x, int y, Number number, Graphics graphics)
        {
            Brush = new SolidBrush(DEFAULT_COLOR);
            Radius = r;
            X = x;
            Y = y;
            Number = number;
            Graphics = graphics;
        }


        /// <summary>
        /// отрисовка круга с числом
        /// </summary>
        public void Draw()
        {
            Graphics.FillEllipse(Brush, X, Y, 2 * Radius, 2 * Radius);
            int rang = (int)Math.Log10(Number.Value + 1) + 1;
            Graphics.DrawString(Number.ToString(), Number.Font, Number.Brush, X + Radius - (14 * rang) / 2 + rang, Y + Radius - (int)(14 / 5.0 * 4.0));
        }

        /// <summary>
        /// Изменение цвета круга
        /// </summary>
        /// <param name="newColor">Новый цвет</param>
        public void ChangeColor(Color newColor)
        {
            Brush.Color = newColor;
            Draw();
        }

        /// <summary>
        /// Очистка круга
        /// </summary>
        public void Clear()
        {
            Graphics.FillEllipse(new SolidBrush(Color.White), X, Y, 2 * Radius, 2 * Radius);
        }

        /// <summary>
        /// Передвинуть круг
        /// </summary>
        /// <param name="dx">Изменение X координаты</param>
        /// <param name="dy">Изменение Y координаты</param>
        public void MoveOn(int dx, int dy)
        {
            Brush = new SolidBrush(DEFAULT_COLOR);
            Clear();
            X += dx;
            Y += dy;
            Draw();
        }
    }
}
