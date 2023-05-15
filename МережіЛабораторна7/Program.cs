using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Lab7 {
	class Program
	{

		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;
			Console.WriteLine("Виберіть категорію");
			string firstpart = "https://api.chucknorris.io/jokes/random?category=";
			string category = Console.ReadLine();
			string url = firstpart + category;

			var client = new RestClient(url);
			var request = new RestRequest();
			var response = client.Get(request);
			string final = response.Content.ToString();

			Console.WriteLine($"Вибрана категорія: {category}");

			string date = final.Substring(final.LastIndexOf("created_at"));
			date = date.Remove(date.IndexOf(","));
			date = date.Replace('"', ' ');
			date = date.Replace("created_at", "Дата створення");

			string joke = final.Substring(final.LastIndexOf("value"));
			joke = joke.Remove(joke.IndexOf("}"));
			joke = joke.Replace('"', ' ');

			joke = joke.Replace("value", "Жарт");

			Console.WriteLine(date);
			Console.WriteLine(joke);
			Console.Read();

		}
	};
}