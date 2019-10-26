//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Clue_Week1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Creates an instance of the Rectangle class.
        /// </summary>
        private Rectangle rect;

        /// <summary>
        /// Creates an instance of the Random class.
        /// </summary>
        private Random rand;

        /// <summary>
        /// Contains logic for updating the title with the mouse X and Y coordinates.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">Contains state information.</param>
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            this.Title = "X: " + e.GetPosition(this).X.ToString("N1") + " Y: " + e.GetPosition(this).Y.ToString("N1");
        }

        /// <summary>
        /// Contains logic for generating a random square aligned in a grid.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">Contains state information.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DrawRect();
        }

        /// <summary>
        /// Contains logic for generating a random square aligned in a grid.
        /// </summary>
        private void DrawRect()
        {
            // The canvas width is 624.
            // The canvas height is 648.
            // There are 26 squares across (width).
            // There are 27 squares down (height).
            // One square width:  624 / 26 = 24.
            // One square height: 648 / 27 = 24.
            this.rect = new Rectangle()
            {
                Width = 24,
                Height = 24,
                StrokeThickness = 3,
                Stroke = Brushes.White
            };

            // Refresh the canvas each time the button is clicked.
            GameCanvas.Children.Clear();
            GameCanvas.Children.Add(this.button);
            GameCanvas.Children.Remove(this.rect);
            GameCanvas.Children.Add(this.rect);

            // Generate a new random.
            this.rand = new Random();

            // There are 26 blocks on the width, minus 1 for the border (on the right).
            int findX = this.rand.Next(1, 25);

            // There are 27 blocks on the height, minus 1 for the border (on the bottom).
            int findY = this.rand.Next(1, 25);

            // Determine X position for the rectangle: random * the rectangle's width.
            // Must convert to int since the width is a double.
            int rectX = findX * Convert.ToInt32(this.rect.Width);

            // Determine Y position for the rectangle: random * the rectangle's height.
            int rectY = findY * Convert.ToInt32(this.rect.Height);

            // Set rectangle X position.
            Canvas.SetLeft(this.rect, rectX);

            // Set rectangle Y position.
            Canvas.SetTop(this.rect, rectY);

            // Output X and Y to the console (for debugging).
            Console.WriteLine("X: " + rectX);
            Console.WriteLine("Y: " + rectY);
        }
    }
}
