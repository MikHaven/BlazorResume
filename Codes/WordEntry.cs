// File: WordEntry.cs
// Project: BlazorResume
// Date Header Updated: Sep 26, 2025 7:11PM
// Date Header Created: Sep 22, 2025 9:55PM
// Date File Created: Sep 22, 2025 9:55PM
// Version: 0.0.0.0000

namespace BlazorResume.Codes
{
    /// <summary>
    /// Using the default Temp, we extend to include other data.
    /// We left the temprature data to showcase how it might work for other data.
    /// </summary>
    public class WordEntry
    {
        /// <summary>
        /// Add data in our minds needs to have a SOLID ID that can be unique.
        /// We know its COULD be not unique but is so rare its improbable.
        /// AND IDs are per data, so we can rarely check mutliple, but makes it less rare.
        /// </summary>
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public string Definition { get; set; } = "No definition available.";
        public bool IsShowDefinition { get; set; } = false;
        public bool IsFocused { get; set; } = false;
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; } = 0;
        /// <summary>
        /// These are GREAT for conversions inline.
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}