using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModels
{
    class CytatDniaEventArgs : EventArgs
    {
        public virtual DateTime WybranaData { get; set; }
    }
}