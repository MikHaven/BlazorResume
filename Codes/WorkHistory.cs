namespace BlazorResume.Codes
{
    /// <summary>
    /// Since we wanted to convert one data, Linkedin to other we used this.
    /// </summary>
    public class WorkHistory
    {
        public string Title { get; set; } = "";
        public string Company { get; set; } = "";
        public string Location { get; set; } = "";
        public string Duration { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> Skills { get; set; } = new List<string>();
    }
}