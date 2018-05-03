// FileName:  MainWindow.xaml.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20180503 10:50
// Description:   

#region

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#endregion

namespace CommandSample {

    /// <summary>
    ///     MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }
        // Executed event handler.
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e) {
            // Calls a method to close the file and release resources.
            CloseFile();
        }

        private bool _fileOpened = true;
        private bool cursorScopeElementOnly=true;
        private readonly Cursor _customCursor = Cursors.Wait;

        private void CloseFile() {
            _fileOpened = false;
        }

        // CanExecute event handler.
        private void CanExecuteHandler(object sender, CanExecuteRoutedEventArgs e) {
            // Call a method to determine if there is a file open.
            // If there is a file open, then set CanExecute to true.
            if (IsFileOpened()) {
                e.CanExecute = true;
            }
            // if there is not a file open, then set CanExecute to false.
            else {
                e.CanExecute = false;
            }
        }

        private bool IsFileOpened() {
            return _fileOpened;
        }

        private void CursorTypeChanged(object sender, SelectionChangedEventArgs e) {
            ComboBox source = e.Source as ComboBox;

            if (source != null) {
                // Changing the cursor of the Border control 
                // by setting the Cursor property
                if (source.SelectedItem is ComboBoxItem selectedCursor)
                    switch (selectedCursor.Content.ToString()) {
                        case "AppStarting":
                            DisplayArea.Cursor = Cursors.AppStarting;
                            break;
                        case "ArrowCD":
                            DisplayArea.Cursor = Cursors.ArrowCD;
                            break;
                        case "Arrow":
                            DisplayArea.Cursor = Cursors.Arrow;
                            break;
                        case "Cross":
                            DisplayArea.Cursor = Cursors.Cross;
                            break;
                        case "HandCursor":
                            DisplayArea.Cursor = Cursors.Hand;
                            break;
                        case "Help":
                            DisplayArea.Cursor = Cursors.Help;
                            break;
                        case "IBeam":
                            DisplayArea.Cursor = Cursors.IBeam;
                            break;
                        case "No":
                            DisplayArea.Cursor = Cursors.No;
                            break;
                        case "None":
                            DisplayArea.Cursor = Cursors.None;
                            break;
                        case "Pen":
                            DisplayArea.Cursor = Cursors.Pen;
                            break;
                        case "ScrollSE":
                            DisplayArea.Cursor = Cursors.ScrollSE;
                            break;
                        case "ScrollWE":
                            DisplayArea.Cursor = Cursors.ScrollWE;
                            break;
                        case "SizeAll":
                            DisplayArea.Cursor = Cursors.SizeAll;
                            break;
                        case "SizeNESW":
                            DisplayArea.Cursor = Cursors.SizeNESW;
                            break;
                        case "SizeNS":
                            DisplayArea.Cursor = Cursors.SizeNS;
                            break;
                        case "SizeNWSE":
                            DisplayArea.Cursor = Cursors.SizeNWSE;
                            break;
                        case "SizeWE":
                            DisplayArea.Cursor = Cursors.SizeWE;
                            break;
                        case "UpArrow":
                            DisplayArea.Cursor = Cursors.UpArrow;
                            break;
                        case "WaitCursor":
                            DisplayArea.Cursor = Cursors.Wait;
                            break;
                        case "Custom":
                            DisplayArea.Cursor = _customCursor;
                            break;
                    }

                // If the cursor scope is set to the entire application
                // Use OverrideCursor to force the cursor for all elements
                if (cursorScopeElementOnly == false) {
                    Mouse.OverrideCursor = DisplayArea.Cursor;
                }
            }
        }

        private void CursorScopeSelected(object sender, RoutedEventArgs e) {
            cursorScopeElementOnly = RbScopeElement.IsChecked ?? false;
        }

    }

}