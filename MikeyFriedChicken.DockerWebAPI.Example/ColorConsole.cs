using System;

namespace MikeyFriedChicken.DockerWebAPI.Example.Controllers
{
    public static class ColorConsole
    {
        public static void WriteLine(string message, string foreground, params object[] args)
        {
            var forgroundInt = GetColour(foreground);

            Console.WriteLine("\u001b[{0}m{1}!\u001b[0m", forgroundInt, String.Format(message, args));
        }

        private static int GetColour(string foreground)
        {
            int forgroundInt;
            switch (foreground)
            {
                case "red":
                    forgroundInt = 31;
                    break;
                case "green":
                    forgroundInt = 32;
                    break;
                case "yellow":
                    forgroundInt = 33;
                    break;
                case "blue":
                    forgroundInt = 34;
                    break;
                case "magenta":
                    forgroundInt = 35;
                    break;
                case "cyan":
                    forgroundInt = 36;
                    break;
                case "white":
                    forgroundInt = 37;
                    break;
                case "reset":
                    forgroundInt = 0;
                    break;
                default:
                    forgroundInt = 30;
                    break;
            }

            return forgroundInt;
        }
    }
}