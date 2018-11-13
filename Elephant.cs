using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ListEbbe.Annotations;

namespace ListEbbe
{
    class Elephant : INotifyPropertyChanged
    {
        private string name;
        private int weight;
        private string _birthplace;

        public Elephant(string name, int weight, string birthplace)
        {
            this.name = name;
            this.weight = weight;
            _birthplace = birthplace;
        }

        public string Birthplace
        {
            get { return _birthplace; }
            set { _birthplace = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + Name + " ");
            sb.Append("Weight: " + Weight + " ");
            sb.Append("Birthplace: " + Birthplace + " ");
            return sb.ToString();
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
