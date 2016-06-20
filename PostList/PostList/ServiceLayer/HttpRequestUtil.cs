using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PostList
{
    public class HttpRequestUtil
    {

        public static HttpResponseMessage HttpClientRequest(string APIServer, string PostListURL)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage Response = null;
            client.BaseAddress = new Uri(APIServer);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constant.HTTP_CONTENT_TYPE_DEFAULT));
          
            try
            {
               Response = client.GetAsync(PostListURL).Result;
            }

            catch (Exception ex)
            {
              Response.ReasonPhrase = ex.Message;
            }
            finally
            {
                if (client != null)
                    client.Dispose();
            }

            return Response;
        
        }
    }

    
}
