// FileName:  RotationManager.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180502 13:33
// Description:   

#region

using System.Windows;
using System.Windows.Media;

#endregion

namespace AttachProperty {

    class RotationManager : DependencyObject {
        public static double GetAngle(DependencyObject obj) {
            return (double)obj.GetValue(AngleProperty);
        }

        public static void SetAngle(DependencyObject obj, double value) {
            obj.SetValue(AngleProperty, value);
        }

        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.RegisterAttached("Angle", typeof(double), typeof(RotationManager), new PropertyMetadata(0.0, OnAngleChanged));

        private static void OnAngleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e) {
            if (obj is UIElement element) {
                element.RenderTransformOrigin = new Point(0.5, 0.5);
                element.RenderTransform = new RotateTransform((double)e.NewValue);
            }
        }
    }
}