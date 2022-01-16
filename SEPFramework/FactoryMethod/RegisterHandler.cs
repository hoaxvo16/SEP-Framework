using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SEPFramework.Membership;

namespace SEPFramework.FactoryMethod
{
    public abstract class RegisterHandler
    {
        public abstract bool Register(Register register);
        public abstract bool AddData(UserInfo user);

        public class UserInfo
        {
            public string Email { get; set; }   
            public string UserName { get; set; }
            public string PassWord { get; set; }
        }
    }



    public class SignUpFactory
    {
        public static RegisterHandler getType(string type)
        {
            if (type == "Normal")
                return new NormalRegister();
            else if (type == "Facebook")
                return new FacebookRegister();
            else if (type == "Twitter")
                return new TwitterRegister();
            else if (type == "Google")
                return new GoogleRegister();
            return null;
        }
    }

    class NormalRegister : RegisterHandler
    {
        public NormalRegister() { }

        public override bool Register(Register register)
        {
            var email = register.Email;
            var userName = register.UserName;
            var password = register.Password;
            var confirmPassword = register.ConFirmPassword;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || password != confirmPassword)
            {
                return false;
            }
            UserInfo userInfo = new UserInfo{ Email = email, UserName = userName, PassWord = password };
            if (AddData(userInfo))
            {
                return true;
            }
            return false;
            
        }

        public override bool AddData(UserInfo user)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "data.xml";
                XDocument xDocument = XDocument.Load(path);
                var data = xDocument.Descendants("Account").
                            Select(o => new UserInfo
                            {
                                Email = o.Element("Email").Value,
                                UserName = o.Element("UserName").Value,
                                PassWord = o.Element("PassWord").Value
                            }).ToList();
                foreach (var item in data)
                {
                    if (item.Email == user.Email)
                    {
                        return false;
                    }
                }
                XElement xElement = new XElement("Account");
                xElement.SetElementValue("Email", user.Email);
                xElement.SetElementValue("UserName", user.UserName);
                xElement.SetElementValue("PassWord", user.PassWord);
                xDocument.Element("Accounts").Add(xElement);
                xDocument.Save(path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            

        }
    }

    class FacebookRegister : RegisterHandler
    {
        public override bool Register(Register register)
        {
            throw new NotImplementedException();
        }
        public override bool AddData(UserInfo user)
        {
            throw new NotImplementedException();
        }
    }

    class TwitterRegister : RegisterHandler
    {
        public override bool Register(Register register)
        {
            throw new NotImplementedException();
        }
        public override bool AddData(UserInfo user)
        {
            throw new NotImplementedException();
        }
    }

    class GoogleRegister : RegisterHandler
    {
        public override bool Register(Register register)
        {
            throw new NotImplementedException();
        }
        public override bool AddData(UserInfo user)
        {
            throw new NotImplementedException();
        }
    }

}
