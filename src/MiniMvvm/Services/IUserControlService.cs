using System.Windows;
using System.Windows.Input;

namespace MiniMvvm.Services
{
    /// <summary>
    /// IUserControlService interface
    /// </summary>
    public interface IUserControlService
    {
        /// <summary>
        /// Gets or sets the cursor.
        /// </summary>
        /// <value>
        /// The cursor.
        /// </value>
        Cursor Cursor { get; set; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        /// <value>
        /// The visibility.
        /// </value>
        Visibility Visibility { get; set; }
    }
}
