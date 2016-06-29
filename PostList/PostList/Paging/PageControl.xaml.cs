using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PostList.Paging
{
    /// <summary>
    /// Interaction logic for PageControl.xaml
    /// </summary>
    public partial class PageControl : UserControl
    {
        public static int start = 1;
        public static int end = 0;
        public static int itemCount;
        public static int totalItems = 0;
        public static PageControl pageControl;
        public static bool flag = false;

        public static ObservableCollection<PostData> PagingPostList;
        public static readonly DependencyProperty DepPostListProperty = DependencyProperty.RegisterAttached("DepPostList", typeof(ObservableCollection<PostData>), typeof(PageControl), new FrameworkPropertyMetadata(DepPostList_CollectionChanged) { BindsTwoWayByDefault = true });


        public ObservableCollection<PostData> DepPostList
        {
            get { return (ObservableCollection<PostData>)GetValue(DepPostListProperty); }
            set
            {
                SetValue(DepPostListProperty, value);
            }
        }

        public PageControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        private static void DepPostList_CollectionChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!flag)
            {
                pageControl = sender as PageControl;
                var items = e.NewValue as ObservableCollection<PostData>;
                PagingPostList = new ObservableCollection<PostData>();
                foreach (var item in items)
                    PagingPostList.Add(item);
                totalItems = PagingPostList.Count;
                itemCount = Convert.ToInt32(AppConfig.ConfigValue[Constant.ItemCount]);
                ReloadPostList();
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement BtnSource = e.Source as FrameworkElement;

            totalItems = PagingPostList.Count;

            switch (BtnSource.Name)
            {

                case Constant.First: start = 1;
                    break;
                case Constant.Next: start = start + itemCount;
                    if (start > totalItems - itemCount)
                        start = totalItems - itemCount + 1;
                    break;
                case Constant.Previous: start = start - itemCount;
                    if (start <= 1)
                        start = 1;
                    break;
                case Constant.Last: start = totalItems - itemCount + 1;
                    break;

            }

            ReloadPostList();

        }

        private static void ReloadPostList()
        {

            end = start + itemCount - 1 < totalItems ? start + itemCount - 1 : totalItems;
            int LoopCount = start + itemCount - 1;


            if (PagingPostList != null)
            {
                if (!flag)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        pageControl.DepPostList.RemoveAt(0);
                    }
                }

                if (flag)
                    pageControl.DepPostList = new ObservableCollection<PostData>();

                for (int i = start - 1; i < LoopCount; i++)
                {
                    pageControl.DepPostList.Add(PagingPostList[i]);
                }

                pageControl.LblStart.Content = start.ToString();
                pageControl.LblEnd.Content = end.ToString();
                pageControl.LblTotalItems.Content = totalItems.ToString();

                flag = true;




            }

        }



    }
}



