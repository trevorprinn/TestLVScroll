using System;

namespace TestLVScroll {
	public class LightChannel {
		public int ChanNo { get; private set; }
		public bool Enabled { get; set; }
		public double Setting { get; set; }

		public string Name {
			get { return "Channel " + ChanNo.ToString(); }
		}

		public LightChannel(int chanNo) {
			ChanNo = chanNo;
		}
	}
}

