using NAudio.Midi;

namespace Console
{
    public partial class MainWindow : Window
    {
        private Dictionary<char, Tuple<int, int>> noteMapping; // Map letters to MIDI note and duration
        private MidiOut midiOut;

        public MainWindow()
        {
            InitializeComponent();
            box.Focus();
            box.KeyDown += Box_KeyDown;
            midiOut = new MidiOut(0);
            InitializeNoteMapping();
        }

        private void InitializeNoteMapping()
        {
            noteMapping = new Dictionary<char, Tuple<int, int>>
            {
                { 'A', new Tuple<int, int>(60, 500) }, // MIDI note 60 (C4), duration 500ms
                // Add more mappings for other letters
            };
        }

        private void Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (takingNote)
            {
                // Your existing Box_KeyDown implementation
            }
            else if (e.Key == Key.M && Keyboard.Modifiers == ModifierKeys.Control)
            {
                // Generate and play music from the saved notes
                string fileName = $"{DateTime.Now:dd_MM_yyyy}.txt";
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
                PlayMusicFromTextFile(filePath);
            }
        }

        private void PlayMusicFromTextFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                foreach (char letter in content)
                {
                    if (noteMapping.TryGetValue(letter, out Tuple<int, int> noteInfo))
                    {
                        int noteNumber = noteInfo.Item1;
                        int duration = noteInfo.Item2;

                        var noteOn = new NoteOnEvent(0, 0, midiOut.DeviceId, noteNumber, 100);
                        var noteOff = new NoteEvent(0, 0, MidiCommandCode.NoteOff, midiOut.DeviceId, noteNumber, 0);

                        midiOut.Send(noteOn.GetAsShortMessage());
                        Thread.Sleep(duration); // Adjust timing
                        midiOut.Send(noteOff.GetAsShortMessage());
                    }
                }
            }
            else
            {
                boxAff.Text += "The specified file does not exist.\n";
            }
        }


        private string ConvertToMusicalNotes(string savedNotes)
        {
            StringBuilder musicalNotes = new StringBuilder();
            foreach (char note in savedNotes)
            {
                if (note == 'A')
                {
                    musicalNotes.Append("C4"); // Replace with appropriate musical note representation
                }
                else if (note == 'B')
                {
                    musicalNotes.Append("D4"); // Replace with appropriate musical note representation
                }
                // Add more cases for other notes
            }
            return musicalNotes.ToString();
        }

        // Other event handlers and methods...
    }
}
