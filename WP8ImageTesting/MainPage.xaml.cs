using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;

namespace WP8ImageTesting
{
    public partial class MainPage : PhoneApplicationPage
    {
        //Binding Object
        private readonly TimeClock _timeClock = new TimeClock();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DataContext = _timeClock;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //Trigger imageUrl Update
            _timeClock.UpdateImage();
        }

        private void BufferImage_OnImageOpened(object sender, RoutedEventArgs e)
        {
            var bufferImage = sender as Image;
            var parentGrid = bufferImage.Parent as Grid;
            //get image grid by check type of Grid.
            var imageGrid = parentGrid.Children.First(child => child.GetType() == typeof (Grid)) as Grid;
            //set image background brush
            imageGrid.Background = new ImageBrush {ImageSource = bufferImage.Source};
        }
    }

    internal class TimeClock : BindableBase
    {
        private static string BaseImageUrl = "http://168.63.133.149/drupal-7/?q=solomon/ws/graph/stockmap/TIMER/";

        private static string NewImageUrl
        {
            get { return BaseImageUrl + "?&g=" + Guid.NewGuid(); }
        }

        public string _imageUrl = NewImageUrl;

        public string ImageUrl
        {
            get
            {
                _imageUrl = NewImageUrl;
                return _imageUrl;
            }
            set { SetProperty(ref _imageUrl, value); }
        }

        public async Task UpdateImage()
        {
            OnPropertyChanged("ImageUrl");
        }
    }
}