using Books.Application.Book.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Application.Book.CommandsValidation
{
    public interface IUpdateBookCommandValidation
    {
        ValidationResponse Validate(UpdateBookCommand command);
    }

    public class UpdateBookCommandValidation : IUpdateBookCommandValidation
    {
        public ValidationResponse Validate(UpdateBookCommand command)
        {
            var response = new ValidationResponse();

            if (command.Code <= 0)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the book.";
                response.Errors = new List<string> { "Invalid book number code." };
            }

            if (command.Title == null || command.Title.Trim() == "")
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the book.";
                response.Errors = new List<string> { "Book title is required." };
            }
            else if (command.Title.Length > 120)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the book.";
                response.Errors = new List<string> { "Book title has a maximum length of 120 characters." };
            }
            if (command.Description?.Length > 500)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the book.";
                response.Errors = new List<string> { "Book description has a maximum length of 500 characters." };
            }
            if (command.Price < 0)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the book.";
                response.Errors = new List<string> { "Price must be a positive value." };
            }
            if (command.PublishedDate == DateTime.MinValue || command.PublishedDate > DateTime.Now)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the book.";
                response.Errors = new List<string> { "The published date is invalid." };
            }
            if (command.AuthorId <= 0)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the book.";
                response.Errors = new List<string> { "Author code is required." };
            }
            if (command.GenreId <= 0)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the book.";
                response.Errors = new List<string> { "Genre code is required." };
            }

            return response;
        }
    }
}
