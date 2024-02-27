namespace PhoneBookConsole.Models
{
    class Contact
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; }
        public string Number { get; set; }
        private static int nextId = 1;

        public Contact(string Name,string phoneNumber)
        {
            Id = nextId++;
            this.Name = Name;
            Number = phoneNumber;
        }
    }
}
