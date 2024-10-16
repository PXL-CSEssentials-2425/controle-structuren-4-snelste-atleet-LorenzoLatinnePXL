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

namespace SnelsteAtleet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int fastestTime = 0;
        string currentAthlete = "";
        string fastestAthelete;
        bool isFirstInput = true;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValidTimeInput = int.TryParse(timeTextBox.Text, out int timeInput);

            if (!isValidTimeInput)
            {
                resultTextBox.Text = "Invalid time input.";
            } 
            else
            {
                if (isFirstInput || timeInput < fastestTime)
                {
                    fastestTime = timeInput;
                    fastestAthelete = nameTextBox.Text;
                    isFirstInput = false;
                }
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            fastestTime = 0;
            fastestAthelete = "";
            isFirstInput = true;
            resultTextBox.Clear();
            nameTextBox.Clear();
            timeTextBox.Clear();
        }

        private void fastestButton_Click(object sender, RoutedEventArgs e)
        {
            int aantalUren = (fastestTime / 3600);
            int aantalMinuten = (fastestTime % 3600) / 60;
            int aantalSeconden = (fastestTime % 3600) % 60 ;

            if (fastestTime != 0)
            {
                resultTextBox.Text = $"De snelste atleet is {fastestAthelete}\n" +
                    $"totaal aantal seconden: {fastestTime}\n\n" +
                    $"aantal uren: {aantalUren}\n" +
                    $"aantal minuten: {aantalMinuten}\n" +
                    $"aantal seconden: {aantalSeconden}";
            }
            else
            {
                resultTextBox.Text = $"No current data entered.";
            }
        }

        private void timeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            newButton.Focus();
        }
    }
}
