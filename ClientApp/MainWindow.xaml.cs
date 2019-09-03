using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ViewModels.VM_Main vmMain { get => (ViewModels.VM_Main)this.Resources["vmMain"]; }
		private HttpClient Client = new HttpClient() { BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApiUri"]), };

		public MainWindow()
		{
			InitializeComponent();

			vmMain.CytatDnia += VmMain_CytatDnia;
			vmMain.StatystykiLiter += VmMain_StatystykiLiterAsync;
		}

		private async void VmMain_StatystykiLiterAsync(object sender, ViewModels.ZliczLiteryEventArgs e)
		{
			try
			{
				vmMain.Working = true;
				System.Diagnostics.Debug.WriteLine($"Wprowadzono ciąg znaków: {e.Tekst}");

				using (var Client = new ClientWcf.Service1Client())
				{
					vmMain.OutputList = await Client.ZliczCzestotliwoscAsync(e.Tekst);

				}
			}
			catch (Exception E)
			{
				MessageBox.Show(this, E.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			finally
			{
				vmMain.Working = false;
			}
		}

		private async void VmMain_CytatDnia(object sender, ViewModels.CytatDniaEventArgs e)
		{
			try
			{
				vmMain.Working = true;
				System.Diagnostics.Debug.WriteLine($"Kliknięto cytat dnia z datą: {e.WybranaData:d}");

				using (var Response = await Client.GetAsync($"api/HubmikTest?dzisiejszyDzien={e.WybranaData:d}"))
				{
					Response.EnsureSuccessStatusCode();

					vmMain.Wynik = await Response.Content.ReadAsAsync<string>();
				}
			}
			catch (Exception E)
			{
				MessageBox.Show(this, E.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			finally
			{
				vmMain.Working = false;
			}
		}
	}
}