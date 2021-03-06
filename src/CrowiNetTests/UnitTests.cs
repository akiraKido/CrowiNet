﻿using System;
using CrowiNet;
using Xunit;

namespace CrowiNetTests
{
    public class UnitTests
    {
        private static readonly Credentials Credentials = new Credentials(Settings.AccessToken);
        private static readonly Uri EndPoint = new Uri(Settings.EndPoint);

        [Fact]
        public async void PageListTest()
        {
            using (var crowi = new Crowi(EndPoint, Credentials))
            {
                var parameter = new User( Settings.User );
                var result = await crowi.GetPageListAsync(parameter);
                Assert.True(result.Ok);
            }
        }

        [Fact]
        public async void UsersTest()
        {
            using (var crowi = new Crowi(EndPoint, Credentials))
            {
                var result = await crowi.GetUsersAsync();
                Assert.True(result.Ok);
            }
        }
    }
}
