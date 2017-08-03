const audioContext = new AudioContext()

// Add a global stereo ping pong delay effect, bouncing left to right,
// a delay time of 3/8 and feedback ratio of 0.4.
let input, output, leftDelay, rightDelay, feedback, merger;

input = audioContext.createGain()
merger = audioContext.createChannelMerger(2)
output = audioContext.createGain()

leftDelay = audioContext.createDelay()
rightDelay = audioContext.createDelay()
feedback = audioContext.createGain()

input.connect(feedback, 0)
leftDelay.connect(rightDelay)
rightDelay.connect(feedback)
feedback.connect(leftDelay)
merger.connect(output)
input.connect(output)
output.connect(audioContext.destination)

feedback.gain.value = 0.4

leftDelay.connect(merger, 0, 0)
rightDelay.connect(merger, 0, 1)

leftDelay.delayTime.value = 3/8
rightDelay.delayTime.value = 3/8
// ^^^^^^^^^^^^^^^^^


play(1/8, 3, 0.05)
play(2/8, 7, 0.05)
play(3/8, 15, 0.05)

function play (startAfter, pitch, duration) {
  var time = audioContext.currentTime + startAfter

  var oscillator = audioContext.createOscillator()

  // Connect to ChannelMergerNode
  oscillator.connect(input)

  oscillator.type = 'square'
  oscillator.detune.value = pitch * 100

  oscillator.start(time)
  oscillator.stop(time + duration)
}
