using System;

namespace PostList
{
    public class PostData
    {
        #region properties

        private int _UserID;
        private int _ID;
        private string _Title;
        private string _Body;

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
     

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string Body
        {
            get { return _Body; }
            set { _Body = value; }
        }
        #endregion properties
   
    }


}
