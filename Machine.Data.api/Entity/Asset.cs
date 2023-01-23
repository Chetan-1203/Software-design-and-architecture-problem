namespace Machine.Data.api.Entity
{
    public class Asset
    {    

        /// <summary>
        /// Machine Type
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// Asset Name
        /// </summary>
        public string AssetName { get; set; }

        /// <summary>
        /// Version Number
        /// </summary>
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
