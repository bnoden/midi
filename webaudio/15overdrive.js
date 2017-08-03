var audioContext = new AudioContext()
var startTime = audioContext.currentTime + 0.2

// Add a basic global overdrive effect by turning the gain up to 20
// and clipping the signal at +/- 1.
var shaper = audioContext.createWaveShaper()
shaper.curve = new Float32Array([-1, 1])

var amp = audioContext.createGain()
amp.gain.value = 20
amp.connect(shaper)
shaper.connect(audioContext.destination)
// ^^^^^^^^^^^^^^^^^

getSample('guitar.wav', function play (buffer) {
  var player = audioContext.createBufferSource()
  player.buffer = buffer

  // Conect to amp for overdrive effect
  player.connect(amp)
  
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
