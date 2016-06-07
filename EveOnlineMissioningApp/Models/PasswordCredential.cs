using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;

namespace EveOnlineMissioningApp.Models
{
    public class PasswordCredential
    {

        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string hash { get; set; }
        public Salt salt { get; set; }

        public Boolean authenticate(string password)
        {
            string testHash = getHashString(password);

            return (testHash.Equals(hash));
        }

        public string getHashString(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str + salt.id);
            SHA256Managed sha = new SHA256Managed();
            byte[] hashBytes = sha.ComputeHash(bytes);
            StringBuilder hashStr = new StringBuilder();

            foreach (byte hashByte in hashBytes)
            {
                hashStr.Append(hashByte.ToString("x2"));
            }

            return hashStr.ToString();
        }

    }
}