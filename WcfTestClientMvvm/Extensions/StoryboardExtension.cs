using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WcfTestClientMvvm
{
    public static class StoryboardExtension
    {
        public static void AddSlideDown(this Storyboard storyboard, float duration,
            double offset, float decelerationRatio = 0.3F)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(0, -offset * 0.75, 0, offset * 0.75),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        public static void AddSlideUp(this Storyboard storyboard, float duration,
                        double offset, float decelerationRatio = 0.3F)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                To = new Thickness(0, -offset * 0.75, 0, offset * 0.75),
                From = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        public static void AddSlideFromLeft(this Storyboard storyboard, float duration, double offset, float decelerationRatio = 0.3F)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(-offset, 0, offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        public static void AddSlideToLeft(this Storyboard storyboard, float duration, 
            double offset, float decelerationRatio = 0.3F)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                To = new Thickness(-offset, 0, offset, 0),
                From = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }
    }
}
