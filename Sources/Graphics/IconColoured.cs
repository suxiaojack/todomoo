/*
 * ===============================================================
 * TODOMOO
 * Copyright 2011 Lorenzo Stanco
 * GNU General Public License (GNU GPL)
 * ===============================================================
 * COLOURED ICON CLASS (ColourIcon.cs)
 * Static methods to get coloured icon images.
 * ===============================================================
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Todomoo {
	
	/// <summary>
	/// A 16x16 coloured icon.
	/// </summary>
	public static class IconColoured {
		
		/// <summary>
		/// Get a sqared coloured icon.
		/// </summary>
		/// <param name="colour">Colour</param>
		/// <returns>An Image representing the icon</returns>
		public static Image GetSquared(Color colour) {
			
			// Create bitmap resource
			Bitmap b = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
			
			// Draw black square
			for (int i = 1; i <= 14; i++) {
				b.SetPixel(i, 1, ColourFromRgb(126, 126, 126));
				b.SetPixel(i, 14, ColourFromRgb(0, 0, 0));
				b.SetPixel(1, 15-i, ColourFromRgb(i * 9, i * 9, i * 9));
				b.SetPixel(14, 15-i, ColourFromRgb(i * 9, i * 9, i * 9));
			}
			
			// Fill rectangle
			for (int i = 3; i <= 12; i++) for (int j = 3; j <= 12; j++) {
				int R = colour.R - (j - 9) * 8;
				int G = colour.G - (j - 9) * 8;
				int B = colour.B - (j - 9) * 8;
				b.SetPixel(i, j, ColourFromRgb(R, G, B));
			}
			
			return (Image)b;
			
		}
		/// <summary>
		/// Get a sqared coloured icon.
		/// </summary>
		/// <param name="colour">Colour</param>
		/// <returns>An Icon representing the icon</returns>
		public static Icon GetSquaredIcon(Color colour) {
			
			// Create bitmap resource
			Bitmap b = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
			
			// Draw black square
			for (int i = 1; i <= 14; i++) {
				b.SetPixel(i, 1, ColourFromRgb(126, 126, 126));
				b.SetPixel(i, 14, ColourFromRgb(0, 0, 0));
				b.SetPixel(1, 15-i, ColourFromRgb(i * 9, i * 9, i * 9));
				b.SetPixel(14, 15-i, ColourFromRgb(i * 9, i * 9, i * 9));
			}
			
			// Fill rectangle
			for (int i = 3; i <= 12; i++) for (int j = 3; j <= 12; j++) {
				int R = colour.R - (j - 9) * 8;
				int G = colour.G - (j - 9) * 8;
				int B = colour.B - (j - 9) * 8;
				b.SetPixel(i, j, ColourFromRgb(R, G, B));
			}
			
			return Icon.FromHandle(b.GetHicon());
			
		}
		
		// Create colour from R, G, B. Adjust incorrect values.
		private static Color ColourFromRgb(int r, int g, int b) {
			if (r > 255) r = 255; if (r < 0) r = 0;
			if (g > 255) g = 255; if (g < 0) g = 0;
			if (b > 255) b = 255; if (b < 0) b = 0;
			return Color.FromArgb(255, r, g, b);
		}
		
		
	}
}
