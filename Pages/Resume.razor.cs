using Microsoft.AspNetCore.Components;

using BlazorResume.Codes;

namespace BlazorResume.Pages
{
    public partial class Resume : ComponentBase
    {
        // If you bind to one 'filter' you get a linked list.
        string selectedSkill = "";
        string selectedGroup = "";
        string selectedUnknown = "";

        Dictionary<string, List<string>> skillGroups = new()
        {
            { "XR", new List<string> { "AR", "VR", "HoloLens", "Unity", "DirectX" } },
            { "Cloud", new List<string> { "Azure", "Intune", "Endpoint", "Jira" } },
            { "Code", new List<string> { "C#", "Python", "SQL", "DirectX" } },
            { "Engines", new List<string> { "Unity", "DirectX" } },
            { "Job", new List<string> { "Job" } }
        };

        List<WorkHistory> workHistory = new()
        {
            new WorkHistory {
                Title = "Unity C# Developer",
                Company = "Haven Studios",
                Location = "Remote · Spokane Valley, WA",
                Duration = "Mar 2009 - Present · 16 yrs 7 mos",
                Description = "Working on AI, Quantum Computers, AR, and Video Games. Building a cross-platform Unity-based app for games and Bible study.",
                Skills = new List<string> { "Unity", "C#", "AR", "VR", "AI", "Cross-platform", "XAML", "Python", "SQL", "DirectX", "HoloLens" }
            },
            new WorkHistory {
                Title = "Owner",
                Company = "Haven Studios LLC",
                Location = "Washougal, WA",
                Duration = "Mar 2013 - Jun 2014 · 1 yr 4 mos",
                Description = "Built a company, secured funding, released BlindContact7 and OneTwoNine.",
                Skills = new List<string> { "Entrepreneurship", "App Development", "Game Design", "Funding", "Leadership" }
            },
            new WorkHistory {
                Title = "IT Consultant",
                Company = "Windows Management Experts, Inc. (WME)",
                Location = "Remote · Spokane Valley, WA",
                Duration = "Mar 2022 - Present · 3 yrs 7 mos",
                Description = "Microsoft Endpoint, Azure AD, Intune.",
                Skills = new List<string> { "Intune", "Azure", "Endpoint", "Consulting", "Remote Work" }
            },
            new WorkHistory {
                Title = "Intune Administrator",
                Company = "Windows Management Experts, Inc. (WME)",
                Location = "Spokane, WA",
                Duration = "Mar 2023 - Aug 2023 · 6 mos",
                Description = "Teams Admin, helpdesk support, Jira tickets.",
                Skills = new List<string> { "Intune", "Azure", "Jira", "Support", "Admin" }
            },
            new WorkHistory {
                Title = "Rover Contractor",
                Company = "Rover.com",
                Location = "Remote · Spokane, WA",
                Duration = "Aug 2023 - Feb 2025 · 1 yr 7 mos",
                Description = "Pet care services, dog boarding, emotional care.",
                Skills = new List<string> { "Job", "Pet Care", "Customer Service", "Remote Work", "Teamwork" }
            },
            new WorkHistory {
                Title = "Video Streamer",
                Company = "Self-employed",
                Location = "Remote",
                Duration = "Feb 2018 - 2020 · 2 yrs",
                Description = "YouTube channel with 99+ dev videos and 109 Let's Plays.",
                Skills = new List<string> { "Job", "C#", "Streaming", "YouTube", "Game Dev", "Content Creation", "Video Editing" }
            }
        };

        HashSet<string> allGroupedSkills => skillGroups
            .SelectMany(kvp => kvp.Value)
            .ToHashSet();

        HashSet<string> allWorkSkills => workHistory
            .SelectMany(w => w.Skills)
            .ToHashSet();

        List<string> unknownSkills => allWorkSkills
            .Where(skill => !allGroupedSkills.Contains(skill))
            .OrderBy(skill => skill)
            .ToList();

        //List<string> unknownSkills => allWorkSkills
        //    .Where(skill => !allGroupedSkills.Contains(skill))
        //    .Where(skill => !allWorkSkills.Contains(skill))
        //    .Distinct()
        //    .OrderBy(skill => skill)
        //    .ToList();

        //List<string> unknownSkills = new()
        //{
        //    "AI",
        //    "Cross-platform",
        //    "XAML",
        //    "Entrepreneurship",
        //    "App Development",
        //    "Game Design",
        //    "Funding",
        //    "Leadership",
        //    "Consulting",
        //    "Remote Work",
        //    "Support",
        //    "Admin",
        //    "Pet Care",
        //    "Customer Service",
        //    "Teamwork",
        //    "Streaming",
        //    "YouTube",
        //    "Content Creation",
        //    "Video Editing"
        //};


        List<string> allSkills => workHistory.SelectMany(w => w.Skills).Distinct().ToList();

        private IEnumerable<WorkHistory> FilteredWorkItems =>
            string.IsNullOrEmpty(selectedSkill)
            ? workHistory
            : workHistory.Where(item =>
                item.Skills.Contains(selectedSkill) ||
                (skillGroups.ContainsKey(selectedSkill) && item.Skills.Any(tag => skillGroups[selectedSkill].Contains(tag)))
        );

        List<string> FilteredSkills =>
            string.IsNullOrEmpty(selectedGroup)
                ? skillGroups.SelectMany(g => g.Value).Distinct().ToList()
                : skillGroups.TryGetValue(selectedGroup, out var skills) ? skills : new List<string>();

        IEnumerable<WorkHistory> FilteredWorkItemsByTags =>
            string.IsNullOrEmpty(selectedSkill)
                ? workHistory
                : workHistory.Where(w => w.Skills.Contains(selectedSkill));

        List<string> allGroups => skillGroups.Keys.ToList();

        private IEnumerable<WorkHistory> FilteredWorkItemsByGroup =>
            string.IsNullOrEmpty(selectedGroup)
                ? workHistory
                : workHistory.Where(item =>
                    item.Skills.Any(tag =>
                        skillGroups.TryGetValue(selectedGroup, out var groupTags) &&
                        groupTags.Contains(tag)
                    )
        );

        private IEnumerable<WorkHistory> FilteredWorkItemsGroupSkill =>
            workHistory.Where(item =>
                (string.IsNullOrEmpty(selectedGroup) ||
                 item.Skills.Any(skill =>
                     skillGroups.TryGetValue(selectedGroup, out var groupSkills) &&
                     groupSkills.Contains(skill))) &&
                (string.IsNullOrEmpty(selectedSkill) ||
                 item.Skills.Contains(selectedSkill))
            );
    }
}