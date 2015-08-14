using System;
using System.ComponentModel;

namespace TestLVScroll {
	public class LightChannel : INotifyPropertyChanged {
		public int ChanNo { get; private set; }

		public event PropertyChangedEventHandler PropertyChanged;

		private bool _enabled;
		public bool Enabled { 
			get { return _enabled; }
			set {
				_enabled = value;
				if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Enabled"));
			}
		}
		public double Setting { get; set; }

		public string Name {
			get { return "Channel " + ChanNo.ToString(); }
		}

		public LightChannel(int chanNo) {
			ChanNo = chanNo;
		}
	}
}

