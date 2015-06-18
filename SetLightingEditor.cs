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
			list.ItemSelected += (sender, e) => { list.SelectedItem = null; };
			Content = list;
		}

		private class ChannelCell : ViewCell {
			public static BindableProperty ChannelProperty =
				BindableProperty.Create<ChannelCell, LightChannel>(c => c.Channel, null,
					BindingMode.OneWay,
					propertyChanged: (c, o, n) => {
						var cell = (ChannelCell)c;
						System.Diagnostics.Debug.WriteLine(string.Format("Old Channel {0}, New Channel {1}",
							o == null ? "null" : o.Name, n == null ? "null" : n.Name));
						cell._switchCurrent.IsToggled = n.Enabled;
						cell._sliderInit.Value = n.Setting;
					});

			private Slider _sliderInit;
			private Switch _switchCurrent;

			public ChannelCell() {
				_sliderInit = new Slider {
					Minimum = 0,
					Maximum = 255,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					IsEnabled = false
				};
				_sliderInit.ValueChanged += (sender, e) => {
					Channel.Setting = e.NewValue;
				};
				_switchCurrent = new Switch {
					IsToggled = false
				};
				_switchCurrent.Toggled += (sender, e) => {
					System.Diagnostics.Debug.WriteLine("Toggled " + (Channel == null ? "null" : Channel.Name));
					Channel.Enabled = e.Value;
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