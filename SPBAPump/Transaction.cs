using System;
namespace SPBAPump
{
	public class Transaction
	{

		public string TransNumber { get; set; }
		public string MemberID { get; set;}
		public string Date { get; set;}
		public string Time { get; set;}
		public string Price { get; set;}
		public string PumpStart { get; set;}
		public string PumpEnd { get; set; }
		public string NumberGallons { get; set; }
		public string TotalPaid { get; set; }


		public Transaction()
		{



		}
	}
}

