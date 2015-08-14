using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace TestLVScroll {
	public class SetLightingEditor : ContentView {

		public SetLightingEditor() {
			var list = new ListView {
				ItemsSource = Enumerable.Range(1, 20).Select(i => new LightChannel(i)),
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