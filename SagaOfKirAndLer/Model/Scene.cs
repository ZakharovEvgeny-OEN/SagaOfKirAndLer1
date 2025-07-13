namespace SagaOfKirAndLer.Model
{
    public class Scene
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsEnding { get; set; }

        public string ImagePath { get; set; }
        
        public string BackgroundPath { get; set; }

        public List<Choice> Choices { get; set; }
    }
}
