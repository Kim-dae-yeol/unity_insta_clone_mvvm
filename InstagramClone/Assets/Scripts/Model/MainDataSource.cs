using UniRx;

namespace Model
{
    public class MainDataSource
    {
        public IReadOnlyReactiveProperty<int> Posts;
        public IReadOnlyReactiveProperty<int> Follower;
        public IReadOnlyReactiveProperty<int> Following;
        public IReadOnlyReactiveProperty<string> Id;
        public IReadOnlyReactiveProperty<string> PhotoUrl;
        public IReadOnlyReactiveProperty<string> Name;
        public IReadOnlyReactiveCollection<PersonWhoShouldKnow> PeopleWhoShouldKnow;
        public IReadOnlyReactiveCollection<StoryHighlight> StoryHighlights;

        public MainDataSource(IReadOnlyReactiveProperty<int> posts,
            IReadOnlyReactiveProperty<int> follower,
            IReadOnlyReactiveProperty<int> following,
            IReadOnlyReactiveProperty<string> id,
            IReadOnlyReactiveProperty<string> photoUrl,
            IReadOnlyReactiveProperty<string> name)
        {
            Posts = posts;
            Follower = follower;
            Following = following;
            Id = id;
            PhotoUrl = photoUrl;
            Name = name;
        }
    }
}