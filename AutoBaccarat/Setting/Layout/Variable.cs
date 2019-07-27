using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AutoBaccarat
{
    internal sealed class Variable
        {
            [DebuggerNonUserCode]
            internal static ScreenCatcher Catcher()
            {
                return _screenCatcher;
            }

            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            internal static void ScreenCatcher(ScreenCatcher screenCatcher)
            {
                _screenCatcher = screenCatcher;
            }

            private static ScreenCatcher _screenCatcher;
        }
    
}