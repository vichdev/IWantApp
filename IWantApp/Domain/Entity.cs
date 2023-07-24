using Flunt.Notifications;

namespace IWantApp.Domain;

public abstract class Entity : Notifiable<Notification>
{

    public Entity() { 

        Id = Guid.NewGuid();

    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string EditedBy { get; set; }
    public DateTime UpdatedDate { get; set;}
    public bool Active { get; set; } = true;
}


