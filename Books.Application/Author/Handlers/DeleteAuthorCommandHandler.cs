using Books.Application.Author.Commands;
using Books.Infrastructure.Interfaces;
using MediatR;

namespace Books.Application.Author.Handlers
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        public DeleteAuthorCommandHandler(
            IAuthorRepository authorRepository,
            IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.FirstOrDefaultAsync(a => a.Id == request.Code);
            if (author == null)
                return false;

            var book = await _bookRepository.FirstOrDefaultAsync(b => b.AuthorId == author.Id);
            if(book != null)
                return false;

            _authorRepository.Remove(author);

            var result = await _authorRepository.SaveChangesAsync();
            
            return result > 0 ? true : false;
        }
    }
}
