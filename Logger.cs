using static System.Console;

namespace ATM_Simulator;

class Logger
{
    private string logFolder = "logs";

    public Logger()
    {
        if (!Directory.Exists(logFolder))
        {
            Directory.CreateDirectory(logFolder);
        }
    }

    public void LogSuccessfulLogin(string username)
    {
        string logMessage = $"Succesful login for user: {username} at {DateTime.Now}";

        try
        {
            File.AppendAllText(Path.Combine(logFolder,"successfulLogins.txt"), logMessage + Environment.NewLine);
        }
        catch(Exception ex)
        {
            WriteLine($"\n{ex.Message}");
        }
    }

    public void LogUserActivity(string username, string activity)
    {
        string logMessage = $"User: {username}, Activity: {activity}, Time: {DateTime.Now}";
        try
        {
            File.AppendAllText(Path.Combine(logFolder, "userActivity.txt"), logMessage + Environment.NewLine);
        }
        catch (Exception ex)
        {
            WriteLine($"\n{ex.Message}");
        }
    }

    public void LogSystemError(Exception ex)
    {
        string logMessage = $"Error: {ex.Message}, Time: {DateTime.Now}";
        try
        {
            File.AppendAllText(Path.Combine(logFolder, "systemErrors.txt"), logMessage + Environment.NewLine);
        }
        catch (Exception logEx)
        {
            WriteLine($"\n{logEx.Message}");
        }
    } 
}