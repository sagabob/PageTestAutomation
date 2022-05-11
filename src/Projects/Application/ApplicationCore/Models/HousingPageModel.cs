namespace ApplicationCore.Models
{
    public class HousingPageModel
    {
        public MainMenuModel MainMenuModel { get; set; }
    }

    public class MainMenuModel
    {
        public string MenuParentDivClassName { get; set; }
        public string MenuClassName { get; set; }

        public string MenuItemBtnClassName { get; set; }
        public string MenuItemHomeClassName { get; set; }

        public string MenuItemCollapsibleDivClassName { get; set; }
        public string MenuItemCollapsibleUlClassName { get; set; }
        public string MenuItemCollapsibleLiClassName { get; set; }
    }
}