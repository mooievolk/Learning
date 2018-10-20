
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
    
    public class AudUsdQQ 

    {
        
        public static List<double> AudUsdBidQuote_list = new List<double>();

       
        private static double _audMark;
        public static double AudMark
        {
            get
            {
                return _audMark;
            }
            set
            {
                _audMark = value;
            }

        }


      
        private static double _audBid;
        public static double AudBid
        {
            get
            {
                return _audBid;
            }
            set
            {
                if (AudBid == value)
                    return;

                _audBid = value;

              

            }

        }
    
        private static double _audAsk;
        public static double AudAsk
        {
            get
            {
                return _audAsk;
            }
            set
            {
                _audAsk = value;
            }
        }

        private static double _audLast;
        public static double AudLast
        {
            get
            {
                return _audLast;
            }
            set
            {
                _audLast = value;
            }
        }

        private static double _audVolumn;
        public static double AudVolumn
        {
            get
            {
                return _audVolumn;
            }
            set
            {
                _audVolumn = value;
            }
        }

        private static double _audLastSize;
        public static double AudLastSize
        {
            get
            {
                return _audLastSize;
            }
            set
            {
                _audLastSize = value;
            }
        }

        private static double[] _audMarkArry;
        public static double[] AudMarkArry
        {
            get
            {
                return Program.audBidArry;
            }
            set
            {
                _audMarkArry = value;
               
            }
        }

        private static double[] _audBidArry;
        public static double[] AudBidArry
        {
            get
            {
                return Program.audBidArry;
            }
            set
            {
                _audBidArry = value;
              
            }
        }

        /*
        private static double[] _audAskArry;
        public static double[] AudAskArry
        {
            get
            {
                return Program.audAskArry;
            }
            set
            {
                _audAskArry = value;
               
            }
        }
        */


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
