using Microsoft.WindowsAzure.MobileServices;
using System.Security.Principal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
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
using System.Security.Principal;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;




// Документацию по шаблону элемента "Основная страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=234237

namespace NotAlone_v3.Views
{


    public class Users
    {
        public int Id { get; set; }

        [DataMember(Name = "Login")]
        public string Login { get; set; }

        [DataMember(Name = "City")]
        public string City { get; set; }

        [DataMember(Name = "years")]
        public string years { get; set; }

        [DataMember(Name = "AproveEvents")]
        public string AproveEvents { get; set; }

        [DataMember(Name = "Music")]
        public string Music { get; set; }

        [DataMember(Name = "Sport")]
        public string Sport { get; set; }
    }

    

    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class AdminDashboardPage : NotAlone_v3.Common.LayoutAwarePage
    {
        string interesMusic, interesSport;

        public ObservableCollection<Users> items = new ObservableCollection<Users>();

        private MobileServiceCollectionView<Event> LocalUser;

        private IMobileServiceTable<Event> Event = App.MobileService.GetTable<Event>();

        

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


        public AdminDashboardPage()
        {
            this.InitializeComponent();
        }


        public IMobileServiceTable<Event> UsersTable
        {
            get { return App.MobileService.GetTable<Event>(); }
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


        private void RefreshTodoItems()
        {
            // This code refreshes the entries in the list view be querying the TodoItems table.
            // The query excludes completed TodoItems                     

            LocalUser = UsersTable.Where(a => a.User == UserID).IncludeTotalCount().ToCollectionView();   
            ListEvent.ItemsSource = LocalUser;

        }


        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
              
            await Authenticate();
            base.OnNavigatedTo(e);
            RefreshTodoItems();

            if (ListEvent.Items.Count == 0)
            {
               // var dialog = new MessageDialog("dsf");
               /// dialog.Commands.Add(new UICommand("OK"));
              //  await dialog.ShowAsync();
            }

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

        private void ChangeAvatar()
        {



        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {

            ///GetAvatarUrl();
            
            ///<CheckHobbie>
            if (CheckSportFootbal.IsChecked.Value == true)
            {
                interesMusic = "Footbal";
            }

            if (CheckSportHockey.IsChecked.Value == true)
            {
                interesMusic = "Hockey";
            }

            if (CheckSportTennis.IsChecked.Value == true)
            {
                interesMusic = "Tennis";
            }

            if (CheckSportVolleyball.IsChecked.Value == true)
            {
                interesMusic = "Volleyball";
            }


            if (CheckMusicPop.IsChecked.Value == true)
            {
                interesSport = "Pop";
            }

            if (CheckMusicPank.IsChecked.Value == true)
            {
                interesSport = "Pank";
            }

            if (CheckMusicRap.IsChecked.Value == true)
            {
                interesSport = "Rap";
            }

            if (CheckMusicRock.IsChecked.Value == true)
            {
                interesSport = "Rock";
            }


            if (CheckMovieGenreAction.IsChecked.Value == true)
            {
                interesSport = "Action";
            }

            if (CheckMovieGenreComedy.IsChecked.Value == true)
            {
                interesSport = "Comedy";
            }

            if (CheckMovieGenreDrama.IsChecked.Value == true)
            {
                interesSport = "Drama";
            }

            if (CheckMovieGenreTragedy.IsChecked.Value == true)
            {
                interesSport = "Tragedy";
            }


            if (CheckTechnologiesWP.IsChecked.Value == true)
            {
                interesSport = "Windows Phone";
            }

            if (CheckTechnologiesW8.IsChecked.Value == true)
            {
                interesSport = "Windows 8";
            }

            if (CheckTechnologiesKinect.IsChecked.Value == true)
            {
                interesSport = "Kinect";
            }

            if (CheckTechnologiesWA.IsChecked.Value == true)
            {
                interesSport = "Windows Azure";
            }
            ///</CheckHobbie>
            
            Users Event = new Users {AproveEvents = "Oboltys", City = "Kemerovo", years = "20", Login = UserID, Music = interesMusic, Sport = interesSport };
            await App.MobileService.GetTable<Users>().InsertAsync(Event);
        }


        /// <summary>
        /// Gravatar Class
        /// </summary>
        /// <param name="email"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public string GetAvatarUrl()
        {
            var str = "oboltyss@Gmail.com";
            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            HashAlgorithmProvider hashAlgorithm = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha1);
            IBuffer hashBuffer = hashAlgorithm.HashData(buffer);
            var strHashBase64 = CryptographicBuffer.EncodeToBase64String(hashBuffer);        
            const string GravatarUrlFormat = "http://www.gravatar.com/avatar/{0}?r=G&s={1}&d=wavatar";
            var result = new StringBuilder();
            return string.Format(GravatarUrlFormat, strHashBase64);
        }

    }
}
