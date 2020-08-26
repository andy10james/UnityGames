using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    private State currentState;

    private string defaultText;

    public Text Text;

    // Use this for initialization
    private void Start () {
        this.currentState = State.cell;
    }

    // Update is called once per frame
    private void Update () {
        if      (this.currentState == State.cell)           this.cell();
        else if (this.currentState == State.sheets_0)       this.sheets_0();
        else if (this.currentState == State.lock_0)         this.lock_0();
        else if (this.currentState == State.mirror)         this.mirror();
        else if (this.currentState == State.cell_mirror)    this.cell_mirror();
        else if (this.currentState == State.sheets_1)       this.sheets_1();
        else if (this.currentState == State.lock_1)         this.lock_1();
        else if (this.currentState == State.corridor_0)     this.corridor_0();
        else if (this.currentState == State.corridor_1)     this.corridor_1();
        else if (this.currentState == State.corridor_2)     this.corridor_2();
        else if (this.currentState == State.corridor_3)     this.corridor_3();
        else if (this.currentState == State.stairs_0)       this.stairs_0();
        else if (this.currentState == State.stairs_1)       this.stairs_1();
        else if (this.currentState == State.stairs_2)       this.stairs_2();
        else if (this.currentState == State.stairs_3)       this.stairs_3();
        else if (this.currentState == State.closet_door)    this.closet_door();
        else if (this.currentState == State.in_closet)      this.in_closet();
        else if (this.currentState == State.courtyard)      this.courtyard();
    }

    private void cell () {
        this.Text.text = 
            "You've been arrested for feeding Mars bars to Teemo - the little devil. "
            + "You need to make your escape, you see your bed sheets, a mirror and notice "
            + "the lock on the cell doors. \n\n"
            + "What do you do?\n\n"
            + "[S]\tLook at the Sheets\n"
            + "[M]\tLook at the Mirror\n"
            + "[L]\tLook at the Lock";
        if      (Input.GetKeyDown(KeyCode.S))   this.currentState = State.sheets_0;
        else if (Input.GetKeyDown(KeyCode.M))   this.currentState = State.mirror;
        else if (Input.GetKeyDown(KeyCode.L))   this.currentState = State.lock_0;
    }

    private void sheets_0 () {
        this.Text.text =
            "You don't want to sleep in these, they clearly haven't been washed, and Miss Fortune isn't here!\n"
            + "However, you may have to if you don't get out of here quickly!\n\n"
            + "What do you do?\n\n"
            + "[R]\tReturn\n";
        if      (Input.GetKeyDown(KeyCode.R))   this.currentState = State.cell;
    }

    private void lock_0 () {
        this.Text.text =
            "It's a pretty simple lock, you could try to find something to shimmy it, or call Sion!\n\n"
            + "What do you do?\n\n"
            + "[R]\tReturn\n";
        if      (Input.GetKeyDown(KeyCode.R))    this.currentState = State.cell;
    }

    private void mirror() {
        this.Text.text =
            "You notice the mirror is concaved, and move your fingers to the opening on the side. You find a key!\n\n"
            + "What do you do?\n\n"
            + "[R]\tReturn\n";
        if      (Input.GetKeyDown(KeyCode.R))    this.currentState = State.cell_mirror;
    }

    private void cell_mirror() {
        this.Text.text = "You need to make your escape, you still see your bed sheets, and "
                         + "the lock on the cell doors. \n\n"
                         + "What do you do?\n\n"
                         + "[S]\tLook at the Sheets\n"
                         + "[L]\tLook at the Lock";
        if      (Input.GetKeyDown(KeyCode.S))   this.currentState = State.sheets_1;
        else if (Input.GetKeyDown(KeyCode.L))   this.currentState = State.lock_1;
    }

    private void sheets_1() {
        this.Text.text =
            "You let a little tear fall past your cheek as images of Miss Fortune fill your mind... and other areas.\n\n"
            + "What do you do?\n\n"
            + "[R]\tReturn\n";
        if      (Input.GetKeyDown(KeyCode.R))   this.currentState = State.cell_mirror;
    }

    private void lock_1() {
        this.Text.text =
            "It's a pretty simple lock, you could try to shimmy it, or call Sion!\n\n"
            + "What do you do?\n\n"
            + "[O]\tOpen with the Key\n"
            + "[R]\tReturn\n";
        if      (Input.GetKeyDown(KeyCode.O))   this.currentState = State.corridor_0;
        else if (Input.GetKeyDown(KeyCode.R))   this.currentState = State.cell_mirror;
    }

    private void corridor_0() {
        this.Text.text =
            "You're free from the cell! You now find yourself in the corridor. There's a nearby closet, and some stairs.\n\n"
            + "What do you do?\n\n"
            + "[F]\tScour the floor\n"
            + "[S]\tWalk up the stairs\n"
            + "[C]\tInspect the closet\n";
        if      (Input.GetKeyDown(KeyCode.F))   this.currentState = State.corridor_1;
        if      (Input.GetKeyDown(KeyCode.S))   this.currentState = State.stairs_0;
        if      (Input.GetKeyDown(KeyCode.C))   this.currentState = State.closet_door;
    }

    private void stairs_0() {
        this.Text.text =
            "You see Garen at the top of the stairs, you cannot proceed.\n\n"
            + "What do you do?\n\n"
            + "[F]\tScour the floor\n"
            + "[C]\tInspect the closet\n";
        if (Input.GetKeyDown(KeyCode.F)) this.currentState = State.corridor_1;
        if (Input.GetKeyDown(KeyCode.C)) this.currentState = State.closet_door;
    }

    private void closet_door() {
        this.Text.text =
            "The door is locked. Maybe you can pick the lock and find something useful inside!\n\n"
            + "What do you do?\n\n"
            + "[F]\tScour the floor\n"
            + "[S]\tWalk up the stairs\n";
        if (Input.GetKeyDown(KeyCode.F)) this.currentState = State.corridor_1;
        if (Input.GetKeyDown(KeyCode.S)) this.currentState = State.stairs_0;
    }

    private void corridor_1() {
        this.Text.text =
            "You found a hair clip! You may be able to make use of this.\n\n"
            + "What do you do?\n\n"
            + "[S]\tWalk up the stairs\n"
            + "[C]\tInspect the closet\n";
        if (Input.GetKeyDown(KeyCode.S)) this.currentState = State.stairs_1;
        if (Input.GetKeyDown(KeyCode.C)) this.currentState = State.in_closet;
    }

    private void stairs_1() {
        this.Text.text =
            "If you think you're going to take on Garen with a hair clip - think again.\n\n"
            + "What do you do?\n\n"
            + "[C]\tInspect the closet\n";
        if (Input.GetKeyDown(KeyCode.C)) this.currentState = State.in_closet;
    }

    private void in_closet() {
        this.Text.text =
            "You walk into the closet and find some clothes for a cleaner.\n\n"
            + "What do you do?\n\n"
            + "[W]\tPut them on and return to the corridor\n"
            + "[R]\tReturn to the corridor\n";
        if (Input.GetKeyDown(KeyCode.W)) this.currentState = State.corridor_3;
        if (Input.GetKeyDown(KeyCode.R)) this.currentState = State.corridor_2;
    }

    private void corridor_2() {
        this.Text.text =
            "You leave the closet without putting on the cleaning clothes, and find yourself back in the corridor..\n\n"
            + "What do you do?\n\n"
            + "[W]\tPut on the cleaner's clothes\n"
            + "[S]\tWalk up the stairs\n";
        if (Input.GetKeyDown(KeyCode.W)) this.currentState = State.stairs_3;
        if (Input.GetKeyDown(KeyCode.S)) this.currentState = State.stairs_2;
    }

    private void corridor_3() {
        this.Text.text =
            "You find yourself in the corridor wearing the cleaner's clothes.\n\n"
            + "What do you do?\n\n"
            + "[S]\tWalk up the stairs\n";
        if      (Input.GetKeyDown(KeyCode.S))   this.currentState = State.stairs_3;
    }

    private void stairs_2() {
        this.Text.text =
            "If you think you're going to take on Garen with a hair clip - think again.\n\n"
            + "What do you do?\n\n"
            + "[W]\tPut on the cleaner's clothes\n";
        if (Input.GetKeyDown(KeyCode.W)) this.currentState = State.corridor_3;
    }

    private void stairs_3() {
        this.Text.text =
            "You climb the stairs and walk past Garen without so much as a sweat. You move round the corner out of sight. There's a door and a window.\n\n"
            + "What do you do?\n\n"
            + "[C]\tClimb out the window\n"
            + "[D]\tWalk out the door\n";
        if      (Input.GetKeyDown(KeyCode.C))   this.currentState = State.courtyard;
        if      (Input.GetKeyDown(KeyCode.D))   this.currentState = State.courtyard;
    }

    private void courtyard() {
        this.Text.text =
            "You're free!\n"
            + "You immediately teleport back to the fountain and tell you're wife - Lux - your story.\n\n\n"
            + "[P]\tPlay again\n";
        if      (Input.GetKeyDown(KeyCode.P))   this.currentState = State.cell;
    }

    private enum State {

        cell,
        mirror,
        sheets_0,
        lock_0,
        cell_mirror,
        sheets_1,
        lock_1,
        corridor_0,
        corridor_1,
        corridor_2,
        corridor_3,
        stairs_0, 
        stairs_1,
        stairs_2,
        stairs_3,
        closet_door,
        in_closet,
        courtyard
    }

}