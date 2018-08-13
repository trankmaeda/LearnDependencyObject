using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace LearnDependencyObject
{
    class Range : DependencyObject
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(Range), new PropertyMetadata(0, ValueChanged));
        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(int), typeof(Range), new PropertyMetadata(int.MinValue, MinChanged));
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(int), typeof(Range), new PropertyMetadata(int.MaxValue, MaxChanged));

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public int Min
        {
            get => (int)GetValue(MinProperty);
            set => SetValue(MinProperty, value);
        }

        public int Max
        {
            get => (int)GetValue(MaxProperty);
            set => SetValue(MaxProperty, value);
        }

        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AdjustVal((Range)d);
        }

        private static void MinChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AdjustMin((Range)d);
            AdjustVal((Range)d);
        }

        private static void MaxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AdjustMax((Range)d);
            AdjustVal((Range)d);
        }

        private static void AdjustVal(Range range)
        {
            if (range.Value > range.Max)
            {
                range.Value = range.Max;
            }
            if (range.Value < range.Min)
            {
                range.Value = range.Min;
            }
        }

        private static void AdjustMin(Range range)
        {
            if (range.Min > range.Max)
            {
                range.Min = range.Max;
            }
        }

        private static void AdjustMax(Range range)
        {
            if (range.Max < range.Min)
            {
                range.Max = range.Min;
            }
        }
    }
}
