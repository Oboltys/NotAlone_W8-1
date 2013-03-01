using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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

namespace NotAlone_v3.Views
{   

    public class Event
    {
        public int id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "interests")]
        public string Interests { get; set; }

        [DataMember(Name = "DateTime")]
        public string DateTime { get; set; }

        [DataMember(Name = "Adress")]
        public string Adress { get; set; }

        [DataMember(Name = "Eventis")]
        public bool Eventis { get; set; }

        [DataMember(Name = "User")]
        public string User { get; set; }
    

    }

    public class interes
    {
        public int id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class AddNewEventPage : NotAlone_v3.Common.LayoutAwarePage
    {

        /// <Authenticate>
        /// Аутентификация пользователя в приложнии Microsoft account
        private MobileServiceUser user;
        private string UserID;
        private async System.Threading.Tasks.Task Authenticate()
        {
            while (user == null)
            {
                string message;
                try
                {
                    user = await App.MobileService
                        .LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount);
                    message =
                        string.Format("You are now logged in - {0}", user.UserId);
                    UserID = user.UserId;
                }
                catch (InvalidOperationException)
                {
                    message = "You must log in. Login Required";
                }


                var dialog = new MessageDialog(message);
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }


        }
        /// </Authenticate>

        string check;
        /// <DataAzure>
        /// Описание связи классов с таблицами в Windows Azure
        private MobileServiceCollectionView<Event> ppp;
        private IMobileServiceTable<Event> Interes = App.MobileService.GetTable<Event>();
        /// 
        /// </DataAzure>

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await Authenticate();
            base.OnNavigatedTo(e);
        }

        public AddNewEventPage()
        {
            this.InitializeComponent();
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
              

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /// <Checked Interests>
            /// Выбор интересов для создания встречи
            if (CheckSportFootbal.IsChecked == true)
            {
                check = CheckSportFootbal.Content.ToString();
            }

            if (CheckSportHockey.IsChecked == true)
            {
                check = CheckSportHockey.Content.ToString();
            }

            if (CheckSportTennis.IsChecked == true)
            {
                check = CheckSportTennis.Content.ToString();
            }

            if (CheckSportVolleyball.IsChecked == true)
            {
                check = CheckSportVolleyball.Content.ToString();
            }


            if (CheckMusicPop.IsChecked == true)
            {
                check = CheckMusicPop.Content.ToString();
            }

            if (CheckMusicPank.IsChecked == true)
            {
                check = CheckMusicPank.Content.ToString();
            }

            if (CheckMusicRap.IsChecked == true)
            {
                check = CheckMusicRap.Content.ToString();
            }

            if (CheckMusicRock.IsChecked == true)
            {
                check = CheckMusicRock.Content.ToString();
            }


            if (CheckMovieGenreAction.IsChecked == true)
            {
                check = CheckMovieGenreAction.Content.ToString();
            }

            if (CheckMovieGenreComedy.IsChecked == true)
            {
                check = CheckMovieGenreComedy.Content.ToString();
            }

            if (CheckMovieGenreDrama.IsChecked == true)
            {
                check = CheckMovieGenreDrama.Content.ToString();
            }

            if (CheckMovieGenreTragedy.IsChecked == true)
            {
                check = CheckMovieGenreTragedy.Content.ToString();
            }


            if (CheckTechnologiesWP.IsChecked == true)
            {
                check = CheckTechnologiesWP.Content.ToString();
            }

            if (CheckTechnologiesW8.IsChecked == true)
            {
                check = CheckTechnologiesW8.Content.ToString();
            }

            if (CheckTechnologiesKinect.IsChecked == true)
            {
                check = CheckTechnologiesKinect.Content.ToString();
            }

            if (CheckTechnologiesWA.IsChecked == true)
            {
                check = CheckTechnologiesWA.Content.ToString();
            }

            /// </checked interests>

            /// <New Event>
            /// Создание встречи
            
            

            Event Event = new Event { City = "Kemerovo", Name = NameEvent.Text, Adress = Adress.Text, Interests = check.ToString(), DateTime = DatePicker.Value.ToString(), Eventis = true, User = UserID };
            await App.MobileService.GetTable<Event>().InsertAsync(Event);
            /// </New event>
            
            /// Вывод сообщения о создании встречи 
            var dialog = new MessageDialog("Поздравляю, ты организовал новое событие ;)");
            dialog.Commands.Add(new UICommand("OK"));
            await dialog.ShowAsync();
        }
    }
}
