using System;
using System.Windows;
using PostList.ViewModels;

namespace PostList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PostView : Window
    {
        public PostView()
        {
            InitializeComponent();
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            PostViewModel obj = new PostViewModel();
            obj.Init();
            this.DataContext = obj;
         
        }

       
    }
}
