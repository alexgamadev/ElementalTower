using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public void Start()
    {
        print("LevelComplete");
        SendRunData();
    }

    public async void SendRunData()
    {
        using (var client = new HttpClient())
        {
            var data = new Dictionary<string, string>
            {
                {"duration",$"{GameManager.Instance.GetTimer().GetTimeUnformatted()}"}
            };
            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5251/api/ascensiondata", content);
            var sentData = await response.Content.ReadAsStringAsync();
            Dictionary<string, string> jsonData = JsonConvert.DeserializeObject<Dictionary<string, string>>(sentData);
            print(sentData);
        }
    }

    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }
}
