

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RTDServerQuotes;
using System.Management;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;


namespace ConsoleQuotes
{
    public class Program
    {

        public DateTime highResUtc { get; set; }
        public static int aLr = 200;
        public static double[] Dots { get; private set; }
       
        public static double[] audBidArry = new double[aLr];
        public static double audSpread;
        public static double audPip;

        public static double[] cadMarkArry = new double[aLr];
        public static double[] cadBidArry = new double[aLr];
        public static double[] cadAskArry = new double[aLr];
        public static double[] cadLastArry = new double[aLr];
        public static double cadSpread;
        public static double cadPip;

        private static int counter = 0;
        public static double[] AudUsdBidQuote_list { get; private set; }


        public static void Main(string[] args)
        {


            Application.EnableVisualStyles();

            Task.Run(() => Application.Run(new Form2()));

            Process[] tos = Process.GetProcessesByName("ThinkorSwim");
            if (tos.Length == 0)
            {
                Console.WriteLine("ThinkorSwim is not running."); // Open Outlook anew.
                Process.Start(@"C:\Program Files\thinkorswim\thinkorswim.exe");

            }
            else
            {
                Console.WriteLine("ThinkorSwim is running."); // Do not re-open Outlook.
                GetQuotes();

            }

        }

       private void loadArry(object sender, EventArgs e)
       {
	
         for (int i = 0; i < CadUsdQQ.CadBidArry.Length; i++)
         {

           CadUsdQQ.CadBidArry[i] = 0;

         }



       }


        public static void GetQuotes()
        {



            var client = new Client();
            // AUD/USD
            client.Add(Symbols.Aud, QuoteType.Mark);
            client.Add(Symbols.Aud, QuoteType.Ask);
            client.Add(Symbols.Aud, QuoteType.Bid);
            client.Add(Symbols.Aud, QuoteType.Last);
            client.Add(Symbols.Aud, QuoteType.Volume);
            client.Add(Symbols.Aud, QuoteType.LAST_SIZE);
            // USD/CAD
            client.Add(Symbols.Cad, QuoteType.Mark);
            client.Add(Symbols.Cad, QuoteType.Ask);
            client.Add(Symbols.Cad, QuoteType.Bid);
            client.Add(Symbols.Cad, QuoteType.Last);
            client.Add(Symbols.Cad, QuoteType.Volume);
            client.Add(Symbols.Cad, QuoteType.LAST_SIZE);
            client.Add(Symbols.Cad, QuoteType.Open);
            client.Add(Symbols.Cad, QuoteType.High);
            client.Add(Symbols.Cad, QuoteType.Low);

            List<double> AudUsdQuote_list = new List<double>();
            //List<double> AudUsdBidQuote_list = new List<double>();

            foreach (var quote in client.Quotes())
            {
                counter = 0;
                if (quote.Symbol == "AUD/USD")
                {
                    if (quote.Type == "Mark")
                    {
                        AudUsdQQ.AudMark = quote.Value;
                    }
                    if (quote.Type == "Bid")
                    {

                        AudUsdQQ.AudBid = quote.Value;
                        AudUsdQQ.AudUsdBidQuote_list.Add(quote.Value);
                        AudUsdQQ.AudUsdBidQuote_list.ForEach(i => Console.WriteLine("{0}\t", i));
                        Dots = updateValue(AudUsdQQ.AudBid, AudUsdQQ.AudBidArry);
                       
                        foreach (var dot in Dots)
                        {
                           // Console.WriteLine(dot);
                        }

                    }
                    if (quote.Type == "Ask")
                    {
                      
                        AudUsdQQ.AudAsk = quote.Value;
                    }
                    if (quote.Type == "Last")
                    {
                       
                        AudUsdQQ.AudLast = quote.Value;
                    }
                    if (quote.Type == "Volume")
                    {

                      
                        AudUsdQQ.AudVolumn = quote.Value;
                    }
                    if (quote.Type == "LAST_SIZE")
                    {
                       
                        AudUsdQQ.AudLastSize = quote.Value;
                    }


                    short pipcost = 10000;
                    audSpread = AudUsdQQ.AudAsk - AudUsdQQ.AudBid;
                    audPip = audSpread * pipcost;



                    // AudUsdQuote_list.Add(AudUsdQQ.AudMark);
                    // AudUsdQuote_list.Add(AudUsdQQ.AudBid);
                    // AudUsdQuote_list.Add(AudUsdQQ.AudAsk);
                    // AudUsdQuote_list.Add(AudUsdQQ.AudLast);
                    // AudUsdQuote_list.Add(AudUsdQQ.AudLastSize);
                    // AudUsdQuote_list.Add(AudUsdQQ.AudVolumn);
                    // AudUsdQuote_list.Add(AudUsdQQ.Aud);
                    // AudUsdQuote_list.Add(audSpread);
                    // AudUsdQuote_list.Add(audPip);
                    // AudUsdQuote_list.Add(counter);




                }

                counter++;
                //Console.WriteLine(counter);

                if (quote.Symbol == "USD/CAD")
                {


                    if (quote.Type == "Mark")
                    {

                        CadUsdQQ.CadMark = quote.Value;
                        CadUsdQQ.CaddUsdMarkQuote_list.Add(quote.Value);

                        Dots = updateValue(CadUsdQQ.CadMark, CadUsdQQ.CadMarkArry);

                    }

                    if (quote.Type == "Bid")
                    {

                        CadUsdQQ.CadBid = quote.Value;
                        CadUsdQQ.CaddUsdBidQuote_list.Add(quote.Value);
                        
                        for (int i = 0; i < CadUsdQQ.CaddUsdBidQuote_list.Count; i++)
                        {
                            //Form2.listBox1.Items.Add(CadUsdQQ.CaddUsdBidQuote_list[i]);
                        }

                    }
                    if (quote.Type == "Ask")
                    {

                        CadUsdQQ.CadAsk = quote.Value;
                        CadUsdQQ.CaddUsdAskQuote_list.Add(quote.Value);
                        Dots = updateValue(CadUsdQQ.CadAsk, CadUsdQQ.CadAskArry);

                    }
                    if (quote.Type == "Last")
                    {

                        CadUsdQQ.CadLast = quote.Value;
                    }
                    if (quote.Type == "Volume")
                    {


                        CadUsdQQ.CadVolumn = quote.Value;
                    }
                    if (quote.Type == "LAST_SIZE")
                    {

                        CadUsdQQ.CadLastSize = quote.Value;
                    }
                    if (quote.Type == "Open")
                    {

                        CadUsdQQ.CadOpen = quote.Value;
                    }
                    if (quote.Type == "High")
                    {

                        CadUsdQQ.CadHigh = quote.Value;
                    }
                    if (quote.Type == "Low")
                    {

                        CadUsdQQ.CadLow = quote.Value;
                    }
                    if (quote.Type == "Close")
                    {

                        CadUsdQQ.CadClose = quote.Value;
                    }

                    short pipcost = 10000;
                    cadSpread = CadUsdQQ.CadAsk - CadUsdQQ.CadBid;
                    cadPip = cadSpread * pipcost;



                }
            }
        }
    }

	 public static void chartUpdateVal(Form2 formChart)
        {
	    Dots = updateValue(CadUsdQQ.CadBid, CadUsdQQ.CadBidArry);
	    chart1.series["Series1"].Points.Clear();
	    foreach (var dot in Dots)
            {
		
             chart1.Series["Series1"].Points.Add(dot);

            {
           
        }

	private static double[] updateValue(double newValue, double[] values)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                values[i] = values[i + 1];
            }
            values[values.Length - 1] = newValue;
            return values;
        }

    
}
