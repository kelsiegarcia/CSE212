using System.Text.Json;
using System.Text.Json.Serialization;

namespace prove_06;

public static class EarthquakesService
{
    /// <summary>
    /// <para>This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.</para>
    /// <para>JSON data is organized like a dictionary.  After reading the data,
    /// this function will create a list of all earthquake locations ('place' attribute)
    /// and magnitudes ('mag' attribute).</para>
    /// <para>Additional information about the format of the JSON data can be found 
    /// at this website:  </para>
    /// <para>https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php</para>
    /// </summary>
    /// <returns>A list of strings representing one earthquake per string of the format
    /// <c>&lt;place&gt; - Mag &lt;mag&gt;</c> (e.g. <c>1km NE of Pahala, Hawaii - Mag 2.36</c>)</returns>
    public static List<string> EarthquakeDailySummary()
    {
        const string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        var json = new HttpClient().GetStringAsync(url).Result;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        FeatureCollection? featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Map the earthquake data to objects and add to the results in the right format
        // 1. Add your code to map the json to the feature collection object, creating additional classes as needed
        List<string> results = new List<string>();
        
        if (featureCollection != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                string place = feature.Properties.Place;
                double? mag = feature.Properties?.Magnitude ?? 0.0;
                
                string summary = $"{place} - Mag {mag}";
                results.Add(summary); // Example add of 1 earthquake
            }
        }
            
        // 2. Add each earthquake to the results list in the correct format (see below for example
       

        // TODO Change the results to add earthquakes from today to the results instead of these hard-coded ones

        return results;
    }
    
    public class FeatureCollection
    {
        [JsonPropertyName("features")]
        public List<Feature> Features { get; set; }
    }
        
    public class Feature
    {
        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        [JsonPropertyName("mag")]
        public double? Magnitude { get; set; }

        [JsonPropertyName("place")]
        public string Place { get; set; }
    }

}