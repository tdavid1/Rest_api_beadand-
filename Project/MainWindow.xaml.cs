using System;
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

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Allamoklistazas lista = new Allamoklistazas();
        public MainWindow()
        {
            InitializeComponent();
            Allamok_tomb.ItemsSource = lista.GetAll();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Allamokablak ablak = new Allamokablak();
            ablak.Closed += (_, _) =>
            {
                Allamok_tomb.ItemsSource = lista.GetAll();
            };
            ablak.ShowDialog();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Allamok selected = Allamok_tomb.SelectedItem as Allamok;
            if (selected == null)
            {
                MessageBox.Show("Törléshez előbb válasszon ki elemet!");
                return;
            }

            MessageBoxResult clickedButton = MessageBox.Show($"Biztos, hogy törölni szeretné az alábbi Allamot: {selected.Allam}", "Törlés", MessageBoxButton.YesNo);
            if (clickedButton == MessageBoxResult.Yes)
            {
                if (lista.Delete(selected))
                {
                    MessageBox.Show("Sikeres törlés!");
                }
                else
                {
                    MessageBox.Show("Hiba történt a törlés során!");
                }
                Allamok_tomb.ItemsSource = lista.GetAll();
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Allamok selected = Allamok_tomb.SelectedItem as Allamok;
            if (selected == null)
            {
                MessageBox.Show("Módosításhoz előbb válasszon ki elemet!");
                return;
            }

            Allamokablak ablak = new Allamokablak(selected);
            ablak.Closed += (_, _) =>
            {
                Allamok_tomb.ItemsSource = lista.GetAll();
            };
            ablak.ShowDialog();
        }
    }
}