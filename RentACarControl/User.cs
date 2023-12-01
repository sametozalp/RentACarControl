using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarControl
{
    internal class User
    {
        public User(int id, string mail, DateTime date)
        {
            this.id = id;
            this.mail = mail;
            this.date = date;
        }

        public int getAd() { return id; }
        public DateTime getDate() { return date; }
        public string getMail() { return mail; }

        private int id;
        private string mail;
        private DateTime date;
    }
}
