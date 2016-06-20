using System;
using System.Windows;

namespace PostList
{
    public class ExceptionHandling
    {

        public static void ShowException(string Message)
        {

           MessageBox.Show(Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
        
        }


    }
}
