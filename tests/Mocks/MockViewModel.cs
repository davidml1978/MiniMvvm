using MiniMvvm.ViewModels;

namespace MiniMvvmTestes.Mocks
{
    public class MockViewModel : ViewModelBase
    {
        private int mockProperty;

        public int MockProperty
        {
            get
            {
                return this.mockProperty;
            }

            set
            {
                this.SetField(ref mockProperty, value, "MockProperty");
            }
        }

        internal void InvokeOnPropertyChanged()
        {
            RaisePropertyChanged(nameof(MockProperty));
        }
    }
}
