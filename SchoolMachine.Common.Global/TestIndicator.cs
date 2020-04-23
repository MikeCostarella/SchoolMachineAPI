using System;

namespace SchoolMachine.Common.Global
{
    public class TestIndicator
    {
        private static bool isTestMode = false;

        public static bool IsTestMode { get { return isTestMode; } set { isTestMode = value; } }
    }
}
