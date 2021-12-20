using System;
using Generator;

Console.WriteLine("Hello, World!");


using (var db = new postgresContext())
{
    db.Add(new UserAcc { UserId = Guid.NewGuid(),AccountBalance = 40, UserName = "ppppp", DateOfBirth = new DateOnly(1980,09,14), Fullname = "Hugo", Roleid= 1 });
    db.SaveChanges();
}
