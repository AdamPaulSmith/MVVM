using NUnit.Framework;
using Shouldly;

namespace TheRX.MVVM.VisualSupport.Tests.Unit
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void CanExecute_WhenCommandIsContructedWithNoParameters_ReturnsTrue()
        {
            var testCommand = new TestCommand();

            bool commandCanExecute = testCommand.CanExecute(null);

            commandCanExecute.ShouldBeTrue();
        }

        [Test]
        public void CanExecute_WhenTheCommandIsContructedWithTheCanExecuteParamterSet_ReturnsTheSetValue([Values(true, false)] bool canExecuteParameter)
        {
            var testCommand = new TestCommand(canExecuteParameter);

            bool commandCanExecute = testCommand.CanExecute(null);

            commandCanExecute.ShouldBe(canExecuteParameter);
        }

        [Test]
        public void CanExecuteChanged_IsRaised_WhenSetCanExecuteIsInvoked()
        {
            bool canExecuteChangedInvoked = false;

            var testCommand = new TestCommand();
            testCommand.CanExecuteChanged += (sender, args) => canExecuteChangedInvoked = true;

            testCommand.InvokeSetCanExecuteChanged();

            canExecuteChangedInvoked.ShouldBeTrue();
        }

        private class TestCommand : Command
        {
            public TestCommand()
            {
            }

            public TestCommand(bool canExecute) : base(canExecute)
            {
            }

            public override void Execute(object parameter)
            {
            }

            public void InvokeSetCanExecuteChanged()
            {
                SetCanExecute(true);
            }
        }
    }
}