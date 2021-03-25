using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace PerspectiveCamera.ViewApp
{
    public partial class MainWindow : Window
    {
        private const int Delta = 10;
        private const double ZoomDelta = 1.0;
        private const double FiDelta = 1.0;

        private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();

        public MainWindow()
        {
            State.Init();

            InitializeComponent();

            DescriptionTextBox.Text =
                "W\t- move back \nS\t- move front \nA\t- move left \nD\t- move right \nQ\t- move up\nE\t- move down\n"
                + "R\t- zoom- \nF\t- zoom+\n"
                + "I\\K\t- rotate AX\nJ\\L\t- rotate AY\nU\\O\t- rotate AZ\n";

            Canvas.Focus();
            Canvas.Background = Brushes.CornflowerBlue;
            Canvas.HorizontalAlignment = HorizontalAlignment.Right;
            Canvas.VerticalAlignment = VerticalAlignment.Top;

            _dispatcherTimer.Tick += TimerEvent;
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(16);
            _dispatcherTimer.Start();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            if (KeysState.W)
            {
                State.Points = State.Points.Select(p => (p.X, p.Y, p.Z + Delta, p.Id)).ToArray();
            }

            if (KeysState.S)
            {
                State.Points = State.Points.Select(p => (p.X, p.Y, p.Z - Delta, p.Id)).ToArray();
            }

            if (KeysState.A)
            {
                State.Points = State.Points.Select(p => (p.X + Delta, p.Y, p.Z, p.Id)).ToArray();
            }

            if (KeysState.D)
            {
                State.Points = State.Points.Select(p => (p.X - Delta, p.Y, p.Z, p.Id)).ToArray();
            }

            if (KeysState.Q)
            {
                State.Points = State.Points.Select(p => (p.X, p.Y + Delta, p.Z, p.Id)).ToArray();
            }

            if (KeysState.E)
            {
                State.Points = State.Points.Select(p => (p.X, p.Y - Delta, p.Z, p.Id)).ToArray();
            }

            if (KeysState.R)
            {
                State.Fov += ZoomDelta;
            }

            if (KeysState.F)
            {
                State.Fov -= ZoomDelta;
            }

            if (KeysState.I)
            {
                State.RotateAx(FiDelta);
            }

            if (KeysState.K)
            {
                State.RotateAx(-FiDelta);
            }

            if (KeysState.J)
            {
                State.RotateAy(FiDelta);
            }

            if (KeysState.L)
            {
                State.RotateAy(-FiDelta);
            }

            if (KeysState.U)
            {
                State.RotateAz(FiDelta);
            }

            if (KeysState.O)
            {
                State.RotateAz(-FiDelta);
            }

            State.Draw(Canvas, State.Fov);
        }

        private void Canvas_OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    KeysState.W = true;
                    break;
                case Key.S:
                    KeysState.S = true;
                    break;
                case Key.A:
                    KeysState.A = true;
                    break;
                case Key.D:
                    KeysState.D = true;
                    break;
                case Key.Q:
                    KeysState.Q = true;
                    break;
                case Key.E:
                    KeysState.E = true;
                    break;
                case Key.R:
                    KeysState.R = true;
                    break;
                case Key.F:
                    KeysState.F = true;
                    break;
                case Key.I:
                    KeysState.I = true;
                    break;
                case Key.K:
                    KeysState.K = true;
                    break;
                case Key.J:
                    KeysState.J = true;
                    break;
                case Key.L:
                    KeysState.L = true;
                    break;
                case Key.U:
                    KeysState.U = true;
                    break;
                case Key.O:
                    KeysState.O = true;
                    break;
            }
        }

        private void Canvas_OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    KeysState.W = false;
                    break;
                case Key.S:
                    KeysState.S = false;
                    break;
                case Key.A:
                    KeysState.A = false;
                    break;
                case Key.D:
                    KeysState.D = false;
                    break;
                case Key.Q:
                    KeysState.Q = false;
                    break;
                case Key.E:
                    KeysState.E = false;
                    break;
                case Key.R:
                    KeysState.R = false;
                    break;
                case Key.F:
                    KeysState.F = false;
                    break;
                case Key.I:
                    KeysState.I = false;
                    break;
                case Key.K:
                    KeysState.K = false;
                    break;
                case Key.J:
                    KeysState.J = false;
                    break;
                case Key.L:
                    KeysState.L = false;
                    break;
                case Key.U:
                    KeysState.U = false;
                    break;
                case Key.O:
                    KeysState.O = false;
                    break;
            }
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            State.Init();
            KeysState.Reset();
            Canvas.Focus();
        }
    }
}