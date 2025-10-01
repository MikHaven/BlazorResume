// File: SearchService.cs
// Project: BlazorResume
// Date Header Updated: Sep 26, 2025 7:11PM
// Date Header Created: Sep 22, 2025 9:54PM
// Date File Created: Sep 22, 2025 9:54PM
// Version: 0.0.0.0000

namespace BlazorResume.Codes
{
    /// <summary>
    /// Search gives us great functionality and a great demo.
    /// </summary>
    public class SearchService
    {
        /// <summary>
        /// We keep track of our entries here.
        /// </summary>
        List<WordEntry> _wordEntries = new();

        /// <summary>
        /// We like to give an easy way to use our data.
        /// </summary>
        public IEnumerable<WordEntry> WordEntries => _wordEntries;

        /// <summary>
        /// We setup our service and give it default data.
        /// </summary>
        public SearchService()
        {
            Initialize();
        }

        /// <summary>
        /// Default data, gives us a way to test our search.
        /// </summary>
        void Initialize()
        {
            _wordEntries = new List<WordEntry>
            {
                new WordEntry { Name = "Apple", Definition = "Fruit" },
                new WordEntry { Name = "Banana", Definition = "Fruit" },
                new WordEntry { Name = "Cherry", Definition = "Fruit" },
                new WordEntry { Name = "Date", Definition = "Fruit" }
            };
        }

        /// <summary>
        /// A larger concept, that is not used in this Demo.
        /// </summary>
        /// <param name="newWord"></param>
        public void AddWord(WordEntry newWord)
        {
            _wordEntries.Add(newWord);
        }

        /// <summary>
        /// Since we are searching we need to apply a filter to get the search results.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public IEnumerable<WordEntry> FilteredItems(string searchTerm)
        {
            return string.IsNullOrWhiteSpace(searchTerm)
                ? WordEntries
                : WordEntries.Where(i => i.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// We use this to stop showing its 'definition'
        /// </summary>
        public void ClearShown()
        {
            foreach (var word in _wordEntries)
            {
                word.IsShowDefinition = false;
            }
        }

        /// <summary>
        /// Once we click a word, we affect its state to show us more information.
        /// </summary>
        /// <param name="wordItem"></param>
        /// <returns></returns>
        public async Task HandleFocus(WordEntry wordItem)
        {
            wordItem.IsFocused = true;
            //wordItem.IsShowDefinition = true;
            // await JS.InvokeVoidAsync("focusElement", "myButton");
            //ClearShown();
        }

        /// <summary>
        /// Here we lose focus, or want to stop showing a word.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public async Task ToggleDefinition(WordEntry word)
        {
            // Since we know ClearShown will reset regardless we need to save our toggle here.
            bool isShown = word.IsShowDefinition;
            // Resets all so we need to be aware and act accordingly.
            ClearShown();
            // Now that all are turned off, we can use our shown saved previous to toggle.
            word.IsShowDefinition = !isShown;
        }
    }
}