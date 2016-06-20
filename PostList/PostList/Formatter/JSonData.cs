using System;


namespace PostList
{
    public class JSonData : IFormatter
    {

        public  string GetData(PostData Data)
        {
            try
            {
                return ("{ \r\n User ID : " + Data.UserID + "\r\n ID : " + Data.ID + "\r\n Title : " + Data.Title + "\r\n Detail : " + Data.Body+"\r\n }");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
