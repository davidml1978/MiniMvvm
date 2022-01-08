using MiniMvvm.Commands;
using MiniMvvm.ViewModels;

using System;
using System.Windows.Input;

using Xunit;

namespace MiniMvvmTestes.Commands
{
    /// <summary>
    /// Summary description for DelegateCommandFixture
    /// </summary>
    public class RelayCommandFixture : ViewModelBase
    {
        [Fact]
        public void WhenConstructedWithGenericTypeOfObject_InitializesValues()
        {
            // Prepare

            // Act
            var actual = new RelayCommand<object>(param => { });

            // verify
            Assert.NotNull(actual);
        }

        [Fact]
        public void WhenConstructedWithGenericTypeOfNullable_InitializesValues()
        {
            // Prepare

            // Act
            var actual = new RelayCommand<int?>(param => { });

            // verify
            Assert.NotNull(actual);
        }


        [Fact]
        public void ExecuteCallsPassedInExecuteDelegate()
        {
            var handlers = new DelegateHandlers();
            var command = new RelayCommand<object>(handlers.Execute);
            object parameter = new object();

            command.Execute(parameter);

            Assert.Same(parameter, handlers.ExecuteParameter);
        }

        [Fact]
        public void CanExecuteCallsPassedInCanExecuteDelegate()
        {
            var handlers = new DelegateHandlers();
            var command = new RelayCommand<object>(handlers.Execute, handlers.CanExecute);
            object parameter = new object();

            handlers.CanExecuteReturnValue = true;
            bool retVal = command.CanExecute(parameter);

            Assert.Same(parameter, handlers.CanExecuteParameter);
            Assert.Equal(handlers.CanExecuteReturnValue, retVal);
        }

        [Fact]
        public void CanExecuteReturnsTrueWithouthCanExecuteDelegate()
        {
            var handlers = new DelegateHandlers();
            var command = new RelayCommand<object>(handlers.Execute);

            bool retVal = command.CanExecute(null);

            Assert.True(retVal);
        }

        [Fact]
        public void RaiseCanExecuteChangedRaisesCanExecuteChanged()
        {
            var handlers = new DelegateHandlers();
            var command = new RelayCommand<object>(handlers.Execute);
            bool canExecuteChangedRaised = false;
            command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

            command.RaiseCanExecuteChanged();

            Assert.True(canExecuteChangedRaised);
        }

        [Fact]
        public void CanRemoveCanExecuteChangedHandler()
        {
            var command = new RelayCommand<object>((o) => { });

            bool canExecuteChangedRaised = false;

            EventHandler handler = (s, e) => canExecuteChangedRaised = true;

            command.CanExecuteChanged += handler;
            command.CanExecuteChanged -= handler;
            command.RaiseCanExecuteChanged();

            Assert.False(canExecuteChangedRaised);
        }

        [Fact]
        public void ShouldPassParameterInstanceOnExecute()
        {
            bool executeCalled = false;
            MyClass testClass = new MyClass();
            ICommand command = new RelayCommand<MyClass>(delegate (MyClass parameter)
            {
                Assert.Same(testClass, parameter);
                executeCalled = true;
            });

            command.Execute(testClass);
            Assert.True(executeCalled);
        }

        [Fact]
        public void ShouldPassParameterInstanceOnCanExecute()
        {
            bool canExecuteCalled = false;
            MyClass testClass = new MyClass();
            ICommand command = new RelayCommand<MyClass>((p) => { }, delegate (MyClass parameter)
            {
                Assert.Same(testClass, parameter);
                canExecuteCalled = true;
                return true;
            });

            command.CanExecute(testClass);
            Assert.True(canExecuteCalled);
        }






        [Fact]
        public void GenericRelayCommandNotObservingPropertiesShouldNotRaiseOnEmptyPropertyName()
        {
            bool canExecuteChangedRaised = false;

            var command = new RelayCommand<object>((o) => { });

            command.CanExecuteChanged += delegate { canExecuteChangedRaised = true; };

            RaisePropertyChanged(null);

            Assert.False(canExecuteChangedRaised);
        }



        class CanExecutChangeHandler
        {
            public bool CanExeucteChangedHandlerCalled;
            public void CanExecuteChangeHandler(object sender, EventArgs e)
            {
                CanExeucteChangedHandlerCalled = true;
            }
        }

        class DelegateHandlers
        {
            public bool CanExecuteReturnValue = true;
            public object CanExecuteParameter;
            public object ExecuteParameter;

            public bool CanExecute(object parameter)
            {
                CanExecuteParameter = parameter;
                return CanExecuteReturnValue;
            }

            public void Execute(object parameter)
            {
                ExecuteParameter = parameter;
            }
        }
    }

    internal class MyClass
    {
    }
}
