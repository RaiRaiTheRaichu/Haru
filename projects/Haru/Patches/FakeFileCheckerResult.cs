﻿using System;
using FilesChecker;

namespace Haru.Patches
{
    public class FakeFileCheckerResult : ICheckResult
    {
        public TimeSpan ElapsedTime { get; private set; }
        public Exception Exception { get; private set; }

        public FakeFileCheckerResult()
        {
            ElapsedTime = new TimeSpan();
            Exception = null;
        }
    }
}