const SAMPLE_RATE = 44100
var audioContext = new AudioContext()
var startTime = audioContext.currentTime + 0.2

var shaper = audioContext.createWaveShaper()
shaper.curve = generateCurve(SAMPLE_RATE/2)

// Improve the distortion effect by adding a soft clipping curve and insert a
// bandpass of 1000 Hz before clipping.
var bandpass = audioContext.createBiquadFilter()
bandpass.type = 'bandpass'
bandpass.frequency.value = 1000
bandpass.connect(shaper)

function generateCurve(steps) {
  var curve = new Float32Array(steps)
  var deg = Math.PI/180
  
  for (let i = 0; i < steps; i++) {
    let x = i*2/steps-1
    curve[i] = (3+10)*x*20*deg/(Math.PI+10*Math.abs(x))
  }
  
  return curve
}
// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


var amp = audioContext.createGain()
amp.gain.value = 20

// Connect to bandpass for soft clipping
amp.connect(bandpass)


shaper.connect(audioContext.destination)

getSample('guitar.wav', function play (buffer) {
  var player = audioContext.createBufferSource()
  player.buffer = buffer
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
