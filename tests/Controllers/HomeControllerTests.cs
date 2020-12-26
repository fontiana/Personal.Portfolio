﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Moq;
using PersonalPortfolio.Context.Entity;
using PersonalPortfolio.Controllers;
using PersonalPortfolio.Models;
using PersonalPortfolio.Repository.Post;
using PersonalPortfolio.Repository.Project;
using Xunit;

namespace PersonalPortfolio.Tests.Controllers
{
    public class HomeControllerTests
    {
        //private static ServiceProvider Provider;
        //private static ServiceCollection Services;

        [Fact(DisplayName = "Should return a view result")]
        public void Index_ReturnsAViewResult()
        {
            // Arrange
            var localize = new Mock<IStringLocalizer<HomeController>>();

            var controller = new HomeController(localize.Object, null, null);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }

        [Fact(DisplayName = "Should return a view result with a list of projects")]
        public async Task Portfolio_ReturnsAViewResult_WithAListOfProjects()
        {
            // Arrange
            var localize = new Mock<IStringLocalizer<HomeController>>();

            var projects = new List<ProjectEntity>();
            projects.Add(new ProjectEntity());
            projects.Add(new ProjectEntity());

            var projectRepository = new Mock<IProjectRepository>();
            projectRepository
                .Setup(repo => repo.GetAsync())
                .ReturnsAsync(projects);

            var controller = new HomeController(localize.Object, projectRepository.Object, null);

            // Act
            var result = await controller.Portfolio();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<ProjectViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count);
        }

        [Fact(DisplayName = "Should return a view result with the detailed project")]
        public async Task Project_ReturnsAViewResult()
        {
            // Arrange
            var localize = new Mock<IStringLocalizer<HomeController>>();

            var projects = new List<ProjectEntity>();

            var projectRepository = new Mock<IProjectRepository>();
            projectRepository
                .Setup(repo => repo.GetAsync())
                .ReturnsAsync(projects);

            var controller = new HomeController(localize.Object, projectRepository.Object, null);

            // Act
            var result = await controller.Project("Teste");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProjectViewModel>(viewResult.ViewData.Model);
            Assert.NotNull(model);
        }

        [Fact(DisplayName = "Should return a view result")]
        public void About_ReturnsAViewResult()
        {
            // Arrange
            var localize = new Mock<IStringLocalizer<HomeController>>();

            var controller = new HomeController(localize.Object, null, null);

            // Act
            var result = controller.About();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }

        [Fact(DisplayName = "Should return a view result")]
        public void Resume_ReturnsAViewResult()
        {
            // Arrange
            var localize = new Mock<IStringLocalizer<HomeController>>();

            var controller = new HomeController(localize.Object, null, null);

            // Act
            var result = controller.Resume();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }

        [Fact(DisplayName = "Should return a view result")]
        public void Blog_ReturnsAViewResult()
        {
            // Arrange
            var localize = new Mock<IStringLocalizer<HomeController>>();

            var posts = new List<PostEntity>();
            posts.Add(new PostEntity());
            posts.Add(new PostEntity());

            var postRepository = new Mock<IPostRepository>();
            postRepository
                .Setup(repo => repo.GetAsync())
                .ReturnsAsync(posts);

            var controller = new HomeController(localize.Object, null, postRepository.Object);

            // Act
            var result = controller.Blog();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }

        [Fact(DisplayName = "Should return a view result")]
        public async Task Post_ReturnsAViewResult()
        {
            // Arrange
            var localize = new Mock<IStringLocalizer<HomeController>>();

            var post = new PostEntity();

            var postRepository = new Mock<IPostRepository>();
            postRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(post);

            var controller = new HomeController(localize.Object, null, postRepository.Object);

            // Act
            var result = await controller.Post(0);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }

        [Fact(DisplayName = "Should return a view result")]
        public void Contact_ReturnsAViewResult()
        {
            // Arrange
            var localize = new Mock<IStringLocalizer<HomeController>>();

            var controller = new HomeController(localize.Object, null, null);

            // Act
            var result = controller.Contact();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }
    }
}
