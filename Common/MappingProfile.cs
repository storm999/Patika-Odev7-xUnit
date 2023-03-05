using AutoMapper;
using BookStorePtk.Applications.BookOperations.Commands.CreateBook;
using BookStorePtk.Applications.BookOperations.Queries.GetBookDetail;
using BookStorePtk.Applications.BookOperations.Queries.GetBooks;
using BookStorePtk.Applications.BookOperations.Commands.UpdateBook;
using static BookStorePtk.Applications.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static BookStorePtk.Applications.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;
using static BookStorePtk.Applications.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static BookStorePtk.Applications.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;
using static BookStorePtk.Applications.AuthorOperations.Queries.GetAuthors.GetAuthorsQuery;
using static BookStorePtk.Applications.AuthorOperations.Queries.GetAuthorDetail.GetAuthorDetailQuery;
using static BookStorePtk.Applications.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static BookStorePtk.Applications.AuthorOperations.Commands.UpdateAuthor.UpdateAuthorCommand;
using BookStorePtk.Entities;

namespace BookStorePtk.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<CreateBookCommand.CreateBookViewModel, Book>();
            CreateMap<UpdateBookViewModel, Book>();

            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateGenreViewModel, Genre>();
            CreateMap<UpdateGenreViewModel, Genre>();

            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<CreateAuthorViewModel, Author>();
            CreateMap<UpdateAuthorViewModel, Author>();

        }
    }
}
