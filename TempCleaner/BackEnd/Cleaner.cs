using EnumsNET;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace TempCleanner
{
    public class Cleaner : INotifyPropertyChanged
    {

        public Cleaner()
        {
            this.SetValue();
        }

        private string _pathState;
        public string PathState
        {
            get => _pathState;

            set
            {
                _pathState = value;
                NotifyPropertyChanged(nameof(PathState));
            }
        }


        [DefaultValue(eState.Dirty)]
        private eState State { get; set; }

        public void SetValue() => this.PathState = this.State.AsString(EnumFormat.Description);

        public void Clean()
        {
            this.State = eState.Clean;
            this.SetValue();
            this.ClearTempFolder();
        }

        private void ClearTempFolder()
        {
            var tempPath = Path.GetTempPath();

            foreach (var directory in Directory.GetDirectories(tempPath))
            {
                try { Directory.Delete(directory, true); }

                catch { continue; }
            }

            foreach (var file in Directory.GetFiles(tempPath))
            {
                try { File.Delete(file); }

                catch { continue; }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
