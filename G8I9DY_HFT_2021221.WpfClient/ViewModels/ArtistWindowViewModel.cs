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

        public RestCollection<Artists> Artists { get; set; }

        private Artists selectedArtist;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public Artists SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                if (value != null)
                {
                    selectedArtist = new Artists()
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
                Artists = new RestCollection<Artists>("http://localhost:57125/", "artists", "hub");
                CreateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Add(new Artists()
                    {
                        Name = selectedArtist.Name,
                        Birthday= selectedArtist.Birthday,
                        Nationality= selectedArtist.Nationality,
                        GrammyWinner= selectedArtist.GrammyWinner
                    });
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
                selectedArtist = new Artists();
            }

        }


    }
}
