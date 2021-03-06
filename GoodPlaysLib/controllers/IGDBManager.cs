﻿using GoodPlaysLib.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace GoodPlaysLib.controllers
{
    public class IGDBManager
    {

        /// <summary>
        /// Gathers game data based on a list of game ids.
        /// </summary>
        /// <param name="ids">The ids to look up.</param>
        /// <returns>An array of games found by the api call.</returns>
        public Game[] GamesFromIds(List<int> ids)
        {
            StringBuilder idList = new StringBuilder();
            for (int i = 0; i < ids.Count; i++) {
                idList.Append(ids[i]);
                if (i != ids.Count - 1) {
                    idList.Append(',');
                }
            }
            string requestBody = $"fields {Game.FieldNames()};" +
                                 $"where id = ({idList}) & category = 0;";
            string jsonResponse = ResponseToJson(MakeRequest("games", requestBody));
            return new JavaScriptSerializer().Deserialize<Game[]>(jsonResponse);
        }

        /// <summary>
        /// Finds a single game by its id.
        /// </summary>
        /// <param name="id">The id of the game to find.</param>
        /// <returns>The game with the id specified.</returns>
        public Game GameFromId(int id) {
            string requestBody = $"fields {Game.FieldNames()};" +
                                 $"where id = {id} & category = 0;";
            string jsonResponse = ResponseToJson(MakeRequest("games", requestBody));
            return new JavaScriptSerializer().Deserialize<Game>(jsonResponse);
        }

        /// <summary>
        /// Searches IGDB games by name
        /// </summary>
        /// <param name="name">The name to search with.</param>
        /// <returns>The results of the search.</returns>
        public Game[] SearchGamesByName(string name) {
            string requestBody = $"fields {Game.FieldNames()};" +
                                 $"search \"{name}\";" +
                                  "where category = 0;";
            string jsonResponse = ResponseToJson(MakeRequest("games", requestBody));
            return new JavaScriptSerializer().Deserialize<Game[]>(jsonResponse);
        }

        /// <summary>
        /// Makes a request to IGDB.
        /// </summary>
        /// <param name="endpoint">Which endpoint to send the request to.</param>
        /// <param name="body">The body of the request.</param>
        /// <returns>The request's response.</returns>
        private WebResponse MakeRequest(string endpoint, string body) {
            HttpWebRequest request = WebRequest.CreateHttp($"https://api-v3.igdb.com/{endpoint}");
            request.Method = "POST";
            request.Accept = "application/json";
            request.Headers.Add("user-key", Environment.GetEnvironmentVariable("IGDB_KEY"));

            byte[] data = Encoding.ASCII.GetBytes(body);
            request.ContentType = "text/plain";
            request.ContentLength = data.LongLength;
            Stream newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            return request.GetResponse();
        }

        /// <summary>
        /// Extracts JSON from a WebResponse.
        /// </summary>
        /// <param name="response">The response to extract from.</param>
        /// <returns>The JSON content of the response.</returns>
        private string ResponseToJson(WebResponse response) {
            string result;
            {
                StringBuilder responseJsonBuilder = new StringBuilder();
                Stream responseStream = response.GetResponseStream();
                int character = responseStream.ReadByte();
                while (character != -1) {
                    responseJsonBuilder.Append((char)character);
                    character = responseStream.ReadByte();
                }
                result = responseJsonBuilder.ToString();
            }
            return result;
        }
    }
}
