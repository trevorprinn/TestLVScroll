using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using Xamarin.Forms;

namespace TestLVScroll {
	public class SetLightingEditor : ContentView {
		private ObservableCollection<LightChannel> _channels;

		public SetLightingEditor() {
			_channels = new ObservableCollection<LightChannel>(Enumerable.Range(1, 20).Select(i => new LightChannel(i)));
			var list = new ListView {
				ItemsSource = _channels,
				ItemTemplate = new DataTemplate(() => {
					var c = new ChannelCell();
					c.SetBinding(ChannelCell.ChannelProperty, ".");
					return c;
				}),
			};
			Content = list;
		}

		private class ChannelCell : ViewCell {
			public static BindableProperty ChannelProperty =
				BindableProperty.Create<ChannelCell, LightChannel>(c => c.Channel, null,
					BindingMode.OneWay);

			private Slider _sliderInit;
			private Switch _switchCurrent;

			public ChannelCell() {
				_sliderInit = new Slider {
					Minimum = 0,
					Maximum = 255,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					IsEnabled = false
				};
				_switchCurrent = new Switch {
					IsToggled = false
				};
				_switchCurrent.Toggled += (sender, e) => {
					System.Diagnostics.Debug.WriteLine("Toggled " + (Channel == null ? "null" : Channel.Name));
					_sliderInit.IsEnabled = e.Value;
				};

				var layout = new StackLayout {
					Orientation = StackOrientation.Horizontal,
					Children = { _sliderInit, _switchCurrent }
				};

				View = layout;
			}

			public LightChannel Channel {
				get { return (LightChannel)GetValue(ChannelProperty); }
				set { SetValue(ChannelProperty, value); }
			}
		}
	}
}