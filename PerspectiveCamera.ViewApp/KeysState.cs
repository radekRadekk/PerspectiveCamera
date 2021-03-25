namespace PerspectiveCamera.ViewApp
{
    public static class KeysState
    {
        //true = down
        public static bool W { get; set; }
        public static bool S { get; set; }
        public static bool A { get; set; }
        public static bool D { get; set; }
        public static bool Q { get; set; }
        public static bool E { get; set; }
        public static bool R { get; set; }
        public static bool F { get; set; }
        public static bool I { get; set; }
        public static bool K { get; set; }
        public static bool J { get; set; }
        public static bool L { get; set; }
        public static bool U { get; set; }
        public static bool O { get; set; }

        public static void Reset()
        {
            KeysState.W = false;
            KeysState.S = false;
            KeysState.A = false;
            KeysState.D = false;
            KeysState.Q = false;
            KeysState.E = false;
            KeysState.R = false;
            KeysState.F = false;
            KeysState.I = false;
            KeysState.K = false;
            KeysState.J = false;
            KeysState.L = false;
            KeysState.U = false;
            KeysState.O = false;
        }
    }
}