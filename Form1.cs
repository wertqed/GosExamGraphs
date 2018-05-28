using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GosExamGrafs
{
    public partial class Form1 : Form
    {
        int[][] matrix = new int[][]
            {
                new int[] {0, 0 , 1 , 0, 0 ,1},
                new int[] {0, 0 , 0 , 1, 0 ,0},
                new int[] {1, 0 , 0 , 0, 1 ,0},
                new int[] {0, 1 , 0 , 0, 0 ,1},
                new int[] {0, 0 , 1 , 0, 0 ,1},
                new int[] {1, 0 , 0 , 1, 1 ,0},
            };
        string tmpStr = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Queue<int> q = new Queue<int>(); //Это очередь, хранящая номера вершин
            int u = 1; //C какой вершины начинать обход
            bool[] used = new bool[6];  //массив отмечающий посещённые вершины
            used[u] = true;     //массив, хранящий состояние вершины(посещали мы её или нет)
            string str = "";

            q.Enqueue(u);

            str+= "Начинаем обход с "+ (u + 1).ToString()+ " вершины\n";
            while (q.Count != 0)
            {
                u = q.Peek();
                q.Dequeue();
                str+="Перешли к узлу " + (u + 1).ToString()+ "\n";
                for (int i = 0; i < matrix.Length; i++)
                {
                    //!!!!!!!!!Сейчас это просто алгоритм обхода графа, для поиска что-то подобное!!!!!!
                    //if (i == 2 && Convert.ToBoolean(matrix[u][i])) //вершина для поиска
                    //{
                    //    str += "Нашли 3 вершину!";
                    //    MessageBox.Show(str);
                    //    return;
                    //}
                    if (Convert.ToBoolean(matrix[u][i]))
                    {
                        if (!used[i]) // проверяем вершину на использование
                        {
                            used[i] = true;
                            q.Enqueue(i);
                            str+="Добавили в очередь узел "+ (i + 1).ToString()+ "\n";
                        }
                    }
                }
            }
            MessageBox.Show(str);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(int[] temp in matrix)
            {
                foreach(int t in temp)
                {
                    this.richTextBox1.Text += t + " ";
                }
                this.richTextBox1.Text += "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            poiskVGlubinu(1);
            MessageBox.Show(tmpStr);
        }

        bool[] used = new bool[6];

        private void poiskVGlubinu(int vershina)
        {
            used[vershina] = true;
            tmpStr += "Зашли в вершину "+ (vershina + 1) + "\n";
            for(int i=0;i<matrix[vershina].Length;i++)
            {
                if (!used[i])
                {
                    poiskVGlubinu(i);
                }
            }
        }
    }
}
