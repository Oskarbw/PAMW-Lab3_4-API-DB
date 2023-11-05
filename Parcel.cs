namespace PAMW3_API
{
    public class Parcel
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public int Weight { get; set; }

        public Carrier Carrier { get; set; }
        public int CarrierId { get; set; }
    }
}
