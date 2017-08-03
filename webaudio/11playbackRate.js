var audioContext = new AudioContext()
var startTime = audioContext.currentTime + 0.1

getSample('vox.wav', function play (buffer) {
  var player = audioContext.createBufferSource()
  player.buffer = buffer
  player.connect(audioContext.destination)
  
  // Change the sample pitch down 1 octave (halve the speed).
  player.playbackRate.value = 0.5
  
  player.start(startTime)
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
