using MusicApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.ViewModels
{
    public class AddTrackViewModel : BaseViewModel
    {
        public int AlbumId { get; set; }

        private string _name;
        public string Name 
        { 
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _clip;
        public string Clip
        {
            get { return _clip; }
            set
            {
                _clip = value;
                OnPropertyChanged();
            }
        }

        private string _preview;
        public string Preview
        {
            get { return _preview; }
            set
            {
                _preview = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public Action CloseWindow { get; set; }

        public AddTrackViewModel(AddTrackCommand addTrackCommand)
        {
            AddCommand = addTrackCommand;
        }
    }
}
