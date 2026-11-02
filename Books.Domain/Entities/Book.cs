using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;
using System.Xml.Linq;

namespace Books.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }        
        public DateTime? PublishedDate { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }

        public void Update(Book updated)
        {
            Title = updated.Title;
            PublishedDate = updated.PublishedDate;
            Price = updated.Price;
            AuthorId = updated.AuthorId;
            GenreId = updated.GenreId;
            Description = updated.Description;
        }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Title))
                return false;
            else if (Title.Length > 120)
                return false;
            if (PublishedDate == DateTime.MinValue)
                return false;
            else if (PublishedDate >= DateTime.Now)
                return false;
            if (Price < 0)
                return false;
            else if (Description?.Length > 500)
                return false;

            return true;
        }
    }
}
