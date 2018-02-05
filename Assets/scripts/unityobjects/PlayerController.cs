using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

    private const double ERROR_RATE = 0.3;

    private readonly Vector3 START_POS = new Vector3(0f, 0.75f, 0f);
    private const float speed = 10f;
    private const float TIME_LIMIT = 2f;


    public int Points {
        get {
            return (int) (this.points + (this.points * ERROR_RATE * (Config.SENSOR_LIMIT - (this.error / this.measurements))));
        }
    }

    private double points;
    private double error;
    private int measurements;

    public int ID { set; get; }
    public NeuralNetwork NeuralNetwork { set; get; }
    public SensorController Sensor { set; get; }
    public Action OnDead;

    private Rigidbody rb;
    private bool dead;
    private float time;

    private Vector3 lastDir;
    public Vector3 Dir {
        get {
            Vector3 v = rb.velocity;
            if (v.x != 0 || v.z != 0)
                this.lastDir = v;
            return this.lastDir.normalized;
        }
    }

    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        if (dead)
            return;
        
        if (Config.NEURAL_NETWORK_LEARNING)
        {
            this.NeuralControl();
            if (Time.time - this.time > TIME_LIMIT)
                Dead();
        }
        else
        {
            this.ReadInputFromUser();
        }
    }

    public void Right(float rate = 1) {
        rb.AddForce (VectorUtils.RotateToForward(Vector3.right, Dir) * speed * rate);
    }

    public void Forward(float rate = 1) {
        rb.AddForce (VectorUtils.RotateToForward(Vector3.forward, Dir) * speed * rate);
    }

    public void CheckpointDone() {
        this.points++;
        this.time = Time.time;
    }

    public void Dead() {
        if (dead)
            return;
        this.dead = true;
        this.NeuralNetwork.Points = Points;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        if (this.OnDead != null)
            this.OnDead();
    }

    public void Reset() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = START_POS;
        transform.rotation = Quaternion.identity;
        lastDir = Vector3.forward;
        Sensor.UpdateInputs();
        this.points = 0;
        this.error = 0;
        this.measurements = 0;
        this.dead = false;
        this.time = Time.time;
    }

    private void ReadInputFromUser() {
        if (Input.GetKey(KeyCode.UpArrow))
            Forward();

        if (Input.GetKey(KeyCode.DownArrow))
            Forward(-1f);

        if (Input.GetKey(KeyCode.RightArrow))
            Right();

        if (Input.GetKey(KeyCode.LeftArrow))
            Right(-1f);
    }

    private void NeuralControl() {
        if (this.points < 80)
        {
            this.error += Math.Abs(Sensor.Inputs[0] - Sensor.Inputs[8]);
            this.measurements++;
        }

        int length = Sensor.Inputs.Length + 1;
        double[] inputs = new double[length];
        for (int i = 0; i < length - 1; ++i)
        {
            inputs[i] = Sensor.Inputs[i];
        }

        double v = (double) rb.velocity.magnitude;

        inputs[length - 1] = v < 0.01 ? 0 : v;

        double[] outputs = NeuralNetwork.Response(inputs);
        Right((float) outputs[0]);
        Forward((float) outputs[1]);
    }

}
