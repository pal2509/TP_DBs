using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Models.MongoDB
{
    class User
    {
        [BsonExtraElements]
        public BsonDocument CatchAll { get; set; }
    }
}
