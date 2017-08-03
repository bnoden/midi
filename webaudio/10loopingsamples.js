var audioContext = new AudioContext()
var startTime = audioContext.currentTime + 0.2

getSample('zara.wav', function play (buffer) {
  var player = audioContext.createBufferSource()
  player.buffer = buffer
  player.connect(audioContext.destination)
  
  // Play the sample from the beginning for 4 seconds,
  // then loop between 3 seconds and 4 seconds three times.
  player.loop = true
  player.loopStart = 3
  player.loopEnd = 4
  player.start(startTime, 0)
  player.stop(startTime+7)
})

function getSample (url, cb) {
  var request = new XMLHttpRequest()
  request.open('GET', url)
  request.responseType = 'arraybuffer'
  request.onload = function () {
    audioContext.decodeAudioData(request.response, cb)
  }
  request.send()
}
