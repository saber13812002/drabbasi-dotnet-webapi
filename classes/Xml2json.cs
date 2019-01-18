using System.Xml;
using Newtonsoft.Json;
using RestSharp;

namespace DACIS_api.classes
{
    public class Xml2json : IXml2json
    {
        public RestSharp.IRestResponse res;

        public string url;
        public string body;

        public Xml2json (string url, string body)
        {
            this.url = url;
            this.body = body;
        }

        public string xml2json ()
        {
            doRestCall (this.url, this.body);
            XmlDocument doc2 = new XmlDocument ();
            doc2.LoadXml (this.res.Content);

            XmlNodeList xmlnode2 = doc2.GetElementsByTagName ("soap:Body");

            return JsonConvert.SerializeXmlNode (xmlnode2[0]);
        }

        public void doRestCall (string url, string body)
        {
            var client = new RestClient (url);
            var request = new RestRequest (Method.POST);
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer ();
            request.RequestFormat = DataFormat.Xml;

            request.AddHeader ("cache-control", "no-cache");
            request.AddHeader ("Content-Type", "text/xml");
            request.AddParameter ("undefined", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute (request);
            this.res = response;
        }
    }
}