using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float gravityForce = 4;

    private Boost[] rightBoosters;
    private Boost[] leftBoosters;
    private Boost propulser;
    private string rotation = null;

    // Start is called before the first frame update
    void Start()
    {
        List<Boost> boosters = GameObject.FindObjectsOfType<Boost>().ToList();

        propulser = boosters.Single(x => x.tag == "propulser");
        leftBoosters = boosters.Where(x => x.tag == "booster_left").ToArray();
        rightBoosters = boosters.Where(x => x.tag == "booster_right").ToArray();

        Physics.gravity = Vector3.down * gravityForce;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = Vector3.down * gravityForce;

        ProcessBoost();
        ProcessRotation();
    }

    void ProcessBoost()
    {
        if (Input.GetKey(KeyCode.Space)) propulser.Fire();
    }

    void ProcessRotation()
    {
        Boost[] boosters = null;
        bool kick = Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D);

        if (Input.GetKey(KeyCode.Q)) boosters = leftBoosters;
        else if (Input.GetKey(KeyCode.D)) boosters = rightBoosters;

        if (boosters == null) return;
        foreach (Boost booster in boosters)
        {
            if (kick) booster.Kick();
            else booster.Fire();
        }
    }
}
