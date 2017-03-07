﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WordCloudGen = WordCloud.WordCloud;

namespace WordCloudTestApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			var lines = File.ReadLines("../../content/counts.csv");
		    this.Words = new List<string>(100);
		    this.Frequencies = new List<int>(100);
			foreach (var line in lines)
			{
				var textValue = line.Split(new char[] {','});
			    this.Words.Add(textValue[0]);
			    this.Frequencies.Add(int.Parse(textValue[1]));
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var s = new Stopwatch();
			s.Start();
			var wc = new WordCloudGen(1000, 600);
			if(this.resultPictureBox.Image != null) this.resultPictureBox.Image.Dispose();
			var i = wc.Draw(this.Words, this.Frequencies);
			s.Stop();
		    this.elapsedLabel.Text = s.Elapsed.TotalMilliseconds.ToString();
		    this.resultPictureBox.Image = i;
		}

		List<string> Words { get; set; }

		List<int> Frequencies { get; set; } 
	}
}