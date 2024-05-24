using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace viragok
{
    public partial class MainWindow : Window
    {
        List<Flowers> flowers;

        public MainWindow()
        {
            InitializeComponent();
            flowers = new List<Flowers>();
            var sr = new StreamReader("../../../src/flowers.txt");
            while (!sr.EndOfStream)
            {
                flowers.Add(new Flowers(sr.ReadLine(), ";"));
            }
            sr.Close();

            listbox.ItemsSource = flowers;
            listbox.SelectionChanged += Listbox_SelectionChanged;
        }
        private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbox.SelectedItem is Flowers selectedFlower)
            {
                string imagePath = Path.Combine("../../../src/img", selectedFlower.ImagePath);
                var bitmap = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                var tempImage = bitmap;
                imgFlower.Source = tempImage;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedItem is Flowers selectedFlower)
            {
                flowers.Remove(selectedFlower);
                listbox.Items.Refresh();
                imgFlower.Source = null;
            }
        }
    }
}