namespace Books.Domain.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public virtual ICollection<Book> Books { get; set; }

        public void Update(Genre updated)
        {
            Name = updated.Name;
        }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
                return false;
            else if (Name.Length > 100)
                return false;

            return true;
        }
    }
}
