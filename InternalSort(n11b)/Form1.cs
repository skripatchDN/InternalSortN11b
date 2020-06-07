/// Лабораторная работа по Структура и алгоритмам. Лаба №11b
/// Выполнил Дюжев Никита, 2 курс, 10 группа
///
/// Реализовать сортировку массива целых чисел методом двухпутевых вставок
/// при использовании следующих дополнительных структур данных:
/// b) двунаправленного списка.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable All

namespace InternalSort_n11b_
{
    public partial class Form1 : Form
    {
        // кол-во элементов в демо-версии
        private const int COUNT = 10;
        // уровни элементов по вертикали
        private const int LEVEL_1 = 30;
        private const int LEVEL_2 = 120;
        private const int LEVEL_3 = 210;
        // скорости элементов 
        private const int DEFAULT_FAST_SPEED = 7;
        private const int DEFAULT_COMPARE_DELAY = 600;
        private const int DEFAULT_SPEED = 3;
        // отступы и размеры кружков
        private const int LEFT_BORDER = 30;
        private const int RADIUS = 20;
        private const int MARGIN = 12;

        Random random = new Random();
        Sorter sorter = new Sorter();
        Graphics graphics;
        Circle[] circles = new Circle[COUNT];
        int[] xCoords = new int[COUNT * 2];
        int[] numbers = new int[COUNT];
        private bool isSorted = false;

        public Form1()
        {
            InitializeComponent();
            graphics = tabPageVisual.CreateGraphics();
            for (int i = 0; i < xCoords.Length; i++)
            {
                xCoords[i] = LEFT_BORDER + i * (MARGIN + RADIUS * 2);
            }

            buttonSort.Enabled = false;
        }

        /// <summary>
        /// Сравнение двух кружков
        /// </summary>
        /// <param name="circle1">Тот круг, который будет двигаться ко второму</param>
        /// <param name="circle2">Круг, с которым сравниваем</param>
        /// <returns>Асинхронный таск</returns>
        private async Task CompareCircleWith(Circle circle1, Circle circle2)
        {
            await MoveUpDown(circle1, LEVEL_2);
            await MoveLeftRight(circle1, circle2.X);
            circle1.ChangeColor(Color.Green);
            circle2.ChangeColor(Color.Green);
            await Task.Delay(DEFAULT_COMPARE_DELAY);
            circle1.ChangeColor(circle1.DEFAULT_COLOR);
            circle2.ChangeColor(circle2.DEFAULT_COLOR);
        }

        /// <summary>
        /// Перемещение кружка по вертикали
        /// </summary>
        /// <param name="circle">Круг</param>
        /// <param name="level">Необходимая y-координата</param>
        /// <param name="speed">Скорость движения</param>
        /// <returns>Асинхронный таск</returns>
        private async Task MoveUpDown(Circle circle, int level, int speed = DEFAULT_SPEED)
        {
            int dy = 1;
            if (circle.Y > level)
                dy = -1;
            int dist = Math.Abs(circle.Y - level);
            for (int i = 0; i < dist / speed; i++)
            {
                circle.MoveOn(0, dy * speed);
                await Task.Delay(1);
            }
        }

        /// <summary>
        /// Перемещение кружка по горизонтали
        /// </summary>
        /// <param name="circle">Круг</param>
        /// <param name="x">Необходимая x-координата</param>
        /// <param name="speed">Скорость движения</param>
        /// <returns>Асинхронный таск</returns>
        private async Task MoveLeftRight(Circle circle, int x, int speed = DEFAULT_SPEED)
        {
            int dx = 1;
            if (x < circle.X)
                dx = -1;
            int dist = Math.Abs(circle.X - x);
            for (int i = 0; i < dist / speed; i++)
            {
                circle.MoveOn(dx*speed, 0);
                await Task.Delay(1);
            }
        }

        /// <summary>
        /// Установка доступности кнопок
        /// </summary>
        /// <param name="value">Доступны ли кнопки</param>
        private void SetButtonsEnabled(bool value = true)
        {
            buttonSort.Enabled = value;
            buttonGenerate.Enabled = value;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку Сортировка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonSort_Click(object sender, EventArgs e)
        {
            SetButtonsEnabled(false);

            Circle[] circlesDown = new Circle[circles.Length * 2];
            int leftIndex = circles.Length;
            int rightIndex = circles.Length;
            int centerIndex = circles.Length;

            List<ActionHandle> actions = sorter.ActionList;
            sorter.DoubleSidedInsertSort(ref numbers);
            foreach (var action in actions)
            {
                if (action.Act == Act.InsertFirstElem)
                {
                    circles[0].DEFAULT_COLOR = Color.Sienna;
                    Console.WriteLine($"InsertFirstElem({centerIndex}, {centerIndex})");
                    await MoveUpDown(circles[0], LEVEL_2);
                    await MoveLeftRight(circles[0], xCoords[centerIndex]);
                    await MoveUpDown(circles[0], LEVEL_3);
                    circlesDown[centerIndex] = circles[0];
                }
                else if (action.Act == Act.Compare)
                {
                    Console.WriteLine($"Compare({action.First}, {action.Second})");
                    await CompareCircleWith(circles[action.First], circlesDown[action.Second]);
                }
                else if (action.Act == Act.InsertLeftIn)
                {
                    Console.WriteLine($"InsertLeftIn({action.First}, {action.Second})");
                    leftIndex--;
                    for (int i = leftIndex+1; i < action.Second+1; i++)
                    {
                        await MoveLeftRight(circlesDown[i], xCoords[i-1]);
                        circlesDown[i - 1] = circlesDown[i];
                    }

                    circlesDown[action.Second] = circles[action.First];
                    await MoveLeftRight(circles[action.First], xCoords[action.Second]);
                    await MoveUpDown(circles[action.First], LEVEL_3);
                }
                else if (action.Act == Act.InsertRightIn)
                {
                    Console.WriteLine($"InsertRightIn({action.First}, {action.Second})");
                    rightIndex++;
                    for (int i = rightIndex; i > action.Second; i--)
                    {
                        await MoveLeftRight(circlesDown[i-1], xCoords[i]);
                        circlesDown[i] = circlesDown[i-1];
                    }

                    circlesDown[action.Second] = circles[action.First];
                    await MoveLeftRight(circles[action.First], xCoords[action.Second]);
                    await MoveUpDown(circles[action.First], LEVEL_3);
                }
                else if (action.Act == Act.MoveBack)
                {
                    await MoveUpDown(circlesDown[leftIndex + action.First], LEVEL_2, DEFAULT_FAST_SPEED);
                    await MoveLeftRight(circlesDown[leftIndex + action.First], xCoords[action.First], DEFAULT_FAST_SPEED);
                    await MoveUpDown(circlesDown[leftIndex + action.First], LEVEL_1, DEFAULT_FAST_SPEED);
                    circles[action.First] = circlesDown[leftIndex + action.First];
                    circles[action.First].ChangeColor(Color.DarkOrange);
                }
            }
            SetButtonsEnabled();
            isSorted = true;
            buttonSort.Enabled = !isSorted;
        }

        /// <summary>
        /// Кнопка Сгенерировать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            GenerateCircles();
        }

        /// <summary>
        /// Процедура генерации новых кругов
        /// </summary>
        private void GenerateCircles()
        {
            graphics.Clear(Color.White);
            Random r = new Random();
            numbers = new int[COUNT];
            for (int i = 0; i < circles.Length; i++)
            {
                numbers[i] = r.Next(99);
                Number number = new Number(numbers[i], Color.White, new Font("Microsoft Sans Serif", 12));
                circles[i] = new Circle(RADIUS, xCoords[i], LEVEL_1, number, graphics);
            }

            foreach (Circle circle in circles)
            {
                circle.Draw();
            }

            isSorted = false;
            buttonSort.Enabled = !isSorted;
        }

        /// <summary>
        /// Кнопка отрисовки графика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartPlot_Click(object sender, EventArgs e)
        {
            ClearChart();
            int step = (int)numericUpDownStep.Value;
            int size = step;
            chartSort.ChartAreas[0].AxisX.Minimum = size;
            chartSort.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(numericUpDownCount.Value);
            
            while (size <= Convert.ToInt32(numericUpDownCount.Value))
            {
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next();
                }

                sorter.DoubleSidedInsertSort(ref array);
                chartSort.Series.ElementAt(0).Points.AddXY(size, (sorter.Compares));
                chartSort.Series.ElementAt(1).Points.AddXY(size, (sorter.LinkAssignments));
                Console.WriteLine($"size: {size} Compares: {sorter.Compares}, links: {sorter.LinkAssignments}");
                size += step;
            }
        }

        /// <summary>
        /// Очистка графиков
        /// </summary>
        private void ClearChart()
        {
            chartSort.Series[0].Points.Clear();
            chartSort.Series[1].Points.Clear();
        }
    }
}
