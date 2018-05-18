using UnityEngine;

public class StatusManager : MonoBehaviour {
    public enum Status { Menu, CourseIndex, CourseCard, Learn, Stack };
    public static Status CurrentStatus { get; set; }
    
    void Start () {
        CurrentStatus = Status.Menu;		
	}
}
