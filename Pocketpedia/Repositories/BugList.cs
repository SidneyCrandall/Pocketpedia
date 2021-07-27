namespace Pocketpedia.Repositories
{
    internal class BugList
    {
        private object id;
        private object name;
        private object location;
        private object season;
        private object image_url;

        public BugList(object id, object name, object location, object season, object image_url)
        {
            this.id = id;
            this.name = name;
            this.location = location;
            this.season = season;
            this.image_url = image_url;
        }
    }
}