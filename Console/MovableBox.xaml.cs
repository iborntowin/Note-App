using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Console
{
    public partial class MovableBox : UserControl
    {
        private bool isDragging = false;
        private Canvas parentCanvas;
        public event EventHandler DeleteButtonClicked;
        private bool isEditMode = false;
        private bool isContentCleared = false;
        private bool isTitleCleared = false;
        public int Id { get; }
        public string Title { get; }
        public float X { get; set; }
        public float Y { get; set; }


        public bool IsEditMode
        {
            get { return (bool)GetValue(IsEditModeProperty); }
            set { SetValue(IsEditModeProperty, value); }
        }
        public static readonly DependencyProperty IsEditModeProperty =
        DependencyProperty.Register("IsEditMode", typeof(bool), typeof(MovableBox), new PropertyMetadata(false));

        public MovableBox(Box box, Canvas canvas)
        {
            InitializeComponent();
            parentCanvas = canvas;
            TitleTextBox.Text = box.Title;
            ContentTextBox.Text = box.Content;

            
            TitleTextBox.IsEnabled = false;
            ContentTextBox.IsEnabled = false;

            X = (float)Canvas.GetLeft(this);
            Y = (float)Canvas.GetTop(this);

        }

        private void ToggleModifyEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (isEditMode)
            {
                ToggleModifyEditButton.Content = "Modify";
                ModifyButtonsPanel.Visibility = Visibility.Hidden;

                // Disable TextBox controls when exiting edit mode
                TitleTextBox.IsEnabled = false;
                ContentTextBox.IsEnabled = false;
            }
            else
            {
                ToggleModifyEditButton.Content = "Done";
                ModifyButtonsPanel.Visibility = Visibility.Visible;

                // Enable TextBox controls when entering edit mode
                TitleTextBox.IsEnabled = true;
                ContentTextBox.IsEnabled = true;
                
            }

            isEditMode = !isEditMode;
        }
        private void ContentTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!isContentCleared && isEditMode)
            {
                ContentTextBox.Clear();
                isContentCleared = true;
            }
        }

        private void ContentTitleBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!isTitleCleared && isEditMode)
            {
                TitleTextBox.Clear();
                isTitleCleared = true;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteButtonClicked != null)
                DeleteButtonClicked(this, EventArgs.Empty);
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            this.CaptureMouse();
            isEditMode = false;

            ToggleModifyEditButton.Content = "Modify";
            ModifyButtonsPanel.Visibility = Visibility.Collapsed;
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            this.ReleaseMouseCapture();
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPosition = e.GetPosition(parentCanvas);
                Canvas.SetLeft(this, currentPosition.X - this.ActualWidth / 2);
                Canvas.SetTop(this, currentPosition.Y - this.ActualHeight / 2);

                X = (float)Canvas.GetLeft(this);
                Y = (float)Canvas.GetTop(this);
            }
        }






    }
}
