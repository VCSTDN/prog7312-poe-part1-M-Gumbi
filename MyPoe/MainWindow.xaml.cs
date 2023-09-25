using System;
using System.Windows;

namespace MyPoe
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Existing event handlers
        private void ReplacingBooks_Click(object sender, RoutedEventArgs e)
        {
            ReplacingBooks replacingBooksWindow = new ReplacingBooks();
            replacingBooksWindow.Show();
        }

        private void IdentifyingAreas_Click(object sender, RoutedEventArgs e)
        {
            // Implement the code to handle the Identifying Areas button click
        }

        private void FindingCallNumbers_Click(object sender, RoutedEventArgs e)
        {
            // Implement the code to handle the Finding Call Numbers button click
        }

        // Event handler for the "Info" button
        private void ShowInfo_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the visibility of the InfoPopup when the "Info" button is clicked
            InfoPopup.IsOpen = !InfoPopup.IsOpen;
        }
    }
}
