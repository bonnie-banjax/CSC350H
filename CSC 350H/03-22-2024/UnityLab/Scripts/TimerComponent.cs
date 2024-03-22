using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerComponent : ScriptableObject
{
    
    
    float counter_01;
    bool isRunning;
    float interval_01;
    float threshold_01;
    int mode; // 0 = down ; 1 = up;

    /*
    public struct timerSettings {
        float counter_01;
        bool isRunning;
        float interval_01;
        float threshold_01;
        int mode; // 0 = down ; 1 = up;
    }
    */


    public void boot(float interval_val = 1, float threshold = 1, int mode = 0)
    {
        isRunning = false;
        counter_01 = 0;
        set_interval(interval_val);
        set_threshold(threshold);
        setMode(mode);
    }

    public void start_timer()
    { isRunning = true; }
    public void stop_timer()
    { isRunning = false; }
    public void reset_timer()
    { counter_01  = 0; }

    public void set_interval(float interval)
    { 
        interval_01 = interval;
        if (interval_01 < 0) interval_01 = 1;
    }
    public void set_threshold(float threshold)
    {  
        threshold_01 = threshold;
        if (threshold <= 0) threshold_01 = 1;
    }
    public void setMode(int input_mode)
    {
        switch (input_mode)
        {
            case 0:
                mode = input_mode; break;
            case 1:
                mode = input_mode; break;
            default:
                mode = 0; break;
        } // END_SWITCH

    } // END_FUNC

    public float getTime()
    { return counter_01; }

    public bool Tick()
    {
        float interval = interval_01;
        if (!isRunning)
            return false;

        switch (mode)
        {
            case 0: counter_01 += interval; break;
            case 1: counter_01 -= interval; break;
        } // END_SWITCH

        switch (mode) 
        { 
            case 0:
                if (counter_01 >= threshold_01)
                    return true;
                else return false;
            case 1:
                if (counter_01 <= threshold_01)
                    return true;
                else return false;
            default:
                return false;
        } // END_SWITCH
    }

    public bool Tock()
    {
        float interval = interval_01;
        if (!isRunning)
            return false;

        switch (mode)
        {
            case 0: counter_01 += interval; break;
            case 1: counter_01 -= interval; break;
        } // END_SWITCH

        switch (mode)
        {
            case 0:
                if (counter_01 >= threshold_01)
                {
                    isRunning = false;
                    return true;
                }   
                else return false;
            case 1:
                if (counter_01 <= threshold_01)
                {
                    isRunning = false;
                    return true;
                }
                else return false;
            default:
                return false;
        } // END_SWITCH
    }



}

