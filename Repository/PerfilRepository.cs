using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBot.OM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository
{
    public class PerfilRepository
    {
        private static readonly Lazy<PerfilRepository> lazy =
    new Lazy<PerfilRepository>(() => new PerfilRepository());

        public static PerfilRepository Instance { get { return lazy.Value; } }

        IMongoCollection<ProfileOM> col;
        IMongoDatabase db;
        MongoClient cliente;

        private PerfilRepository()
        {
            cliente = new MongoClient();
            db = cliente.GetDatabase("Chatbot");
            col = db.GetCollection<ProfileOM>("Perfil");
        }

        public long InsertVisit(string id)
        {
            var filtro = Builders<ProfileOM>.Filter.Eq("IdUser", id);
            var profile = col.Find(filtro).FirstOrDefault();

            if (profile == null)
            {
                profile = new ProfileOM()
                {
                    Id = id,
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