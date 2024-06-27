using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrakingOreder.Models
{
    public class LoadUrlData
    {
        public static List<Url> urls()
        {
            var json = File.ReadAllText("appsettings.json");
            var obj = JObject.Parse(json);
            var theme = obj["Controllers"].ToString();

            var themes = JsonConvert.DeserializeObject<List<Url>>(theme);
            return themes;
        }
    }
}
