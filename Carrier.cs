namespace PAMW3_API
{
    public class Carrier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Parcel> Parcels { get; set; }
    }
}
