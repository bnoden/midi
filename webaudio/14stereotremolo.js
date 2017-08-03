var audioContext = new AudioContext()

// Add a global effect so that the audio output has a 'sine' shaped
// stereo tremolo (panning between left and right speakers) at a rate of 2 Hz
var panner = audioContext.createStereoPanner()
panner.connect(audioContext.destination)

var lfo = audioContext.createOscillator()
lfo.connect(panner.pan)
lfo.type = 'sine'
lfo.frequency.value = 2
lfo.start(audioContext.currentTime)
// ^^^^^^^^^^^^^^^^^

play(0, -7, 2.25)
play(0, 5, 2.25)
play(0, 0, 2.25)

function play (delay, pitch, duration) {
  var time = audioContext.currentTime + delay

  var oscillator = audioContext.createOscillator()

  // Connect to StereoPannerNode
  oscillator.connect(panner)

  oscillator.type = 'triangle'
  oscillator.detune.value = pitch * 100

  oscillator.start(time)
  oscillator.stop(time + duration)
}
