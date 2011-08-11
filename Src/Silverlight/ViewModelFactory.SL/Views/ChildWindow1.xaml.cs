using System.Windows;
using System.Windows.Controls;

namespace ViewModelFactory
{
    public partial class ChildWindow1 : ChildWindow
    {
        public ChildWindow1()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

