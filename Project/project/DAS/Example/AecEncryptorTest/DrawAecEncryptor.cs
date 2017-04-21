using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AecEncryptorTest
{
    /// <summary>
    /// AES加密
    /// </summary>
    public class DrawAecEncryptor
    {
        #region 加密

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iV">向量</param>
        /// <returns>
        /// 密文
        /// </returns>
        public static string AesEncrypt(string plainStr, string key, string iV)
        {
            var bKey = Encoding.UTF8.GetBytes(key);
            var bIv = Encoding.UTF8.GetBytes(iV);
            var byteArray = Encoding.UTF8.GetBytes(plainStr);

            string encrypt = null;
            var aes = Rijndael.Create();
            try
            {
                using (var mStream = new MemoryStream())
                {
                    using (var cStream = new CryptoStream(mStream, aes.CreateEncryptor(bKey, bIv), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch
            {
                // ignored
            }
            aes.Clear();

            return encrypt;
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainStr">明文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iV">向量</param>
        /// <param name="returnNull">加密失败时是否返回 null，false 返回 String.Empty</param>
        /// <returns>
        /// 密文
        /// </returns>
        public static string AesEncrypt(string plainStr, string key, string iV, bool returnNull)
        {
            var encrypt = AesEncrypt(plainStr, key, iV);
            return returnNull ? encrypt : (encrypt ?? String.Empty);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iV">向量</param>
        /// <returns>
        /// 密文
        /// </returns>
        public static string AesDecrypt(string encryptStr, string key, string iV)
        {
            var bKey = Encoding.UTF8.GetBytes(key);
            var bIv = Encoding.UTF8.GetBytes(iV);
            var byteArray = Convert.FromBase64String(encryptStr);

            string decrypt = null;
            var aes = Rijndael.Create();
            try
            {
                using (var mStream = new MemoryStream())
                {
                    using (var cStream = new CryptoStream(mStream, aes.CreateDecryptor(bKey, bIv), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
            }
            catch
            {
                // ignored
            }
            aes.Clear();

            return decrypt;
        }

        #endregion

        #region 解密

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="toDecrypt">加密字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="iV">向量</param>
        /// <returns></returns>
        public static string Decrypt(string toDecrypt, string key, string iV)
        {
            var keyArray = Encoding.UTF8.GetBytes(key);
            var ivArray = Encoding.UTF8.GetBytes(iV);
            var toEncryptArray = Convert.FromBase64String(toDecrypt);

            var rDel = new RijndaelManaged
            {
                BlockSize = 128,
                KeySize = 256,
                FeedbackSize = 128,
                Padding = PaddingMode.PKCS7,
                Key = keyArray,
                IV = ivArray,
                Mode = CipherMode.CBC
            };

            var cTransform = rDel.CreateDecryptor();

            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }

        #endregion
    }
}
