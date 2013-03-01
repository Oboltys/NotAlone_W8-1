using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Основная страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=234237

namespace NotAlone_v3
{
    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class StartPage : NotAlone_v3.Common.LayoutAwarePage
    {
        string UserID;

        private IMobileServiceTable<NotAlone_v3.Views.Users> Events = App.MobileService.GetTable<NotAlone_v3.Views.Users>();


        private ObservableCollection<Data.MenuTilesGroup> _groups;

        public StartPage()
        {
            this.InitializeComponent();

            _groups = new ObservableCollection<Data.MenuTilesGroup>();
            var first = new Data.MenuTilesGroup { GroupName = "Events" };
            var second = new Data.MenuTilesGroup { GroupName = "Dashboard" };
            _groups.Add(first);
            _groups.Add(second);
            first.MenuTiles.Add(new Data.MenuTiles { Title = "New event", Description = "Create a new event", HorizontalSize = 2, VerticalSize = 2, Image = "/Assets/Q/2.png" });
            first.MenuTiles.Add(new Data.MenuTiles { Title = "All events", Description = "...", HorizontalSize = 1, VerticalSize = 1, Image = "/Assets/Q/4.png" });
            second.MenuTiles.Add(new Data.MenuTiles { Title = "Me", Description = "My account", HorizontalSize = 2, VerticalSize = 2, Image = "/Assets/Logo.png" });
            second.MenuTiles.Add(new Data.MenuTiles { Title = "Last events", Description = "Where I was", HorizontalSize = 1, VerticalSize = 1, Image = "/Assets/Q/1.png" });
            second.MenuTiles.Add(new Data.MenuTiles { Title = "Upcoming events", Description = "Where I will be", HorizontalSize = 1, VerticalSize = 1, Image = "/Assets/Logo.png" });
            cvsMain.Source = _groups;
            gvZoomedOut.ItemsSource = cvsMain.View.CollectionGroups;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {            
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Заполняет страницу содержимым, передаваемым в процессе навигации. Также предоставляется любое сохраненное состояние
        /// при повторном создании страницы из предыдущего сеанса.
        /// </summary>
        /// <param name="navigationParameter">Значение параметра, передаваемое
        /// <see cref="Frame.Navigate(Type, Object)"/> при первоначальном запросе этой страницы.
        /// </param>
        /// <param name="pageState">Словарь состояния, сохраненного данной страницей в ходе предыдущего
        /// сеанса. Это значение будет равно NULL при первом посещении страницы.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Сохраняет состояние, связанное с данной страницей, в случае приостановки приложения или
        /// удаления страницы из кэша навигации. Значения должны соответствовать требованиям сериализации
        /// <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">Пустой словарь, заполняемый сериализуемым состоянием.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void gvMain_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var itemId = ((Data.MenuTiles)e.ClickedItem).Title.ToString();

            if (itemId == "New event")
                this.Frame.Navigate(typeof(Views.AddNewEventPage));
            if (itemId == "All events")
                this.Frame.Navigate(typeof(Views.AllEventsPage));
            if (itemId == "Me")
                this.Frame.Navigate(typeof(Views.AdminDashboardPage));
        }
    }
}
