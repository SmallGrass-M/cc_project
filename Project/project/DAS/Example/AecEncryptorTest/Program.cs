using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AecEncryptorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "c3f47504-7734-4ad3-9ff0-e30d3bc1ef5a";
            string key = "95719F41-8111-47";
            string iV = "easypassv3161115";

            string newStr = DrawAecEncryptor.AesEncrypt(str, key, iV, true);

            Console.WriteLine("加密前：" + str);
            Console.WriteLine("加密后：" + newStr);

            string decStr = "QCrj/jONC6v2xuzejJU9VOrYjmR4l/6wiq0Nor/+4hIb4eLnzXETVJO8ugo7nNWF";
            newStr = DrawAecEncryptor.AesDecrypt(decStr, key, iV);

            Console.WriteLine("解密后：" + newStr);
            Console.ReadLine();
        }
    }
}
