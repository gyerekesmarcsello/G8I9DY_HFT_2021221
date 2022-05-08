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
    public class ArtistWindowViewModel:ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Artist> Artists { get; set; }

        private Artist selectedArtist;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public Artist SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                if (value != null)
                {
                    selectedArtist = new Artist()
                    {
                        ArtistID = value.ArtistID,
                        Name = value.Name,
                        Birthday = value.Birthday,
                        Nationality = value.Nationality,
                        GrammyWinner = value.GrammyWinner,
                    };

                    OnPropertyChanged();
                    (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateArtistCommand { get; set; }

        public ICommand DeleteArtistCommand { get; set; }

        public ICommand UpdateArtistCommand { get; set; }

        public ArtistWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Artists = new RestCollection<Artist>("http://localhost:2509/", "artist", "hub");
                CreateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Add(new Artist()
                    {
                        Name = selectedArtist.Name,
                        Birthday= selectedArtist.Birthday,
                        Nationality= selectedArtist.Nationality,
                        GrammyWinner= selectedArtist.GrammyWinner
                    });
                    System.Threading.Thread.Sleep(150);
                    Artists.Update(Artists.Last());
                });

                UpdateArtistCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Artists.Update(selectedArtist);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteArtistCommand = new RelayCommand(() =>
                {
                    Artists.Delete(selectedArtist.ArtistID);
                },
                () =>
                {
                    return selectedArtist != null;
                });
                selectedArtist = new Artist();
            }

        }


    }
}
