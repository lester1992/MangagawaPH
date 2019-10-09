using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangagawaPH.Models;
using System.IO;

namespace MangagawaPH.ViewModel
{
    class FirebaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://mangagawaph-44be4.firebaseio.com/");
        public static FirebaseStorage firebaseStorage = new FirebaseStorage("mangagawaph-44be4.appspot.com");
        //Read All    
        public static async Task<List<Freelancer>> GetAllUser()
        {
            try
            {
                List<Freelancer> userlist = (await firebase
                .Child("Freelancer")
                .OnceAsync<Freelancer>()).Select(item =>
                new Freelancer
                {
                    Email = item.Object.Email,
                    Password = item.Object.Password,
                    Firstname = item.Object.Firstname,                    
                    Lastname = item.Object.Lastname
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read     
        public static async Task<Freelancer> GetUser(string email)
        {
            try
            {
                var allUsers = await GetAllUser().ConfigureAwait(false);
                await firebase
                .Child("Freelancer")
                .OnceAsync<Freelancer>().ConfigureAwait(false);
                return allUsers.Where(a => a.Email == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        //Read All JobType
        public static async Task<List<JobTypes>> GetAllJobType()
        {
            try
            {
                List<JobTypes> JobList = (await firebase
                .Child("JobTypes")
                .OnceAsync<JobTypes>()).Select(item =>
                new JobTypes
                {
                    JobId = item.Object.JobId,
                    JobType = item.Object.JobType
                }).ToList();
                return JobList;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Insert a user    
        public static async Task<bool> AddUser(Freelancer model)
        {
            try
            {
                await firebase
                .Child("Freelancer")
                .PostAsync(model);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update     
        public static async Task<bool> UpdateUser(string email, string password)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new Users() { Email = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User    
        public static async Task<bool> DeleteUser(string email)
        {
            try
            {


                var toDeletePerson = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase.Child("Users").Child(toDeletePerson.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
        
        //upload image
        public static async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            var imageUrl = await firebaseStorage
                .Child("Freelancer")
                .Child(fileName)
                .PutAsync(fileStream);
            return imageUrl;
        }
        public static async Task<string> GetFile(string fileName)
        {
            try
            {
                var imageUrl = await firebaseStorage
                .Child("Freelancer")
                .Child(fileName)
                .GetDownloadUrlAsync().ConfigureAwait(false);
                return imageUrl;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return "default_pic.png";
            }
            
        }
    }
} 
   
