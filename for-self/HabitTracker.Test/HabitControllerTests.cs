using HabitTracker.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitTracker.Test
{
    public class HabitControllerTests
    {
        private readonly HabitTrackerWebApplicationFactory _factory;
        private readonly HttpClient _client;

        public HabitControllerTests()
        {
            _factory= new HabitTrackerWebApplicationFactory();
            _client= new HttpClient();

            _client = _factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost")
            });
        }

        [Fact]
        public async Task CreateHabit_ShouldReturnCreated()
        {
            Habit habit = Habit.Create("Read");

            var response = await _client.PostAsync("/habits", habit);

            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }

    }
}
