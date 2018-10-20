	
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuotes
{
	
	public static class HiResDateTime
	{
		public static bool IsAvailable { get; private set; }

		[DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi)]
		private static extern void GetSystemTimePreciseAsFileTime(out long filetime);

		public static DateTime UtcNow
		{
			get
			{
				if (!IsAvailable)
				{
					throw new InvalidOperationException(
						"High resolution clock isn't available.");
				}

				long filetime;
				GetSystemTimePreciseAsFileTime(out filetime);

				return DateTime.FromFileTimeUtc(filetime);
			}
		}

		static HiResDateTime()
		{
			try
			{
				long filetime;
				GetSystemTimePreciseAsFileTime(out filetime);
				IsAvailable = true;
			}
			catch (EntryPointNotFoundException)
			{
				// Not running Windows 8 or higher.
				IsAvailable = false;
			}
		}
	}
}

// HiResDateTime.UtcNow
