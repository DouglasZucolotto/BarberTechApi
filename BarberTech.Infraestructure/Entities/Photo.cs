namespace BarberTech.Infraestructure.Entities
{
    public class Photo
    {
        public Guid Id { get; set; }

        public byte[] File { get; set; }

        public Photo(byte[] file)
        {
            File = file;
        }
    }
}
