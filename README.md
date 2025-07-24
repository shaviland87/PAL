# MAVLinkPal
## Description
Reads MAVLink packets over UDP channel and deserializes them into CSV files.
## How to Run
Run "MAVLinkPal.exe from the command prompt to see the list of options.

## Options

-h, --host             (Default: 127.0.0.1) MAVLink UDP IP address.

-p, --port             (Default: 14550) MAVLink UDP port.

-o, --output-folder    (Default: logs) Output folder.

-m, --message-ids      Required. Space-separated MAVLink message IDs. Options: 0 (Heartbeat), 1 (SysStatus), 24 (GpsRawInt), 30 (Attitude), 35 (RcChannelsRaw), 74 (VfrHud), 147 (BatteryStatus), 168 (Wind), 193 (EkfStatusReport), 194 (PidTuning), 251 (NamedValueFloat)

-w, --overwrite-files  (Default: false) Whether overwrite the existing files.

--help                 Display this help screen.

--version              Display version information.
## Examples
**Example 1:** MAVLinkPal.exe -m 0<br>*Dumps message #0 (heartbeat) to heartbeat.csv.*

**Example 2:** MAVLinkPal.exe -h 127.0.0.1 -p 14550 -m 0 1<br>*Dumps message #0 (heartbeat) and #1 (sys_status) to heartbeat.csv and sys_status.csv.*
## Build From Source Code
### Requirements
- **Windows 10 or later**
- **.NET 6.x**
- **Visual Studio 2022**
### Instructions
- ***Build Using Visual Studio:*** Open the solution (.sln) in Visual Studio and build the solution.
