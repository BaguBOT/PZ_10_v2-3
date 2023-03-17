﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Controls;

namespace WpfTutorialSamples.Rich_text_controls
{
	public partial class RichTextEditorSample : Window
	{
		public RichTextEditorSample()
		{
			InitializeComponent();
			cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
			cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
		}

		private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
		{
			object temp = rtbErditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
			btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
			temp = rtbErditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
			btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
			temp = rtbErditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
			btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

			temp = rtbErditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
			cmbFontFamily.SelectedItem = temp;
			temp = rtbErditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
			cmbFontSize.Text = temp.ToString();
		}

		private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
			if(dlg.ShowDialog() == true)
			{
				FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
				TextRange range = new TextRange(rtbErditor.Document.ContentStart, rtbErditor.Document.ContentEnd);
				range.Load(fileStream, DataFormats.Rtf);
			}
		}

		private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
			if(dlg.ShowDialog() == true)
			{
				FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
				TextRange range = new TextRange(rtbErditor.Document.ContentStart, rtbErditor.Document.ContentEnd);
				range.Save(fileStream, DataFormats.Rtf);
			}
		}

		private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(cmbFontFamily.SelectedItem != null)
				rtbErditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
		}

		private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
		{
			rtbErditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
		}

		private void fontcolor()
		{
			var colorDialog = new System.Windows.Forms.ColorDialog();
			if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				var wpfcolor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
				TextRange range = new TextRange(rtbErditor.Selection.Start, rtbErditor.Selection.End);
				range.ApplyPropertyValue(FlowDocument.ForegroundProperty, new SolidColorBrush(wpfcolor));
			}
		}
		
			
		
		private void Button_Click(object sender, RoutedEventArgs e)
        {
		fontcolor();

		}

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
			if (dlg.ShowDialog() == true)
			{
				FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
				TextRange range = new TextRange(rtbErditor.Document.ContentStart, rtbErditor.Document.ContentEnd);
				range.Load(fileStream, DataFormats.Rtf);
			}
		}

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
			if (dlg.ShowDialog() == true)
			{
				FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
				TextRange range = new TextRange(rtbErditor.Document.ContentStart, rtbErditor.Document.ContentEnd);
				range.Save(fileStream, DataFormats.Rtf);
			}
		}

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
			this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object p = rtbErditor.Paragraph.LineHeight++;

		}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }

        
}