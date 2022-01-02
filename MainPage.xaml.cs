using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ShowTimeApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            

        }
        public ObservableCollection<login> GetLogins(string connectionString)
        {
            const string GetloginsQuery = "select email, password from login";
            var logins = new ObservableCollection<login>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if(conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetloginsQuery;
                                using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while(reader.Read())
                                {
                                    var login = new login();
                                    login.email = reader.GetString(1);
                                    login.password = reader.GetString(2);
                                }
                            }
                        }
                    }
                }
                return logins;

            }
            catch(Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {
            Button loginbtn = (Button)sender;
        }
    }
}
