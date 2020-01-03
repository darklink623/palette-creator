using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace bmp_creation
{
	public partial class Form1: Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		Button[] btnArray;
		Int32[] colors;
		String imagePath;
		Bitmap testImage;

		private void Form1_Load(object sender, EventArgs e)
		{
			// create buttons
			createButtons();
			testImage = new Bitmap(imagePath);
			readImage();
		}

		private void createButtons()
		{
			// get the location of the picture
			OpenFileDialog dialog = new OpenFileDialog
			{
				Filter = "Image files (*.jpg, *.jpeg, *.bmp, *.gif, *.png) | *.jpg; *.jpeg; *.bmp; *.gif; *.png"
			};

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					imagePath = Path.GetFullPath(dialog.FileName);
					testImage = new Bitmap(imagePath);
				}
				catch (NullReferenceException)
				{
					MessageBox.Show("image not found");
				}
			}
			else
			{
				Close();
			}

			// get palette from the image and create buttons with those colors. more than 16 colors will not work
			btnArray = new Button[16];
			for (Int16 i = 0; i < 16; i++)
			{
				// defines
				Int16 x = i;

				btnArray[i] = new Button();
				btnArray[i].Size = new Size(15, 15);
				btnArray[i].Location = new Point(15 + (16 * i), 20);
				btnArray[i].BackColor = Color.Black;
				btnArray[i].FlatStyle = FlatStyle.Flat;

				// create a function call for each button
				btnArray[i].Click += (sender, args) =>
				{
					Color previous = btnArray[x].BackColor;
					btnArray[x].BackColor = changecolors(previous);
					generateBitmap(previous, btnArray[x].BackColor);
				};
			}
			Controls.AddRange(btnArray);
		}

		private Color changecolors(Color previous)
		{
			ColorDialog x = new ColorDialog();

			Color color = previous;
			if (x.ShowDialog() == DialogResult.OK)
			{
				color = x.Color;
			}
			return color;
		}

		private void readImage() 
		{
			// set imageDisplay's image
			imageDisplay.Image = testImage;
			colors = new Int32[16];

			for (int y = 0; y < testImage.Height; y++)
			{
				for (int x = 0; x < testImage.Width; x++)
				{
					parseColors(testImage.GetPixel(x, y));
				}
			}
			for (int i = 0; i < colors.Length; i++)
			{
				// grab color from palette
				btnArray[i].BackColor = Color.FromArgb(colors[i]);
			}
			colors = null;
		}

		private int parseColors(Color pixel)
		{
			// check if the color is in the palette -- if not, add it
			for (int i = 0; i < colors.Length; i++)
			{
				if (colors[i] == 0 || Color.FromArgb(colors[i]) == pixel)
				{
					colors[i] = pixel.ToArgb();
					return i;
				}
			}
			return -1;
		}



		private void generateBitmap(Color pixel, Color replacement)
		{
			// import image
			testImage = new Bitmap(imageDisplay.Image);

			for (int y = 0; y < testImage.Height; y++)
			{
				for(int x = 0; x < testImage.Width; x++)
				{
					// comparison/conversion of each pixel
					if (testImage.GetPixel(x, y) == pixel)
					{
						testImage.SetPixel(x, y, replacement);
					}
				}
			}
			// swap out the image for the new updated one, reduce the color palette if needed
			imageDisplay.Image = testImage;
			readImage();
		}
	}
}
