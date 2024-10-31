using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FILLING_IN_POLYGONS
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen DrawPen = new Pen(Color.Black, 1);
        List<Point> VertexList = new List<Point>();
        private bool isCW = false; // Ориентация многоугольника 
        bool type;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics(); //инициализация графики
        }

        // Обработчик события выбора цвета
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (colorSelection.SelectedIndex) // выбор цвета
            {
                case 0:
                    DrawPen.Color = Color.Black;
                    break;
                case 1:
                    DrawPen.Color = Color.Red;
                    break;
                case 2:
                    DrawPen.Color = Color.Green;
                    break;
                case 3:
                    DrawPen.Color = Color.Blue;
                    break;
            }
        }

        // Очистка окна
        private void btClear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            VertexList.Clear();
        }

        // Обработчик события
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int i = VertexList.Count;
            VertexList.Add(new Point() { X = e.X, Y = e.Y });
            g.DrawEllipse(DrawPen, e.X - 2, e.Y - 2, 5, 5);

            if (VertexList.Count > 1)
            {
                g.DrawLine(DrawPen, VertexList[i - 1], VertexList[i]);
            }

            if (e.Button == MouseButtons.Right) // Конец ввода
            {
                g.DrawLine(DrawPen, VertexList[i], VertexList[0]);
            }

        }

        // Обработчик события выбора типа закрашивания
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (fillType.SelectedIndex) // выбор режима вывода
            {
                case 0:
                    type = true;
                    break;
                case 1:
                    type = false;
                    break;
            }
        }

        private void PaintOver_Click(object sender, EventArgs e)
        {
            if (type)
            {
                orientedPainting();
            }
            else coloringAlgorithm();
        }

        private void coloringAlgorithm()
        {

            if (VertexList.Count > 2)
            {
                // Поиск Ymin и Ymax
                int Ymin = VertexList[0].Y;
                int Ymax = VertexList[0].Y;
                foreach (var point in VertexList)
                {
                    if (point.Y < Ymin) Ymin = point.Y;
                    if (point.Y > Ymax) Ymax = point.Y;
                }

                // Пробегаем по каждой строке от Ymin до Ymax
                for (int Y = Ymin; Y <= Ymax; Y++)
                {
                    List<int> Xb = new List<int>(); // Список пересечений X

                    // Поиск пересечений текущей строки Y со сторонами многоугольника
                    for (int i = 0; i < VertexList.Count; i++)
                    {
                        int k = 0;
                        if (i < VertexList.Count - 1)
                        {
                            k = i + 1;
                        }

                        Point Pi = VertexList[i];
                        Point Pk = VertexList[k];

                        // Условие пересечения строки Y со стороной Pi Pk
                        if ((Pi.Y < Y && Pk.Y >= Y) || (Pi.Y >= Y && Pk.Y < Y))
                        {
                            // Вычисляем координату X пересечения
                            int xIntersect = Pi.X + (Y - Pi.Y) * (Pk.X - Pi.X) / (Pk.Y - Pi.Y);
                            Xb.Add(xIntersect); // Добавляем в список пересечений
                        }
                    }

                    // Сортируем пересечения по X
                    Xb.Sort();

                    // Закрашиваем сегменты
                    for (int j = 0; j < Xb.Count; j += 2)
                    {
                        if (j + 1 < Xb.Count)
                        {
                            g.DrawLine(DrawPen, Xb[j], Y, Xb[j + 1], Y);
                        }
                    }
                }
            }
        }

        // алгоритм закрашивания ориентированного многогранника
        private void orientedPainting()
        {
            if (VertexList.Count > 2)
            {
                // Шаг 1: Найти Ymin и Ymax
                int Ymin = VertexList.Min(p => p.Y);
                int Ymax = VertexList.Max(p => p.Y);
                int w = pictureBox1.Width;
                int h = pictureBox1.Height;

                // Шаг 2: Проверить ориентацию CW
                isCW = CalculatePolygonOrientation();

                if (isCW)
                {
                    //Если CW, то строки области вывода от 0 до Ymin и от Ymax до Yemax закрасить целиком
                    for (int j = 0; j < Ymin; j++)
                    {
                        g.DrawLine(DrawPen, 0, j, w, j);
                    }
                    for (int j = Ymax; j < h; j++)
                    {
                        g.DrawLine(DrawPen, 0, j, w, j);
                    }
                }
                // Шаг 3: Закрасить от Ymin до Ymax
                for (int Y = Ymin; Y <= Ymax; Y++)
                {
                    List<int> Xl = new List<int>(); // Левая граница
                    List<int> Xr = new List<int>(); // Правая граница

                    // Шаг 4: Найти пересечения с текущей строкой Y
                    for (int i = 0; i < VertexList.Count; i++)
                    {
                        int k = 0;
                        if (i < VertexList.Count - 1)
                        {
                            k = i + 1;
                        }
                        Point Pi = VertexList[i];
                        Point Pk = VertexList[k];

                        // Условие пересечения строки Y со стороной Pi Pk
                        if ((Pi.Y < Y && Pk.Y >= Y) || (Pi.Y >= Y && Pk.Y < Y))
                        {
                            int xIntersect = Pi.X + (Y - Pi.Y) * (Pk.X - Pi.X) / (Pk.Y - Pi.Y);

                            if ((Pk.Y - Pi.Y) > 0)
                            {
                                Xr.Add(xIntersect);
                            }
                            else
                            {
                                Xl.Add(xIntersect);
                            }
                        }
                    }

                    if (isCW)
                    {
                        Xl.Add(w);
                        Xr.Add(0);
                    }

                    // Шаг 5: Сортировать пересечения
                    Xl.Sort();
                    Xr.Sort();

                    for (int j = 0; j < Xl.Count && j < Xr.Count; j++)
                    {
                        if (isCW)
                        {
                            g.DrawLine(DrawPen, Xr[j], Y, Xl[j], Y);
                        }
                        else
                        {
                            g.DrawLine(DrawPen, Xl[j], Y, Xr[j], Y);
                        }
                    }
                }
            }
        }



        // Метод для вычисления ориентации многоугольника
        private bool CalculatePolygonOrientation()
        {
            int sum = 0;
            for (int i = 0; i < VertexList.Count; i++)
            {
                int k = (i + 1) % VertexList.Count;
                Point Pi = VertexList[i];
                Point Pk = VertexList[k];
                sum += (Pk.X - Pi.X) * (Pk.Y + Pi.Y);
            }
            return sum < 0;
        }
    }
}