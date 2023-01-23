using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Machine.Data.api.Entity
{
    public class Asset
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }
        /// <summary>
        /// Machine Type
        /// </summary>
        [BsonElement("machine_type")]
        public string MachineName { get; set; }

        /// <summary>
        /// Asset Type
        /// </summary>
        [BsonElement("asset_name")]
        public string AssetName { get; set; }

        /// <summary>
        /// Version Number
        /// </summary>
        [BsonElement("version")]
        public string SeriesNumber { get; set; }

        public Asset()
        {

        }

        public Asset(string machineName,string assetName,string seriesNumber)
        {
            MachineName = machineName;
            AssetName = assetName;
            SeriesNumber = seriesNumber;
        }
    }
}
