using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {




    double speed =0;
    double firepower=0;
    double endurance=0;
    double luck=0;
    double charisma=0;
    double weight=0;
    double maneuver=0;
    double morale=0;

    public Stats(double speed, double firepower, double endurance, double luck, double charisma, double weight, double maneuver, double morale)
    {
        this.speed = speed;
        this.firepower = firepower;
        this.endurance = endurance;
        this.luck = luck;
        this.charisma = charisma;
        this.weight = weight;
        this.maneuver = maneuver;
        this.morale = morale;
    }


    public Stats(List<double> stats) {
        speed = stats[0];
        firepower = stats[1];
        endurance = stats[2];
        luck = stats[3];
        charisma = stats[4];
        weight = stats[5];
        maneuver = stats[6];
        morale = stats[7];
    }

    public List<double> GetList() {
        return new List<double>() { speed,firepower,endurance,luck,charisma,weight,maneuver,morale};

    }

    public double Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public double Firepower
    {
        get
        {
            return firepower;
        }

        set
        {
            firepower = value;
        }
    }

    public double Endurance
    {
        get
        {
            return endurance;
        }

        set
        {
            endurance = value;
        }
    }

    public double Luck
    {
        get
        {
            return luck;
        }

        set
        {
            luck = value;
        }
    }

    public double Charisma
    {
        get
        {
            return charisma;
        }

        set
        {
            charisma = value;
        }
    }

    public double Weight
    {
        get
        {
            return weight;
        }

        set
        {
            weight = value;
        }
    }

    public double Maneuver
    {
        get
        {
            return maneuver;
        }

        set
        {
            maneuver = value;
        }
    }

    public double Morale
    {
        get
        {
            return morale;
        }

        set
        {
            morale = value;
        }
    }

    public static Stats operator +(Stats add, Stats toAdd)
    {

        Stats stats = new Stats(0, 0, 0, 0, 0, 0, 0, 0);
        if (add != null && toAdd != null) { 
            stats.speed =
                toAdd.speed +
                add.speed;
            stats.firepower = toAdd.firepower + add.firepower;
            stats.endurance = toAdd.endurance + add.endurance;
            stats.luck = toAdd.luck + add.luck;
            stats.charisma = toAdd.charisma + add.charisma;
            stats.weight = toAdd.weight + add.weight;
            stats.maneuver = toAdd.maneuver + add.maneuver;
            stats.morale = toAdd.morale + add.morale;
            return stats;
        }
        if (add != null)
            return add;
        
        if (toAdd != null)
            return toAdd;

        return stats;
    }

    public void addStats(Stats toAdd) {
        speed += toAdd.speed;
        firepower += toAdd.firepower;
        endurance += toAdd.endurance;
        luck += toAdd.luck;
        charisma += toAdd.charisma;
        weight += toAdd.weight;
        maneuver += toAdd.maneuver;
        morale += toAdd.morale;
    }
}
