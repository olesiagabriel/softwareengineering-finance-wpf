using System.ComponentModel;

namespace курсовой
{
    public class VM : INotifyPropertyChanged
    {
       
            public event PropertyChangedEventHandler PropertyChanged;

            public void OnProperty(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

