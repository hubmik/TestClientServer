using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModels
{
    class VM_Main:Prism.Mvvm.BindableBase
    {
        public event EventHandler<CytatDniaEventArgs> CytatDnia;
        public event EventHandler<ZliczLiteryEventArgs> StatystykiLiter;

        private DateTime m_Date = DateTime.Today;
        private string m_Wynik;
        private bool m_Working;
        private string m_InputText;
        private List<ClientWcf.CharStatistic> m_OutputList;

        public virtual DateTime Date { get => this.m_Date; set => this.SetProperty(ref this.m_Date, value); }
        public string Wynik { get=>this.m_Wynik; set=>this.SetProperty(ref this.m_Wynik, value); }
        public Prism.Commands.DelegateCommand CytatDniaCommand { get; set; }
        public Prism.Commands.DelegateCommand ZliczLiteryCommand { get; set; }
        public string InputText { get=>this.m_InputText; set=>this.SetProperty(ref this.m_InputText, value); }
        public List<ClientWcf.CharStatistic> OutputList { get => this.m_OutputList; set => this.SetProperty(ref this.m_OutputList, value); }
        
        public bool Working
        {
            get => this.m_Working;
            set
            {
                if (SetProperty(ref this.m_Working, value))
                {
                    CytatDniaCommand.RaiseCanExecuteChanged();
                    ZliczLiteryCommand.RaiseCanExecuteChanged();
                }
            }
        }
		
        public VM_Main()
        {
            CytatDniaCommand = new Prism.Commands.DelegateCommand(() => OnCytatDnia(new CytatDniaEventArgs() { WybranaData = this.Date }), () => !this.Working);
            ZliczLiteryCommand = new Prism.Commands.DelegateCommand(() => OnZliczLitery(new ZliczLiteryEventArgs() { Tekst = this.InputText }), ()=> !this.Working);
        }
        void OnZliczLitery(ZliczLiteryEventArgs e)
        {
            StatystykiLiter.Invoke(this, e);
        }
        protected virtual void OnCytatDnia(CytatDniaEventArgs e)
        {
            CytatDnia?.Invoke(this, e);
        }
    }
}