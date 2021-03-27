using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using PerspectiveCamera.ViewApp.Extensions;
using PerspectiveCamera.ViewApp.Helpers;

namespace PerspectiveCamera.ViewApp
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();

        private readonly KeysState _keysState;
        private CameraState _cameraState;

        public MainWindow()
        {
            InitializeComponent();

            InitializeLayoutElements();
            InitializeDispatcherTimer();

            _keysState = new KeysState();
            _cameraState = CameraInitialization.DefaultWithThreeCubes();
        }

        private void InitializeLayoutElements()
        {
            DescriptionTextBox.Text = Constants.MenuText;

            Canvas.Focus();
            Canvas.Background = Brushes.CornflowerBlue;
            Canvas.HorizontalAlignment = HorizontalAlignment.Right;
            Canvas.VerticalAlignment = VerticalAlignment.Top;
        }

        private void InitializeDispatcherTimer()
        {
            _dispatcherTimer.Tick += TimerEvent;
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(16);
            _dispatcherTimer.Start();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            _cameraState.HandleControl(_keysState);
            Canvas.Draw(_cameraState);
        }

        private void Canvas_OnKeyDown(object sender, KeyEventArgs e)
        {
            _keysState.HandleButtonDown(e);
        }

        private void Canvas_OnKeyUp(object sender, KeyEventArgs e)
        {
            _keysState.HandleButtonUp(e);
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            _cameraState = CameraInitialization.DefaultWithThreeCubes();
            _keysState.SetDefault();
            Canvas.Draw(_cameraState);
            Canvas.Focus();
        }
    }
}