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
    public class CadchartUpdater
    {

        public CadchartUpdater(Chart chartControl)
        {
            chart = chartControl;

        }

        private Chart chart { get; set; }

        private double[] cadMrkArray = new double[500];
        private double[] cadBidArray = new double[500];
        private double[] cadAskArray = new double[500];

        public void usdCadChart()
        {
            double usdCadMrk = CadUsdQQ.CadMark;
            double usdCadBid = CadUsdQQ.CadBid;
            double usdCadAsk = CadUsdQQ.CadAsk;

          
                cadMrkArray[cadMrkArray.Length - 1] = usdCadMrk;
                cadBidArray[cadBidArray.Length - 1] = usdCadBid;
                cadAskArray[cadAskArray.Length - 1] = usdCadAsk;

               Array.Copy(cadMrkArray, 1, cadMrkArray, 0, cadMrkArray.Length - 1);
               Array.Copy(cadMrkArray, 1, cadBidArray, 0, cadBidArray.Length - 1);
               Array.Copy(cadAskArray, 1, cadAskArray, 0, cadAskArray.Length - 1);

           
            


        }

        private void UpdateCadChart()
        {
            var area = chart.ChartAreas[0];
            double min = cadAskArray.Min();
            double max = cadBidArray.Max();
            chart.Series["Series1"].Points.Clear();
            chart.Series["Series1"].Points.Clear();
            chart.Series["Series1"].Points.Clear();

            for (int i = 0; i < cadMrkArray.Length - 1; ++i)
            {
                chart.Series["Series1"].Points.AddY(cadMrkArray[i]);

            }

            for (int i = 0; i < cadBidArray.Length - 1; ++i)
            {
                chart.Series["Series2"].Points.AddY(cadBidArray[i]);

            }

            for (int i = 0; i < cadAskArray.Length - 1; ++i)
            {
                chart.Series["Series3"].Points.AddY(cadAskArray[i]);

            }

            if (max != min)
            {

                chart.ChartAreas[0].AxisY.Maximum = max;
                chart.ChartAreas[0].AxisY.Minimum = min;

            }


        }
    }
}