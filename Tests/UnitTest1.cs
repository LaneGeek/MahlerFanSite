using System;
using MahlerFanSite.Controllers;
using MahlerFanSite.Models;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        public IRepository repository = new FakeStoryRepository();

        public UnitTest1()
        {
            // Lets populate our empty repository in the constructor here
            repository.AddStory(new Story
            {
                StoryId = 1,
                Text = "Mahler once slept the whole day!",
                PublishedDate = new DateTime(2012, 6, 12),
                Ratings = { 4, 0, 5, 1 },
                Comments =
                {
                    new Comment {Text = "Good story", Name = "Taylor"},
                    new Comment {Text = "Crappy story", Name = "David"}
                }
            });
            repository.AddStory(new Story
            {
                StoryId = 2,
                Text = "I met Mahler once!",
                PublishedDate = new DateTime(2002, 6, 12)
            });

            repository.AddStory(new Story
            {
                StoryId = 3,
                Text = "Once upon a time...",
                PublishedDate = new DateTime(2012, 11, 12),
                Ratings = { 0, 0, 5 },
                Comments =
                {
                    new Comment {Text = "Sad story", Name = "John"},
                    new Comment {Text = "Fake story!", Name = "Donald"}
                }
            });
        }

        // This test verifies that a story is added correctly and that the date is parsed from
        // a string in to the DateTime type and that story id is parsed to an integer from a string
        [Fact]
        public void AddStoryTest()
        {
            // Arrange
            HomeController homeController = new HomeController(repository);

            // Act
            homeController.AddStory("Life", "01/10/1997", "7");

            // Assert
            Assert.Equal("Life", repository.Stories[^1].Text);
            Assert.Equal(new DateTime(1997, 1, 10), repository.Stories[^1].PublishedDate);
            Assert.Equal(7, repository.Stories[^1].StoryId);
            // Lets also ensure that we now have a total of four stories in our repository
            Assert.Equal(4, repository.Stories.Count);
        }

        // This test verifies the comment is added correctly to the story and appended to list of comments
        [Fact]
        public void AddCommentTest()
        {
            // Arrange
            HomeController homeController = new HomeController(repository);

            // Act
            homeController.AddComment("Mahler once slept the whole day!", "Horrible story", "Peter");

            // Assert
            Assert.Equal("Horrible story", repository.Stories[0].Comments[^1].Text);
            Assert.Equal("Peter", repository.Stories[0].Comments[^1].Name);
            // Lets also check that the original two comments are not altered in any way
            Assert.Equal("Good story", repository.Stories[0].Comments[0].Text);
            Assert.Equal("Taylor", repository.Stories[0].Comments[0].Name);
            Assert.Equal("Crappy story", repository.Stories[0].Comments[1].Text);
            Assert.Equal("David", repository.Stories[0].Comments[1].Name);
        }

        // This test verifies that the rating is correctly parsed to an integer and added
        // to the story and appended to list of ratings
        [Fact]
        public void AddRatingTest()
        {
            // Arrange
            HomeController homeController = new HomeController(repository);
            
            // Act
            homeController.AddRating("Once upon a time...", "3");

            // Assert
            Assert.Equal(3, repository.Stories[2].Ratings[^1]);
            // Lets also check that the original three ratings are not altered in any way
            Assert.Equal(0, repository.Stories[^1].Ratings[0]);
            Assert.Equal(0, repository.Stories[^1].Ratings[1]);
            Assert.Equal(5, repository.Stories[^1].Ratings[2]);
        }
    }
}
