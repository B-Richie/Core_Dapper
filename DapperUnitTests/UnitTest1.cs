using Core_Dapper.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestQueryAsync()
        {
            List<IArtistDto> _queues = new List<IArtistDto>()
            {
                new ArtistDto()
                {
                    ArtistID = 1,
                    ArtistName = "My new test artist"
                }
            };
            
        }
    }
}
