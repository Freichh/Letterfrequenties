using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Letterfrequenties
{
    /// <summary>
    /// Opdracht 4: Letterfrequenties
    /// Maak een programma dat telt hoe vaak bepaalde letters in een document voorkomen.Test het uit
    /// op teksten in verschillende talen.
    /// Goed algoritmiseren en bedenken hoe de zaak aangepakt moet worden is hier het belangrijkst.
    /// </summary>
    public partial class MainWindow : Window
    {
        string readText;
        string textInput;
        int charCounter;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void open_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                //save text from document in readText var
                readText = File.ReadAllText(openFileDialog.FileName);
                loaded_CheckBox.IsChecked = true;
                search_TextBox.IsEnabled = true;
            }
        }

        private void search_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //save userinput in textInput var
            textInput = search_TextBox.Text;

            if (textInput.Length != 0)
            {
                Console.WriteLine("textInput = " + textInput);
                calculate_Button.IsEnabled = true;
            }
            if (textInput.Length == 0)
            {
                calculate_Button.IsEnabled = false;
            }
        }
        private void search_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //disable numerical input
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = true;
            }
            else
            {
            }
        }

        private void calculate_Button_Click(object sender, RoutedEventArgs e)
        {
            charCounter = 0;

            for (int i = 0; i < readText.Length; i++)
            {
                string readString;

                //check if 1 or 2 chars as input
                if (textInput.Length == 2 && i < readText.Length-1)
                {
                    //create string readString from 2 chars, to use for .Equals
                    readString = readText[i].ToString() + readText[i + 1].ToString();
                }
                else
                {
                    //create string readString from 1 char, to use for .Equals
                    readString = readText[i].ToString();
                }
                
                if (readString.Equals(textInput) == true)
                {
                    charCounter += 1;
                    result_TextBlock.Text = textInput + " appears " + charCounter + " time(s)!";
                }
                else if (readString.Equals(textInput) == false && charCounter == 0)
                {
                    result_TextBlock.Text = textInput + " does not appear!";
                }
            }
        }


    }
}
