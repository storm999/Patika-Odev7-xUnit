using AutoMapper;
using BookStorePtk.Applications.BookOperations.Commands.CreateBook;
using BookStorePtk.Common;
using BookStorePtk.DBOperations;
using FluentAssertions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using static BookStorePtk.Applications.BookOperations.Commands.CreateBook.CreateBookCommand;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Tests
{
    public class CreateBookCommandTests
    {

        protected IMapper mapper;
        public CreateBookCommand createBookCommand;

        public CreateBookCommandTests()
        {
            
            MapperConfiguration configuration = new MapperConfiguration(opt => {
                opt.AddProfile(new MappingProfile());
            });
            mapper = configuration.CreateMapper();

            createBookCommand = new CreateBookCommand(new BookStoreDbContext(new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreDB").Options), mapper);
        }

        public static IEnumerable<object[]> InvalidInputList => new List<object[]>
                                                                 {
                                                                        new object[] { new CreateBookViewModel("t",1,new DateTime(2020,01,01),1,100)},
                                                                        new object[] { new CreateBookViewModel("aaa",1,new DateTime(2020,01,01),1,-1)}
                                                                 };

        [Theory, MemberData(nameof(InvalidInputList))]
        public void CreateBookCommandInvalidInputTests(CreateBookViewModel createBookViewModel)
        {
            createBookCommand.Model = createBookViewModel;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            createBookCommand.Handle();

            FluentValidation.Results.ValidationResult valRes = validator.Validate(createBookCommand);

            valRes.Errors.Count.Should().BeGreaterThan(0);
        }




        public static IEnumerable<object[]> ValidInputList => new List<object[]>
                                                                 {
                                                                        new object[] { new CreateBookViewModel("ada",1,new DateTime(2020,01,01),1,100)},
                                                                        new object[] { new CreateBookViewModel("efe",1,new DateTime(2020,01,01),1,1)}
                                                                 };

        [Theory, MemberData(nameof(ValidInputList))]
        public void CreateBookCommandValidInputTests(CreateBookViewModel createBookViewModel)
        {
            createBookCommand.Model = createBookViewModel;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            createBookCommand.Handle();

            FluentValidation.Results.ValidationResult valRes = validator.Validate(createBookCommand);

            valRes.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}