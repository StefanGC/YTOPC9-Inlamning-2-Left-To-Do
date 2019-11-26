public class TaskType1 : Task
{
    private bool isChecked;

    //Constructor
    public TaskType1 (int id, string name, Status status, bool isChecked) : base (id, name, status) {
        this.isChecked = isChecked;
    }

     //Get and set methods
    public bool getIsChecked() { return this.isChecked; }
    public void isIsChecked(bool isChecked) { this.isChecked = isChecked; }

}