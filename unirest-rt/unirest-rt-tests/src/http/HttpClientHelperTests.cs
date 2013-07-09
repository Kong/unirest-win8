using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

//using NUnit;
//using NUnit.Framework;
using FluentAssertions;

using unirest_rt.http;
using unirest_rt.request;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace unirest_rt_tests.http
{
    [TestClass]
    public class HttpClientHelperTests
    {
        [TestMethod]
        public void HttpClientHelper_Should_Reqeust()
        {
            Action request = () => HttpClientHelper.Request<string>(new HttpRequest(HttpMethod.Get, "http://www.google.com"));
            request.ShouldNotThrow();
        }

        [TestMethod]
        public void HttpClientHelper_Should_Reqeust_Async()
        {
            Action request = () => HttpClientHelper.RequestAsync<string>(new HttpRequest(HttpMethod.Get, "http://www.google.com"));
            request.ShouldNotThrow();
        }

        [TestMethod]
        public void HttpClientHelper_Should_Reqeust_With_Fields()
        {
            Action request = () => HttpClientHelper.Request<string>(new HttpRequest(HttpMethod.Post, "http://www.google.com").field("test","value"));
            request.ShouldNotThrow();
        }

        [TestMethod]
        public void HttpClientHelper_Should_Reqeust_Async_With_Fields()
        {
            Action request = () => HttpClientHelper.RequestAsync<string>(new HttpRequest(HttpMethod.Post, "http://www.google.com").field("test", "value"));
            request.ShouldNotThrow();
        }
    }
}
