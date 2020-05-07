using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace Tutorias2020.Clases
{
	public class UseManager
	{
		const String URL = "http://tutoriaseiptpl.alessdeveloper.dx.am/PHP/";

		private HttpClient getClient()
		{
			HttpClient client = new HttpClient();

			client.DefaultRequestHeaders.Add("Accept", "application/json");
			client.DefaultRequestHeaders.Add("Connection", "Close");

			return client;

		}

		public async Task<IEnumerable<User>> userLogin(String Id_Matricula)
		{
			HttpClient cliente = getClient();

			var result = await cliente.GetAsync(URL + "Consulta.php?Matricula=" + Id_Matricula);

			if (result.IsSuccessStatusCode)
			{
				string content = await result.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<IEnumerable<User>>(content);
			}
			return Enumerable.Empty<User>();
		}

		public async Task<IEnumerable<User>> viewinfo()
		{
			HttpClient client = getClient();

			var result = await client.GetAsync(URL + "Listado.php");

			if(result.IsSuccessStatusCode)
			{
				string content = await result.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<IEnumerable<User>>(content);
			}
			return Enumerable.Empty<User>();
		}

		public async void Reporte(string Id_Matricula, string Motivo, string Fecha, string Observacion, string Remitente)
		{
			HttpClient client = getClient();
			var result = await client.GetAsync(URL + "Reporte.php?Id_Matricula="+Id_Matricula+"&Motivo="+Motivo+"&Fecha="+Fecha+"&Observacion="+Observacion+"&Remitente="+Remitente);
		}
	}
}
