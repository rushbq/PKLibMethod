using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKLib_Method.Methods
{
    public abstract class FtpBase
    {
        private string _userName;
        public string Username
        {
            get { return _userName; }
            set { _userName = value; }
        }


        private string _passWord;
        public string Password
        {
            get { return _passWord; }
            set { _passWord = value; }
        }


        private string _serverUrl;
        public string ServerUrl
        {
            get { return _serverUrl; }
            set { _serverUrl = value; }
        }


        public FtpBase(string userName, string passWord, string serverUrl)
        {
            this._userName = userName;
            this._passWord = passWord;
            this._serverUrl = serverUrl;
        }
    }
}
