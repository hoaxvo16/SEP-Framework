using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SEPFramework.Membership;

namespace SEPFramework.Factory
{
    public abstract class LogInHandler
    {
        public abstract void Login(Login login);
        public abstract object LoadData();

        public class UserInfo
        {
            public string UserName { get; set; }
            public string PassWord { get; set; }

            // public object Facebok, Google, ..
        }

        protected bool isLogIn = false;
        public bool IsLogin
        {
            get { return this.isLogIn; }
        }

        public void Logout()
        {
            this.isLogIn = false;
        }
    }

    

    public class LogInFactory
    {
        public static LogInHandler getType(string type)
        {
            if (type == "Normal")
                return new NormalLogin();
            else if (type == "Facebook")
                return new FacebookLogin();
            else if (type == "Twitter")
                return new TwitterLogin();
            else if (type == "Google")
                return new GoogleLogin();
            return null;
        }
    }

    class NormalLogin : LogInHandler
    {
        public NormalLogin() { }



        public override void Login(Login login)
        {
            var userName = login.UserName;
            var password = login.Password;
            var data = LoadData();
            List<UserInfo> list = (List<UserInfo>)data;
            foreach (var item in list)
            {
                if (item != null && item.UserName == userName && item.PassWord == password)
                {
                    isLogIn = true;
                    return;
                }
            }
            isLogIn = false;
        }

        public override object LoadData()
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + "data.xml";
            XDocument xDocument = XDocument.Load(path);

            return xDocument.Descendants("Account").
                            Select(o => new UserInfo
                            {
                                UserName = o.Element("UserName").Value,
                                PassWord = o.Element("PassWord").Value
                            }).ToList();

        }
    }

    class FacebookLogin : LogInHandler
    {
        public override void Login(Login login)
        {
            throw new NotImplementedException();
        }
        public override object LoadData()
        {
            throw new NotImplementedException();
        }
    }

    class TwitterLogin : LogInHandler
    {
        public override void Login(Login login)
        {
            throw new NotImplementedException();
        }
        public override object LoadData()
        {
            throw new NotImplementedException();
        }
    }

    class GoogleLogin : LogInHandler
    {
        public override void Login(Login login)
        {
            throw new NotImplementedException();
        }
        public override object LoadData()
        {
            throw new NotImplementedException();
        }
    }

}
