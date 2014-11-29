using System;
using System.Diagnostics;

namespace Library.Configuration.Factories
{
    public class CommonFactory
    {
        public Action<string> CreateQueryLogger()
        {
#if DEBUG
            return x => Debug.Write(x);
#endif
        }
    }
}
