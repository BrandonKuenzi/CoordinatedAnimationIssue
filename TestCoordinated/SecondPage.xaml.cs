using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;


namespace TestCoordinated
{
    public sealed partial class SecondPage : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;

        public SecondPage()
        {
            this.InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(MainPage), null, new SuppressNavigationTransitionInfo());
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var _animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ThumbnailToHeaderAnimation");
            _animation.Configuration = new BasicConnectedAnimationConfiguration();
            if (_animation != null)
            {
               var isAnimating = _animation.TryStart(Header, new UIElement[] { CoordinatedText1, CoordinatedText2 });
            }
        }
    }
}
