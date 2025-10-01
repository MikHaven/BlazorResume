// File: LayoutState.cs
// Project: BlazorResume
// Date Header Updated: Sep 26, 2025 7:11PM
// Date Header Created: Sep 23, 2025 10:28PM
// Date File Created: Sep 23, 2025 10:28PM
// Version: 0.0.0.0000

namespace BlazorResume.Codes
{
    /// <summary>
    /// LayoutState is for controlling our side bar.
    /// </summary>
    public class LayoutState
    {
        /// <summary>
        /// We were testing out Actions, and was not doable in a static webpage.
        /// </summary>
        public event Action? OnSideBarToggled;
        
        /// <summary>
        /// We also use private backed fields and public accessors
        /// </summary>
        bool _sidebarCollapsed;
        /// <summary>
        /// This gives us control and usability to who is managing our state.
        /// </summary>
        public bool SidebarCollapsed
        {
            get => _sidebarCollapsed;
            set
            {
                _sidebarCollapsed = value;
                OnSideBarToggled?.Invoke();
            }
        }
    }
}