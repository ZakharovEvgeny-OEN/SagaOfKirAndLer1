namespace SagaOfKirAndLer.Model
{
    public class Choice
    {
        public int Id { get; set; }
        public int SceneId { get; set; }
        public string Text { get; set; }
        public int NextSceneId { get; set; }

        public Scene Scene { get; set; }
    }
}
