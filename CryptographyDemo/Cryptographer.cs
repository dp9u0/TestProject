using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyDemo {

    public sealed class Cryptographer : IDisposable {

        private SymmetricAlgorithm _mobjCryptoService;

        private string _key;

        /// <summary>
        /// 对称加密类的构造函数
        /// </summary>
        public Cryptographer() {
            _mobjCryptoService = new RijndaelManaged();
            _key = "fvHUFCy76*h%(HilJ$lhj!y6&(*jkP87jH7Guz(%&hj7x89H$yuBI0456FtmaT5&";
            _mobjCryptoService.Padding = PaddingMode.PKCS7;
        }
        /// <summary>
        /// 获得密钥
        /// </summary>
        /// <returns>密钥</returns>
        private byte[] GetLegalKey() {
            string sTemp = _key;
            _mobjCryptoService.GenerateKey();
            byte[] bytTemp = _mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');
            var key= ASCIIEncoding.ASCII.GetBytes(sTemp);
            return key;
        }
        /// <summary>
        /// 获得初始向量IV
        /// </summary>
        /// <returns>初试向量IV</returns>
        private byte[] GetLegalIV() {
            string sTemp = "ghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjkE4ghj*Ghg7!rNIfb&95GUY86Gf";
            _mobjCryptoService.GenerateIV();
            byte[] bytTemp = _mobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            var iv= ASCIIEncoding.ASCII.GetBytes(sTemp);
            return iv;
        }
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        public string Encrypto(string Source) {
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
            MemoryStream ms = new MemoryStream();
            _mobjCryptoService.Key = GetLegalKey();
            _mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = _mobjCryptoService.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            byte[] bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut);
        }
        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="Source">待解密的串</param>
        /// <returns>经过解密的串</returns>
        public string Decrypto(string Source) {
            string result = string.Empty;
            byte[] bytIn = Convert.FromBase64String(Source);
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
            _mobjCryptoService.Key = GetLegalKey();
            _mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = _mobjCryptoService.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            result = sr.ReadToEnd();
            sr.Close();
            return result;
        }


        #region IDisposable 成员
        
        public void Dispose() {
            //_mobjCryptoService.Dispose();
        }

        #endregion
    }

}
