using System;
public class TaskType2 : Task
{
    private DateTime date;

    //Constructor
    public TaskType2 (int id, string name, Status status, DateTime date) : base (id, name, status) {
        this.date = date;
    }

     //Get and set methods
    public DateTime getDate() { return this.date; }
    public void setDate(DateTime date) { this.date = date; }
}