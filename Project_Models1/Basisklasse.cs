using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Models1
{
    public abstract class Basisklasse : IDataErrorInfo
    {
        public abstract string this[string columnName] { get; }

        public string Error
        {
            get
            {
                string foutmeldingen = "";
                foreach (var item in GetType().GetProperties())
                {
                    string fout = this[item.Name];
                    if (!string.IsNullOrWhiteSpace(fout))
                    {
                        foutmeldingen += fout + Environment.NewLine;
                    }                    
                }
                return foutmeldingen;
            }
        }

        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Error);
        }
    }
}
