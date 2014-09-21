using LocationReporter.External;
using LocationReporter.Geospatial;
using System;
using System.Collections.Generic;
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

namespace LocationReporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeMap();
        }

        /// <summary>
        /// Initializes the browser with map
        /// </summary>
        private void InitializeMap()
        {
            string programDirectory = Directory.GetCurrentDirectory();
            mapViewPort.Source = new Uri(String.Format("file:///{0}/MapClient.html", programDirectory));
        }

        /// <summary>
        /// Handles the UI logic for validating the positon
        /// </summary>
        private void validateLocationDataButton_Click(object sender, RoutedEventArgs e)
        {
            bool isLatitudeValid = GeospatialValidator.isLatitudeValid(latitudeTextBox.Text);
            bool isLongitudeValid = GeospatialValidator.isLongitudeValid(longitudeTextBox.Text);

            latitudeTextBox.Background = isLatitudeValid ? Brushes.LightGreen : Brushes.Red;
            longitudeTextBox.Background = isLongitudeValid ? Brushes.LightGreen : Brushes.Red;

            if (isLatitudeValid && isLongitudeValid)
            {
                repositionMap();
                publishLocationDataButton.IsEnabled = true;
            }
            else
            {
                publishLocationDataButton.IsEnabled = false;
                MessageBox.Show("The entered position is not valid. Please ensure that the lat long has been entered in Decimal Degrees (i.e -23.324, 34.43).",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Publishes the location to the specified consumer
        /// </summary>
        private void publishLocationDataButton_Click(object sender, RoutedEventArgs e)
        {
           IPositionReport posReporter = ExternalPublishFactory.getExternalDataConsumer(ExternalPublishFactory.ExternalDataConsumers.AMAZON_SQS);
           posReporter.sendPosition(latitudeTextBox.Text, longitudeTextBox.Text);
           MessageBox.Show("Position has been published!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Handles the interaction with the javascript/map
        /// </summary>
        private void repositionMap()
        {
            String latitude = latitudeTextBox.Text;
            String longitude = longitudeTextBox.Text;
            mapViewPort.InvokeScript("setCenter", new object[] { latitude, longitude });
        }

    }
}
