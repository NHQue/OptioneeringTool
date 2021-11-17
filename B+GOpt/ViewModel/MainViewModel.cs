using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B_GOpt.Core;

namespace B_GOpt.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand CalculateViewCommand { get; set; }
        public RelayCommand ExportViewCommand { get; set; }
        public RelayCommand InstructionsViewCommand { get; set; }

        private object _currentView;
        //public HomeViewModel HomeVM { get; set; }
        //public CalculateViewModel CalculateVM { get; set; }
        //public ExportViewModel ExportVM { get; set; }
        //public InstructionsViewModel InstructionsVM { get; set; }
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            //HomeVM = new HomeViewModel();
            //CalculateVM = new CalculateViewModel();
            //ExportVM = new ExportViewModel();
            //InstructionsVM = new InstructionsViewModel();
            //CurrentView = HomeVM;

            //HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVM; });
            //CalculateViewCommand = new RelayCommand(o => { CurrentView = CalculateVM; });
            //InstructionsViewCommand = new RelayCommand(o => { CurrentView = InstructionsVM; });
            //ExportViewCommand = new RelayCommand(o => { CurrentView = ExportVM; });
        }
    }
}
