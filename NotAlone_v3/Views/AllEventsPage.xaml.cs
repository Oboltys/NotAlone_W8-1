using Microsoft.WindowsAzure.MobileServices;
using NotAlone_v3.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Основная страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=234237

namespace NotAlone_v3.Views
{

   


    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class AllEventsPage : NotAlone_v3.Common.LayoutAwarePage
    {
        public string imPath;
        public string interestForPath;

        public ObservableCollection<Event> items = new ObservableCollection<Event>();

        private MobileServiceCollectionView<Event> ppp;

        private IMobileServiceTable<Event> Events = App.MobileService.GetTable<Event>();

        public AllEventsPage()
        {
            this.InitializeComponent();
        }

        public IMobileServiceTable<Event> Table
        {
            get { return App.MobileService.GetTable<Event>(); }
        }

        public MobileServiceCollectionView<Event> GetAllSpeaker()
        {
            return Table.OrderBy(a => a.City).IncludeTotalCount().ToCollectionView();
           
        }
        


        private void RefreshTodoItems()
        {
            // This code refreshes the entries in the list view be querying the TodoItems table.
            // The query excludes completed TodoItems
           
            ppp = Table.OrderBy(a => a.City).IncludeTotalCount().ToCollectionView();

            itemListView.ItemsSource = ppp;
            itemGridView.ItemsSource = ppp;
            //ListEvent.ItemsSource = ppp;
            
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
            RefreshTodoItems();   
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

        private void itemGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //(Application.Current as App).nameForInfo = this.itemGridView.SelectedItems.ToString();
            //this.Frame.Navigate(typeof(Views.EventInfoPage));
        }

        private void itemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //(Application.Current as App).nameForInfo = this.itemGridView.SelectedItems.ToString();
            //this.Frame.Navigate(typeof(Views.EventInfoPage));
        }
    }
}
