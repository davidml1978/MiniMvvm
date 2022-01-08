using Microsoft.Win32;

namespace MiniMvvm.Services
{
    public class SaveFileDialogService : FileDialogService
    {
        #region Public Construtoras

        public SaveFileDialogService() : base(new SaveFileDialog())
        {
        }

        #endregion Public Construtoras
    }
}