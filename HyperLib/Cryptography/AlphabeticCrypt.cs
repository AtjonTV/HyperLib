using System.Text;

namespace HyperLib.Cryptography
{
    public class AlphabeticCrypt
    {
        protected string WebAPI_Str = "http://api.atvg-studios.at/AlphaCrypt/crypt.api.php";
        protected AlphabeticCryptVersion version = AlphabeticCryptVersion.v2;
        protected Managers.JsonManager JsonMan = new Managers.JsonManager();

        public string WebAPI { get; set; }

        public AlphabeticCrypt(AlphabeticCryptVersion version)
        {
            this.version = version;
            WebAPI = WebAPI_Str;
        }

        public AlphabeticCrypt(string WebAPI)
        {
            this.WebAPI = WebAPI;
        }

        public AlphabeticCrypt()
        {
        }

        public string Encrypt(bool useWebAPI, string toEncrypt)
        {
            if (useWebAPI)
            {
                string newRequest = WebAPI + "?ver=" + version.ToString() + "&act=encrypt&str=" + toEncrypt;
                using (System.Net.WebClient wc = new System.Net.WebClient())
                {
                    byte[] response = wc.DownloadData(newRequest);
                    UTF8Encoding utf = new UTF8Encoding();
                    string res = utf.GetString(response);
                    object o = JsonMan.DeSerialize(res, typeof(AlphabeticCryptWebAPI_Response));
                    AlphabeticCryptWebAPI_Response ACWR = (AlphabeticCryptWebAPI_Response)o;
                    if (ACWR.Success)
                        return ACWR.Message;
                    else
                        return ACWR.Error;
                }
            }
            else
                return "Not Implemented";
        }

		public string Decrypt(bool useWebAPI, string toDecrypt)
		{
			if (useWebAPI)
			{
				string newRequest = WebAPI + "?ver=" + version.ToString() + "&act=decrypt&str=" + toDecrypt;
				using (System.Net.WebClient wc = new System.Net.WebClient())
				{
					byte[] response = wc.DownloadData(newRequest);
					UTF8Encoding utf = new UTF8Encoding();
					string res = utf.GetString(response);
					object o = JsonMan.DeSerialize(res, typeof(AlphabeticCryptWebAPI_Response));
					AlphabeticCryptWebAPI_Response ACWR = (AlphabeticCryptWebAPI_Response)o;
					if (ACWR.Success)
						return ACWR.Message;
					else
						return ACWR.Error;
				}
			}
			else
				return "Not Implemented";
		}
    }

    public enum AlphabeticCryptVersion
    {
        v1,
        v2,
        v3
    }

    public class AlphabeticCryptWebAPI_Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }

        public AlphabeticCryptWebAPI_Response(){}
    }
}
