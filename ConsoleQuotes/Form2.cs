using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Win32;
using RTDServerQuotes;

namespace ConsoleQuotes
{
    
    public  partial class Form2 : Form
    {
       
        public double min;  
        public double max;
        private double[] cadMrkArray = new double[500];
        private double[] cadBidArray = new double[500];
        private double[] cadAskArray = new double[500];
        
       

        public Form2()
        {
            InitializeComponent();
             ChartUpdateTimer.Enabled = true;

            Load += Form2_Load;

        }

       


        public void Form2_Load(object sender, EventArgs e)
        {

           
            
        }


        public void uploadText(string text)
        {
            label2.Text = text;
        }

        public void cadChartUpdater()
        {
            
            var markSerys = chart1.Series[0].Points;
            var bidSerys = chart1.Series[1].Points;
            var askSerys = chart1.Series[2].Points;
            var cadCrtAra = chart1.ChartAreas[0];

            chart1.Series[1].Points.Clear();

            chart1.Series[1].Points.DataBindY(CadUsdQQ.CadMarkArry);
            
        }
  

         
  
       
      

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void ChartUpdateTimer_Tick(object sender, EventArgs e)
        {
            //cadChartUpdater();
            // updateCadchart();
            double min, max;

            min = CadUsdQQ.CadMarkArry[0];
            max = CadUsdQQ.CadMarkArry[0];


            cadChart.Series[0].Points.Clear();
            for (int i = 0; i < CadUsdQQ.CadMarkArry.Length; i++)
            {

                if (min > CadUsdQQ.CadMarkArry[i])
                    min = CadUsdQQ.CadMarkArry[i];
                if (max < CadUsdQQ.CadMarkArry[i])
                    max = CadUsdQQ.CadMarkArry[i];


                // cadChart.Series[0].Points.DataBindY(CadUsdQQ.CadMarkArry);
                // Series series = chart1.Series.Add(CadUsdQQ.CadMarkArry[i]);
                //series.ChartArea = "ChartArea0";
                // Add point.
                //Array.Clear(CadUsdQQ.CadMarkArry, 0, CadUsdQQ.CadMarkArry.Length);
                cadChart.Series[0].Points.AddY(CadUsdQQ.CadMarkArry[i]);
            }
            CadUsdQQ.myMethod(this);
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
