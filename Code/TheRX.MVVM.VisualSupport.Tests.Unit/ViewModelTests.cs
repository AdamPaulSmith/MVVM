using NUnit.Framework;
using Shouldly;

namespace TheRX.MVVM.VisualSupport.Tests.Unit
{
    [TestFixture]
    public class ViewModelTests
    {
        [Test]
        public void PropertyChanged_IsInvokedWithTheCorrectPropertyName_WhenInvokedInAPropertySetter()
        {
            string propertyName = string.Empty;

            var testViewModel = new TestViewModel();
            testViewModel.PropertyChanged += (sender, args) => propertyName = args.PropertyName;
            testViewModel.TestProperty = "New value";

            propertyName.ShouldBeSameAs(nameof(testViewModel.TestProperty));
        }

        private class TestViewModel : ViewModel
        {
            private string _testProperty;

            public string TestProperty
            {
                get { return _testProperty; }
                set
                {
                    _testProperty = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}