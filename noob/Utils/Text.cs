namespace noob.Utils;

public static class Text
{
    public static void WriteLogo()
    {
        Console.WriteLine(@"
      ___         ___         ___                 
     /__/\       /  /\       /  /\       _____    
     \  \:\     /  /::\     /  /::\     /  /::\   
      \  \:\   /  /:/\:\   /  /:/\:\   /  /:/\:\  
  _____\__\:\ /  /:/  \:\ /  /:/  \:\ /  /:/~/::\ 
 /__/::::::::/__/:/ \__\:/__/:/ \__\:/__/:/ /:/\:|
 \  \:\~~\~~\\  \:\ /  /:\  \:\ /  /:\  \:\/:/~/:/
  \  \:\  ~~~ \  \:\  /:/ \  \:\  /:/ \  \::/ /:/ 
   \  \:\      \  \:\/:/   \  \:\/:/   \  \:\/:/  
    \  \:\      \  \::/     \  \::/     \  \::/   
     \__\/       \__\/       \__\/       \__\/    
            ");
    }

    public static void WriteH1(string text)
    {
        Console.WriteLine("\n");
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(text.ToUpper());
        Console.ResetColor();
    }

    public static void WriteH2(string text)
    {
        Console.WriteLine("\n");
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(text.ToUpper());
        Console.ResetColor();
    }

    public static void WriteH3(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(text.ToUpper());
        Console.ResetColor();
    }

    public static void WriteText(string text, bool newline = false)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(text);
        Console.ResetColor();

        if(newline)
        {
            NewLine();
        }
    }

    public static void NewLine()
    {
        Console.WriteLine("\n");
    }
}
