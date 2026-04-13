using HabitTracker.Api;
using HabitTracker.Api.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

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

            var json = JsonSerializer.Serialize<Habit>(habit);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
                );

            var response = await _client.PostAsync("/api/habits", content);

            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task CreateHabit_ShouldAcceptValidRequest()
        {
            CreateHabitRequest habitReq = new CreateHabitRequest("Read");

            string json=JsonSerializer.Serialize<CreateHabitRequest>(habitReq);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await _client.PostAsync("/api/habits", content);

            Assert.NotEqual(System.Net.HttpStatusCode.BadRequest,response.StatusCode);
        }

        [Fact]
        public async Task CreateHabit_ShouldReciveInput()
        {
            var habitReq = new CreateHabitRequest("Read");
            var json = JsonSerializer.Serialize(habitReq);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/habits", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            Assert.Contains("Read",responseBody);
        }

        [Fact]
        public async Task CreateHabit_ShouldReturnGeneratedId()
        {
            var habitReq = new CreateHabitRequest("Read");
            var json =JsonSerializer.Serialize(habitReq);
            var content=new StringContent(json, Encoding.UTF8,"application/json");
            var response = await _client.PostAsync("/api/habits", content);
            var responseBody=await response.Content.ReadAsStringAsync();

            Assert.Contains("id", responseBody);
        }
    }
}
