using System;
using System.Windows;

namespace WcfTestClientMvvm
{
    public abstract class BaseAttachedProperty<Perent, Property>
        where Perent : new()
    {
        #region Public events
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };
        public event Action<DependencyObject, object> ValueUdating = (sender, e) => { };
        #endregion //Public events

        public static Perent Instance { get; set; } = new Perent();

        #region AttachedProperty
        public static Property GetValue(DependencyObject obj) => (Property)obj.GetValue(ValueProperty);

        public static void SetValue(DependencyObject obj, Property value) => obj.SetValue(ValueProperty, value);

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Perent, Property>),
                new PropertyMetadata(default(Property),
                    new PropertyChangedCallback(OnValuePropertyChanged), new CoerceValueCallback(OnValuePropertyUpdating)));

        private static object OnValuePropertyUpdating(DependencyObject d, object baseValue)
        {
            (Instance as BaseAttachedProperty<Perent, Property>).OnValueUpdating(d, baseValue);
            (Instance as BaseAttachedProperty<Perent, Property>).ValueUdating(d, baseValue);

            return baseValue;
        }

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (Instance as BaseAttachedProperty<Perent, Property>).OnValueChanged(d, e);
            (Instance as BaseAttachedProperty<Perent, Property>).ValueChanged(d, e);
        }
        #endregion //AttachedProperty

        #region Event Method

        public virtual void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { }
        public virtual void OnValueUpdating(DependencyObject d, object baseValue) { }

        #endregion
    }

}
