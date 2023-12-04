using System.Diagnostics;

namespace BankAPI
{
    public class Logging
    {
        public Logging() { }

        public void SaveLog(Exception exception)
        {
            string route= "appLogs.txt";
            using (StreamWriter writer = new StreamWriter(route, true))
            {
                writer.WriteLine("");
                writer.WriteLine(DateTime.Now);
                writer.WriteLine($"ERROR: {exception.Message}");

                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1)!;
                {
                    if (frame != null)
                    {
                        // Escribir información adicional
                        writer.WriteLine($"Function: {frame.GetMethod().Name}");
                        writer.WriteLine($"File: {frame.GetFileName()}");
                        writer.WriteLine($"Line: {frame.GetFileLineNumber()}");
                    }
                }
            }
        }
    }
}
