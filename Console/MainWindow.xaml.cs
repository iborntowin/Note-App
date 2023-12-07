using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Console
{
    public partial class MainWindow : Window
    {
        private int boxIdCounter = 1;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void AddElementButton_Click(object sender, RoutedEventArgs e)
        {
            Box newBox = new Box(boxIdCounter, "Box " + boxIdCounter, "Content of Box " + boxIdCounter);
            MovableBox movableBox = new MovableBox(newBox, canvas);
            movableBox.DeleteButtonClicked += HandleDeleteButtonClicked;
            canvas.Children.Add(movableBox);

            boxIdCounter++;
        }


        private void HandleDeleteButtonClicked(object sender, EventArgs e)
        {
            if (sender is MovableBox box)
            {
                canvas.Children.Remove(box);
            }
        }
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the visibility of the menu elements panel
            if (MenuElementsPanel.Visibility == Visibility.Collapsed)
            {
                MenuElementsPanel.Visibility = Visibility.Visible;
            }
            else
            {
                MenuElementsPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "BoxData.txt");

            List<string> existingData = new List<string>();

            // Read existing data from the file
            if (File.Exists(filePath))
            {
                existingData.AddRange(File.ReadAllLines(filePath));
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Append existing data to the new data
                foreach (string line in existingData)
                {
                    writer.WriteLine(line);
                }

                // Append new data from MovableBox elements
                foreach (MovableBox movableBox in canvas.Children.OfType<MovableBox>())
                {
                    string title = movableBox.TitleTextBox.Text;
                    string content = movableBox.ContentTextBox.Text;
                    float x = movableBox.X; // Get the X-coordinate
                    float y = movableBox.Y; // Get the Y-coordinate

                    writer.WriteLine($"Title: {title}");
                    writer.WriteLine($"Content: {content}");
                    writer.WriteLine($"X: {x}"); // Save X-coordinate
                    writer.WriteLine($"Y: {y}"); // Save Y-coordinate
                    writer.WriteLine();
                }
            }

          
        }
        private void SaveByDayButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the current date in the "day-month-year" format
            string currentDate = DateTime.Now.ToString("dd-MM-yyyy");

            // Create the file name with the current date
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = $"BoxData_{currentDate}.txt"; // Example: "BoxData_30-08-2023.txt"
            string filePath = Path.Combine(desktopPath, fileName);

            List<string> existingData = new List<string>();

            // Read existing data from the file
            if (File.Exists(filePath))
            {
                existingData.AddRange(File.ReadAllLines(filePath));
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Append existing data to the new data
                foreach (string line in existingData)
                {
                    writer.WriteLine(line);
                }

                // Append new data from MovableBox elements
                foreach (MovableBox movableBox in canvas.Children.OfType<MovableBox>())
                {
                    string title = movableBox.TitleTextBox.Text;
                    string content = movableBox.ContentTextBox.Text;
                    float x = movableBox.X; // Get the X-coordinate
                    float y = movableBox.Y; // Get the Y-coordinate

                    writer.WriteLine($"Title: {title}");
                    writer.WriteLine($"Content: {content}");
                    writer.WriteLine($"X: {x}"); // Save X-coordinate
                    writer.WriteLine($"Y: {y}"); // Save Y-coordinate
                    writer.WriteLine();
                }
            }

            
          
        }
        private void DropdownButton_Click(object sender, RoutedEventArgs e)
        {
            if (DropdownPopup.IsOpen)
            {
                DropdownPopup.IsOpen = false; // Close the popup if it's open
            }
            else
            {
                DropdownPopup.IsOpen = true; // Open the popup if it's closed
            }
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {
            // Handle Option 1 click
            DropdownPopup.IsOpen = false; // Close the popup
        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {
            // Handle Option 2 click
            DropdownPopup.IsOpen = false; // Close the popup
        }

        private void Option3_Click(object sender, RoutedEventArgs e)
        {
            // Handle Option 3 click
            DropdownPopup.IsOpen = false; // Close the popup
        }


        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "BoxData.txt");

            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    // Variables to store current box data
                    string currentTitle = null;
                    string currentContent = null;
                    float currentX = 0;
                    float currentY = 0;

                    foreach (string line in lines)
                    {
                        if (line.StartsWith("Title: "))
                        {
                            currentTitle = line.Substring("Title: ".Length);
                        }
                        else if (line.StartsWith("Content: "))
                        {
                            currentContent = line.Substring("Content: ".Length);
                        }
                        else if (line.StartsWith("X: "))
                        {
                            float.TryParse(line.Substring("X: ".Length), out currentX);
                        }
                        else if (line.StartsWith("Y: "))
                        {
                            float.TryParse(line.Substring("Y: ".Length), out currentY);

                            // Create a new MovableBox with the loaded data
                            Box newBox = new Box(boxIdCounter, currentTitle, currentContent);
                            MovableBox movableBox = new MovableBox(newBox, canvas);
                            movableBox.DeleteButtonClicked += HandleDeleteButtonClicked;
                            canvas.Children.Add(movableBox);

                            // Set the position of the loaded MovableBox
                            Canvas.SetLeft(movableBox, currentX);
                            Canvas.SetTop(movableBox, currentY);

                            boxIdCounter++;
                        }
                    }

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading box data: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No box data file found on the desktop.");
            }
        }







    }
}
