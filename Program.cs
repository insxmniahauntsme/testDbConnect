﻿using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using HelloWorld.Data;
using System.Runtime.CompilerServices;
using System.Data.Common;


namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataDapper Dapper = new DataDapper();

            //string sqlCommand = "SELECT GETDATE()";

            Computer myComputer = new Computer() 
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

            string pull_request = @"INSERT INTO TutorialAppSchema.Computer (Motherboard,HasWifi,HasLTE,ReleaseDate,Price,VideoCard) 
                    VALUES ('" + myComputer.Motherboard 
                    + "','" + myComputer.HasWifi 
                    + "','" + myComputer.HasLTE
                    + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
                    + "','" + myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
                    + "','" + myComputer.VideoCard
            + "')";

            string select_request = @"SELECT * FROM TutorialAppSchema.Computer";

            Dapper.ExecuteSql(pull_request);

            Dapper.SelectSql(select_request);
         
        }
    }
}
