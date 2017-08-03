var audioContext = new AudioContext()
var startTime = audioContext.currentTime + 0.2

getSample('guitar.wav', function play (buffer) {

// Add the spring.mp3 impulse response to the guitar to give it a reverb effect
  getSample('spring.mp3', function play (impulseBuffer) {
    var player = audioContext.createBufferSource()
    player.buffer = buffer
    
    var convolver = audioContext.createConvolver()
    convolver.buffer = impulseBuffer
    
    player.connect(convolver)
    convolver.connect(audioContext.destination)
    
    player.start(startTime)
  })
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
