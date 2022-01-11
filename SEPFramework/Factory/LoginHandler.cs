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
        public abstract void LoadData();
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
            LoadData();
        }

        public override void LoadData()
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + "data.xml";
            XDocument xDocument = XDocument.Load(path);

            var data = xDocument.Descendants("Account").Where(t => Int32.Parse(t.Attribute("Id").Value) > 0).
                            Select(o => new
                            {
                                id = o.Attribute("Id").Value,
                                username = o.Element("UserName").Value,
                                password = o.Element("PassWord").Value
                            }).ToList();

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

        }
    }

    class FacebookLogin : LogInHandler
    {
        public override void Login(Login login)
        {
            throw new NotImplementedException();
        }
        public override void LoadData()
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
        public override void LoadData()
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
        public override void LoadData()
        {
            throw new NotImplementedException();
        }
    }

    //abstract class Creator
    //{
    //    public abstract LogInHandler FactoryMethod();
    //}

    //class NormalLoginCreator : Creator
    //{
    //    public override LogInHandler FactoryMethod()
    //    {
    //        return new NormalLogin();
    //    }
    //}

    //class FacebookLoginCreator : Creator
    //{
    //    public override LogInHandler FactoryMethod()
    //    {
    //        return new FacebookLogin();
    //    }
    //}

    //class GoogleLoginCreator : Creator
    //{
    //    public override LogInHandler FactoryMethod()
    //    {
    //        return new GoogleLogin();
    //    }
    //}
}
