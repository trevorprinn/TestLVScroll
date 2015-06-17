# TestLVScroll

This is a small test app to demonstrate some problems found with scrolling ListViews in Xamarin.Forms v1.4.2. A runtime environment where the problems have manifested is Android 4.4.4. It has not been tested in any other environment.

The app displays a ListView in which each cell initially has a disabled Slider and a Switch. The Switch enables or disables the Slider.

When run in Portrait, where all of the cells fit on the screen, there is no problem.

When run in Landscape, where scrolling is required, two problems appear.

1. Enabling sliders near the top of the list can also, after scrolling down, erroneously enable some sliders at the bottom, and vice versa. When scrolling back up, sometimes the wrong sliders are enabled/disabled at the top of the list.
2. Occasionally, when scrolling up, the slider on one cell takes up more space than it should, and the switch appears to be off the right hand side of the screen. When this happens, scrolling back down and up again causes the cell to display correctly.     