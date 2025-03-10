using System.Threading.Channels;

namespace Master
{
    public interface ProtocolMaster
    {
        public byte[] Read(byte[] bytes, string[] parametrs);

        public byte[] Read(byte[] bytes);

        public byte[] Read();

        public byte[] Write(byte[] bytes, string[] parametrs);

        public byte[] Write(byte[] bytes);

        public byte[] Write();

        public List<string> Informantion(byte[] bytes);
    }
}
