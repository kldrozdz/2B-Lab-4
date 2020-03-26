using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using static _2BLab_4.Team;

namespace _2BLab_4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var responce2 = await Website.Download("https://api.collegefootballdata.com", "/teams/fbs?year=2019");
            var json2 = responce2.Content;
            var resoult2 = JsonConvert.DeserializeObject<Team[]>(json2);

            var responce3 = await Website.Download("https://api.collegefootballdata.com", "/coaches?year=2019");
            var json3 = responce3.Content;
            var resoult3 = JsonConvert.DeserializeObject<Coach[]>(json3);

            var db = new Kontekst();
            db.Database.EnsureCreated();
            foreach (var elem in resoult2)
            {
                db.Teams.Add(new Team()
                {
                    school = elem.school,
                    mascot = elem.mascot,
                });
                db.SaveChanges();
            }
            foreach (var elem in resoult3)
            {
                string szkola = " ";
                foreach (var elem2 in elem.seasons)
                {
                    szkola = elem2.school;
                }
                try
                {
                    db.CoachTBs.Add(new CoachTB()
                    {
                        School = szkola,
                        First_name = elem.first_name,
                        Last_name = elem.last_name,

                    });
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    foreach (var element in db.Teams.Include(x => x.CoachNavigation))
                    {
                        Console.WriteLine($"{element.id} {element.school}" +
                            $" {element.mascot} {element.CoachNavigation.First_name}" +
                            $" {element.CoachNavigation.Last_name}");
                    }
                }

            }
        }
    }
}
