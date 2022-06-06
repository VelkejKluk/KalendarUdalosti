using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalendarUdalosti;
using MongoDB.Driver;

namespace KalendarUdalosti
{
    internal class DataAccess
    {
        private MongoClient klientDb;
        private IMongoDatabase kalendar;
        private IMongoCollection<DateOnly> data;

        public DataAccess()
        {
            klientDb = new MongoClient("mongodb+srv://VelkejKluk:cotozkousis@clusterspellbook.5uqbn.mongodb.net/ClusterSpellBook?retryWrites=true&w=majority");

            kalendar = klientDb.GetDatabase("Calendar");
            data = kalendar.GetCollection<DateOnly>("calendarData");
        }
    }
}
