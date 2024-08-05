using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;
using Xunit;
using Assert = Xunit.Assert;

namespace TestAPI;

public class ContactsControllerTests
{
    private readonly Mock<IContactService> _mockContactService;
    private readonly Mock<IManagerNameService> _mockManagerNameService;
    private readonly ContactsController _controller;

    public ContactsControllerTests()
    {
        _mockContactService = new Mock<IContactService>();
        _mockManagerNameService = new Mock<IManagerNameService>();
        _controller = new ContactsController(_mockContactService.Object, _mockManagerNameService.Object);
    }

    [Fact]
    public async Task GetAllContacts_ReturnsOkResult_WithListOfContacts()
    {
        // Arrange
        var contacts = new List<Contact> { new Contact(), new Contact() };
        _mockContactService.Setup(s => s.GetAllContacts()).ReturnsAsync(contacts);

        // Act
        var result = await _controller.GetAllContacts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedContacts = Assert.IsType<List<Contact>>(okResult.Value);
        Assert.Equal(2, returnedContacts.Count);
    }

    [Fact]
    public async Task GetAllManagerNames_ReturnsOkResult_WithListOfManagerNames()
    {
        // Arrange
        var managerNames = new List<ManagerName> { new ManagerName(), new ManagerName() };
        _mockManagerNameService.Setup(s => s.GetAllManagerName()).ReturnsAsync(managerNames);

        // Act
        var result = await _controller.GetAllManagerNames();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedManagerNames = Assert.IsType<List<ManagerName>>(okResult.Value);
        Assert.Equal(2, returnedManagerNames.Count);
    }

    [Fact]
    public async Task GetContactById_ReturnsOkResult_WhenContactExists()
    {
        // Arrange
        var contactId = 1;
        var contact = new ContactDto { Id = contactId };
        _mockContactService.Setup(s => s.GetContactById(contactId)).ReturnsAsync(contact);

        // Act
        var result = await _controller.GetContactById(contactId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedContact = Assert.IsType<ContactDto>(okResult.Value);
        Assert.Equal(contactId, returnedContact.Id);
    }

    [Fact]
    public async Task GetContactById_ReturnsNotFound_WhenContactDoesNotExist()
    {
        // Arrange
        var contactId = 1;
        _mockContactService.Setup(s => s.GetContactById(contactId)).ReturnsAsync((ContactDto)null);

        // Act
        var result = await _controller.GetContactById(contactId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task AddContact_ReturnsCreatedAtAction_WhenModelIsValid()
    {
        // Arrange
        var createContactDto = new CreateContactDto
        {
            Firstname = "John",
            Surname = "Doe",
            ManagerNameId = 1
        };
        var managerName = new ManagerName { Id = 1, Name = "Manager" };
        _mockManagerNameService.Setup(s => s.GetManagerNameById(1)).ReturnsAsync(managerName);
        _mockContactService.Setup(s => s.AddContact(It.IsAny<Contact>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.AddContact(createContactDto);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal("GetContactById", createdAtActionResult.ActionName);
        var returnedContact = Assert.IsType<ContactDto>(createdAtActionResult.Value);
        Assert.Equal(createContactDto.Firstname, returnedContact.Firstname);
    }

    [Fact]
    public async Task UpdateContact_ReturnsNoContent_WhenContactExists()
    {
        // Arrange
        var contactId = 1;
        var updateContactDto = new UpdateContactDto
        {
            Firstname = "John",
            Surname = "Doe",
            ManagerNameId = 1
        };
        var existingContact = new ContactDto { Id = contactId };
        _mockContactService.Setup(s => s.GetContactById(contactId)).ReturnsAsync(existingContact);
        _mockManagerNameService.Setup(s => s.GetManagerNameById(1)).ReturnsAsync(new ManagerName());
        _mockContactService.Setup(s => s.UpdateContact(It.IsAny<Contact>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.UpdateContact(contactId, updateContactDto);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task UpdateContact_ReturnsNotFound_WhenContactDoesNotExist()
    {
        // Arrange
        var contactId = 1;
        var updateContactDto = new UpdateContactDto();
        _mockContactService.Setup(s => s.GetContactById(contactId)).ReturnsAsync((ContactDto)null);

        // Act
        var result = await _controller.UpdateContact(contactId, updateContactDto);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }
}