import streamlink


def handleVideoLink(streamURL):
    print("handleVideoLink start:")
    print(streamURL)
    streams = streamlink.streams(streamURL)
    print(streams)
    beststream = streams["best"]
    print("Working with beststream " + beststream.url)
    fd = beststream.open()
    videodata = fd.read(1024)
    print(videodata)
