using System.Windows.Media;

namespace BasicMiniMvvm.Services
{
    public interface IInputBoxService
    {
        /// <summary>
        /// Gets or sets the color of the box background.
        /// </summary>
        /// <value>
        /// The color of the box background.
        /// </value>
        Brush BoxBackgroundColor { get; set; }
        /// <summary>
        /// Gets or sets the default text.
        /// </summary>
        /// <value>
        /// The default text.
        /// </value>
        string DefaultText { get; set; }
        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>
        /// The font.
        /// </value>
        FontFamily Font { get; set; }
        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        /// <value>
        /// The size of the font.
        /// </value>
        int FontSize { get; set; }
        /// <summary>
        /// Gets the color of the input background.
        /// </summary>
        /// <value>
        /// The color of the input background.
        /// </value>
        Brush InputBackgroundColor { get; }
        /// <summary>
        /// Gets or sets the ok button text.
        /// </summary>
        /// <value>
        /// The ok button text.
        /// </value>
        string OkButtonText { get; set; }
        /// <summary>
        /// Gets or sets the prompt.
        /// </summary>
        /// <value>
        /// The prompt.
        /// </value>
        string Prompt { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title { get; set; }
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <returns></returns>
        string ShowDialog();
    }
}