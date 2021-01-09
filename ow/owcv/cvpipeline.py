import sys
from videointake import handleVideoLink
#the main pipeline
#split into other methods

#take a link

#intake video

#process frames


#run analysis format
#broad for scene recognition
#narrow for relevant scene analytics

def main(streamURL):
    print("ow cvpipeline start streamURL: " + streamURL)
    handleVideoLink(streamURL)


if __name__ == "__main__":
    main(sys.argv[1])




