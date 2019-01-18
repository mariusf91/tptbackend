using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThePhantomTroupe.Models;

namespace ThePhantomTroupe.Repository
{
    public class RaiderIoRepository : RepositoryBase
    {
        public RaiderIOCharacter GetRaiderIOCharacter(string name)
        {
            return GetOne<RaiderIOCharacter>(Collection.RaiderIO, "Name", name);
        }

        public IEnumerable<RaiderIOCharacter> GetRaiderIOCharacters()
        {
            return GetMany<RaiderIOCharacter>(Collection.RaiderIO, new MongoDB.Bson.BsonDocument());
        }

        public void InsertRaiderIOCharacter(RaiderIOCharacter character)
        {
            InsertOne<RaiderIOCharacter>(Collection.RaiderIO, character);
        }

    }
}