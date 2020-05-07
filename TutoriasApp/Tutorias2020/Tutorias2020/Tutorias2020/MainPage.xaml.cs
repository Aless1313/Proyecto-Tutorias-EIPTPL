using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Tutorias2020.Clases;
using System.Text.RegularExpressions;

namespace Tutorias2020
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			txt_matricula.Text = "";
		}

		private void Btn_ingresar_Clicked(object sender, EventArgs e)
		{
			xr();
		}

		public async void ing()
		{
			string mtr = txt_matricula.Text;
			try
			{
				UseManager manager = new UseManager();
				var result = await manager.userLogin(txt_matricula.Text.ToString());

				if (result.Count() > 0)
				{
					await Navigation.PushAsync(new InfoAlumno(mtr));
				}
				else
				{
					await DisplayAlert("Error", "Matricula No encontrada", "Aceptar");
				}
			}
			catch (Exception e1)
			{

			}
		}
		public async void xr()
		{
			if (String.IsNullOrWhiteSpace(txt_matricula.Text))
			{
				await this.DisplayAlert("Advertencia", "El campo del nombre es obligatorio.", "OK");

			}
			else
			{
				if (!txt_matricula.Text.ToCharArray().All(Char.IsNumber))
				{
					await this.DisplayAlert("Advertencia", "Tu información contiene Letras, favor de validar.", "OK");
				}
				else
				{
					if (!txt_matricula.Text.ToCharArray().All(Char.IsDigit))
					{
						await this.DisplayAlert("Advertencia", "Solo se aceptan numeros.", "OK");

					}
					else
					{
						if (txt_matricula.Text.Length != 7)
						{
							await this.DisplayAlert("Advertencia", "Faltan digitos, favor de ingresar su matricula a 7 digitos.", "OK");

						}
						else
						{
							ing();
						}
					}
				}
			}
		}
	}
}
