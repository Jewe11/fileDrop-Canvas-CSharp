using RestSharp;
using System;
using System.IO;
using System.Collections.Generic;
using RestSharp.Deserializers;
    namespace CSharpCanvas
{
    public class StartTest { 
        public void InitMethod()
        {
            //Basic RESTful pointer and the API call
            var http = new RestClient("https://canvas.instructure.com/api/v1/courses?access_token=<ACCESS-TOKEN>");
            var request = new RestRequest("https://canvas.instructure.com/api/v1/users/self/files",Method.POST);
            //additions to the API call restrictions/filters
            request.AddUrlSegment("?sort=content_type",1);
            //File and info to load
            const string fileName = "someTestfile.txt";
            var fileContent = File.ReadAllLines(fileName);
            request.AddFile(fileName, "/some/filepath/someTestfile.txt");
            //what actually wrote
            var daResponse = http.Execute(request);
            //test what wrote
            Console.Write($"whatChaSay:{daResponse.StatusCode}");
        }
    }

}