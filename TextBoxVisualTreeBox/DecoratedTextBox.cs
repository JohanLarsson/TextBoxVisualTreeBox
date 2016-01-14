namespace TextBoxVisualTreeBox
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class DecoratedTextBox : TextBox
    {
        public static readonly DependencyProperty DecoratorProperty = DependencyProperty.Register(
            "Decorator",
            typeof(Border),
            typeof(DecoratedTextBox),
            new FrameworkPropertyMetadata(
                default(Border),
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange,
                OnDecoratorChanged));

        public Border Decorator
        {
            get { return (Border)this.GetValue(DecoratorProperty); }
            set { this.SetValue(DecoratorProperty, value); }
        }

        private static void OnDecoratorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DecoratedTextBox)d).OnDecoratorChanged((Border)e.OldValue, (Border)e.NewValue);
        }

        private void OnDecoratorChanged(Border oldValue, Border newValue)
        {
            if (oldValue != null && newValue != null)
            {
                newValue.Child = oldValue.Child;
            }

            if (oldValue == null && newValue != null)
            {
                var visualChild = (UIElement)this.GetVisualChild(0);
                this.RemoveVisualChild(visualChild);
                newValue.Child = visualChild;
                this.AddVisualChild(newValue);
            }

            if (oldValue != null && newValue == null)
            {
                var visualChild = (UIElement)VisualTreeHelper.GetChild(oldValue, 0);
                oldValue.Child = null;
                this.AddVisualChild(visualChild);
            }
        }
    }
}
