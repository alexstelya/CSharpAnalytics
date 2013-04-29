﻿using System;
using System.Collections.Generic;
using CSharpAnalytics.Protocols.Measurement;
#if WINDOWS_STORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace CSharpAnalytics.Test.Protocols.Measurement
{
    [TestClass]
    public class MeasurementActivityExtensionTests
    {
        private List<Uri> SimpleCatchingClient()
        {
            var list = new List<Uri>();
            var client = new MeasurementAnalyticsClient();
            client.Configure(TestHelpers.MeasurementConfiguration, TestHelpers.CreateSessionManager(), new Environment("en-us"), list.Add);
            return list;
        }

        [TestMethod]
        public void AppViewExtension_Tracks_AppView()
        {

            client.TrackAppView("SomeScreenName");

            Assert.AreEqual(1, list.Count);
            StringAssert.Contains(list[0].OriginalString, "t=appview");
        }

#if WINDOWS_STORE
        [TestMethod]
        public void AppViewExtension_Throws_If_AnalyticsClient_Null()
        {
            Assert.ThrowsException<ArgumentException>(() => AppViewExtensions.TrackAppView(null, "test"));
        }

        [TestMethod]
        public void AppViewExtension_Throws_If_ScreenName_Null()
        {
            Assert.ThrowsException<ArgumentException>(() => new MeasurementAnalyticsClient().TrackAppView(null));
        }

        [TestMethod]
        public void AppViewExtension_Throws_If_ScreenName_Blank()
        {
            Assert.ThrowsException<ArgumentException>(() => new MeasurementAnalyticsClient().TrackAppView(""));
        }
#endif

#if NET45
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AppViewExtension_Throws_If_AnalyticsClient_Null()
        {
            AppViewExtensions.TrackAppView(null, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AppViewExtension_Throws_If_ScreenName_Null()
        {
            new MeasurementAnalyticsClient().TrackAppView(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AppViewExtension_Throws_If_ScreenName_Blank()
        {
            new MeasurementAnalyticsClient().TrackAppView("");
        }
#endif
    }
}