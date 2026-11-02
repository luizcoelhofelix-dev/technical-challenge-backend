using Books.Application.Author.Commands;
using Books.Application.Genre.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Application.Genre.CommandsValidation
{
    public interface ICreateGenreCommandValidation
    {
        ValidationResponse Validate(CreateGenreCommand command);
    }

    public class CreateGenreCommandValidation : ICreateGenreCommandValidation
    {
        public ValidationResponse Validate(CreateGenreCommand command)
        {
            var response = new ValidationResponse();

            if (command.Name == null || command.Name.Trim() == "")
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to create the new genre.";
                response.Errors = new List<string> { "Name is required." };
            }
            if (command.Name?.Length > 100)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to create the new genre.";
                response.Errors = new List<string> { "Name has a maximum length of 100 characters." };
            }

            return response;
        }
    }
}
