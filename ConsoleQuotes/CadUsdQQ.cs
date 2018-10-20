using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ConsoleQuotes
{

    public class CadUsdQQ

    {


        public static List<double> CaddUsdMarkQuote_list = new List<double>();
        public static List<double> CaddUsdBidQuote_list = new List<double>();
        public static List<double> CaddUsdAskQuote_list = new List<double>();

        public static Chart chart_ { get; set; }
       


        private static double _cadMark;
        public static double CadMark
        {
            get
            {
                return _cadMark;
            }
            set
            {
                _cadMark = value;
              
            }

        }
     

        private static double _cadBid;
        public static double CadBid
        {
            get
            {
                return _cadBid;
            }
            set
            {
                

                _cadBid = value;
               


            }

        }

        public CadUsdQQ (double bprc)
        {

            CadBid = bprc;
        }

        private static double _cadAsk;
        public static double CadAsk
        {
            get
            {
                return _cadAsk;
            }
            set
            {
                _cadAsk = value;
            }
        }

        private static double _cadLast;
        public static double CadLast
        {
            get
            {
                return _cadLast;
            }
            set
            {
                _cadLast = value;
            }
        }

        private static double _cadVolumn;
        public static double CadVolumn
        {
            get
            {
                return _cadVolumn;
            }
            set
            {
                _cadVolumn = value;
            }
        }

        private static double _cadLastSize;
        public static double CadLastSize
        {
            get
            {
                return _cadLastSize;
            }
            set
            {
                _cadLastSize = value;
            }
        }

        private static double _cadOpen;
        public static double CadOpen
        {
            get
            {
                return _cadOpen;
            }
            set
            {
                _cadOpen = value;
            }
        }

        private static double _cadHigh;
        public static double CadHigh
        {
            get
            {
                return _cadHigh;
            }
            set
            {
                _cadHigh = value;
            }
        }

        private static double _cadLow;
        public static double CadLow
        {
            get
            {
                return _cadLow;
            }
            set
            {
                _cadLow = value;
            }
        }

        private static double _cadClose;
        public static double CadClose
        {
            get
            {
                return _cadClose;
            }
            set
            {
                _cadClose = value;
            }
        }

        // Array's

        private static double[] _cadMarkArry;
        public static double[] CadMarkArry
        {
            get
            {
                return Program.cadMarkArry;
            }
            set
            {
                _cadMarkArry = value;

            }
        }
        private static double[] _cadBidArry;
        public static double[] CadBidArry
        {
            get
            {
                return Program.cadBidArry;
            }
            set
            {
                _cadBidArry = value;

            }
        }
        private static double[] _cadAskArry;
        public static double[] CadAskArry
        {
            get
            {
                return Program.cadAskArry;
            }
            set
            {
                _cadAskArry = value;

            }
        }
        public static void myMethod(Form2 formObject)
        {
            formObject.textBox1.Text = "CadBid" + CadUsdQQ.CadBid;
        }

        public static double[] updateValue(double newValue, double[] values)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                values[i] = values[i + 1];
            }
            values[values.Length - 1] = newValue;
            return values;

        }




    }
}
