namespace TextBoxVisualTreeBox
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.DecoratedTextBox.Decorator = new Border
            {
                BorderBrush = Brushes.HotPink,
                BorderThickness = new Thickness(2)
            };
        }
    }
}
