using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BasicMiniMvvm.Services
{
    /// <summary>
    /// InputBoxService class
    /// </summary>
    /// <seealso cref="BasicMiniMvvm.Services.IInputBoxService" />
    public class InputBoxService : IInputBoxService
    {
        private TextBox textBox;
        private Window window;

        /// <summary>
        /// Shows the inputbox.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="title">The title.</param>
        /// <param name="defaultText">The default text.</param>
        /// <returns>String</returns>
        public string ShowDialog(string prompt, string title = "", string defaultText = "")
        {
            if (prompt == null)
                prompt = "";
            if (title == null)
                title = "";
            if (defaultText == null)
                defaultText = "";

            var window = CreateWindow(prompt, title, defaultText);
            if (window.ShowDialog() == true)
                return textBox.Text;

            return defaultText;
        }

        private Window CreateWindow(string prompt, string title, string defaultText)
        {
            window = new Window();
            window.Title = title;
            window.MinWidth = 300;
            window.SizeToContent = SizeToContent.WidthAndHeight;
            StackPanel stackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(3),
            };
            var textBlock = new TextBlock
            {
                Text = prompt,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(3),
            };
            textBox = new TextBox
            {
                Text = defaultText,
                Margin = new Thickness(3),
            };
            var stackPanelButtons = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(3)
            };
            var buttonOk = new Button
            {
                Content = "Ok",
                Padding = new Thickness(30, 0, 30, 0),
                Margin = new Thickness(3, 6, 3, 3),
                HorizontalAlignment = HorizontalAlignment.Right,
            };
            buttonOk.Click += ButtonOk_Click;
            var buttonCancel = new Button
            {
                Content = "Cancel",
                Padding = new Thickness(30, 0, 30, 0),
                Margin = new Thickness(3, 6, 3, 3),
                HorizontalAlignment = HorizontalAlignment.Right,
            };
            buttonCancel.Click += ButtonCancel_Click;
            stackPanelButtons.Children.Add(buttonOk);
            stackPanelButtons.Children.Add(buttonCancel);
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(textBox);
            stackPanel.Children.Add(stackPanelButtons);
            window.Content = stackPanel;
            return window;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            window.DialogResult = true;
            window.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            window.DialogResult = false;
            window.Close();
        }
    }
}
