﻿using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSQLiteHelperBase.Model
{
    public class ThreadDetailsModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        virtual internal protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private int id;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged("ID");
                    }
        }

        private string guid;

        public string Guid
        {
            get { return guid; }
            set { guid = value;
                OnPropertyChanged("Guid");
            }
        }

        private string owner;

        public string Owner
        {
            get { return owner; }
            set { owner = value;
                OnPropertyChanged("Owner");
            }
        }

        private string threadurl;

        public string ThreadURL
        {
            get { return threadurl; }
            set { threadurl = value;
                OnPropertyChanged("Uri"); }
        }

        private string casetype;

        public string Casetype
        {
            get { return casetype; }
            set { casetype = value;
                OnPropertyChanged("Casetype");
            }
        }




    }
}
