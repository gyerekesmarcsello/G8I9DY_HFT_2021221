using G8I9DY_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace G8I9DY_HFT_2021221.WpfClient.ViewModels
{
    public class AlbumWindowViewModel:ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Albums> Albums { get; set; }


        private Albums selectedAlbum;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public Albums SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                if (value != null)
                {
                    selectedAlbum = new Albums()
                    {
                        AlbumID = value.AlbumID,
                        Title = value.Title,
                        ArtistID= value.ArtistID,
                        Label = value.Label,
                        Length = value.Length,
                        ReleaseDate = value.ReleaseDate,
                        Genre = value.Genre
                    };

                    OnPropertyChanged();
                    (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateAlbumCommand { get; set; }

        public ICommand DeleteAlbumCommand { get; set; }

        public ICommand UpdateAlbumCommand { get; set; }

        public AlbumWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Albums = new RestCollection<Albums>("http://localhost:2509/", "album", "hub");
                CreateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Add(new Albums()
                    {
                        Title = selectedAlbum.Title,
                        ArtistID = selectedAlbum.ArtistID,
                        Label = selectedAlbum.Label,    
                        Length= selectedAlbum.Length,
                        ReleaseDate = selectedAlbum.ReleaseDate,
                        Genre= selectedAlbum.Genre
                    });
                });

                UpdateAlbumCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Albums.Update(selectedAlbum);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Delete(selectedAlbum.AlbumID);
                },
                () =>
                {
                    return selectedAlbum != null;
                });
                selectedAlbum = new Albums();
            }

        }

    }
}
