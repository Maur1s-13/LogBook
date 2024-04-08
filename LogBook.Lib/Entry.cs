namespace LogBook.Lib
{
    /// <summary>
    /// Create an entry for the log book
    /// </summary>
    public class Entry
    {
        public bool Favorite { get; set; } = false;
        public string Description { get; set; } = string.Empty;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int StartKM { get; set; }

        public int EndKM { get; set; }

        public int Distance => EndKM - StartKM;

        public string NumberPlate { get; set; }

        public  string From { get; set; }

        public  string To { get; set; }


        public  string Id { get; set; }

        public Entry( DateTime start, DateTime end, int startKM, int endKM, string numberPlate, string from, string to, bool favorite, string id)
        {
            this.Id = id;
            this.Start = start;
            this.End = end;
            this.StartKM = startKM;
            this.EndKM = endKM;
            this.NumberPlate = numberPlate;
            this.From = from;
            this.To = to;
            this.Favorite = favorite;
        }

        public Entry( DateTime start, DateTime end, int startKM, int endKM, string numberPlate, string from, string to, bool favorite )
        {
            this.Id = Guid.NewGuid().ToString();
            this.Start = start;
            this.End = end;
            this.StartKM = startKM;
            this.EndKM = endKM;
            this.NumberPlate = numberPlate;
            this.From = from;
            this.To = to;
            this.Favorite = favorite;
        }

        public Entry()
        {
                
        }
        public override string ToString()
        {
            return string.Format("{0} nach {1}", From, To);
        }

    }
}