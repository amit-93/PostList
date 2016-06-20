using System;


namespace PostList
{
    public class HtmlData : IFormatter
    {

        public  string GetData(PostData Data)
        {
            try
            {
                return ("<html> \r\n <head> \r\n <title>\r\n Post List \r\n </title> \r\n </head> \r\n <body> \r\n " + "User ID : " + Data.UserID + "\r\n ID : " + Data.ID + "\r\n Title : " + Data.Title + "\r\n Detail : " + Data.Body + "\r\n " + "</body> \r\n </html>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
