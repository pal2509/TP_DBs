using System;
using Generator;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

Console.WriteLine("Hello, World!");


using (var db = new postgresContext())
{
    List<UserAcc> users = new List<UserAcc>();
    List<Vehicle> vehicles = new List<Vehicle>();
    StringGenerator g = new StringGenerator();
    ArrayList trips = new ArrayList();
    Stopwatch stopwatch = new Stopwatch();
    
    
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
        vehicles.Add(new Vehicle { VehicleId = Guid.NewGuid(), LocationId = 5, Name = g.RandomGen(4), Model = g.RandomGen(4), Brand = g.RandomGen(4), Autonomy = 20, Startdate = DateTime.Now, HourRate = (float)2.55, State = "active", BatteryLevel = 100, Currentlocation = new NpgsqlTypes.NpgsqlPoint(45.013213, -8.2342) });

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
    Random rng = new Random();
    NpgsqlTypes.NpgsqlPoint[] points = { new NpgsqlTypes.NpgsqlPoint(45.013213, -8.2342), new NpgsqlTypes.NpgsqlPoint(46.013213, -8.2342), new NpgsqlTypes.NpgsqlPoint(47.013213, -8.2342), new NpgsqlTypes.NpgsqlPoint(48.013213, -8.2342) };
    stopwatch.Start();
    foreach(UserAcc u in users)
    {
        for (int i = 0; i < 1000; i++)
        {
            int n = rng.Next(0, 300);
            Trip t = new Trip { TripId = Guid.NewGuid(), VehicleId = vehicles[n].VehicleId, UserId = u.UserId, LocationId = 5, Cost = (float)1.55, Duration = 13, Length = 650, StartTime = DateTime.Now, EndTime = DateTime.Now.AddMinutes(13), Rating = null, FeedbackDescription = null, Path = new NpgsqlTypes.NpgsqlPath(points) };
            db.Add(t);
            db.SaveChanges();
        }
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
