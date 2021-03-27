using System.Windows.Input;

namespace PerspectiveCamera.ViewApp
{
    public class KeysState
    {
        //true = down
        public bool W { get; set; }
        public bool S { get; set; }
        public bool A { get; set; }
        public bool D { get; set; }
        public bool Q { get; set; }
        public bool E { get; set; }
        public bool R { get; set; }
        public bool F { get; set; }
        public bool I { get; set; }
        public bool K { get; set; }
        public bool J { get; set; }
        public bool L { get; set; }
        public bool U { get; set; }
        public bool O { get; set; }

        public void SetDefault()
        {
            W = false;
            S = false;
            A = false;
            D = false;
            Q = false;
            E = false;
            R = false;
            F = false;
            I = false;
            K = false;
            J = false;
            L = false;
            U = false;
            O = false;
        }

        public void HandleButtonDown(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    W = true;
                    break;
                case Key.S:
                    S = true;
                    break;
                case Key.A:
                    A = true;
                    break;
                case Key.D:
                    D = true;
                    break;
                case Key.Q:
                    Q = true;
                    break;
                case Key.E:
                    E = true;
                    break;
                case Key.R:
                    R = true;
                    break;
                case Key.F:
                    F = true;
                    break;
                case Key.I:
                    I = true;
                    break;
                case Key.K:
                    K = true;
                    break;
                case Key.J:
                    J = true;
                    break;
                case Key.L:
                    L = true;
                    break;
                case Key.U:
                    U = true;
                    break;
                case Key.O:
                    O = true;
                    break;
            }
        }

        public void HandleButtonUp(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    W = false;
                    break;
                case Key.S:
                    S = false;
                    break;
                case Key.A:
                    A = false;
                    break;
                case Key.D:
                    D = false;
                    break;
                case Key.Q:
                    Q = false;
                    break;
                case Key.E:
                    E = false;
                    break;
                case Key.R:
                    R = false;
                    break;
                case Key.F:
                    F = false;
                    break;
                case Key.I:
                    I = false;
                    break;
                case Key.K:
                    K = false;
                    break;
                case Key.J:
                    J = false;
                    break;
                case Key.L:
                    L = false;
                    break;
                case Key.U:
                    U = false;
                    break;
                case Key.O:
                    O = false;
                    break;
            }
        }
    }
}