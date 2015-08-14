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
				ItemTemplate = new DataTemplate(typeof(ChannelCell))
			};
			list.ItemSelected += (sender, e) => { list.SelectedItem = null; };
			Content = list;
		}

		private class ChannelCell : ViewCell {
			public ChannelCell() {
				var sliderInit = new Slider {
					Minimum = 0,
					Maximum = 255,
					HorizontalOptions = LayoutOptions.FillAndExpand
				};
				sliderInit.SetBinding(Slider.ValueProperty, "Setting");
				sliderInit.SetBinding(Slider.IsEnabledProperty, "Enabled");
				var switchCurrent = new Switch();
				switchCurrent.SetBinding(Switch.IsToggledProperty, "Enabled");

				var layout = new StackLayout {
					Orientation = StackOrientation.Horizontal,
					Children = { sliderInit, switchCurrent }
				};

				View = layout;
			}
		}
	}
}