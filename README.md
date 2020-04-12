# valorantcv
In addition to the (unreleased API), I was hoping to also get critical information from certain gameplay elements in the UI.
* Will need some pro players to source relevant time series data from

Once we can identify these elements, we will be able to attach them to a corresponding time, creating a time series data set.
Long term, I will hopefully be able to congregate match data to create relevant player analytics (ability timings, spike plants, nade positions, etc)

The idea is to be able to be able to build this around elements we will not be able to see in the API, along with being able to parse tournament UIs and information as well.

Previous similar work at Microsoft Research. 
HMU https://www.linkedin.com/in/willnguyen18/

# Completed
* Canny Test Images Up and Running
* Template Matching Test for Template Image Complete

# RoadMap:
1. Canny Image Matching With Threshold Score
*Refactoring to Programmatic format to handle processing of sequential frames
*Threshold Evaluation Method (probably a ROC curve with a series of test images?)
*Need to map out architecture visually before I proceed so it works effectively for different templates
2. Time Series Data
*Creating Processing Logic for entire Folder
*Creating a class to stitch individual images in a folder into a sequence
*Storing that data in JSON format
3. Switch to SIFT for Symbol Matching
4. Refactoring to decouple frame parsing, image identification, and template provision
*A lot of parameters currently that need to be passed around. Could put them all into a class with class instances
5. Parsing Nade/Ability Direction and method
* Current Thought: parse for when ability is used, look at map and screen angle. Unsure if we can figure out payoff (landing). Would need to parse at much higher rate (30 FPS?)

6. Incorporating Stream and Youtube Video Parsing
7. Data Warehousing