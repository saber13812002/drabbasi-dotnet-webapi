namespace DACIS_api
{
    public interface IXml2json
    {
        string xml2json();
        void doRestCall(string url,string body);
    }
}