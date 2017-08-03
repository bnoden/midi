const SAMPLE_RATE = 44100;

const audioContext = new AudioContext();
const startTime = audioContext.currentTime + 0.2;
const shaper = audioContext.createWaveShaper();
const bandpass = audioContext.createBiquadFilter();
bandpass.type = 'bandpass';
bandpass.frequency.value = 1000;
bandpass.connect(shaper);

function generateCurve (steps) {
  const deg = Math.PI/180;
  return new Float32Array(steps).map((val,index) => {
    const x = index*2/steps-1;
    return (3+10)*x*20*deg/(Math.PI+10*Math.abs(x));
  });
};

shaper.curve = generateCurve(SAMPLE_RATE/2);

const amp = audioContext.createGain();
amp.gain.value = 20;
amp.connect(bandpass);
shaper.connect(audioContext.destination);

function getSample (url, cb) {
  const request = new XMLHttpRequest();
  request.open('GET', url);
  request.responseType = 'arraybuffer';
  request.onload = () => {
    audioContext.decodeAudioData(request.response, cb);
  }
  request.send();
};

getSample('guitar.wav', function play (buffer) {
  const player = audioContext.createBufferSource();
  player.buffer = buffer;
  player.connect(amp);
  player.start(startTime);
});
