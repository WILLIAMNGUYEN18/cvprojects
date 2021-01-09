# valorantcv
In addition to the (unreleased API), I was hoping to also get critical information from certain gameplay elements in the UI.

Once we can identify these elements, we will be able to attach them to a corresponding time, creating a time series data set.
Long term, I will hopefully be able to congregate match data to create relevant player analytics (ability timings, spike plants, nade positions, etc)

The idea is to be able to be able to build this around elements we will not be able to see in the API, along with being able to parse tournament UIs and information as well.

Notes are here:
https://docs.google.com/document/d/1553TyjZVNNKZpvamiKmBqrltt-rMkS2lH322ci06FG0/edit?usp=sharing

Previous similar work at Microsoft Research. 
HMU https://www.linkedin.com/in/willnguyen18/

# Completed


1. Canny Image Matching With Threshold Score

    *Canny Test Images Up and Running
    *Template Matching Test for Template Image Complete
    *Canny Threshold with Smooth Gaussian
    *Refactoring to Programmatic format to handle processing of sequential frames
    *Need to map out architecture visually before I proceed so it works effectively for different templates (https://www.lucidchart.com/invitations/accept/cd4f1794-b34f-4b84-86c2-33badcc54dec)

2. Time Series Data

    *Creating Processing Logic for entire Folder
    *Creating a class to stitch individual images in a folder into a sequence
    *Outputting basic frame information with spike detection in a json file
    *Basic timelinme visualization of when spike is active
    *Storing that data in JSON format
    *Basic visualization

# Current RoadMap:

3. Need context specifics on what's relevant to players. Need to reach around
   
    * Can additionally revise README to include images and be clearer
    * Can work on ability recognition in the meantime?
    * Let's also revise the spike recognition logic based on visualization

4. Switch to SIFT for Symbol Matching

    * new, better, and already a part of opencv

5. Refactoring to decouple classes (frame parsing, image identification, and template provision)

    * Logic Smoothing (exponential?)
    * A lot of parameters currently that need to be passed around. Could put them all into a class with class instances
    * Specialize searches with newtonjsoft so we can filter for elements we care about at the moment?
    * Threshold Evaluation Method (probably a ROC curve with a series of test images?)

6. Parsing Nade/Ability Direction and method
    
    * Current Thought: parse for when ability is used, look at map and screen angle. Unsure if we can figure out payoff (landing). Would need to parse at much higher rate (30 FPS?)
    * can atleast highlight the event in the vod and work from there

7. Incorporating Stream and Youtube Video Parsing

8. Data Warehousing

#Random Thoughts:
*Could add some sort of crowdsourcing method for templating/picking objects to identify?
*Allow users to choose which objects they want to recognize. This set of template classes will be looped through and run
*Potentially a method of parsing CSVs?