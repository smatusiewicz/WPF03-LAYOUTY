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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Gra dla dwóch graczy (nie z komputerem)

        //ropoczecie gry przez pierwszego gracza ale po każdym ruchu zmienia się gracz
        public bool isPlayer1playing { get; set; }

        public int Counter { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            //uruchamiamy restart na starcie gry
            NewGame();
        }

        //metoda umożliwiająca restart gry w dowolnym momecie

        public void NewGame()
        {
            isPlayer1playing = false;
            Counter = 0;
            //czyszczenie siatki po rozpoczęciu nowej gry
            Przycisk00.Content = string.Empty;
            Przycisk01.Content = string.Empty;
            Przycisk02.Content = string.Empty;
            Przycisk10.Content = string.Empty;
            Przycisk11.Content = string.Empty;
            Przycisk12.Content = string.Empty;
            Przycisk20.Content = string.Empty;
            Przycisk21.Content = string.Empty;
            Przycisk22.Content = string.Empty;

            Przycisk00.Background = Brushes.Gray;
            Przycisk01.Background = Brushes.Gray;   
            Przycisk02.Background = Brushes.Gray;
            Przycisk10.Background = Brushes.Gray;
            Przycisk11.Background = Brushes.Gray;
            Przycisk12.Background = Brushes.Gray;
            Przycisk20.Background = Brushes.Gray;
            Przycisk21.Background = Brushes.Gray;
            Przycisk22.Background = Brushes.Gray;

        }

        //metoda po kliknięciu przycisku
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //zmiana gracza po każdym ruchu

            if (isPlayer1playing)
            {
                isPlayer1playing = false;
            }
            else
            {
                isPlayer1playing = true;
            }

            Counter++;

            // sprawdzamy czy licznik nie wynosi 10 - wtedy rozpoczęcie nowej gry
            if (Counter > 9)
            {
                NewGame();
                return;
            }

            var button = sender as Button;

            //zmiana X lub O w zależności od tego który gracz gra 
            if (isPlayer1playing)
            {
                button.Content = "X";
            } else
            {
                button.Content = "O";
            }

            // podświetlanie przycisków które wygrały
            if (CheckIfPlayer1Won())
            {
                //wtedy kolejny przycisk rozpocznie nową grę
                Counter = 9;
            }

            
        }
       
        private bool CheckIfPlayer1Won()
        {
            //sprawdzanie wygranej w rzędzie 0
            if (Przycisk00.Content != string.Empty && Przycisk00.Content == Przycisk01.Content && Przycisk01.Content == Przycisk02.Content )
            {
                Przycisk00.Background = Brushes.Blue;
                Przycisk01.Background = Brushes.Blue;
                Przycisk02.Background = Brushes.Blue;
                return true;
            }
            // sprawdzenie wygranej w rzędzie 1
            if (Przycisk10.Content != string.Empty && Przycisk10.Content == Przycisk11.Content && Przycisk11.Content == Przycisk12.Content)
            {
                Przycisk10.Background = Brushes.Blue;
                Przycisk11.Background = Brushes.Blue;
                Przycisk12.Background = Brushes.Blue;
                return true;
            }

            // sprawdzenie wygranej w rzędzie 2
            if (Przycisk20.Content != string.Empty && Przycisk20.Content == Przycisk21.Content && Przycisk21.Content == Przycisk22.Content)
            {
                Przycisk20.Background = Brushes.Blue;
                Przycisk21.Background = Brushes.Blue;
                Przycisk22.Background = Brushes.Blue;
                return true;
            }

            // sprawdzenie wygranej w kolumnie 0
            if (Przycisk00.Content != string.Empty && Przycisk00.Content == Przycisk10.Content && Przycisk10.Content == Przycisk20.Content)
            {
                Przycisk00.Background = Brushes.Blue;
                Przycisk10.Background = Brushes.Blue;
                Przycisk20.Background = Brushes.Blue;
                return true;
            }

            // sprawdzenie wygranej w kolumnie 1
            if (Przycisk01.Content != string.Empty && Przycisk01.Content == Przycisk11.Content && Przycisk11.Content == Przycisk21.Content)
            {
                Przycisk01.Background = Brushes.Blue;
                Przycisk11.Background = Brushes.Blue;
                Przycisk21.Background = Brushes.Blue;
                return true;
            }

            // sprawdzenie wygranej w kolumnie 2
            if (Przycisk02.Content != string.Empty && Przycisk02.Content == Przycisk12.Content && Przycisk12.Content == Przycisk22.Content)
            {
                Przycisk02.Background = Brushes.Blue;
                Przycisk12.Background = Brushes.Blue;
                Przycisk22.Background = Brushes.Blue;
                return true;
            }

            // sprawdzenie pierwszej przekatnej
            if (Przycisk00.Content != string.Empty && Przycisk00.Content == Przycisk11.Content && Przycisk11.Content == Przycisk22.Content)
            {
                Przycisk00.Background = Brushes.Blue;
                Przycisk11.Background = Brushes.Blue;
                Przycisk22.Background = Brushes.Blue;
                return true;
            }

            // sprawdzenie drugiej przekatnej
            if (Przycisk02.Content != string.Empty && Przycisk02.Content == Przycisk11.Content && Przycisk11.Content == Przycisk20.Content)
            {
                Przycisk02.Background = Brushes.Blue;
                Przycisk11.Background = Brushes.Blue;
                Przycisk20.Background = Brushes.Blue;
                return true;
            }


            return false;
        }
    }
}
