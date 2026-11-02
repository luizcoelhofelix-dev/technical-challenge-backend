using Books.Application.Author.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Application.Author.CommandsValidation
{
    public interface IUpdateAuthorCommandValidation
    {
        ValidationResponse Validate(UpdateAuthorCommand command);
    }

    public class UpdateAuthorCommandValidation: IUpdateAuthorCommandValidation
    {
        public ValidationResponse Validate(UpdateAuthorCommand command)
        {
            var response = new ValidationResponse();

            if (command.Code <= 0)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the author.";
                response.Errors = new List<string> { "Invalid author number code." };
            }
            if (command.Name == null || command.Name.Trim() == "")
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the new author.";
                response.Errors = new List<string> { "Name is required." };
            }
            if (command.Name?.Length > 100)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the author.";
                response.Errors = new List<string> { "Name has a maximum length of 100 characters." };
            }
            if (command.Country == null || command.Country.Trim() == "")
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the author.";
                response.Errors = new List<string> { "Country is required." };
            }
            if (command.Country?.Length > 70)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the author.";
                response.Errors = new List<string> { "Country has a maximum length of 70 characters." };
            }
            if (command.DateOfBirth == DateTime.MinValue || command.DateOfBirth > DateTime.Now)
            {
                response.IsValid = false;
                response.Message = "There was an error while attempting to update the author.";
                response.Errors = new List<string> { "The date of birth is invalid." };
            }

            return response;
        }
    }
}
