namespace Machine.Data.api.Entity
{
    public class Asset
    {
        public string MachineName { get; set; }
        public string AssetName { get; set; }

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
