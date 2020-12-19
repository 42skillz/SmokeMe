﻿using System;

namespace Smoke
{
    /// <summary>
    /// Result of a <see cref="ITestWithSmoke"/> execution but with its <see cref="Duration"/>.
    /// </summary>
    public class StopWatchedSmokeTestExecution
    {
        /// <summary>
        /// Indicates whether the outcome of this <see cref="ITestWithSmoke"/> execution is positive or not.
        /// </summary>
        public bool Outcome => SmokeTestResult.Outcome;
        
        /// <summary>
        /// Gets the <see cref="Error"/> associated to this <see cref="ITestWithSmoke"/> execution.
        /// </summary>
        public Error ErrorMessage => SmokeTestResult.ErrorMessage;

        /// <summary>
        /// Gets the duration of this <see cref="ITestWithSmoke"/> execution.
        /// </summary>
        public TimeSpan Duration { get; }

        private SmokeTestResult SmokeTestResult { get; }
        
        /// <summary>
        /// Instantiates a <see cref="StopWatchedSmokeTestExecution"/>.
        /// </summary>
        /// <param name="smokeTestResult">The <see cref="SmokeTestResult"/> associated with this <see cref="ITestWithSmoke"/> execution.</param>
        /// <param name="duration">The duration of this <see cref="ITestWithSmoke"/> execution.</param>
        public StopWatchedSmokeTestExecution(SmokeTestResult smokeTestResult, TimeSpan duration)
        {
            SmokeTestResult = smokeTestResult;
            Duration = duration;
        }

        /// <summary>
        /// Returns a string representing the object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Outcome:{SmokeTestResult.Outcome}({Duration.TotalMilliseconds} msec)";
        }
    }
}