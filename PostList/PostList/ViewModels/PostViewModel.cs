using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Net.Http;


namespace PostList.ViewModels
{
    public class PostViewModel : INotifyPropertyChanged
    {
        #region propetries

        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<PostData> postList;
        PostData selectedItem;
        HttpResponseMessage Response = null;
        ICommand _CopyCommand;

        public ICommand CopyCommand
        {
            get
            {
                return _CopyCommand;
            }

            set
            {

                _CopyCommand = value;
            }
        }



        public PostData SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                if (selectedItem != null)
                {
                    OnPropertyChanged();
                }
            }

        }


        public ObservableCollection<PostData> PostList
        {
            get
            {
                return postList;
            }
            set
            {
                postList = value;
                if (postList != null)
                    OnPropertyChanged();
            }

        }

        #endregion properties

        #region private method


        public void Init()
        {
            CopyCommand = new RelayCommand(new Action<object>(CopyContent));
            //read config file
            ReadConfig();
            // call to fetch post list
            PostList = GetPostList();
        }


        private void ReadConfig()
        {
            try
            {
                AppConfig.ReadConfig();

                if (AppConfig.ConfigValue == null || AppConfig.ConfigValue.Count == 0)
                {
                    ExceptionHandling.ShowException(Constant.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.ShowException(ex.Message);
            }

        }

        private ObservableCollection<PostData> GetPostList()
        {

            ObservableCollection<PostData> PostList = null;
            try
            {

                Response = HttpRequestUtil.HttpClientRequest(AppConfig.ConfigValue[Constant.WebAPIServer], AppConfig.ConfigValue[Constant.PostListURL]);
                if (Response == null)
                {
                    ExceptionHandling.ShowException(Constant.Error);
                    return PostList;
                }
                if (Response.IsSuccessStatusCode)
                    PostList = new ObservableCollection<PostData>(Response.Content.ReadAsAsync<IEnumerable<PostData>>().Result.ToList());
                else
                    ExceptionHandling.ShowException(Response.ReasonPhrase);
            }

            catch (Exception ex)
            {

                ExceptionHandling.ShowException(ex.Message);

            }

            return PostList;


        }

        private void OnPropertyChanged([CallerMemberName]string PropertName = "")
        {
            var temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(PropertName));
            }
        }

        private void CopyContent(object CopyCommand)
        {
            IFormatter IFormat;

            if (CopyCommand == null)
            {
                return;
            }

            string Format = CopyCommand.ToString();
            try
            {
                IFormat = Formatter.GetFormatter(Format);

                if (IFormat == null)
                {
                    ExceptionHandling.ShowException(Constant.Error);
                    return;
                }

                Clipboard.SetText(IFormat.GetData(SelectedItem));
            }
            catch (Exception ex)
            {
                ExceptionHandling.ShowException(ex.Message);
            }
        }

        #endregion private method




    }
}
