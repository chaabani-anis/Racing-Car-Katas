using System.IO;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmTextConverter
{
    public class UnicodeFileToHtmTextConverter
    {
        private string _fullFilenameWithPath;


        public UnicodeFileToHtmTextConverter(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public string GetFilename()
        {
            return _fullFilenameWithPath;
        }

        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = File.OpenText(_fullFilenameWithPath))
            {
                string html = string.Empty;

                string line = unicodeFileStream.ReadLine();
                while (line != null)
                {
                    html += HttpUtility.HtmlEncode(line);
                    html += "<br />";
                    line = unicodeFileStream.ReadLine();
                }

                return html;
            }
        }
    }
    class HttpUtility
    {
        public static string HtmlEncode(string line)
        {
            line = line.Replace("<", "&lt;");
            line = line.Replace(">", "&gt;");
            line = line.Replace("&", "&amp;");
            line = line.Replace("\"", "&quot;");
            line = line.Replace("\'", "&quot;");
            return line;
        }
    }
}
