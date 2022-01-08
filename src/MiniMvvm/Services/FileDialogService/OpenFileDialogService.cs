using Microsoft.Win32;

namespace MiniMvvm.Services
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