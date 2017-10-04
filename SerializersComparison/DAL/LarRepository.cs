using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SerializersComparison.Models;
using Dapper;

namespace SerializersComparison.DAL
{
    public class LarRepository : ILarRepository
    {
        public IEnumerable<HmdfEntity> GetHmdfRows(int count)
        {
            var records = new List<HmdfEntity>();
            for (var j = 0; j < count; j++)
            {
                records.Add(BuiltHmdfTestRecord());
            }
            return records;
        }
        private  static HmdfEntity BuiltHmdfTestRecord()
        {
            return new HmdfEntity
            {
                Address = "75 WASHINGTON ST",
                City = "PEABODY",
                STATE_ABRV = "MA",
                Zip = "01960",
                Zip4 = "1563",
                State = "MA",
                MSA = "16974",
                County = "031",
                CensusTrac = "8046.06",
                MmwAddress = "75 WASHINGTON ST",
                mmwCity = "PEABODY",
                mmwState = "MA",
                mmwZip = "01960",
                mmwZip4 = "1563",
                StndStat = "Stnd",
                gsMatchCode = "MC",
                gsLocationCode = "LC",
                gsMatchResult = "MR",
                CongDist = "CD",
                latitude = (decimal)42.012198,
                longitude = (decimal)51.348332,
                BlockGrp = "BG",
                gdtMCD = "MCD",
                gdtPlace = "Gp",
                mmwStat = "B1",
                ULI = "123424",
                LEI = "222312",
                ULIStatus = "1",
                DatasetId = 1,
                Action = "5",
                ApplDate = DateTime.Now,
                ApplDate_NA = false
            };
        }


    }
}