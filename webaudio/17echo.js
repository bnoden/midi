var audioContext = new AudioContext()

// Add a global effect so that the audio output has an echo with a delay
// time of 0.2 seconds and a feedback ratio of 0.6.
var input = audioContext.createGain()
var feedback = audioContext.createGain()
var delay = audioContext.createDelay()
var output = audioContext.createGain()
output.connect(audioContext.destination)

delay.delayTime.value = 0.2
feedback.gain.value = 0.6

input.connect(delay)
input.connect(output)

delay.connect(feedback)
feedback.connect(delay)
feedback.connect(output)
// ^^^^^^^^^^^^^^^^^

play(0, -3, 0.05)
play(0.05, 2, 0.05)
play(0.1, 9, 0.05)
play(0.15, 14, 0.05)
play(0.2, 9, 0.05)
play(0.25, 2, 0.05)
play(0.3, -3, 0.05)
play(0.35, 7, 0.05)
play(0.4, 14, 0.05)
play(0.45, 18, 0.05)
play(0.5, 9, 0.05)
play(0.55, 2, 0.05)

function play (startAfter, pitch, duration) {
  var time = audioContext.currentTime + startAfter

  var oscillator = audioContext.createOscillator()

  // Connect to input for feedback loop
  oscillator.connect(input)

  oscillator.type = 'square'
  oscillator.detune.value = pitch * 100

  oscillator.start(time)
  oscillator.stop(time + duration)
}
