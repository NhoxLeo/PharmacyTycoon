﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ResourceStorage {
    public ResourcePanel rPanel;

    public int currentHealingPlants;
    public int currentChemistry;
    public int currentPlastic;
    public int ResearchPoints;
   
    [SerializeField] private int _maxHealingPlants;
    [SerializeField] private int _maxChemistry;
    [SerializeField] private int _maxPlastic;

    public int MaxHealingPlants
    { get { return _maxHealingPlants; } private set { _maxHealingPlants = value; } }
    public int MaxChemistry
    { get { return _maxChemistry; } private set { _maxChemistry = value; } }
    public int MaxPlastic
    { get { return _maxPlastic; } private set { _maxPlastic = value; } }

    
    
    public void ExpandPlantsStorage(int amount)
    {
        MaxHealingPlants += amount;
    }
    public void ExpandChemistryStorage(int amount)
    {
        MaxChemistry += amount;
    }
    public void ExpandPlasticStorage(int amount)
    {
        MaxPlastic += amount;
    }
    public void AddHealingPlants(int amount)
    {
       currentHealingPlants= AddResources(amount, currentHealingPlants, MaxHealingPlants);
    }
    public void AddResearchPoints(int amount)
    {
        ResearchPoints += amount;
    }
    public void AddChemistry(int amount)
    {
       currentChemistry= AddResources(amount, currentChemistry, MaxChemistry);
    }
    public void AddPlastic(int amount)
    {
        currentPlastic= AddResources(amount, currentPlastic, MaxPlastic);
    }
   
    public void SpendResources(int plants, int chem, int plastic, int researchPoints=0)
    {
        AddHealingPlants(-plants);
        AddChemistry(-chem);
        AddPlastic(-plastic);
        if (researchPoints != 0)
            AddResearchPoints(-researchPoints);
        rPanel.SetPanel(this);
        
    }
    private int AddResources(int amount,  int currentResource, int maxResource)
    {
        if (currentResource+amount<=maxResource)
        {
            currentResource += amount;
        }
        else if (currentResource + amount > MaxHealingPlants)
        {
            currentResource += maxResource - currentResource;
        }
        rPanel.SetPanel(this);
        return currentResource;
    }

}
