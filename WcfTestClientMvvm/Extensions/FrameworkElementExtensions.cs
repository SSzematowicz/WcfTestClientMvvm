using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WcfTestClientMvvm
{
    public static class FrameworkElementExtensions
    {
        public static async Task SlideIn(this FrameworkElement element, AnimateDirection direction, bool firstLoad, float seconds = 0.3F)
        {
            var sb = new Storyboard();

            switch (direction)
            {
                case AnimateDirection.Left:
                    sb.AddSlideFromLeft(seconds, element.ActualWidth);
                    break;
                case AnimateDirection.Up:
                    sb.AddSlideDown(seconds, element.ActualHeight);
                    break;
            }
            sb.Begin(element);

            if (firstLoad)
                element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);

        }

        public static async Task SlideOut(this FrameworkElement element, AnimateDirection direction, bool firstLoad, float seconds = 0.3F)
        {
            var sb = new Storyboard();

            switch(direction)
            {
                case AnimateDirection.Left:
                    sb.AddSlideToLeft(seconds, element.ActualWidth);
                    break;
                case AnimateDirection.Up:
                    sb.AddSlideUp(seconds, element.ActualHeight);
                    break;
            }

            sb.Begin(element);

            if (firstLoad)
                element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
       }        
    }


}
