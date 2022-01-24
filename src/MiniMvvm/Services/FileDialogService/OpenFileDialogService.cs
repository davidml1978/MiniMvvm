using Microsoft.Win32;

namespace BasicMiniMvvm.Services.FileDialogService
{
    public class OpenFileDialogService : FileDialogService
    {
        #region Public Construtoras

        public OpenFileDialogService() : base(new OpenFileDialog())
        {
        }

        #endregion Public Construtoras
    }
}