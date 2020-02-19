using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;


namespace TestCoordinated
{
    public sealed partial class MainPage : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TheButton_Click(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(SecondPage), null, new SuppressNavigationTransitionInfo());
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            try
            {
                ConnectedAnimationService.GetForCurrentView()?
                    .PrepareToAnimate("ThumbnailToHeaderAnimation", TheButton);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
