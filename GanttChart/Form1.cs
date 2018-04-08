using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GanttChart
{
    public partial class Form1 : Form
    {
        public float AverageTime = 0;
        public int[] waiting_time;
        public int[] process;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = AverageTime.ToString();
            grdGanttChart.RowCount = 2;
            if (waiting_time.Length > process.Length)
                grdGanttChart.ColumnCount = waiting_time.Length * 2;
            else
                grdGanttChart.ColumnCount = process.Length * 2;

            for (int i = 1, j = 0; j < process.Length; i += 2, j++)
            {
                grdGanttChart[i, 0].Value = "P" + process[j].ToString();
                grdGanttChart[i, 0].Style.BackColor = Color.Aqua;

            }
            for (int i = 0, j = 0; j < waiting_time.Length; i += 2, j++)
            {
                grdGanttChart[i, 1].Value = waiting_time[j].ToString();
            }
        }
    }
}
