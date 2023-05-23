using Newtonsoft.Json;
using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        string apiUrl = "https://jsonmock.hackerrank.com/api/football_matches?year="+ year + "&team1="+ team;

        int currentPage = 1;
        int totalPages = 1;
        List<dynamic> allMatches = new List<dynamic>();

        while (currentPage <= totalPages)
        {
            string url = $"{apiUrl}&page={currentPage}";
            using (var webClient = new WebClient())
            {
                string jsonResult = webClient.DownloadString(url);
                dynamic resultObject = JsonConvert.DeserializeObject(jsonResult);
                totalPages = resultObject.total_pages;
                List<dynamic> matches = resultObject.data.ToObject<List<dynamic>>();
                allMatches.AddRange(matches);
            }

            currentPage++;
        }

        int totalGoals = 0;

        foreach (dynamic match in allMatches)
        {
            int homeTeamGoals = int.Parse(match.team1goals.ToString());
            totalGoals += homeTeamGoals;
        }

        return totalGoals;
    }

}