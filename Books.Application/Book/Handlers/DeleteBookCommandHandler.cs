using Books.Application.Book.Commands;
using Books.Infrastructure.Interfaces;
using MediatR;

namespace Books.Application.Book.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.FirstOrDefaultAsync(b => b.Id == request.Code);
            if (book == null)
                return false;

            _bookRepository.Remove(book);

            var result = await _bookRepository.SaveChangesAsync();

            return result > 0 ? true : false;
        }
    }
}
