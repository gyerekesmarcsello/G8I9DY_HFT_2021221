using G8I9DY_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace G8I9DY_HFT_2021221.WpfClient.ViewModels
{
    public class TrackWindowViewModel:ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Track> Tracks { get; set; }


        private Track selectedTrack;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public Track SelectedTrack
        {
            get { return selectedTrack; }
            set
            {
                if (value != null)
                {
                    selectedTrack = new Track()
                    {
                        TrackID = value.TrackID,
                        Title = value.Title,
                        AlbumID = value.AlbumID,
                        Plays = value.Plays,
                        Duration = value.Duration,
                        IsExplicit = value.IsExplicit,
                        ArtistID = value.ArtistID,

                    };

                    OnPropertyChanged();
                    (DeleteTrackCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateTrackCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateTrackCommand { get; set; }

        public ICommand DeleteTrackCommand { get; set; }

        public ICommand UpdateTrackCommand { get; set; }

        public TrackWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Tracks = new RestCollection<Track>("http://localhost:2509/", "track", "hub");
                CreateTrackCommand = new RelayCommand(() =>
                {
                    Tracks.Add(new Track()
                    {
                        Title = selectedTrack.Title,
                        AlbumID = selectedTrack.AlbumID,
                        Plays = selectedTrack.Plays,
                        Duration = selectedTrack.Duration,
                        IsExplicit= selectedTrack.IsExplicit,
                        ArtistID = selectedTrack.ArtistID,
                    });
                });

                UpdateTrackCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Tracks.Update(selectedTrack);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteTrackCommand = new RelayCommand(() =>
                {
                    Tracks.Delete(selectedTrack.TrackID);
                },
                () =>
                {
                    return selectedTrack != null;
                });
                selectedTrack = new Track();
            }

        }
    }
}

