// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore.Test.Utilities;
using Microsoft.EntityFrameworkCore.Internal;

namespace Microsoft.AspNetCore.Identity.EntityFrameworkCore.Test
{
    public class ScratchDatabaseFixture : IDisposable
    {
        private readonly Lazy<SqlServerTestStore> _testStore;

        public ScratchDatabaseFixture()
        {
            _testStore = new Lazy<SqlServerTestStore>(() => SqlServerTestStore.CreateScratch());
        }

        public string ConnectionString => _testStore.Value.Connection.ConnectionString;

        public void Dispose()
        {
             if (_testStore.IsValueCreated)
            {
                _testStore.Value.Dispose();
            }
        }
    }
}
