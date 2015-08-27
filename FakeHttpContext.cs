using System.Web;

namespace Sample.Tests
{
    class FakeHttpContext
    {
        public static HttpContext HttpContext
        {
            get
            {
                var httpRequest = new HttpRequest("", "http://localhost:52713/CA/EN/", "");
                var stringWriter = new System.IO.StringWriter();
                var httpResponse = new HttpResponse(stringWriter);
                var httpContext = new HttpContext(httpRequest, httpResponse);

                var sessionContainer = new System.Web.SessionState.HttpSessionStateContainer(
                    "id", new System.Web.SessionState.SessionStateItemCollection(), new HttpStaticObjectsCollection(), 10, true, HttpCookieMode.AutoDetect,
                    System.Web.SessionState.SessionStateMode.InProc, false);

                httpContext.Items["AspSession"] = typeof(System.Web.SessionState.HttpSessionState).GetConstructor(
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null, System.Reflection.CallingConventions.Standard,
                    new[] { typeof(System.Web.SessionState.HttpSessionStateContainer) }, null)
                    .Invoke(new object[] { sessionContainer });

                return httpContext;
            }
        }
    }
}
