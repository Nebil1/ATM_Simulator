using static System.Console;

namespace ATM_Simulator;

class Logger
{
    public void LogSuccessfulLogin(string username)
    {
        string logMessage = $"Succesful login for user: {username} at {DateTime.Now}";
        try{
            File.AppendAllText("successfulLogins.txt", logMessage + Environment.NewLine);
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
            File.AppendAllText("userActivity.txt", logMessage + Environment.NewLine);
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
            File.AppendAllText("systemErrors.txt", logMessage + Environment.NewLine);
        }
        catch (Exception logEx)
        {
            WriteLine($"\n{logEx.Message}");
        }
    }    
}