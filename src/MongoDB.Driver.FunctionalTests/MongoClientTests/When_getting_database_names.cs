﻿/* Copyright 2013-2014 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace MongoDB.Driver.MongoClientTests
{
    [TestFixture]
    public class When_listing_database_names : SpecificationBase
    {
        private IReadOnlyList<string> _result;

        protected override void When()
        {
            _result = _client.GetDatabaseNamesAsync().GetAwaiter().GetResult();
        }

        [Test]
        public void The_result_should_not_be_null()
        {
            _result.Should().NotBeNull();
        }

        [Test]
        public void The_count_should_be_greater_than_0()
        {
            _result.Count.Should().BeGreaterThan(0);
        }
    }
}