using System;
using Moq;
using Test.Models;
using Xunit;

namespace Test.tests
{
    public class ContactService_Test
    {
        private const string TestFileName = @"D:\Projects\Test\testContacts.json";

        [Fact]
        public void AddContact_ValidContact_AddsContactToList()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            var testContact = new Contact
            {
                Firstname = "Thana",
                Lastname = "Sa",
                Email = "Thana@domain.com",
                Phonenumber = "1234567890",
                Address = "Banangatan 1"
            };

            mockContactService.Setup(c => c.AddContact(It.IsAny<Contact>())).Callback<Contact>(contact =>
            {
                Assert.Equal(testContact.Firstname, contact.Firstname);
            });

            // Act
            mockContactService.Object.AddContact(testContact);

            // Assert
            mockContactService.Verify(c => c.AddContact(It.IsAny<Contact>()), Times.Once);
        }

        [Fact]
        public void ShowContacts_ReturnsNonNullList_WhenContactsExist()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(cs => cs.ShowContact()).Returns(new[] { new Contact() }.AsEnumerable<IContact>());


            // Act
            var result = mockContactService.Object.ShowContact();

            // Assert
            Assert.NotNull(result);
        }
    }
}
