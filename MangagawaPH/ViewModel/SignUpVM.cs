using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MangagawaPH.Views;
using MangagawaPH.Models;
using System.Security.Cryptography;

namespace MangagawaPH.ViewModel
{
    public class SignUpVM : INotifyPropertyChanged
    {
        private string email;
        public string Email
        {
            get { return email; }
            set {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string confirmpassword;
        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set {
                confirmpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }
        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set {
                firstname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Firstname"));
            }
        }
        private string middlename;
        public string Middlename
        {
            get { return middlename; }
            set {
                middlename = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Middlename"));
            }
        }
        private string lastname;
        public string Lastname
        {
            get { return lastname; }
            set {
                lastname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Lastname"));
            }
        }
        private string birthday;
        public string Birthday
        {
            get { return birthday; }
            set {
                birthday = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Birthday"));
            }
        }
        private string cellphoneno;
        public string CellphoneNo
        {
            get { return cellphoneno; }
            set {
                cellphoneno = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CellphoneNo"));
            }
        }
        private string dailyrate;
        public string DailyRate
        {
            get { return dailyrate; }
            set {
                dailyrate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DailyRate"));
            }
        }
        private string barangay;
        public string Barangay
        {
            get { return barangay; }
            set {
                barangay = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Barangay"));
            }
        }
        private string city;
        public string City
        {
            get { return city; }
            set {
                city = value;
                PropertyChanged(this, new PropertyChangedEventArgs("City"));
            }
        }
        private string region;
        public string Region
        {
            get { return region; }
            set {
                region = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Region"));
            }
        }
        private string usertype;
        public string UserType
        {
            get { return usertype; }
            set {
                usertype = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserType"));
            }
        }
        public Command SignUpCommand
        {
            get {
                return new Command(() =>
                {
                    if (Password == ConfirmPassword)
                        SignUp();
                    else
                        App.Current.MainPage.DisplayAlert("", "Password must be same as above!", "OK");
                });
            }
        }
        public string SHA512StringHash(String input)
        {
            SHA512 shaM = new SHA512Managed();            
            byte[] data = shaM.ComputeHash(Encoding.UTF8.GetBytes(input));            
            StringBuilder sBuilder = new StringBuilder();            
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }            
            input = sBuilder.ToString();
            return (input);
        }
        private async void SignUp()
        {
            //null or empty field validation, check weather email and password is null or empty

            Freelancer model = new Freelancer();
            ExpHistory EmptyExp = new ExpHistory();            
            model.ContactInfo = new Contact();
            model.Location = new LocationInfo();
            model.Experience = new List<ExpHistory>();
            EmptyExp.ClientName = " ";
            EmptyExp.ClientContact = " ";

            model.Firstname = Firstname;
            model.Middlename = Middlename;
            model.Lastname = Lastname;            
            model.DailyRate = Convert.ToInt32(DailyRate);
            model.ContactInfo.CellphoneNo = CellphoneNo;
            model.ContactInfo.LandlineNo = " ";
            model.Location.Barangay = Barangay;
            model.Location.City = City;
            model.Location.Region = Region;
            model.DailyRate = Convert.ToInt32(DailyRate);
            model.Experience.Add(EmptyExp);
            model.Email = Email;
            model.Password = SHA512StringHash(Password);
            model.IsFreelancer = UserType == "Worker" ? true : false;
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call AddUser function which we define in Firebase helper class
                var user = await FirebaseHelper.AddUser(model);
                //var imagepath = await FirebaseHelper.GetFile(email + ".png");
                var imagepath = "default_pic.png";
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("SignUp Success", "", "Ok");
                    await App.Current.MainPage.Navigation.PushAsync(new MainMasterDetailPage(Email, imagepath, string.Format("{0} {1}", model.Firstname, model.Lastname)));
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "SignUp Fail", "OK");

            }
        }
    }
}
