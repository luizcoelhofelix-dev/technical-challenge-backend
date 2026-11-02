namespace Books.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public  void Update(Author updated)
        {
            Name = updated.Name;
            DateOfBirth = updated.DateOfBirth;
            Country = updated.Country;
        }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
                return false;
            else if (Name.Length > 100)
                return false;
            if (DateOfBirth == DateTime.MinValue)
                return false;
            if (DateOfBirth == DateTime.Now)
                return false;
            if (string.IsNullOrEmpty(Country))
                return false;
            else if(Country.Length > 70)
                return false;

            return true;
        }
    }
}
