namespace Hotel_App.Models.entities
{
    public abstract class BaseEntity
    {
        public int Id;
        public bool isDeleted;

        public BaseEntity(int id,bool isdeleted)
        {
            Id = id;
            isDeleted = isdeleted;
        }
    }
}