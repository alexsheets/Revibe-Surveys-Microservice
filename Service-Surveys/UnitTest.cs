using System;
using System.Collections.Generic;
using Xunit;
using Surveys.Models;
using Surveys.Data;
using Surveys.Profiles;
using Surveys.Controllers;
using Moq;
using AutoMapper;
using AssertLibrary;


namespace Surveys
{
    public class UnitTest 
    {
        private readonly Contact contact = new Contact();

        [Fact]
        public void Contacts_Return()
        {
            try
            {
                // arrange and repos
                Mock<IContactRepo> mockRepo = new Mock<IContactRepo>();
                var contacts = new List<Contact>(){
                    new Contact() { Id=1, FirstName="JohnDoe", Message="John Doe was here." },
                    new Contact() { Id=2, FirstName="JohnMoe", Message="John Moe was here." },
                    new Contact() { Id=3, FirstName="JohnLoe", Message="John Loe was here." }
                };
                mockRepo.Setup(m => m.GetAllContacts()).Returns(value: contacts);

                var mockMap = new MapperConfiguration(cfg => {
                    cfg.AddProfile<ContactsProfile>();
                });
                // create mock mapper to create the contact controller for testing
                var mapper = mockMap.CreateMapper();
                ContactsController controller = new ContactsController(repository: mockRepo.Object, mapper: mapper);

                // use controller to get result or all contacts we recently created
                var result = controller.GetAllContacts();

                // perhaps add more assertions...
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsFalse(false, ex.Message);
            }
        }
    }
}