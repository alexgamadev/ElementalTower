using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    public TMP_Text _rankText;
    public GameObject spinner;

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
            Test jsonData = JsonConvert.DeserializeObject<Test>(sentData);
            var rank = jsonData.rank > 1 ? $"{jsonData.rank}th" : "1st";
            spinner.SetActive(false);
            _rankText.text = $"Global Rank: {jsonData.rank}{GetNumberSuffix(jsonData.rank)}";
        }
    }

    public string GetNumberSuffix(int number)
    {
        if (number == 1)
        {
            return "st";
        }
        else if (number == 2)
        {
            return "nd";
        }
        else if (number == 3)
        {
            return "rd";
        }
        else
        {
            return "th";
        }
    }

    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }
}

public class Test
{
    public string id;
    public int duration;
    public int rank;
}
