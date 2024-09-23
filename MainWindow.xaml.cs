using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private char[] _maleLitery = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
        private char[] _wielkieLitery = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
        private char[] _cyfry = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
        private char[] _znakiSpecjalne = ['!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+'];
        private string _haslo = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         ***********************************************
          nazwa funkcji:    <GenerujHaslo>
          opis funkcji:     <Generuje hasło za pomocą button "Generuj Hasło">

          autor:            <Wiktor Filipczuk>
         ***********************************************
         */
        private void GenerujHaslo(object sender, RoutedEventArgs e)
        {
            _haslo = string.Empty;

            var liczbaZnakow = int.Parse(iloscZnakow.Text);
            var czyDuze = litery.IsChecked;
            var czyCyfry = cyfry.IsChecked;
            var czyZnaki = znaki.IsChecked;
            var wpisaneDuze = false;
            var wpisaneCyfry = false;
            var wpisaneZnaki = false;

            var rng = new Random();

            if (!czyDuze.HasValue) czyDuze = false;
            if (!czyCyfry.HasValue) czyCyfry = false;
            if (!czyZnaki.HasValue) czyZnaki = false;

            if (liczbaZnakow > 0)
            {
                for (var i = 0; i < liczbaZnakow; i++)
                {
                    var temp = rng.Next(7);

                    if (temp == 1 && czyDuze.Value && !wpisaneDuze)
                    {
                        _haslo += _wielkieLitery[rng.Next(_wielkieLitery.Length)];
                        wpisaneDuze = true;
                    }
                    else if (temp == 3 && czyCyfry.Value && !wpisaneCyfry)
                    {
                        _haslo += _cyfry[rng.Next(_cyfry.Length)];
                        wpisaneCyfry = true;
                    }
                    else if (temp == 5 && czyZnaki.Value && !wpisaneZnaki)
                    {
                        _haslo += _znakiSpecjalne[rng.Next(_znakiSpecjalne.Length)];
                        wpisaneZnaki = true;
                    }
                    else
                    {
                        _haslo += _maleLitery[rng.Next(_maleLitery.Length)];
                    }
                }
                MessageBox.Show(_haslo);
            }
        }

        /*
         ***********************************************
          nazwa funkcji:    <Zatwierdz>
          opis funkcji:     <Obsługuje button "Zatwierdz">

          autor:            <Wiktor Filipczuk>
         ***********************************************
         */
        private void Zatwierdz(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Dane pracownika: {imie.Text} {nazwisko.Text} {stanowisko.Text} Hasło: {_haslo}");
        }
    }
}