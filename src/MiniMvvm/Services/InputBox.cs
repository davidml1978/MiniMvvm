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
    /// InputBoxService represent the input box
    /// </summary>
    /// <seealso cref="MiniMvvm.Services.IInputBoxService" />
    public class InputBoxService : IInputBoxService
    {
        Window window = new Window();
        StackPanel stackPanel = new StackPanel();
        bool clicked = false;
        TextBox input = new TextBox();
        Button ok = new Button();
        bool inputreset = false;

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>
        /// The font.
        /// </value>
        public FontFamily Font { get; set; } = new FontFamily("Tahoma");
        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        /// <value>
        /// The size of the font.
        /// </value>
        public int FontSize { get; set; } = 30;
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; } = "";
        /// <summary>
        /// Gets or sets the prompt.
        /// </summary>
        /// <value>
        /// The prompt.
        /// </value>
        public string Prompt { get; set; } = "";
        /// <summary>
        /// Gets or sets the default text.
        /// </summary>
        /// <value>
        /// The default text.
        /// </value>
        public string DefaultText { get; set; } = "";
        /// <summary>
        /// Gets or sets the ok button text.
        /// </summary>
        /// <value>
        /// The ok button text.
        /// </value>
        public string OkButtonText { get; set; } = "OK";
        /// <summary>
        /// Gets or sets the color of the box background.
        /// </summary>
        /// <value>
        /// The color of the box background.
        /// </value>
        public Brush BoxBackgroundColor { get; set; } = Brushes.GreenYellow;
        /// <summary>
        /// Gets the color of the input background.
        /// </summary>
        /// <value>
        /// The color of the input background.
        /// </value>
        public Brush InputBackgroundColor { get; } = Brushes.Ivory;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputBoxService"/> class.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="title">The title.</param>
        /// <param name="defaultText">The default text.</param>
        /// <param name="font">The font.</param>
        /// <param name="fontsize">The fontsize.</param>
        public InputBoxService(string prompt, string title = "", string defaultText = "", string font = "Tahoma", int fontsize = 30)
        {
            if (prompt == null)
                prompt = "";
            if (title == null)
                title = "";
            if (string.IsNullOrWhiteSpace(font))
                font = "Tahoma";
            if (defaultText == null)
                defaultText = "";

            Prompt = prompt;
            Font = new FontFamily(font);
            Title = title;
            if (fontsize >= 1)
                FontSize = fontsize;            
        }

        private void Windowdef()// window building - check only for window size
        {
            window.Height = 500;// Box Height
            window.Width = 300;// Box Width
            window.Background = BoxBackgroundColor;
            window.Title = Title;
            window.Content = stackPanel;
            window.Closing += Box_Closing;
            TextBlock content = new TextBlock();
            content.TextWrapping = TextWrapping.Wrap;
            content.Background = null;
            content.HorizontalAlignment = HorizontalAlignment.Center;
            content.Text = Prompt;
            content.FontFamily = Font;
            content.FontSize = FontSize;
            stackPanel.Children.Add(content);

            input.Background = InputBackgroundColor;
            input.FontFamily = Font;
            input.FontSize = FontSize;
            input.HorizontalAlignment = HorizontalAlignment.Center;
            input.Text = DefaultText;
            input.MinWidth = 200;
            input.MouseEnter += Input_MouseDown;
            stackPanel.Children.Add(input);
            ok.Width = 70;
            ok.Height = 30;
            ok.Click += Ok_Click;
            ok.Content = OkButtonText;
            ok.HorizontalAlignment = HorizontalAlignment.Center;
            stackPanel.Children.Add(ok);

        }

        void Box_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!clicked)
                e.Cancel = true;
        }

        private void Input_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TextBox).Text == DefaultText && inputreset == false)
            {
                (sender as TextBox).Text = null;
                inputreset = true;
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            clicked = true;
            window.Close();
            clicked = false;
        }

        public string ShowDialog()
        {
            Windowdef();
            window.ShowDialog();
            if (string.IsNullOrWhiteSpace(input.Text))
                return DefaultText;
            return input.Text;
        }
    }
}
