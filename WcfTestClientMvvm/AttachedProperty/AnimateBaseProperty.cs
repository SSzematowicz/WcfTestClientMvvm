using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace WcfTestClientMvvm
{
    public abstract class AnimateBaseProperty<Perent> : BaseAttachedProperty<Perent, bool>
        where Perent :BaseAttachedProperty<Perent, bool>, new()
    {
        #region Protected Fields
        protected Dictionary<DependencyObject, bool> mAllreadyLoad = new Dictionary<DependencyObject, bool>();

        protected Dictionary<DependencyObject, bool> mFirstLoad = new Dictionary<DependencyObject, bool>();
        #endregion

        public override void OnValueUpdating(DependencyObject d, object baseValue)
        {
            //check the sander is FrameworkElement
            if (!(d is FrameworkElement element))
            {
                return;
            }

            //dont fire when the value dosen't change
            if((bool)d.GetValue(ValueProperty) == (bool)baseValue && mAllreadyLoad.ContainsKey(d))
            {
                return;
            }

            if (!mAllreadyLoad.ContainsKey(d))
            {
                mAllreadyLoad[d] = false;

                element.Visibility = Visibility.Hidden;

                RoutedEventHandler onLoad = null;

                onLoad = async (ss, ee) =>
                {
                    element.Loaded -= onLoad;

                    await Task.Delay(5);

                    DoAnimation(element, mFirstLoad.ContainsKey(d) ? mFirstLoad[d] : (bool)baseValue, true);

                    mAllreadyLoad[d] = true;
                };

                element.Loaded += onLoad;
            }
            else if (mAllreadyLoad[d] == false)
                mFirstLoad[d] = (bool)baseValue;
            else
                DoAnimation(element, (bool)baseValue, false);
        }

        protected virtual void DoAnimation(FrameworkElement element, bool value, bool firstLoad) { }
    }

    public class AnimateSlideFromAboveProperty : AnimateBaseProperty<AnimateSlideFromAboveProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
            {
                await element.SlideIn( AnimateDirection.Up, firstLoad, firstLoad ? 0 : 0.3F);
            }
            else
            {
                await element.SlideOut(AnimateDirection.Up, firstLoad, firstLoad ? 0 : 0.3F);
            }
        }
    }

    public class AnimationSlideFromLeftProperty : AnimateBaseProperty<AnimationSlideFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if(value)
            {
                await element.SlideIn(AnimateDirection.Left, firstLoad, firstLoad ? 0 : 0.3F);
            }
            else
            {
                await element.SlideOut(AnimateDirection.Left, firstLoad, firstLoad ? 0 : 0.3F);
            }
        }
    }

}
