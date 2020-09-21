# #Cnthesizer

### General description
The app is a Windows Forms application written in C#. It is a simple synthesizer simulator. Its features include playing different tones with different wave forms, recording audio, and modifying the recording.

### Technologies used
The app is targeted for .NET Framework, as .NET Core doesn't yet have proper support for Win Forms applications. It uses the `NAudio` library for working with sound, as .NET's `System.Media` isn't suitable for fast-changing and looped sounds, which is the expected usage of the app.

### Brief overview of sound generation
Analogue sound is a wave. These waves can be of many forms, each forming a different kind of sound. The main properties that affect how a wave sounds are:

- frequency: determines the pitch (or _tone_)
- amplitude: determines the volume
- shape of the wave: determines the _timbre_; for example, a sine wave will be very different from a wave in the shape of a triangle

Computers obviously cannot store analogue objects. Instead, they store a sound wave by _sampling_ it. That means that the value of the analogue wave is stored only at every specified time interval. The time interval, or rather its frequency, is called the _sample rate_.

We use a sample rate of 44100, which is common for sound applications. Each value stored is of type `short`. The app only has one channel.

# `class Session`

This is the class encapsulating every run of the app. It takes care of all user-set properties and gives control to other classes when needed.

##### `void ChangeBeatFrequency(int bpm)`

Is called when the user moves the slider. Stops playing the currently playing beat and starts playing one with the updated bpm.

##### `void ChangeWaveForm(WaveForm waveForm)`

Is called when the user clicks on a button that changes wave transformation function. Updates the WaveForm property.

##### `void StartPlayingBeat(int bpm)`

Plays beat at the specified rate. 

##### `void StartPlayingPitch(Pitch pitch)`

Is called when the user presses a key. Plays the given pitch.

##### `void StartRecording()`

Is called when the user clicks the record button. Creates a new `Recorder` instance and alerts it to start registering what is being played.

##### `void StopPlaying()`

Stops playing any sound.

##### `void StopPlayingBeat()`

Stops playing beat, other sounds being played are unaffected.

##### `void StopPlayingPitch(Pitch pitch)`

Stops playing given pitch, other sounds are unaffected.

##### `void StopRecording()`

Alerts the recorder that the user wants to stop recording. Passes control to the recorder.

# `class Recorder`

Takes care of recording and then modifying user-created sequence of tones.

##### `void AddHarmony(bool manual)`

Prepares to create a new harmony by removing the previously generated one. If `manual` is `true`, creates a new instance of `ManualHarmonyForm`, where user can define their chords.

##### `void AddChord(ChordName chord, long duration)`

Adds a new chord of given duration to harmony.

##### `void AddNewEpoch(List<Pitch> frequencies)`

This method is intended to be called when the set of keys currently pressed changes. It calculates the time difference from the previous change, finds out all keys being pressed currently, and adds this data to its recording-building sequence.

##### `void Playback()`

Plays recording, complete with the generated harmony.

##### `void PlayChord(ChordName chord)`

Plays given chord.

##### `void RegenerateRecording()`

Is intended to be called after any changes are made, such as pitch shift. Rewrites the file that stores the recording.

##### `void StartRecording()`

Indicates that recording has started. Sets bpm from the calling `Session`.

##### `void StopChord()`

Stops any chord currently played.

##### `void StopPlayback()`

Stops all sounds being played.

##### `void StopRecording()`

Is called when the user wants to stop recording. Generates the corresponding file, prompts user to save it and then to modify it.

##### `void UpdateScale(Scale scale)`

Updates the Scale property.

# `class Epoch`

Stores information about `Pitch`es played and the duration until a change.

##### `Epoch CreateEpoch(long duration, List<Pitch> frequencies)`

Creates a new instance of `Epoch`.

##### `short[] ConvertToWave(int sampleRate, Shift shift, WaveFormEquation waveForm)`

Creates a sound wave corresponding to the sound of pitches in `Frequencies` shifted by `shift` being played for `Duration` of time, where the wave has the form `waveForm`.

# `class Wave`

Provides methods for working with sampled soundwaves.

##### `byte[] ConvertShortWaveToBytes(short[] wave)`

Converts a sampled wave into an array of bytes, which is necessary for writing files.

##### `byte[] CreateEmptyWave(int length)`

Creates an array of bytes representing silence.

##### `void CreatePitchWaveFile(string filename, Pitch pitch, WaveFormEquation waveForm, int sampleRate)`

Creates a sound wave representing the given pitch played for one second and writes it into a file. These files are then used internally.

#### `short[] GenerateBeatWave(int bpm)`

Creates an array of short representing one beat.

##### `short[] SampleWaveForm(Pitch pitch, int length, Shift shift, WaveFormEquation waveForm, int sampleRate)`

Creates a sound wave representation with specified parameters.

##### `void WriteToStream(Stream stream, byte[] wave, int samples, int sampleRate, short bitsPerSample, short channels)`

Writes wave into the specified stream with the correct header of a .wav file.

# `class Chord`

Represents one chord by its name and scale.

##### `List<Pitch> GetChord()`

Converts chord's name and scale into a list of playable `Pitch`es.

# `class Scale`

Represents a musical scale.

# `class Mixing`

Provides methods to mix multiple sound waves into one.

#### `short[] MixListOfWaves(List<short[]> waves)`

Takes a list of sound waves and returns one representing the sound of them playing at once with the same amplitude.

#### `short[] MixTwoWaves(short[] a, short[] b)`

Slightly optimized version of the previous method for just two waves.

# `class Frequency`

Assigns a frequency to each `Pitch`.

# `class PitchSelector`

Provides methods to obtain a sound object by specifying the `Pitch`.

# `class KeyControls`

Assigns a `Pitch` to keyboard keys.

# `class Shifts`

Provides methods to shift a frequency by a specified (musical) interval, e.g. an octave or a fifth. All methods from this class can be used as a `Shift` delegate.

# `class WaveForms`

Provides transformation methods for waves. Each generates a differently shaped sound wave. All methods from this class can be used as a `WaveFormEquation` delegate.