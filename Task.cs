public enum Status { leftToDo, Done, Archived };
public abstract class Task
{
    private int id;
    private string name;
    private Status status;

    //Constructor
    public Task (int id, string name, Status status) {
        this.id = id;
        this.name = name;
        this.status = status;
    }

     //Get and set methods
    public int getId() { return this.id; }

	public void setId(int id) { this.id = id; }
    public string getName() { return this.name; }
    public void setName(string name) { this.name = name; }
    
    public Status getStatus() { return this.status; }
    public void setStatus(Status status) { this.status = status; }
}