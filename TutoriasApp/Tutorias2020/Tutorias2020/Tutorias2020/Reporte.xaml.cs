using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Tutorias2020.Clases;


namespace Tutorias2020
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Reporte : ContentPage
	{
		public Reporte(string mtrr)
		{
			InitializeComponent();
			amtrr.Text = mtrr;

		}

		public void Motivo_SelectedIndexChanged(object sender, EventArgs e)
		{
			Picker picker = motivo as Picker;
			string mot = motivo.SelectedItem.ToString();
			mm.Text = mot.ToString();
		}

		public void Btn_reportar_Clicked(object sender, EventArgs e)
		{
			comp();
		}

		public async void comp()
		{
			if (String.IsNullOrWhiteSpace(lbl_Remitente.Text))
			{
				await this.DisplayAlert("Advertencia", "El campo del Grupo es obligatorio.", "OK");
			}
			else
			{
					if(motivo.SelectedIndex == -1)
					{
						await this.DisplayAlert("Advertencia", "El campo del Criterio es obligatorio.", "OK");
					}
					else
					{
						if(String.IsNullOrWhiteSpace(obs.Text))
						{
							obs.Text = "Ninguna";
							rep();
							pan();
						}
						else
						{
							rep();
							pan();
						}
					}
				
			}
			

		}
		public async void pan()
		{
			// Remove page before Edit Page
			this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
			// This PopAsync will now go to List Page
			await Navigation.PopAsync();
		}
		public async void rep()
		{
			string fecha = DateTime.Now.ToString();
			string mot = mm.Text.ToString();


			try
			{
				UseManager manager = new UseManager();
				manager.Reporte(amtrr.Text.ToString(), mot, fecha, obs.Text.ToString(), lbl_Remitente.Text.ToString());
				await DisplayAlert("Reporte Generado", "Reporte Enviado", "Aceptar");
				lbl_Remitente.Text = " ";
				obs.Text = "";
				motivo.SelectedIndex = -1;
				





			}
			catch (Exception e1) { }
		}
	
	}
}