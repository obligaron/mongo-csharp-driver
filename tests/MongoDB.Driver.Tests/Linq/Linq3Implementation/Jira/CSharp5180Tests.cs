﻿/* Copyright 2010-present MongoDB Inc.
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

using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Core.Misc;
using MongoDB.Driver.Core.TestHelpers.XunitExtensions;
using MongoDB.Driver.Linq;
using MongoDB.TestHelpers.XunitExtensions;
using Xunit;

namespace MongoDB.Driver.Tests.Linq.Linq3Implementation.Jira
{
    public class CSharp5180Tests : Linq3IntegrationTest
    {
        [Theory]
        [ParameterAttributeData]
        public void Cast_Decimal_to_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal)x.Decimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { Decimal : '$Decimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$Decimal', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Decimal_to_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double)x.Decimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$Decimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$Decimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Decimal_to_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int)x.Decimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$Decimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$Decimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Decimal_to_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long)x.Decimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Decimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$Decimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Decimal_to_nullable_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal?)x.Decimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Decimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$Decimal', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Decimal_to_nullable_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double?)x.Decimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Decimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$Decimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Decimal_to_nullable_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int?)x.Decimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Decimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$Decimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Decimal_to_nullable_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long?)x.Decimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Decimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$Decimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Double_to_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal)x.Double);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$Double', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$Double' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Double_to_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double)x.Double);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { Double : '$Double', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$Double', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Double_to_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int)x.Double);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$Double', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$Double' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Double_to_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long)x.Double);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Double', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$Double' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Double_to_nullable_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal?)x.Double);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Double', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$Double' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Double_to_nullable_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double?)x.Double);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Double', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$Double', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Double_to_nullable_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int?)x.Double);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Double', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$Double' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Double_to_nullable_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long?)x.Double);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Double', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$Double' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Int_to_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal)x.Int);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$Int', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$Int' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Int_to_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double)x.Int);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$Int', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$Int' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Int_to_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int)x.Int);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { Int : '$Int', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$Int', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Int_to_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long)x.Int);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Int', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$Int' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Int_to_nullable_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal?)x.Int);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Int', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$Int' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Int_to_nullable_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double?)x.Int);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Int', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$Int' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Int_to_nullable_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int?)x.Int);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Int', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$Int', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Int_to_nullable_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long?)x.Int);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Int', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$Int' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Long_to_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal)x.Long);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$Long', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$Long' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Long_to_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double)x.Long);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$Long', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$Long' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Long_to_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int)x.Long);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$Long', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$Long' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Long_to_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long)x.Long);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { Long: '$Long', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$Long', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Long_to_nullable_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal?)x.Long);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Long', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$Long' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Long_to_nullable_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double?)x.Long);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Long', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$Long' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Long_to_nullable_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int?)x.Long);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Long', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$Long' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_Long_to_nullable_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long?)x.Long);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$Long', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$Long', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1L);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDecimal_to_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal)x.NullableDecimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { NullableDecimal : '$NullableDecimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$NullableDecimal', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDecimal_to_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double)x.NullableDecimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$NullableDecimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$NullableDecimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDecimal_to_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int)x.NullableDecimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$NullableDecimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$NullableDecimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDecimal_to_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long)x.NullableDecimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableDecimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$NullableDecimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDecimal_to_nullable_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal?)x.NullableDecimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { NullableDecimal: '$NullableDecimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$NullableDecimal', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDecimal_to_nullable_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double?)x.NullableDecimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableDecimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$NullableDecimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDecimal_to_nullable_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int?)x.NullableDecimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableDecimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$NullableDecimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDecimal_to_nullable_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long?)x.NullableDecimal);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableDecimal', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$NullableDecimal' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDouble_to_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal)x.NullableDouble);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$NullableDouble', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$NullableDouble' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDouble_to_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double)x.NullableDouble);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { NullableDouble : '$NullableDouble', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$NullableDouble', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDouble_to_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int)x.NullableDouble);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$NullableDouble', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$NullableDouble' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDouble_to_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long)x.NullableDouble);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableDouble', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$NullableDouble' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDouble_to_nullable_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal?)x.NullableDouble);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableDouble', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$NullableDouble' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDouble_to_nullable_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double?)x.NullableDouble);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { NullableDouble: '$NullableDouble', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$NullableDouble', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDouble_to_nullable_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int?)x.NullableDouble);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableDouble', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$NullableDouble' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableDouble_to_nullable_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long?)x.NullableDouble);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableDouble', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$NullableDouble' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableInt_to_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal)x.NullableInt);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$NullableInt', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$NullableInt' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableInt_to_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double)x.NullableInt);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$NullableInt', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$NullableInt' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableInt_to_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int)x.NullableInt);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { NullableInt : '$NullableInt', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$NullableInt', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableInt_to_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long)x.NullableInt);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableInt', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$NullableInt' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableInt_to_nullable_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal?)x.NullableInt);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableInt', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$NullableInt' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableInt_to_nullable_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double?)x.NullableInt);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableInt', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$NullableInt' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableInt_to_nullable_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int?)x.NullableInt);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { NullableInt: '$NullableInt', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$NullableInt', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableInt_to_nullable_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long?)x.NullableInt);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableInt', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toLong : '$NullableInt' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableLong_to_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal)x.NullableLong);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$NullableLong', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$NullableLong' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableLong_to_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double)x.NullableLong);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$NullableLong', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$NullableLong' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableLong_to_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int)x.NullableLong);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0 : '$NullableLong', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$NullableLong' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableLong_to_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long)x.NullableLong);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { NullableLong: '$NullableLong', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$NullableLong', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableLong_to_nullable_decimal_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (decimal?)x.NullableLong);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableLong', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDecimal : '$NullableLong' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0M);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableLong_to_nullable_double_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (double?)x.NullableLong);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableLong', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toDouble : '$NullableLong' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1.0);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableLong_to_nullable_int_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            RequireServer.Check().Supports(Feature.ToConversionOperators);
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (int?)x.NullableLong);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { __fld0: '$NullableLong', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : { $toInt : '$NullableLong' }, _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        [Theory]
        [ParameterAttributeData]
        public void Cast_NullableLong_to_nullable_long_should_work(
            [Values(LinqProvider.V2, LinqProvider.V3)] LinqProvider linqProvider)
        {
            var collection = GetCollection(linqProvider);

            var queryable = collection.AsQueryable()
                .Select(x => (long?)x.NullableLong);

            var stages = Translate(collection, queryable);
            if (linqProvider == LinqProvider.V2)
            {
                AssertStages(stages, "{ $project : { NullableLong: '$NullableLong', _id : 0 } }");
            }
            else
            {
                AssertStages(stages, "{ $project : { _v : '$NullableLong', _id : 0 } }");
            }

            var result = queryable.First();
            result.Should().Be(1);
        }

        private IMongoCollection<C> GetCollection(LinqProvider linqProvider)
        {
            var collection = GetCollection<C>("test", linqProvider);
            CreateCollection(
                collection,
                new C
                {
                    Id = 1,
                    Decimal = 1.0M,
                    Double = 1.0,
                    Int = 1,
                    Long = 1L,
                    NullableDecimal = 1.0M,
                    NullableDouble = 1.0,
                    NullableInt = 1,
                    NullableLong = 1L
                });
            return collection;
        }

        private class C
        {
            public int Id { get; set; }
            [BsonRepresentation(BsonType.Decimal128)] public decimal Decimal { get; set; }
            public double Double { get; set; }
            public int Int { get; set; }
            public long Long { get; set; }
            [BsonRepresentation(BsonType.Decimal128)] public decimal? NullableDecimal { get; set; }
            public double? NullableDouble { get; set; }
            public int? NullableInt { get; set; }
            public long? NullableLong { get; set; }
        }
    }
}
