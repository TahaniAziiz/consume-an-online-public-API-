using Newtonsoft.Json;
using RestSharp;
using System.Data;

namespace ConsumeAPI
{
    internal class Program
    {
        static void Main(String[] args)
        {
            string url = "https://api.coinbase.com/v2/currencies";

            Uri uri = new Uri(url);

            var UserInfo = new RestClient(uri);

            var request = new RestRequest();

            //request.AddParameter("name", "bella");

            var response = UserInfo.Get(request);

            string json = response.Content.ToString();

            Model2 m = new Model2(); //object from model2 class


            m = JsonConvert.DeserializeObject<Model2>(json);

            //Datatable 
            //create and set columns 
            DataTable dt = new DataTable(); //create columns //dt name of table
            dt.Columns.Add("name"); //fill table of content
            dt.Columns.Add("id");
            dt.Columns.Add("min_size");

            if (response.IsSuccessful == true) //if condition ..
            {

                foreach (Datum row in m.data) //Dataum is name of table contains name, id and min_size.. create row from Dataum

                {

                    DataRow line = dt.NewRow();
                    line["name"] = row.name;
                    line["id"] = row.id;
                    line["min_size"] = row.min_size;
                    dt.Rows.Add(line);

                }

            }
            else
            {
                Console.WriteLine("No result! IsSuccessful is false..");
            }

        }
    }
}
