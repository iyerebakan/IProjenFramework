using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScaffoldMigrationApp.Helpers
{
    public class ConsoleWriter : TextWriter
    {
        public static ConsoleWriter Current { get; }

        static ConsoleWriter()
        {
            Current = new ConsoleWriter();
        }

        private FileStream FileStream { get; set; }
        private TextWriter FileTextWriter { get; set; }
        private TextWriter ConsoleTextWriter { get; set; }

        public string FilePath { get; set; }

        public override Encoding Encoding => ConsoleTextWriter.Encoding;

        public ConsoleWriter()
        {
            var logDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LOG");

            if (!Directory.Exists(logDirectoryPath))
            {
                Directory.CreateDirectory(logDirectoryPath);
            }

#pragma warning disable SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'
            FileStream = new FileStream(Path.Combine(logDirectoryPath, $"{DateTime.Now.ToFileTimeUtc()}.txt"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
#pragma warning restore SCS0018 // Path traversal: injection possible in {1} argument passed to '{0}'

            FileTextWriter = new StreamWriter(FileStream);
            ConsoleTextWriter = Console.Out;

            Console.SetOut(this);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            FileTextWriter.Write(buffer, index, count);
            FileTextWriter.Flush();
            ConsoleTextWriter.Write(buffer, index, count);
        }

        public override void WriteLine(char[] buffer, int index, int count)
        {
            FileTextWriter.WriteLine(buffer, index, count);
            FileTextWriter.Flush();
            ConsoleTextWriter.WriteLine(buffer, index, count);
        }

        public override void Write(char value)
        {
            FileTextWriter.Write(value);
            FileTextWriter.Flush();
            ConsoleTextWriter.Write(value);
        }

        protected override void Dispose(bool disposing)
        {
            FileStream.Dispose();
            FileTextWriter.Dispose();

            Console.SetOut(ConsoleTextWriter);
            base.Dispose(disposing);
        }

        #region Static
        
        public static void WriteJson(object value, ConsoleColor color)
        {
            var jsonWriter = new JsonTextWriter(ConsoleWriter.Current) as JsonWriter;
            var jsonSerializer = JsonSerializer.Create();

            jsonWriter.Formatting = Formatting.Indented;
            jsonWriter.FloatFormatHandling = FloatFormatHandling.Symbol;
            jsonWriter.AutoCompleteOnClose = true;
            jsonWriter.DateFormatHandling = DateFormatHandling.IsoDateFormat;

            Console.ForegroundColor = color;
            jsonSerializer.Serialize(jsonWriter, value);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void Default(string message)
        {
            Write(message, ConsoleColor.DarkGray);
            Console.WriteLine();
        }

        public static void Info(string message)
        {
            Write(message, ConsoleColor.Green);
            Console.WriteLine();
        }

        public static void Error(string message)
        {
            Write(message, ConsoleColor.Red);
            Console.WriteLine();
        }

        public static void Warning(string message)
        {
            Write(message, ConsoleColor.Yellow);
            Console.WriteLine();
        }

        public static void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        #endregion Static
    }
}
