using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace WMS_2._0
{

    public sealed partial class directoryPage : Page
    {

        public directoryPage()
        {
            this.InitializeComponent();
           //directory("n");

        }

        //Methods
        public void directory(string path)
        {
            Directory.Text = path;
        }


        public static bool TryGoBack()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                return true;
            }
            return false;
        }


        // Buttons Click //

        //Button Back
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TryGoBack();
        }
        
        //Button New Directory
        async private void NewDirectoryButton_Click(object sender, RoutedEventArgs e)
        {

            var savePath = new Windows.Storage.Pickers.FileSavePicker();
            savePath.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            savePath.FileTypeChoices.Add("Text document", new List<string>() { ".txt" });
            savePath.SuggestedFileName = "Track Info(WMS)";
            Windows.Storage.StorageFile file = await savePath.PickSaveFileAsync();
            if (file != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                FutureAccessList.AddOrReplace("PickedFolderToken", file);
                string pathFile = file.Path;
                directory(pathFile);
            }
            else
            {
                directory("We could not find the path to the saved file. There may have been some mistake😭");
            }


        }
    }
}
