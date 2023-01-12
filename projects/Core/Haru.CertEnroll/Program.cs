using System;
using Haru.Framework.Utils;
using Haru.CertEnroll.Utils;

namespace Haru.CertEnroll
{
    public class Program
    {
        static void Main(string[] args)
        {
            // set log path
            Log.Filepath = $"./Logs/Haru/Cert_{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}.log";

            // handle certificate
            // todo: get password from somewhere
            var certutil = new CertUtil();
            certutil.Load("Haru SSL Authority", string.Empty);
        }
    }
}