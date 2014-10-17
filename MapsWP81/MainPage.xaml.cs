using System;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.UI.Xaml.Shapes;

namespace MapsWP81
{
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void buttonRoad_Click(object sender, RoutedEventArgs e)
        {
            map1.Style = MapStyle.Road;
        }

        private void buttonAerial_Click(object sender, RoutedEventArgs e)
        {
            map1.Style = MapStyle.Aerial;
        }

        private void buttonHybrid_Click(object sender, RoutedEventArgs e)
        {
            map1.Style = MapStyle.AerialWithRoads;
        }

        private void buttonTerrain_Click(object sender, RoutedEventArgs e)
        {
            map1.Style = MapStyle.Terrain;
        }

        private void map1_Loaded(object sender, RoutedEventArgs e)
        {
            ZoomToMalmoe();
        }

        private void buttonMalmoe_Click(object sender, RoutedEventArgs e)
        {
            ZoomToMalmoe();
        }

        private void ZoomToMalmoe()
        {
            var malmoe = new Geopoint(new BasicGeoposition() { Latitude = 55.5868550870444, Longitude = 13.0115601917735 });
            map1.TrySetViewAsync(malmoe, 11.4086892086054, 0, 0, MapAnimationKind.Bow);
        }

        private async void buttonYou_Click(object sender, RoutedEventArgs e)
        {
            var gl = new Geolocator() { DesiredAccuracy = PositionAccuracy.High };

            var location = await gl.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(5));
            var pin = new MapIcon()
            {
                Location = location.Coordinate.Point,
                Title = "You are here!",
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png")),
                NormalizedAnchorPoint = new Point() { X = 0.32, Y = 0.78 },
            };
            map1.MapElements.Add(pin);
            map1.TrySetViewAsync(location.Coordinate.Point, 15, 0, 0, MapAnimationKind.Bow);

            #region Alternative pushpin technique
                //var pin2 = CreatePin();
                //map1.Children.Add(pin2);
                //MapControl.SetLocation(pin2, location.Coordinate.Point);
                //MapControl.SetNormalizedAnchorPoint(pin2, new Point(0.0, 1.0));
            #endregion
        }

        private void buttonLondon_Click(object sender, RoutedEventArgs e)
        {
            var london = new Geopoint(new BasicGeoposition() { Latitude = 51.5067275986075, Longitude = -0.0759853888303041 });
            map1.TrySetViewAsync(london, 16.5, 0, 0, MapAnimationKind.Bow);
        }

        private void Landmarks_Checked(object sender, RoutedEventArgs e)
        {
            map1.TrySetViewAsync(map1.Center, map1.ZoomLevel, 340, 35, MapAnimationKind.Bow);
            map1.LandmarksVisible = true;
        }

        private void Landmarks_Unchecked(object sender, RoutedEventArgs e)
        {
            map1.LandmarksVisible = false;
            map1.TrySetViewAsync(map1.Center, map1.ZoomLevel, 0, 0, MapAnimationKind.Bow);
        }

        private void Pedestrian_Checked(object sender, RoutedEventArgs e)
        {
            map1.PedestrianFeaturesVisible = true;
        }

        private void Pedestrian_Unchecked(object sender, RoutedEventArgs e)
        {
            map1.PedestrianFeaturesVisible = false;
        }

        private void Dark_Checked(object sender, RoutedEventArgs e)
        {
            map1.ColorScheme = MapColorScheme.Dark;
        }

        private void Dark_Unchecked(object sender, RoutedEventArgs e)
        {
            map1.ColorScheme = MapColorScheme.Light;
        }

        private void Watermark_Checked(object sender, RoutedEventArgs e)
        {
            map1.WatermarkMode = MapWatermarkMode.On;
        }

        private void Watermark_Unchecked(object sender, RoutedEventArgs e)
        {
            map1.WatermarkMode = MapWatermarkMode.Automatic;
        }

        private void Traffic_Checked(object sender, RoutedEventArgs e)
        {
            map1.TrafficFlowVisible = true;
        }

        private void Traffic_Unchecked(object sender, RoutedEventArgs e)
        {
            map1.TrafficFlowVisible = false;
        }




        private DependencyObject CreatePin()
        {
            //Creating a Grid element.

            var myGrid = new Grid();
            myGrid.RowDefinitions.Add(new RowDefinition());
            myGrid.RowDefinitions.Add(new RowDefinition());
            myGrid.Background = new SolidColorBrush(Colors.Transparent);

            //Creating a Rectangle
            var myRectangle = new Rectangle();
            myRectangle.Fill = new SolidColorBrush(Colors.Black);
            myRectangle.Height = 20;
            myRectangle.Width = 20;
            myRectangle.SetValue(Grid.RowProperty, 0);
            myRectangle.SetValue(Grid.ColumnProperty, 0);

            //Adding the Rectangle to the Grid
            myGrid.Children.Add(myRectangle);

            //Creating a Polygon
            var myPolygon = new Polygon();
            myPolygon.Points.Add(new Point(2, 0));
            myPolygon.Points.Add(new Point(22, 0));
            myPolygon.Points.Add(new Point(2, 40));
            myPolygon.Stroke = new SolidColorBrush(Colors.Black);
            myPolygon.Fill = new SolidColorBrush(Colors.Black);
            myPolygon.SetValue(Grid.RowProperty, 1);
            myPolygon.SetValue(Grid.ColumnProperty, 0);

            //Adding the Polygon to the Grid
            myGrid.Children.Add(myPolygon);
            return myGrid;
        }

        private void TileSource_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TileSource_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
