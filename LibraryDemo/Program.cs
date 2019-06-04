using GoodPlaysEF.services;
using GoodPlaysLib.controllers;
using GoodPlaysLib.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDemo {
    class Program {
        static void Main(string[] args) {
            APIDemo();
            DBDemo();
        }

        static void APIDemo() {
            IGDBManager manager = new IGDBManager();

            //Edit this
            Game[] results = manager.SearchGamesByName("");
        }

        static void DBDemo() {
            GoodPlaysEFService service = new GoodPlaysEFService();
            List<string> userIDs = AddUsers(service);

            //Edit this
            service.AddListItemToUser(userIDs[0], 0, 0);

            RemoveUsers(service, userIDs);
        }

        static List<string> AddUsers(GoodPlaysEFService service) {
            List<string> results = new List<string>();
            results.Add(service.CreateUser("Michael", "Zopff", "mzopff@student.neumont.edu"));
            results.Add(service.CreateUser("Testy", "Testerson", "ttesty@example.com"));
            return results;
        }

        static void RemoveUsers(GoodPlaysEFService service, List<string> userIDs) {
            foreach (string userID in userIDs) {
                service.DeleteListByUserID(userID);
                service.DeleteUserByID(userID);
            }
        }
    }
}
