using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public interface IBaseViewModel
    {
        string PageTitle { get; set; }
        public string ActiveSidebar { get; set; }
        public string ActiveSidebarL1 { get; set; }
        public string ActiveSidebarL2 { get; set; }
        public string ActiveSidebarL3 { get; set; }

        void setSidebar(string sidebar);
    }

    public class BaseViewModel : IBaseViewModel
    {
        public string PageTitle { get; set; }
        public string ActiveSidebar { get; set; } = "";
        public string ActiveSidebarL1 { get; set; }
        public string ActiveSidebarL2 { get; set; }
        public string ActiveSidebarL3 { get; set; }

        public string Copyright
        {
            get
            {
                return $"Copyright © 2021 - {DateTime.Now.Year} Library.";
            }
        }
        public string Version
        {
            get
            {
                return "v1.0.0";
            }
        }

        public void setSidebar(string sidebar)
        {
            ActiveSidebar = sidebar;

            if (string.IsNullOrEmpty(ActiveSidebar))
                return;

            string[] ActiveSidebarPieces = ActiveSidebar.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            ActiveSidebarL1 = ActiveSidebarPieces.Length > 0 ? ActiveSidebarPieces[0] : "";
            ActiveSidebarL2 = ActiveSidebarPieces.Length > 1 ? ActiveSidebarPieces[1] : "";
            ActiveSidebarL3 = ActiveSidebarPieces.Length > 2 ? ActiveSidebarPieces[2] : "";
        }
    }
}
