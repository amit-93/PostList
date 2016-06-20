using System;


namespace PostList
{
    public class PlainData : IFormatter
    {
        public string GetData(PostData Data)
        {
            try
            {
                return ("User ID : " + Data.UserID + "\r\n ID : " + Data.ID + "\r\n Title : " + Data.Title + "\r\n Detail : " + Data.Body);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
