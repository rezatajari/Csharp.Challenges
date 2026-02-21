using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TicketPriority
{
    public class Ticket : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title != value)
                {
                    _title = value;

                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Title)));
                }
            }
        }
        public Priority Priority { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }


    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
