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
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for Allamokablak.xaml
    /// </summary>
    public partial class Allamokablak : Window
    {
        Allamoklistazas lista = new Allamoklistazas();
        Allamok allam;
        public Allamokablak()
        {
            InitializeComponent();
        }
        public Allamokablak(Allamok allam)
        {
            InitializeComponent();
            this.allam = allam;
            LoadPerson();
            addButton.Visibility = Visibility.Collapsed;
            updateButton.Visibility = Visibility.Visible;
        }

        private void LoadPerson()
        {
            allam_nev.Text = this.allam.Allam;
            voltame_input.IsChecked = this.allam.Voltame;
            rating_input.Text = this.allam.Rating.ToString();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Allamok allam = allamokcreateform();
                Allamok ujallam = lista.Add(allam);
                if (ujallam.Id != 0)
                {
                    MessageBox.Show("Sikeres felvétel");
                    allam_nev.Text = "";
                    voltame_input.IsChecked = false;
                    rating_input.Text = "";
                }
                else
                {
                    MessageBox.Show("Hiba történt a felvétel során!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Allamok allam = allamokcreateform();
                Allamok updated = lista.Update(this.allam.Id, allam);
                if (updated.Id != 0)
                {
                    MessageBox.Show("Sikeres módosítás!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hiba történt a módosítás során!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Allamok allamokcreateform()
        {
            string allam = allam_nev.Text.Trim();
            bool voltame = (bool)voltame_input.IsChecked;
            string ratingtext = rating_input.Text.Trim();

            if (string.IsNullOrEmpty(allam))
            {
                throw new Exception("Az Allam kitöltése kötelező!");
            }

            if (string.IsNullOrEmpty(ratingtext))
            {
                throw new Exception("Retinget kötelező meg adni kitöltése kötelező!");
            }

            if (!int.TryParse(ratingtext, out int rating))
            {
                throw new Exception("A ratingnek kötelező számnak lenni-e!");
            }

            if (rating < 1 || rating > 5)
            {
                throw new Exception("A Ratingnek 1 és 5 közötti szám lehet!");
            }

            Allamok a = new Allamok();
            a.Allam = allam;
            a.Voltame= voltame;
            a.Rating = rating;
            return a;
        }
    }
}
