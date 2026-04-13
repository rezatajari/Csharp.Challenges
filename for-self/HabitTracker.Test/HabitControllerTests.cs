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
        }



    }
}
