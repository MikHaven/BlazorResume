// File: LogService.cs
// Project: BlazorResume
// Date Header Updated: Sep 26, 2025 7:11PM
// Date Header Created: Sep 20, 2025 5:38PM
// Date File Created: Sep 20, 2025 5:38PM
// Version: 0.0.0.0000

namespace BlazorResume.Codes
{
    /// <summary>
    /// This gives us a way to log anything we want and allows us to manage it outselves.
    /// Services are great, this gives us a singleton like service we can use site wide.
    /// </summary>
    public class LogService
    {
        /// <summary>
        /// Events are great, but not really good for threading on Blazor.
        /// </summary>
        public event Action? OnLogAdded;
        /// <summary>
        /// We like to keep a local state
        /// WE know this would overflow, but its for demostrations
        /// </summary>
        public List<string> Logs { get; } = new();

        /// <summary>
        /// We always like to add a boot up message.
        /// Copilot is just great to help with those missing details.
        /// </summary>
        public LogService()
        {
            AddLog($"{nameof(LogService)} serviced by Copilot!");
        }

        /// <summary>
        /// Logs a message, Warnings, Errirs and others are extensions.
        /// We could add a ton, but felt it was for demo.
        /// </summary>
        /// <param name="message"></param>
        public void AddLog(string message)
        {
            Logs.Add($"{DateTime.Now}: {message}");
            OnLogAdded?.Invoke();
        }
    }
}