using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using SimpleBot.Interface;
using SimpleBot.OM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository
{
    public sealed class PerfilMongoRepository : IProfileRepository
    {
        private static readonly Lazy<PerfilMongoRepository> lazy =
    new Lazy<PerfilMongoRepository>(() => new PerfilMongoRepository());

        public static PerfilMongoRepository Instance { get { return lazy.Value; } }

        IMongoCollection<ProfileEntity> col;
        IMongoDatabase db;
        MongoClient cliente;

        private PerfilMongoRepository()
        {
            cliente = new MongoClient();
            db = cliente.GetDatabase("Chatbot");
            col = db.GetCollection<ProfileEntity>("Perfil");
        }

        public long InsertVisit(string idProfile)
        {
            var filtro = Builders<ProfileEntity>.Filter.Eq("IdProfile", idProfile);
            var profile = col.Find(filtro).FirstOrDefault();

            if (profile == null)
            {
                profile = new ProfileEntity()
                {
                    IdProfile = idProfile,
                    VisitNumber = 0
                };
            }

            profile.VisitNumber += 1;
            var option = new UpdateOptions();
            option.IsUpsert = true;

            col.ReplaceOne(filtro, profile, option);
            return profile.VisitNumber;
        }
    }
}