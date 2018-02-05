using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExtensionList;
using UnityEngine.UI;

public class Simulation : MonoBehaviour {


    public CameraController camera;
    public Text text;

    long generation;
    private int currentDeads;
    private GeneticAlgorithm geneticAlgorithm;
    private List<PlayerController> offsprings = new List<PlayerController>();
    private List<SensorController> sensors = new List<SensorController>();
    private CheckpointController[] checkpoints;
    private int bestEntireFitness;
    private int bestFitness;

    void Start() {

        this.geneticAlgorithm = Config.GENETIC_ALGORITHM;
        this.generation = 1;
        this.currentDeads = 0;

        for (int i = 0; i < Config.OFFSPRINGS_COUNT; ++i)
        {
            offsprings.Add(Instantiate((Resources.Load("Player", typeof(GameObject))) as GameObject).GetComponent<PlayerController>());
            offsprings[i].ID = i + 1;
            offsprings[i].NeuralNetwork = new NeuralNetwork(Config.TOPOLOGY);
            offsprings[i].OnDead += this.OnOffspringDead;

            sensors.Add(Instantiate((Resources.Load("Sensor", typeof(GameObject))) as GameObject).GetComponent<SensorController>());
            sensors[i].Player = offsprings[i];
            offsprings[i].Sensor = sensors[i];
            offsprings[i].Reset();

        }

        Physics.IgnoreLayerCollision(offsprings[0].gameObject.layer, offsprings[0].gameObject.layer, true);

        this.bestEntireFitness = 0;
        this.bestFitness = 0;
        this.checkpoints = Object.FindObjectsOfType<CheckpointController>();
        this.UpdateText();
     
    }

    void FixedUpdate() {
        this.UpdateCamera();

        if (Input.GetKeyDown(KeyCode.W))
            Time.timeScale *= 1.2f;

        if (Input.GetKeyDown(KeyCode.S))
            Time.timeScale = 1.0f;

        if (Input.GetKeyDown(KeyCode.Space))
            GenerateNextPopulation();

    }

    private void UpdateCamera() {
        int max = 0;
        int index = 0;

        for (int i = 0; i < offsprings.Count; ++i)
        {
            if (offsprings[i].Points > max)
            {
                max = offsprings[i].Points;
                index = i;
            }
        }

        camera.Player = offsprings[index].gameObject.transform;

    }

    private void OnOffspringDead() {
        if (++this.currentDeads >= Config.OFFSPRINGS_COUNT)
        {
            this.GenerateNextPopulation();
        }
    }

    private void GenerateNextPopulation() {
        List<NeuralNetwork> currentPopulation = new List<NeuralNetwork>(Config.OFFSPRINGS_COUNT);

        int fitness = 0;
        for (int i = 0; i < Config.OFFSPRINGS_COUNT; ++i)
        {
            currentPopulation.Add(offsprings[i].NeuralNetwork.Clone);
            fitness += currentPopulation[i].Points;

            if (currentPopulation[i].Points > this.bestFitness)
            {
                this.bestFitness = currentPopulation[i].Points;
            }
         
        }

        if (fitness > this.bestEntireFitness)
            this.bestEntireFitness = fitness;

        List<NeuralNetwork> newPopulation = this.geneticAlgorithm.NextPopulation(currentPopulation);

        foreach(CheckpointController c in this.checkpoints) {
            c.Reset();
        }

        for (int i = 0; i < Config.OFFSPRINGS_COUNT; ++i)
        {
            offsprings[i].NeuralNetwork = newPopulation[i];
            offsprings[i].Reset();
        }

        this.currentDeads = 0;
        this.generation++;
        this.UpdateText(fitness);
    }

    private void UpdateText(int lastFitness = 0) {
        text.text = "Generation: " + this.generation +'\n' + "Last entire fitness: " + lastFitness + '\n' + "Best entire fitness: " + this.bestEntireFitness + '\n' + "Best fitness " + this.bestFitness;

    }
	
}
