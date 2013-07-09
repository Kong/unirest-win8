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
    public class HttpResponseTests
    {
        [TestMethod]
        public void HttpResponse_Should_Construct()
        {
            Action stringResponse = () => new HttpResponse<string>(new HttpResponseMessage { Content = new StringContent("test") });
            Action streamResponse = () => new HttpResponse<Stream>(new HttpResponseMessage { Content = new StreamContent(new MemoryStream())});
            Action objectResponse = () => new HttpResponse<int>(new HttpResponseMessage { Content = new StringContent("1")});

            stringResponse.ShouldNotThrow();
            streamResponse.ShouldNotThrow();
            objectResponse.ShouldNotThrow();
        }
    }
}
