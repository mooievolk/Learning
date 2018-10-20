using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ConsoleQuotes
{
    /*
    public class chartUpdater
    {



        public chartUpdater(Chart chartControl)
        {
            chart = chartControl;

        }

        private Chart chart { get; set; }

       

        private double[] cpuArray = new double[60];

        public void getPerformanceCounters()
        {
            double  cpuPerfCounter = AudUsdQQ.AudBid;

            while (true)
            {
                cpuArray[cpuArray.Length - 1] = cpuPerfCounter;

                Array.Copy(cpuArray, 1, cpuArray, 0, cpuArray.Length - 1);

                if (chart.IsHandleCreated)
                {
                    chart.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
                }
                else
                {
                    //......
                }

                Thread.Sleep(50);
            }


        }


        private void UpdateCpuChart()
        {
            var area = chart.ChartAreas[0];
            double min = cpuArray.Min();
            double max = cpuArray.Max();
            chart.Series["Series1"].Points.Clear();

            for (int i = 0; i < cpuArray.Length - 1; ++i)
            {
                chart.Series["Series1"].Points.AddY(cpuArray[i]);

            }


            
                
            


        }

    }
    */
}
