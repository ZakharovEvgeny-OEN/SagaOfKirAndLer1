namespace SagaOfKirAndLer.Model
{
    public class PlayerProgress
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }
        public int SaveSceneId { get; set; }
        public int magicKir { get; set; }
        public int magicLer { get; set; }
        public int strengthKir { get; set; }
        public int strengthLer { get; set; }
        public int intelligenceKir { get; set; }

        public int intelligenceLer { get; set; }
    }
}
