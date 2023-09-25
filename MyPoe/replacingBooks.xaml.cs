using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyPoe
{
    public partial class ReplacingBooks : Window
    {
        private List<string> generatedCallNumbers = new List<string>();

        public ReplacingBooks()
        {
            InitializeComponent();
        }

        private void GenerateCallNumbers_Click(object sender, RoutedEventArgs e)
        {
            // Clear previous data
            generatedCallNumbers.Clear();
            CallNumbersListBox.Items.Clear();
            SortedCallNumbersListBox.Items.Clear();

            // Generate 10 random call numbers
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                string callNumber = $"{random.Next(1000):D3}.{random.Next(100):D2} {RandomAuthorSurname()}";
                generatedCallNumbers.Add(callNumber);

                // Create a button with the call number as content
                Button callNumberButton = new Button
                {
                    Content = callNumber,
                    Width = 150,
                    Margin = new Thickness(0, 5, 0, 0)
                };

                // Add click event handler to the button
                callNumberButton.Click += CallNumberButton_Click;

                // Add the button to the left ListBox
                CallNumbersListBox.Items.Add(callNumberButton);
            }

            // Enable UI elements
            CallNumbersListBox.IsEnabled = true;
            SortButton.IsEnabled = true;
            ProgressBar.Value = 0;
        }

        private string RandomAuthorSurname()
        {
            string[] surnames = { "SMI", "JON", "DAN", "LEE", "WIL" };
            return surnames[new Random().Next(surnames.Length)];
        }

        private void CallNumberButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle call number button click
            Button clickedButton = (Button)sender;
            string selectedCallNumber = clickedButton.Content.ToString();

            // Remove the button from the left ListBox
            CallNumbersListBox.Items.Remove(clickedButton);

            // Add the call number to the right ListBox
            SortedCallNumbersListBox.Items.Add(selectedCallNumber);
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle sort button click
            List<string> userSortedCallNumbers = new List<string>();

            // Collect sorted call numbers from the right ListBox
            foreach (var item in SortedCallNumbersListBox.Items)
            {
                if (item is string sortedCallNumber)
                {
                    userSortedCallNumbers.Add(sortedCallNumber);
                }
            }

            // Check if the user's order is correct
            bool isOrderCorrect = CheckUserInputOrder(userSortedCallNumbers);
            if (isOrderCorrect)
            {
                MessageBox.Show("Well done! 😄", "Correct Order", MessageBoxButton.OK, MessageBoxImage.Information);
                ProgressBar.Value = 100;
            }
            else
            {
                MessageBox.Show("Try again! 😞", "Incorrect Order", MessageBoxButton.OK, MessageBoxImage.Error);
                ProgressBar.Value = 0;
            }
        }

        private bool CheckUserInputOrder(List<string> userSortedCallNumbers)
        {
            // Check if user's input is in ascending order
            for (int i = 0; i < userSortedCallNumbers.Count - 1; i++)
            {
                if (string.Compare(userSortedCallNumbers[i], userSortedCallNumbers[i + 1]) > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
