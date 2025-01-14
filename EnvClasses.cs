// WindowsPhoneSpeedyBlupi, Version=1.0.0.5, Culture=neutral, PublicKeyToken=6db12cd62dbec439
// WindowsPhoneSpeedyBlupi.Def

using static WindowsPhoneSpeedyBlupi.EnvClasses;

namespace WindowsPhoneSpeedyBlupi
{

    public static class EnvClasses
    {
        public enum Platform
        {
            Desktop,
            Android,
            iOS,
            Web
        }

        public enum Impl
        {
            MonoGame = ProgrammingLanguage.CSharp,
            FNA = ProgrammingLanguage.CSharp,
            KNI = ProgrammingLanguage.CSharp,
            JXNA = ProgrammingLanguage.Java,
            JSXNA = ProgrammingLanguage.JavaScript
        }

        public enum ProgrammingLanguage
        {
            CSharp,
            Java,
            JavaScript
        }

    
    }

    public static class Extensions
    {
        public static ProgrammingLanguage getProgrammingLanguage(this Impl xnaImpl)
        {
            return (ProgrammingLanguage)((int)xnaImpl);
        }
        public static bool isMonoGame(this Impl xnaImpl)
        {
            return xnaImpl == Impl.MonoGame;
        }
        public static bool isFNA(this Impl xnaImpl)
        {
            return xnaImpl == Impl.FNA;
        }

        public static bool isKNI(this Impl xnaImpl)
        {
            return xnaImpl == Impl.KNI;
        }

        public static bool isJXNA(this Impl xnaImpl)
        {
            return xnaImpl == Impl.JXNA;
        }

        public static bool isJSXNA(this Impl xnaImpl)
        {
            return xnaImpl == Impl.JSXNA;
        }
        public static bool isNotMonoGame(this Impl xnaImpl)
        {
            return xnaImpl != Impl.MonoGame;
        }
        public static bool isNotFNA(this Impl xnaImpl)
        {
            return xnaImpl != Impl.FNA;
        }

        public static bool isNotKNI(this Impl xnaImpl)
        {
            return xnaImpl != Impl.KNI;
        }

        public static bool isNotJXNA(this Impl xnaImpl)
        {
            return xnaImpl != Impl.JXNA;
        }

        public static bool isNotJSXNA(this Impl xnaImpl)
        {
            return xnaImpl != Impl.JSXNA;
        }
        //
        public static bool isDesktop(this Platform platform)
        {
            return platform == Platform.Desktop;
        }
        public static bool isAndroid(this Platform platform)
        {
            return platform == Platform.Android;
        }
        public static bool isIOS(this Platform platform)
        {
            return platform == Platform.iOS;
        }
        public static bool isWeb(this Platform platform)
        {
            return platform == Platform.Web;
        }
        public static bool isNotDesktop(this Platform platform)
        {
            return platform != Platform.Desktop;
        }
        public static bool isNotAndroid(this Platform platform)
        {
            return platform != Platform.Android;
        }
        public static bool isNotIOS(this Platform platform)
        {
            return platform != Platform.iOS;
        }
        public static bool isNotWeb(this Platform platform)
        {
            return platform != Platform.Web;
        }
    }
}