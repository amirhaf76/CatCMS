using CMS.Domain.ValueObjects;
using SharedKernel;

namespace CMS.Domain.Entities
{
    public class Post : Entity
    {

        private Post(PostId id, DateTime createdDate, DateTime modifiedDate)
        {
            Id = id;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            Content = string.Empty;
        }

        public static Post Create(PostId id)
        {
            var modifiedAndCreatedDate = DateTime.UtcNow;

            return Create(id, modifiedAndCreatedDate, modifiedAndCreatedDate);
        }
        public static Post Create(PostId id, DateTime createdDate)
        {
            var modifiedDate = createdDate;

            return Create(id, createdDate, modifiedDate);
        }
        public static Post Create(PostId id, DateTime createdDate, DateTime modifiedDate)
        {
            return new Post(id, createdDate, modifiedDate);
        }



        public PostId Id { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime ModifiedDate { get; private set; }

        public string Content { get; private set; }

        
        public void SetContentAndUpdateModifiedDate(string content)
        {
            Content = content;

            ModifiedDate = DateTime.UtcNow;
        }
    }

    
}
