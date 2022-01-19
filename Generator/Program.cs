using System;
using Generator;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using MongoDB.Driver;
using Generator.Models.MongoDB;
using MongoDB.Bson;

using Neo4j.Driver;

Console.WriteLine("Hello, World!");


using (var db = new postgresContext())
{
    List<UserAcc> users = new List<UserAcc>();
    List<Vehicle> vehicles = new List<Vehicle>();
    StringGenerator g = new StringGenerator();
    ArrayList trips = new ArrayList();
    Stopwatch stopwatch = new Stopwatch();



    var client = new MongoClient(
    "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
    var database = client.GetDatabase("DBA");


    //var u = database.GetCollection<BsonDocument>("Users");
    //var doc = u.Find(new BsonDocument()).ToList();


    // for (int i = 0; i < 10000; i++)
    // {
    //    var doc = new BsonDocument
    //        {
    //            {"user_name", g.RandomGen(16)},
    //            {"date_of_birth", new DateOnly(1980, 09, 14).ToString()},
    //        {"fullname", g.RandomGen(16) },
    //        {"account_balance", (double)40 },
    //        {"role", new BsonDocument{ {"id", 1},{"type", "client"} } }
    //        };
    //    u.InsertOne(doc);
    // }

    //var User_doc = u.Find(new BsonDocument()).ToList();
    //var v = database.GetCollection<BsonDocument>("Vehicles");
    //var V_doc = v.Find(new BsonDocument()).ToList();

    Random rng = new Random();

    //var t = database.GetCollection<BsonDocument>("Trips");


    //double[][] coordinates = new double[][] { new double[] { 45.31231, -8.12312 },
    //            new double[] { 45.31231, -8.12312 },
    //            new double[] { 45.31231, -8.12312 },
    //            new double[] { 45.313231, -8.12312 },
    //            new double[] { 45.31125231, -8.1265712 },
    //            new double[] { 45.366571231, -8.123167552 }};

    //Console.WriteLine(new BsonDocument { { "coordinates", coordinates.ToBsonDocument() } }.ToString());

    // var x = new BsonArray();
    // x.Add(45.13213);
    // x.Add(-8.13213);

    // var z = new BsonArray();
    // z.Add(x);
    // z.Add(x);
    // z.Add(x);
    // z.Add(x);
    // z.Add(x);
    // z.Add(x);
    // z.Add(x);

    // var array = new BsonDocument { { "coordinates", z } };

    // var y = new BsonDocument {
    //                    { "type", "LineString"},
    //                    { "coordinates", z.AsBsonArray } };


    // var doc = new BsonDocument
    //        {
    //            { "vehicle_id", V_doc[rng.Next(0,300)].GetValue("_id").ToString() },
    //            {"location_id", "61bc9ef5538163155768d8b0" },
    //            { "user_id", "61bc9d10538163155768d8a8" },
    //            {"cost", (double) 2.34 },
    //            {"length", 344 },
    //            {"duration", 12 },
    //            {"start_time", DateTime.Now.ToString() },
    //            {"ent_time", DateTime.Now.ToString() },
    //            {"features", new BsonArray().Add(y) },

    //        };

    // t.InsertOne(doc);

// int p = 0;
//     foreach (BsonDocument b in User_doc)
//     {
//        //Console.WriteLine(b.GetValue("_id").ToString());
//        for (int i = 0; i < 100; i++)
//        {
// p++;
//            var doc = new BsonDocument
//            {
//                { "vehicle_id", V_doc[rng.Next(0,300)].GetValue("_id").ToString() },
//                {"location_id", "61bc9ef5538163155768d8b0" },
//                { "user_id", b.GetValue("_id").ToString() },
//                {"cost", (double) 2.34 },
//                {"length", 344 },
//                {"duration", 12 },
//                {"start_time", DateTime.Now.ToString() },
//                {"ent_time", DateTime.Now.ToString() },
//                {"features",new BsonArray().Add(y) },

//            };
//            t.InsertOne(doc);
//        }
//        if(p>30000)break;
//     }




    // for (int i = 0; i < 325; i++)
    // {
    //    var doc = new BsonDocument
    //        {
    //            {"location_id", "61e06e7d9b070523fed79e96"},
    //            {"name", g.RandomGen(5)},
    //        {"model", g.RandomGen(5) },
    //        {"brand", g.RandomGen(5) },
    //        {"autonomy", 20 },
    //        {"startdate", DateTime.Now.ToString() },
    //        {"hour_rate", (double)1.05 },
    //        {"state", "active" },
    //        {"battery_level", 100 },
    //        {"currentLocation", new BsonDocument{ {"lat", 45.1232131},{"lon", -8.123123} } }
    //        };
    //    v.InsertOne(doc);
    // }



    stopwatch.Start();


    //Create Users
    for (int i = 0; i< 10000; i++)
    {
       users.Add(new UserAcc { UserId = Guid.NewGuid(), AccountBalance = 40, UserName =  g.RandomGen(16), DateOfBirth = new DateOnly(1980, 09, 14), Fullname = g.RandomGen(16), Roleid= 1 });
    }
    stopwatch.Stop();
    Console.WriteLine("Elapsed time creating users: {0}", stopwatch.ElapsedMilliseconds);
    stopwatch.Start();

    //Create Vehicles
    for (int i = 0; i < 300; i++)
    {
       vehicles.Add(new Vehicle { VehicleId = Guid.NewGuid(), LocationId = 1, Name = g.RandomGen(4), Model = g.RandomGen(4), Brand = g.RandomGen(4), Autonomy = 20, Startdate = DateTime.Now, HourRate = (float)2.55, State = "active", BatteryLevel = 100, Currentlocation = new NpgsqlTypes.NpgsqlPoint(45.013213, -8.2342) });

    }
    stopwatch.Stop();
    Console.WriteLine("Elapsed time creating vehicles: {0}", stopwatch.ElapsedMilliseconds);

    //foreach (UserAcc u in users)
    //{
    //    Console.WriteLine(u.UserId.ToString() + "---" + u.UserName +"---"+ u.Fullname);
    //}
    //foreach (Vehicle v in vehicles)
    //{
    //    Console.WriteLine(v.VehicleId.ToString());
    //}

    //Save each User and Vehicle to DB
    foreach (UserAcc u in users) { db.Add(u); }
    foreach(Vehicle v in vehicles)db.Add(v);
    db.SaveChanges();

    //Generate trips
    //Random rng = new Random();
    NpgsqlTypes.NpgsqlPoint[] points = { new NpgsqlTypes.NpgsqlPoint(45.013213, -8.2342), new NpgsqlTypes.NpgsqlPoint(46.013213, -8.2342), new NpgsqlTypes.NpgsqlPoint(47.013213, -8.2342), new NpgsqlTypes.NpgsqlPoint(48.013213, -8.2342) };
    stopwatch.Start();
    int k = 0;
    foreach(UserAcc u in users)
    {
       for (int i = 0; i < 1000; i++)
       {
           int n = rng.Next(0, 300);
           Trip t = new Trip { TripId = Guid.NewGuid(), VehicleId = vehicles[n].VehicleId, UserId = u.UserId, LocationId = 1, Cost = (float)1.55, Duration = 13, Length = 650, StartTime = DateTime.Now, EndTime = DateTime.Now.AddMinutes(13), Rating = null, FeedbackDescription = null, Path = new NpgsqlTypes.NpgsqlPath(points) };
           db.Add(t);
           db.SaveChanges();
       }
       if(k>30000)break;
    }

    stopwatch.Stop();
    Console.WriteLine("Elapsed time creating trips: {0}", stopwatch.ElapsedMilliseconds);

    return 0;
    //db.Add(new UserAcc { UserId = Guid.NewGuid(),AccountBalance = 40, UserName = "ppppp", DateOfBirth = new DateOnly(1980,09,14), Fullname = "Hugo", Roleid= 1 });
    //db.SaveChanges();
    




}











public class StringGenerator
{

    public string RandomGen(int length)
    {
        Random random = new Random();
        var rString = "";
        for (var i = 0; i < length; i++)
        {
            rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
        }
        return rString;
    }
}
