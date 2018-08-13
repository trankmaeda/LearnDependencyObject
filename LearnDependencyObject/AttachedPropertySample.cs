using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace LearnDependencyObject
{
    class AttachedPropertySample
    {
        public static readonly DependencyProperty SampleValueProperty =
            DependencyProperty.RegisterAttached("SampleValue", typeof(int), typeof(AttachedPropertySample), new PropertyMetadata(0));

        public static int GetSampleValue(DependencyObject obj) =>
            (int)obj.GetValue(SampleValueProperty);

        public static void SetSampleValue(DependencyObject obj, int value) =>
            obj.SetValue(SampleValueProperty, value);
    }
}
