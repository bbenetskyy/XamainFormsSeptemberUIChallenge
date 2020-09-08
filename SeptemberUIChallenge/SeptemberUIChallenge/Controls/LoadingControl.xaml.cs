
using Xamarin.Forms;

namespace SeptemberUIChallenge.Controls
{
    public partial class LoadingControl : Grid
    {
        public LoadingControl()
        {
            InitializeComponent();
            SetBinding(IsVisibleProperty, new Binding(nameof(IsBusy), source: this) );
        }

        public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
            propertyName: nameof(IsBusy),
            returnType: typeof(bool),
            declaringType: typeof(LoadingControl),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay);

        public bool IsBusy
        {
            get => (bool)GetValue(IsBusyProperty);
            set => SetValue(IsBusyProperty, value);
        }
    }
}
