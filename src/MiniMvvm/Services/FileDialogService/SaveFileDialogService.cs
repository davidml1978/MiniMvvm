using Microsoft.Win32;

namespace BasicMiniMvvm.Services.FileDialogService
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