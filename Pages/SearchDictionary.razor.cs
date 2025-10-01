// File: SearchDictionary.razor.cs
// Project: BlazorResume
// Date Header Updated: Sep 26, 2025 7:11PM
// Date Header Created: Sep 26, 2025 10:19AM
// Date File Created: Sep 26, 2025 10:19AM
// Version: 0.0.0.0000

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

using BlazorResume.Codes;

namespace BlazorResume.Pages
{
    public partial class SearchDictionary : ComponentBase
    {
        [Inject] public SearchService SearchService { get; set; } = default!;

        string _searchTerm = "";
        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                if (_searchTerm != value)
                {
                    _searchTerm = value;
                    StateHasChanged();
                }
            }
        }

        public IEnumerable<WordEntry> FilteredItems => SearchService.FilteredItems(SearchTerm);

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(50);
            //SearchService.Initialize();
        }

        WordEntry? selectedItem; // Replace ItemType with your actual model type

        async Task HandleFocus(WordEntry focusWord)
        {
            selectedItem = focusWord;
            await SearchService.HandleFocus(focusWord);
        }

        async Task ToggleDefinition(WordEntry word)
        {
            await SearchService.ToggleDefinition(word);
        }
    }
}

//public partial class SearchDictionary : ComponentBase
//{
//    string _searchTerm = "";

//    public string SearchTerm
//    {
//        get => _searchTerm;
//        set
//        {
//            if (_searchTerm != value)
//            {
//                _searchTerm = value;
//                StateHasChanged(); // Trigger UI refresh
//            }
//        }
//    }

//    //WordEntry[]? wordEntries;
//    List<WordEntry> wordEntries = new List<WordEntry>();

//    IEnumerable<WordEntry> FilteredItems =>
//        string.IsNullOrWhiteSpace(SearchTerm)
//        ? wordEntries
//        : wordEntries.Where(i => i.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase));

//    public IEnumerable<WordEntry> Contains(string sWord)
//    {
//        IEnumerable<WordEntry> containsItems =
//        string.IsNullOrWhiteSpace(sWord)
//        ? wordEntries
//        : wordEntries.Where(i => i.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase));
//        return containsItems;   
//    }

//    protected override async Task OnInitializedAsync()
//    {
//        await Task.Delay(50);

//        wordEntries = new List<WordEntry>()
//        {
//            new WordEntry { Name = "Apple", Definition = "Fruit"},
//            new WordEntry { Name = "Banana", Definition = "Fruit" },
//            new WordEntry { Name = "Cherry", Definition = "Fruit" },
//            new WordEntry { Name = "Date", Definition = "Fruit" }
//        };
//    }

//    //protected override async Task OnParametersSetAsync()
//    //{
//    //    await Task.Delay(50);

//    //    wordEntries = new List<WordEntry>
//    //    {
//    //        new WordEntry { Name = "Apple" },
//    //        new WordEntry { Name = "Banana" },
//    //        new WordEntry { Name = "Cherry" },
//    //        new WordEntry { Name = "Date" }
//    //    };
//    //}

//    public void ClearShown()
//    {
//        foreach (var wordEntry in wordEntries)
//        {
//            wordEntry.IsShowDefinition = false;
//        }
//    }

//    async Task HandleBlur(WordEntry wordItem)
//    {
//        wordItem.IsFocused = false;
//        wordItem.IsShowDefinition = false;
//        await JS.InvokeVoidAsync("blurElement", wordItem.ID);
//        //ClearShown();
//    }

//    async Task HandleFocus(WordEntry wordItem)
//    {
//        wordItem.IsFocused = true;
//        //wordItem.IsShowDefinition = true;
//        // await JS.InvokeVoidAsync("focusElement", "myButton");
//        //ClearShown();
//    }

//    async Task ToggleDefinition(WordEntry wordEntry)
//    {
//        bool isShown = wordEntry.IsShowDefinition;
//        ClearShown();
//        wordEntry.IsShowDefinition = !isShown;
//        if (!wordEntry.IsShowDefinition)
//        {
//            // Optional: blur the button manually
//            await JS.InvokeVoidAsync("blurElement", wordEntry.ID);
//        }
//    }
//}

// Simulate asynchronous loading to demonstrate streaming rendering
//await Task.Delay(500);
//var startDate = DateOnly.FromDateTime(DateTime.Now);
//var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
//wordEntries = Enumerable.Range(1, 5).Select(index => new WordEntry
//{
//    Date = startDate.AddDays(index),
//    TemperatureC = Random.Shared.Next(-20, 55),
//    Definition = summaries[Random.Shared.Next(summaries.Length)]
//}).ToArray();
