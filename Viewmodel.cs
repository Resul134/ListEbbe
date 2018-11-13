using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using ListEbbe.Annotations;

namespace ListEbbe
{
    class Viewmodel : INotifyPropertyChanged
    {
        private RelayCommand _nameSort;
        private RelayCommand _weightSort;
        private RelayCommand _birthSort;
        private ObservableCollection<Elephant> _elephant = new ObservableCollection<Elephant>();

        public Viewmodel()
        {
            _elephant = new ObservableCollection<Elephant>();
            _elephant.Add(new Elephant("Michael" , 200, "Wakanda"));
            _elephant.Add(new Elephant("Daniel", 500, "Wakanda"));
            _elephant.Add(new Elephant("Lucas", 4000, "Wakanda"));

            _elephant = new ObservableCollection<Elephant>(_elephant.OrderBy(_elephant => _elephant.Weight).ToList());

            NameSort = new RelayCommand(SortByName);
            WeightSort = new RelayCommand(SortByWeight);
            BirthSort = new RelayCommand(SortByBirth);

        }

        public ObservableCollection<Elephant> Elephant
        {
            get { return _elephant; }
            set
            {
                _elephant = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NameSort
        {
            get { return _nameSort; }
            set { _nameSort = value; }
        }

        public RelayCommand WeightSort
        {
            get { return _weightSort; }
            set { _weightSort = value; }
        }

        public RelayCommand BirthSort
        {
            get { return _birthSort; }
            set { _birthSort = value; }
        }

        public void SortByName()
        {
            Debug.WriteLine("det virker");
            Elephant = new ObservableCollection<Elephant>(_elephant.OrderBy(_elephant => _elephant.Name).ToList());
        }

        public void SortByWeight()
        {
            Debug.WriteLine("det virker");
            Elephant = new ObservableCollection<Elephant>(_elephant.OrderBy(_elephant => _elephant.Weight).ToList());
        }

        public void SortByBirth()
        {
            Debug.WriteLine("det virker");
            Elephant = new ObservableCollection<Elephant>(_elephant.OrderBy(_elephant => _elephant.Birthplace).ToList());
        }


        #region MyRegion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

}
