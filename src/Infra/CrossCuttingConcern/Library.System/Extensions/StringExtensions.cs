using System;
using System.Text;

namespace Library.System.Extensions
{
    public static class StringExtensions
    {
        public static string Base64Decode(this string base64EncodedData)
        {
            //Check if the specified string contains white-space characters
            var mm = base64EncodedData.Replace(" ", "").Length % 4;
            if (mm > 0)
            {
                //Trailing padding
                base64EncodedData += new string('=', 4 - mm);
            }

            var data = Convert.FromBase64String(base64EncodedData);

            return Encoding.UTF8.GetString(data);
        }
    }
}
