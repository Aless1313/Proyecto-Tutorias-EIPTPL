using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Tutorias2020.Clases;
using System.IO;

namespace Tutorias2020
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InfoAlumno : ContentPage
	{
		 public InfoAlumno (string mtrr)
		{
			InitializeComponent ();
		
			info(mtrr);
			Id_Mtr.Text = mtrr;
			
		}

		private async void info(string mtr)
		{
			
			try
			{
				UseManager manager = new UseManager();
				var result = await manager.userLogin(mtr);

				if(result != null)
				{
					lst_alumno.ItemsSource = result;
				}
			}catch(Exception e1)
			{

			}
		}
		
		private async void Btn_report_Clicked(object sender, EventArgs e)
		{
			string mtr = Id_Mtr.Text;
			await Navigation.PushAsync(new Reporte(mtr));
		}

		
	}
}