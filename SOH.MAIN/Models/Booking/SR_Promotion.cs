namespace SOH.MAIN.Models.Booking
{
    public class SR_Promotion
    {
        public int idPromotion { get; set; }
        public string name { get; set; }
        public string concep { get; set; }
        public float value { get; set; }
        public bool isActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
