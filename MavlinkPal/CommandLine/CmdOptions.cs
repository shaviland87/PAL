using CommandLine;
using MavLinkPal.MavLinkProtocol;

namespace MavLinkPal.CommandLine
{
    public class CmdOptions
    { 
        [Option('h', "host", Default= "127.0.0.1", HelpText = "MAVLink UDP IP address.")]
        public string Host { get; set; }

        [Option('p', "port", Default = 14550, HelpText = "MAVLink UDP port.")]
        public int Port { get; set; }

        [Option('o', "output-folder", Default = "logs", HelpText = "Output folder.")]
        public string OutputFolder { get; set; }

        [Option('m', "message-ids", Required = true, HelpText = "Space-separated MAVLink message IDs. Options: " +
            $"0 ({nameof(Heartbeat)}), 1 ({nameof(SysStatus)}), 24 ({nameof(GpsRawInt)}), 30 ({nameof(Attitude)}), " +
            $"35 ({nameof(RcChannelsRaw)}), 74 ({nameof(VfrHud)}), 147 ({nameof(BatteryStatus)}), 168 ({nameof(Wind)}), " +
            $"193 ({nameof(EkfStatusReport)}), 194 ({nameof(PidTuning)})")]
        public IEnumerable<int> MessageIds { get; set; }

        [Option('w', "overwrite-files", Default = false, HelpText = "Whether overwrite the existing files.")]
        public bool OverwriteFiles { get; set; }
    }
}