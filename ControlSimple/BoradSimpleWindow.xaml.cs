// FileName:  BoradSimpleWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180507 14:20
// Description:   

#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

#endregion

namespace ControlSimple {

    /// <summary>
    ///     BoradSimpleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BoradSimpleWindow : Window {

        public BoradSimpleWindow() {
            InitializeComponent();

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            // Create a Border which will be the target of the animation.
            Border myBorder = new Border {
                Background = Brushes.Gray,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Margin = new Thickness(0, 60, 0, 20),
                Padding = new Thickness(20)
            };


            // Assign the border a name so that
            // it can be targeted by a Storyboard.
            RegisterName(
                "myAnimatedBorder", myBorder);

            ThicknessAnimation myThicknessAnimation = new ThicknessAnimation {
                Duration = TimeSpan.FromSeconds(1.5),
                FillBehavior = FillBehavior.HoldEnd,
                From = new Thickness(1, 1, 1, 1),
                To = new Thickness(28, 14, 28, 14)
            };

            // Set the From and To properties of the animation.
            // BorderThickness animates from left=1, right=1, top=1, and bottom=1 
            // to left=28, right=28, top=14, and bottom=14 over one and a half seconds.

            // Set the animation to target the Size property
            // of the object named "myArcSegment."
            Storyboard.SetTargetName(myThicknessAnimation, "myAnimatedBorder");
            Storyboard.SetTargetProperty(
                myThicknessAnimation, new PropertyPath(Border.BorderThicknessProperty));

            // Create a storyboard to apply the animation.
            Storyboard ellipseStoryboard = new Storyboard();
            ellipseStoryboard.Children.Add(myThicknessAnimation);

            // Start the storyboard when the Path loads.
            myBorder.Loaded += delegate { ellipseStoryboard.Begin(this); };

            StackPanel myStackPanel = new StackPanel { HorizontalAlignment = HorizontalAlignment.Center };
            myStackPanel.Children.Add(myBorder);

            Content = myStackPanel;
        }

    }

}