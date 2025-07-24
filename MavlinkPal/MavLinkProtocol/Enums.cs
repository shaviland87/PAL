namespace MavLinkPal.MavLinkProtocol
{
    /// <summary>
    /// Micro air vehicle / autopilot classes. This identifies the individual model.
    /// </summary>
    public enum MavAutopilot
    {

        /// <summary> Generic autopilot, full support for everything </summary>
        Generic = 0,

        /// <summary> Reserved for future use. </summary>
        Reserved = 1,

        /// <summary> SLUGS autopilot, http://slugsuav.soe.ucsc.edu </summary>
        Slugs = 2,

        /// <summary> ArduPilotMega / ArduCopter, http://diydrones.com </summary>
        Ardupilotmega = 3,

        /// <summary> OpenPilot, http://openpilot.org </summary>
        Openpilot = 4,

        /// <summary> Generic autopilot only supporting simple waypoints </summary>
        GenericWaypointsOnly = 5,

        /// <summary> Generic autopilot supporting waypoints and other simple navigation commands </summary>
        GenericWaypointsAndSimpleNavigationOnly = 6,

        /// <summary> Generic autopilot supporting the full mission command set </summary>
        GenericMissionFull = 7,

        /// <summary> No valid autopilot, e.g. a GCS or other MAVLink component </summary>
        Invalid = 8,

        /// <summary> PPZ UAV - http://nongnu.org/paparazzi </summary>
        Ppz = 9,

        /// <summary> UAV Dev Board </summary>
        Udb = 10,

        /// <summary> FlexiPilot </summary>
        Fp = 11,

        /// <summary> PX4 Autopilot - http://pixhawk.ethz.ch/px4/ </summary>
        Px4 = 12,

        /// <summary> SMACCMPilot - http://smaccmpilot.org </summary>
        Smaccmpilot = 13,

        /// <summary> AutoQuad -- http://autoquad.org </summary>
        Autoquad = 14,

        /// <summary> Armazila -- http://armazila.com </summary>
        Armazila = 15,

        /// <summary> Aerob -- http://aerob.ru </summary>
        Aerob = 16,

        /// <summary> ASLUAV autopilot -- http://www.asl.ethz.ch </summary>
        Asluav = 17
    };

    public enum MavType
    {

        /// <summary> Generic micro air vehicle. </summary>
        Generic = 0,

        /// <summary> Fixed wing aircraft. </summary>
        FixedWing = 1,

        /// <summary> Quadrotor </summary>
        Quadrotor = 2,

        /// <summary> Coaxial helicopter </summary>
        Coaxial = 3,

        /// <summary> Normal helicopter with tail rotor. </summary>
        Helicopter = 4,

        /// <summary> Ground installation </summary>
        AntennaTracker = 5,

        /// <summary> Operator control unit / ground control station </summary>
        Gcs = 6,

        /// <summary> Airship, controlled </summary>
        Airship = 7,

        /// <summary> Free balloon, uncontrolled </summary>
        FreeBalloon = 8,

        /// <summary> Rocket </summary>
        Rocket = 9,

        /// <summary> Ground rover </summary>
        GroundRover = 10,

        /// <summary> Surface vessel, boat, ship </summary>
        SurfaceBoat = 11,

        /// <summary> Submarine </summary>
        Submarine = 12,

        /// <summary> Hexarotor </summary>
        Hexarotor = 13,

        /// <summary> Octorotor </summary>
        Octorotor = 14,

        /// <summary> Octorotor </summary>
        Tricopter = 15,

        /// <summary> Flapping wing </summary>
        FlappingWing = 16,

        /// <summary> Flapping wing </summary>
        Kite = 17,

        /// <summary> Onboard companion controller </summary>
        OnboardController = 18,

        /// <summary> Two-rotor VTOL using control surfaces in vertical operation in addition. Tailsitter. </summary>
        VtolDuorotor = 19,

        /// <summary> Quad-rotor VTOL using a V-shaped quad config in vertical operation. Tailsitter. </summary>
        VtolQuadrotor = 20,

        /// <summary> Tiltrotor VTOL </summary>
        VtolTiltrotor = 21,

        /// <summary> VTOL reserved 2 </summary>
        VtolReserved2 = 22,

        /// <summary> VTOL reserved 3 </summary>
        VtolReserved3 = 23,

        /// <summary> VTOL reserved 4 </summary>
        VtolReserved4 = 24,

        /// <summary> VTOL reserved 5 </summary>
        VtolReserved5 = 25,

        /// <summary> Onboard gimbal </summary>
        Gimbal = 26,

        /// <summary> Onboard ADSB peripheral </summary>
        Adsb = 27
    };

    /// <summary>
    /// These values define the type of firmware release.  These values indicate the first version or release of this type.  For example the first alpha release would be 64, the second would be 65.
    /// </summary>
    public enum FirmwareVersionType
    {

        /// <summary> development release </summary>
        Dev = 0,

        /// <summary> alpha release </summary>
        Alpha = 64,

        /// <summary> beta release </summary>
        Beta = 128,

        /// <summary> release candidate </summary>
        Rc = 192,

        /// <summary> official stable release </summary>
        Official = 255
    };

    /// <summary>
    /// These flags encode the MAV mode.
    /// </summary>
    public enum MavModeFlag
    {

        /// <summary> 0b10000000 MAV safety set to armed. Motors are enabled / running / can start. Ready to fly. </summary>
        SafetyArmed = 128,

        /// <summary> 0b01000000 remote control input is enabled. </summary>
        ManualInputEnabled = 64,

        /// <summary> 0b00100000 hardware in the loop simulation. All motors / actuators are blocked, but internal software is full operational. </summary>
        HilEnabled = 32,

        /// <summary> 0b00010000 system stabilizes electronically its attitude (and optionally position). It needs however further control inputs to move around. </summary>
        StabilizeEnabled = 16,

        /// <summary> 0b00001000 guided mode enabled, system flies MISSIONs / mission items. </summary>
        GuidedEnabled = 8,

        /// <summary> 0b00000100 autonomous mode enabled, system finds its own goal positions. Guided flag can be set or not, depends on the actual implementation. </summary>
        AutoEnabled = 4,

        /// <summary> 0b00000010 system has a test mode enabled. This flag is intended for temporary system tests and should not be used for stable implementations. </summary>
        TestEnabled = 2,

        /// <summary> 0b00000001 Reserved for future use. </summary>
        CustomModeEnabled = 1
    };

    /// <summary>
    /// These values encode the bit positions of the decode position. These values can be used to read the value of a flag bit by combining the base_mode variable with AND with the flag position value. The result will be either 0 or 1, depending on if the flag is set or not.
    /// </summary>
    public enum MavModeFlagDecodePosition
    {

        /// <summary> First bit:  10000000 </summary>
        Safety = 128,

        /// <summary> Second bit: 01000000 </summary>
        Manual = 64,

        /// <summary> Third bit:  00100000 </summary>
        Hil = 32,

        /// <summary> Fourth bit: 00010000 </summary>
        Stabilize = 16,

        /// <summary> Fifth bit:  00001000 </summary>
        Guided = 8,

        /// <summary> Sixt bit:   00000100 </summary>
        Auto = 4,

        /// <summary> Seventh bit: 00000010 </summary>
        Test = 2,

        /// <summary> Eighth bit: 00000001 </summary>
        CustomMode = 1
    };

    /// <summary>
    /// Override command, pauses current mission execution and moves immediately to a position
    /// </summary>
    public enum MavGoto
    {

        /// <summary> Hold at the current position. </summary>
        DoHold = 0,

        /// <summary> Continue with the next item in mission execution. </summary>
        DoContinue = 1,

        /// <summary> Hold at the current position of the system </summary>
        HoldAtCurrentPosition = 2,

        /// <summary> Hold at the position specified in the parameters of the DO_HOLD action </summary>
        HoldAtSpecifiedPosition = 3
    };

    /// <summary>
    /// These defines are predefined OR-combined mode flags. There is no need to use values from this enum, but it                simplifies the use of the mode flags. Note that manual input is enabled in all modes as a safety override.
    /// </summary>
    public enum MavMode
    {

        /// <summary> System is not ready to fly, booting, calibrating, etc. No flag is set. </summary>
        Preflight = 0,

        /// <summary> System is allowed to be active, under assisted RC control. </summary>
        StabilizeDisarmed = 80,

        /// <summary> System is allowed to be active, under assisted RC control. </summary>
        StabilizeArmed = 208,

        /// <summary> System is allowed to be active, under manual (RC) control, no stabilization </summary>
        ManualDisarmed = 64,

        /// <summary> System is allowed to be active, under manual (RC) control, no stabilization </summary>
        ManualArmed = 192,

        /// <summary> System is allowed to be active, under autonomous control, manual setpoint </summary>
        GuidedDisarmed = 88,

        /// <summary> System is allowed to be active, under autonomous control, manual setpoint </summary>
        GuidedArmed = 216,

        /// <summary> System is allowed to be active, under autonomous control and navigation (the trajectory is decided onboard and not pre-programmed by MISSIONs) </summary>
        AutoDisarmed = 92,

        /// <summary> System is allowed to be active, under autonomous control and navigation (the trajectory is decided onboard and not pre-programmed by MISSIONs) </summary>
        AutoArmed = 220,

        /// <summary> UNDEFINED mode. This solely depends on the autopilot - use with caution, intended for developers only. </summary>
        TestDisarmed = 66,

        /// <summary> UNDEFINED mode. This solely depends on the autopilot - use with caution, intended for developers only. </summary>
        TestArmed = 194
    };

    public enum MavState
    {

        /// <summary> Uninitialized system, state is unknown. </summary>
        Uninit = 0,

        /// <summary> System is booting up. </summary>
        Boot = 1,

        /// <summary> System is calibrating and not flight-ready. </summary>
        Calibrating = 2,

        /// <summary> System is grounded and on standby. It can be launched any time. </summary>
        Standby = 3,

        /// <summary> System is active and might be already airborne. Motors are engaged. </summary>
        Active = 4,

        /// <summary> System is in a non-normal flight mode. It can however still navigate. </summary>
        Critical = 5,

        /// <summary> System is in a non-normal flight mode. It lost control over parts or over the whole airframe. It is in mayday and going down. </summary>
        Emergency = 6,

        /// <summary> System just initialized its power-down sequence, will shut down now. </summary>
        Poweroff = 7
    };

    public enum MavComponent
    {

        /// <summary>  </summary>
        MavCompIdAll = 0,

        /// <summary>  </summary>
        MavCompIdGps = 220,

        /// <summary>  </summary>
        MavCompIdMissionplanner = 190,

        /// <summary>  </summary>
        MavCompIdPathplanner = 195,

        /// <summary>  </summary>
        MavCompIdMapper = 180,

        /// <summary>  </summary>
        MavCompIdCamera = 100,

        /// <summary>  </summary>
        MavCompIdImu = 200,

        /// <summary>  </summary>
        MavCompIdImu2 = 201,

        /// <summary>  </summary>
        MavCompIdImu3 = 202,

        /// <summary>  </summary>
        MavCompIdUdpBridge = 240,

        /// <summary>  </summary>
        MavCompIdUartBridge = 241,

        /// <summary>  </summary>
        MavCompIdSystemControl = 250,

        /// <summary>  </summary>
        MavCompIdServo1 = 140,

        /// <summary>  </summary>
        MavCompIdServo2 = 141,

        /// <summary>  </summary>
        MavCompIdServo3 = 142,

        /// <summary>  </summary>
        MavCompIdServo4 = 143,

        /// <summary>  </summary>
        MavCompIdServo5 = 144,

        /// <summary>  </summary>
        MavCompIdServo6 = 145,

        /// <summary>  </summary>
        MavCompIdServo7 = 146,

        /// <summary>  </summary>
        MavCompIdServo8 = 147,

        /// <summary>  </summary>
        MavCompIdServo9 = 148,

        /// <summary>  </summary>
        MavCompIdServo10 = 149,

        /// <summary>  </summary>
        MavCompIdServo11 = 150,

        /// <summary>  </summary>
        MavCompIdServo12 = 151,

        /// <summary>  </summary>
        MavCompIdServo13 = 152,

        /// <summary>  </summary>
        MavCompIdServo14 = 153,

        /// <summary>  </summary>
        MavCompIdGimbal = 154,

        /// <summary>  </summary>
        MavCompIdLog = 155,

        /// <summary>  </summary>
        MavCompIdAdsb = 156,

        /// <summary> On Screen Display (OSD) devices for video links </summary>
        MavCompIdOsd = 157,

        /// <summary> Generic autopilot peripheral component ID. Meant for devices that do not implement the parameter sub-protocol </summary>
        MavCompIdPeripheral = 158
    };

    /// <summary>
    /// These encode the sensors whose status is sent as part of the SYS_STATUS message.
    /// </summary>
    public enum MavSysStatusSensor
    {

        /// <summary> 0x01 3D gyro </summary>
        _3dGyro = 1,

        /// <summary> 0x02 3D accelerometer </summary>
        _3dAccel = 2,

        /// <summary> 0x04 3D magnetometer </summary>
        _3dMag = 4,

        /// <summary> 0x08 absolute pressure </summary>
        AbsolutePressure = 8,

        /// <summary> 0x10 differential pressure </summary>
        DifferentialPressure = 16,

        /// <summary> 0x20 GPS </summary>
        Gps = 32,

        /// <summary> 0x40 optical flow </summary>
        OpticalFlow = 64,

        /// <summary> 0x80 computer vision position </summary>
        VisionPosition = 128,

        /// <summary> 0x100 laser based position </summary>
        LaserPosition = 256,

        /// <summary> 0x200 external ground truth (Vicon or Leica) </summary>
        ExternalGroundTruth = 512,

        /// <summary> 0x400 3D angular rate control </summary>
        AngularRateControl = 1024,

        /// <summary> 0x800 attitude stabilization </summary>
        AttitudeStabilization = 2048,

        /// <summary> 0x1000 yaw position </summary>
        YawPosition = 4096,

        /// <summary> 0x2000 z/altitude control </summary>
        ZAltitudeControl = 8192,

        /// <summary> 0x4000 x/y position control </summary>
        XyPositionControl = 16384,

        /// <summary> 0x8000 motor outputs / control </summary>
        MotorOutputs = 32768,

        /// <summary> 0x10000 rc receiver </summary>
        RcReceiver = 65536,

        /// <summary> 0x20000 2nd 3D gyro </summary>
        _3dGyro2 = 131072,

        /// <summary> 0x40000 2nd 3D accelerometer </summary>
        _3dAccel2 = 262144,

        /// <summary> 0x80000 2nd 3D magnetometer </summary>
        _3dMag2 = 524288,

        /// <summary> 0x100000 geofence </summary>
        MavSysStatusGeofence = 1048576,

        /// <summary> 0x200000 AHRS subsystem health </summary>
        MavSysStatusAhrs = 2097152,

        /// <summary> 0x400000 Terrain subsystem health </summary>
        MavSysStatusTerrain = 4194304,

        /// <summary> 0x800000 Motors are reversed </summary>
        MavSysStatusReverseMotor = 8388608
    };

    public enum MavFrame
    {

        /// <summary> Global coordinate frame, WGS84 coordinate system. First value / x: latitude, second value / y: longitude, third value / z: positive altitude over mean sea level (MSL) </summary>
        Global = 0,

        /// <summary> Local coordinate frame, Z-up (x: north, y: east, z: down). </summary>
        LocalNed = 1,

        /// <summary> NOT a coordinate frame, indicates a mission command. </summary>
        Mission = 2,

        /// <summary> Global coordinate frame, WGS84 coordinate system, relative altitude over ground with respect to the home position. First value / x: latitude, second value / y: longitude, third value / z: positive altitude with 0 being at the altitude of the home location. </summary>
        GlobalRelativeAlt = 3,

        /// <summary> Local coordinate frame, Z-down (x: east, y: north, z: up) </summary>
        LocalEnu = 4,

        /// <summary> Global coordinate frame, WGS84 coordinate system. First value / x: latitude in degrees*1.0e-7, second value / y: longitude in degrees*1.0e-7, third value / z: positive altitude over mean sea level (MSL) </summary>
        GlobalInt = 5,

        /// <summary> Global coordinate frame, WGS84 coordinate system, relative altitude over ground with respect to the home position. First value / x: latitude in degrees*10e-7, second value / y: longitude in degrees*10e-7, third value / z: positive altitude with 0 being at the altitude of the home location. </summary>
        GlobalRelativeAltInt = 6,

        /// <summary> Offset to the current local frame. Anything expressed in this frame should be added to the current local frame position. </summary>
        LocalOffsetNed = 7,

        /// <summary> Setpoint in body NED frame. This makes sense if all position control is externalized - e.g. useful to command 2 m/s^2 acceleration to the right. </summary>
        BodyNed = 8,

        /// <summary> Offset in body NED frame. This makes sense if adding setpoints to the current flight path, to avoid an obstacle - e.g. useful to command 2 m/s^2 acceleration to the east. </summary>
        BodyOffsetNed = 9,

        /// <summary> Global coordinate frame with above terrain level altitude. WGS84 coordinate system, relative altitude over terrain with respect to the waypoint coordinate. First value / x: latitude in degrees, second value / y: longitude in degrees, third value / z: positive altitude in meters with 0 being at ground level in terrain model. </summary>
        GlobalTerrainAlt = 10,

        /// <summary> Global coordinate frame with above terrain level altitude. WGS84 coordinate system, relative altitude over terrain with respect to the waypoint coordinate. First value / x: latitude in degrees*10e-7, second value / y: longitude in degrees*10e-7, third value / z: positive altitude in meters with 0 being at ground level in terrain model. </summary>
        GlobalTerrainAltInt = 11
    };

    public enum MavlinkDataStreamType
    {

        /// <summary>  </summary>
        MavlinkDataStreamImgJpeg = 1,

        /// <summary>  </summary>
        MavlinkDataStreamImgBmp = 2,

        /// <summary>  </summary>
        MavlinkDataStreamImgRaw8u = 3,

        /// <summary>  </summary>
        MavlinkDataStreamImgRaw32u = 4,

        /// <summary>  </summary>
        MavlinkDataStreamImgPgm = 5,

        /// <summary>  </summary>
        MavlinkDataStreamImgPng = 6
    };

    public enum FenceAction
    {

        /// <summary> Disable fenced mode </summary>
        None = 0,

        /// <summary> Switched to guided mode to return point (fence point 0) </summary>
        Guided = 1,

        /// <summary> Report fence breach, but don't take action </summary>
        Report = 2,

        /// <summary> Switched to guided mode to return point (fence point 0) with manual throttle control </summary>
        GuidedThrPass = 3,

        /// <summary> Switch to RTL (return to launch) mode and head for the return point. </summary>
        Rtl = 4
    };

    public enum FenceBreach
    {

        /// <summary> No last fence breach </summary>
        None = 0,

        /// <summary> Breached minimum altitude </summary>
        Minalt = 1,

        /// <summary> Breached maximum altitude </summary>
        Maxalt = 2,

        /// <summary> Breached fence boundary </summary>
        Boundary = 3
    };

    /// <summary>
    /// Enumeration of possible mount operation modes
    /// </summary>
    public enum MavMountMode
    {

        /// <summary> Load and keep safe position (Roll,Pitch,Yaw) from permant memory and stop stabilization </summary>
        Retract = 0,

        /// <summary> Load and keep neutral position (Roll,Pitch,Yaw) from permanent memory. </summary>
        Neutral = 1,

        /// <summary> Load neutral position and start MAVLink Roll,Pitch,Yaw control with stabilization </summary>
        MavlinkTargeting = 2,

        /// <summary> Load neutral position and start RC Roll,Pitch,Yaw control with stabilization </summary>
        RcTargeting = 3,

        /// <summary> Load neutral position and start to point to Lat,Lon,Alt </summary>
        GpsPoint = 4
    };

    /// <summary>
    /// Commands to be executed by the MAV. They can be executed on user request, or as part of a mission script. If the action is used in a mission, the parameter mapping to the waypoint/mission message is as follows: Param 1, Param 2, Param 3, Param 4, X: Param 5, Y:Param 6, Z:Param 7. This command list is similar what ARINC 424 is for commercial aircraft: A data format how to interpret waypoint/mission data.
    /// </summary>
    public enum MavCmd
    {

        /// <summary> Navigate to MISSION. </summary>
        NavWaypoint = 16,

        /// <summary> Loiter around this MISSION an unlimited amount of time </summary>
        NavLoiterUnlim = 17,

        /// <summary> Loiter around this MISSION for X turns </summary>
        NavLoiterTurns = 18,

        /// <summary> Loiter around this MISSION for X seconds </summary>
        NavLoiterTime = 19,

        /// <summary> Return to launch location </summary>
        NavReturnToLaunch = 20,

        /// <summary> Land at location </summary>
        NavLand = 21,

        /// <summary> Takeoff from ground / hand </summary>
        NavTakeoff = 22,

        /// <summary> Land at local position (local frame only) </summary>
        NavLandLocal = 23,

        /// <summary> Takeoff from local position (local frame only) </summary>
        NavTakeoffLocal = 24,

        /// <summary> Vehicle following, i.e. this waypoint represents the position of a moving vehicle </summary>
        NavFollow = 25,

        /// <summary> Continue on the current course and climb/descend to specified altitude.  When the altitude is reached continue to the next command (i.e., don't proceed to the next command until the desired altitude is reached. </summary>
        NavContinueAndChangeAlt = 30,

        /// <summary> Begin loiter at the specified Latitude and Longitude.  If Lat=Lon=0, then loiter at the current position.  Don't consider the navigation command complete (don't leave loiter) until the altitude has been reached.  Additionally, if the Heading Required parameter is non-zero the  aircraft will not leave the loiter until heading toward the next waypoint.  </summary>
        NavLoiterToAlt = 31,

        /// <summary> Being following a target </summary>
        DoFollow = 32,

        /// <summary> Reposition the MAV after a follow target command has been sent </summary>
        DoFollowReposition = 33,

        /// <summary> Sets the region of interest (ROI) for a sensor set or the vehicle itself. This can then be used by the vehicles control system to control the vehicle attitude and the attitude of various sensors such as cameras. </summary>
        NavRoi = 80,

        /// <summary> Control autonomous path planning on the MAV. </summary>
        NavPathplanning = 81,

        /// <summary> Navigate to MISSION using a spline path. </summary>
        NavSplineWaypoint = 82,

        /// <summary> Takeoff from ground using VTOL mode </summary>
        NavVtolTakeoff = 84,

        /// <summary> Land using VTOL mode </summary>
        NavVtolLand = 85,

        /// <summary> hand control over to an external controller </summary>
        NavGuidedEnable = 92,

        /// <summary> Delay the next navigation command a number of seconds or until a specified time </summary>
        NavDelay = 93,

        /// <summary> NOP - This command is only used to mark the upper limit of the NAV/ACTION commands in the enumeration </summary>
        NavLast = 95,

        /// <summary> Delay mission state machine. </summary>
        ConditionDelay = 112,

        /// <summary> Ascend/descend at rate.  Delay mission state machine until desired altitude reached. </summary>
        ConditionChangeAlt = 113,

        /// <summary> Delay mission state machine until within desired distance of next NAV point. </summary>
        ConditionDistance = 114,

        /// <summary> Reach a certain target angle. </summary>
        ConditionYaw = 115,

        /// <summary> NOP - This command is only used to mark the upper limit of the CONDITION commands in the enumeration </summary>
        ConditionLast = 159,

        /// <summary> Set system mode. </summary>
        DoSetMode = 176,

        /// <summary> Jump to the desired command in the mission list.  Repeat this action only the specified number of times </summary>
        DoJump = 177,

        /// <summary> Change speed and/or throttle set points. </summary>
        DoChangeSpeed = 178,

        /// <summary> Changes the home location either to the current location or a specified location. </summary>
        DoSetHome = 179,

        /// <summary> Set a system parameter.  Caution!  Use of this command requires knowledge of the numeric enumeration value of the parameter. </summary>
        DoSetParameter = 180,

        /// <summary> Set a relay to a condition. </summary>
        DoSetRelay = 181,

        /// <summary> Cycle a relay on and off for a desired number of cyles with a desired period. </summary>
        DoRepeatRelay = 182,

        /// <summary> Set a servo to a desired PWM value. </summary>
        DoSetServo = 183,

        /// <summary> Cycle a between its nominal setting and a desired PWM for a desired number of cycles with a desired period. </summary>
        DoRepeatServo = 184,

        /// <summary> Terminate flight immediately </summary>
        DoFlighttermination = 185,

        /// <summary> Mission command to perform a landing. This is used as a marker in a mission to tell the autopilot where a sequence of mission items that represents a landing starts. It may also be sent via a COMMAND_LONG to trigger a landing, in which case the nearest (geographically) landing sequence in the mission will be used. The Latitude/Longitude is optional, and may be set to 0/0 if not needed. If specified then it will be used to help find the closest landing sequence. </summary>
        DoLandStart = 189,

        /// <summary> Mission command to perform a landing from a rally point. </summary>
        DoRallyLand = 190,

        /// <summary> Mission command to safely abort an autonmous landing. </summary>
        DoGoAround = 191,

        /// <summary> Reposition the vehicle to a specific WGS84 global position. </summary>
        DoReposition = 192,

        /// <summary> If in a GPS controlled position mode, hold the current position or continue. </summary>
        DoPauseContinue = 193,

        /// <summary> Control onboard camera system. </summary>
        DoControlVideo = 200,

        /// <summary> Sets the region of interest (ROI) for a sensor set or the vehicle itself. This can then be used by the vehicles control system to control the vehicle attitude and the attitude of various sensors such as cameras. </summary>
        DoSetRoi = 201,

        /// <summary> Mission command to configure an on-board camera controller system. </summary>
        DoDigicamConfigure = 202,

        /// <summary> Mission command to control an on-board camera controller system. </summary>
        DoDigicamControl = 203,

        /// <summary> Mission command to configure a camera or antenna mount </summary>
        DoMountConfigure = 204,

        /// <summary> Mission command to control a camera or antenna mount </summary>
        DoMountControl = 205,

        /// <summary> Mission command to set CAM_TRIGG_DIST for this flight </summary>
        DoSetCamTriggDist = 206,

        /// <summary> Mission command to enable the geofence </summary>
        DoFenceEnable = 207,

        /// <summary> Mission command to trigger a parachute </summary>
        DoParachute = 208,

        /// <summary> Change to/from inverted flight </summary>
        DoInvertedFlight = 210,

        /// <summary> Mission command to control a camera or antenna mount, using a quaternion as reference. </summary>
        DoMountControlQuat = 220,

        /// <summary> set id of master controller </summary>
        DoGuidedMaster = 221,

        /// <summary> set limits for external control </summary>
        DoGuidedLimits = 222,

        /// <summary> NOP - This command is only used to mark the upper limit of the DO commands in the enumeration </summary>
        DoLast = 240,

        /// <summary> Trigger calibration. This command will be only accepted if in pre-flight mode. </summary>
        PreflightCalibration = 241,

        /// <summary> Set sensor offsets. This command will be only accepted if in pre-flight mode. </summary>
        PreflightSetSensorOffsets = 242,

        /// <summary> Trigger UAVCAN config. This command will be only accepted if in pre-flight mode. </summary>
        PreflightUavcan = 243,

        /// <summary> Request storage of different parameter values and logs. This command will be only accepted if in pre-flight mode. </summary>
        PreflightStorage = 245,

        /// <summary> Request the reboot or shutdown of system components. </summary>
        PreflightRebootShutdown = 246,

        /// <summary> Hold / continue the current action </summary>
        OverrideGoto = 252,

        /// <summary> start running a mission </summary>
        MissionStart = 300,

        /// <summary> Arms / Disarms a component </summary>
        ComponentArmDisarm = 400,

        /// <summary> Request the home position from the vehicle. </summary>
        GetHomePosition = 410,

        /// <summary> Starts receiver pairing </summary>
        StartRxPair = 500,

        /// <summary> Request the interval between messages for a particular MAVLink message ID </summary>
        GetMessageInterval = 510,

        /// <summary> Request the interval between messages for a particular MAVLink message ID. This interface replaces REQUEST_DATA_STREAM </summary>
        SetMessageInterval = 511,

        /// <summary> Request autopilot capabilities </summary>
        RequestAutopilotCapabilities = 520,

        /// <summary> Start image capture sequence </summary>
        ImageStartCapture = 2000,

        /// <summary> Stop image capture sequence </summary>
        ImageStopCapture = 2001,

        /// <summary> Enable or disable on-board camera triggering system. </summary>
        DoTriggerControl = 2003,

        /// <summary> Starts video capture </summary>
        VideoStartCapture = 2500,

        /// <summary> Stop the current video capture </summary>
        VideoStopCapture = 2501,

        /// <summary> Create a panorama at the current position </summary>
        PanoramaCreate = 2800,

        /// <summary> Request VTOL transition </summary>
        DoVtolTransition = 3000,

        /// <summary> Deploy payload on a Lat / Lon / Alt position. This includes the navigation to reach the required release position and velocity. </summary>
        PayloadPrepareDeploy = 30001,

        /// <summary> Control the payload deployment. </summary>
        PayloadControlDeploy = 30002,

        /// <summary> User defined waypoint item. Ground Station will show the Vehicle as flying through this item. </summary>
        WaypointUser1 = 31000,

        /// <summary> User defined waypoint item. Ground Station will show the Vehicle as flying through this item. </summary>
        WaypointUser2 = 31001,

        /// <summary> User defined waypoint item. Ground Station will show the Vehicle as flying through this item. </summary>
        WaypointUser3 = 31002,

        /// <summary> User defined waypoint item. Ground Station will show the Vehicle as flying through this item. </summary>
        WaypointUser4 = 31003,

        /// <summary> User defined waypoint item. Ground Station will show the Vehicle as flying through this item. </summary>
        WaypointUser5 = 31004,

        /// <summary> User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item. </summary>
        SpatialUser1 = 31005,

        /// <summary> User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item. </summary>
        SpatialUser2 = 31006,

        /// <summary> User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item. </summary>
        SpatialUser3 = 31007,

        /// <summary> User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item. </summary>
        SpatialUser4 = 31008,

        /// <summary> User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item. </summary>
        SpatialUser5 = 31009,

        /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item. </summary>
        User1 = 31010,

        /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item. </summary>
        User2 = 31011,

        /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item. </summary>
        User3 = 31012,

        /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item. </summary>
        User4 = 31013,

        /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item. </summary>
        User5 = 31014,

        /// <summary> Mission command to perform motor test </summary>
        DoMotorTest = 209,

        /// <summary> Mission command to operate EPM gripper </summary>
        DoGripper = 211,

        /// <summary> Enable/disable autotune </summary>
        DoAutotuneEnable = 212,

        /// <summary> Mission command to wait for an altitude or downwards vertical speed. This is meant for high altitude balloon launches, allowing the aircraft to be idle until either an altitude is reached or a negative vertical speed is reached (indicating early balloon burst). The wiggle time is how often to wiggle the control surfaces to prevent them seizing up. </summary>
        NavAltitudeWait = 83,

        /// <summary> A system wide power-off event has been initiated. </summary>
        PowerOffInitiated = 42000,

        /// <summary> FLY button has been clicked. </summary>
        SoloBtnFlyClick = 42001,

        /// <summary> FLY button has been held for 1.5 seconds. </summary>
        SoloBtnFlyHold = 42002,

        /// <summary> PAUSE button has been clicked. </summary>
        SoloBtnPauseClick = 42003,

        /// <summary> Initiate a magnetometer calibration </summary>
        DoStartMagCal = 42424,

        /// <summary> Initiate a magnetometer calibration </summary>
        DoAcceptMagCal = 42425,

        /// <summary> Cancel a running magnetometer calibration </summary>
        DoCancelMagCal = 42426,

        /// <summary> Reply with the version banner </summary>
        DoSendBanner = 42428,

        /// <summary> Causes the gimbal to reset and boot as if it was just powered on </summary>
        GimbalReset = 42501,

        /// <summary> Command autopilot to get into factory test/diagnostic mode </summary>
        SetFactoryTestMode = 42427,

        /// <summary> Reports progress and success or failure of gimbal axis calibration procedure </summary>
        GimbalAxisCalibrationStatus = 42502,

        /// <summary> Starts commutation calibration on the gimbal </summary>
        GimbalRequestAxisCalibration = 42503,

        /// <summary> Erases gimbal application and parameters </summary>
        GimbalFullReset = 42505
    };

    /// <summary>
    /// THIS INTERFACE IS DEPRECATED AS OF JULY 2015. Please use MESSAGE_INTERVAL instead. A data stream is not a fixed set of messages, but rather a      recommendation to the autopilot software. Individual autopilots may or may not obey      the recommended messages.
    /// </summary>
    public enum MavDataStream
    {

        /// <summary> Enable all data streams </summary>
        All = 0,

        /// <summary> Enable IMU_RAW, GPS_RAW, GPS_STATUS packets. </summary>
        RawSensors = 1,

        /// <summary> Enable GPS_STATUS, CONTROL_STATUS, AUX_STATUS </summary>
        ExtendedStatus = 2,

        /// <summary> Enable RC_CHANNELS_SCALED, RC_CHANNELS_RAW, SERVO_OUTPUT_RAW </summary>
        RcChannels = 3,

        /// <summary> Enable ATTITUDE_CONTROLLER_OUTPUT, POSITION_CONTROLLER_OUTPUT, NAV_CONTROLLER_OUTPUT. </summary>
        RawController = 4,

        /// <summary> Enable LOCAL_POSITION, GLOBAL_POSITION/GLOBAL_POSITION_INT messages. </summary>
        Position = 6,

        /// <summary> Dependent on the autopilot </summary>
        Extra1 = 10,

        /// <summary> Dependent on the autopilot </summary>
        Extra2 = 11,

        /// <summary> Dependent on the autopilot </summary>
        Extra3 = 12
    };

    /// <summary>
    ///  The ROI (region of interest) for the vehicle. This can be                 be used by the vehicle for camera/vehicle attitude alignment (see                 MAV_CMD_NAV_ROI).
    /// </summary>
    public enum MavRoi
    {

        /// <summary> No region of interest. </summary>
        None = 0,

        /// <summary> Point toward next MISSION. </summary>
        Wpnext = 1,

        /// <summary> Point toward given MISSION. </summary>
        Wpindex = 2,

        /// <summary> Point toward fixed location. </summary>
        Location = 3,

        /// <summary> Point toward of given id. </summary>
        Target = 4
    };

    /// <summary>
    /// ACK / NACK / ERROR values as a result of MAV_CMDs and for mission item transmission.
    /// </summary>
    public enum MavCmdAck
    {

        /// <summary> Command / mission item is ok. </summary>
        Ok = 1,

        /// <summary> Generic error message if none of the other reasons fails or if no detailed error reporting is implemented. </summary>
        ErrFail = 2,

        /// <summary> The system is refusing to accept this command from this source / communication partner. </summary>
        ErrAccessDenied = 3,

        /// <summary> Command or mission item is not supported, other commands would be accepted. </summary>
        ErrNotSupported = 4,

        /// <summary> The coordinate frame of this command / mission item is not supported. </summary>
        ErrCoordinateFrameNotSupported = 5,

        /// <summary> The coordinate frame of this command is ok, but he coordinate values exceed the safety limits of this system. This is a generic error, please use the more specific error messages below if possible. </summary>
        ErrCoordinatesOutOfRange = 6,

        /// <summary> The X or latitude value is out of range. </summary>
        ErrXLatOutOfRange = 7,

        /// <summary> The Y or longitude value is out of range. </summary>
        ErrYLonOutOfRange = 8,

        /// <summary> The Z or altitude value is out of range. </summary>
        ErrZAltOutOfRange = 9
    };

    /// <summary>
    /// Specifies the datatype of a MAVLink parameter.
    /// </summary>
    public enum MavParamType
    {

        /// <summary> 8-bit unsigned integer </summary>
        Uint8 = 1,

        /// <summary> 8-bit signed integer </summary>
        Int8 = 2,

        /// <summary> 16-bit unsigned integer </summary>
        Uint16 = 3,

        /// <summary> 16-bit signed integer </summary>
        Int16 = 4,

        /// <summary> 32-bit unsigned integer </summary>
        Uint32 = 5,

        /// <summary> 32-bit signed integer </summary>
        Int32 = 6,

        /// <summary> 64-bit unsigned integer </summary>
        Uint64 = 7,

        /// <summary> 64-bit signed integer </summary>
        Int64 = 8,

        /// <summary> 32-bit floating-point </summary>
        Real32 = 9,

        /// <summary> 64-bit floating-point </summary>
        Real64 = 10
    };

    /// <summary>
    /// result from a mavlink command
    /// </summary>
    public enum MavResult
    {

        /// <summary> Command ACCEPTED and EXECUTED </summary>
        Accepted = 0,

        /// <summary> Command TEMPORARY REJECTED/DENIED </summary>
        TemporarilyRejected = 1,

        /// <summary> Command PERMANENTLY DENIED </summary>
        Denied = 2,

        /// <summary> Command UNKNOWN/UNSUPPORTED </summary>
        Unsupported = 3,

        /// <summary> Command executed, but failed </summary>
        Failed = 4
    };

    /// <summary>
    /// result in a mavlink mission ack
    /// </summary>
    public enum MavMissionResult
    {

        /// <summary> mission accepted OK </summary>
        MavMissionAccepted = 0,

        /// <summary> generic error / not accepting mission commands at all right now </summary>
        MavMissionError = 1,

        /// <summary> coordinate frame is not supported </summary>
        MavMissionUnsupportedFrame = 2,

        /// <summary> command is not supported </summary>
        MavMissionUnsupported = 3,

        /// <summary> mission item exceeds storage space </summary>
        MavMissionNoSpace = 4,

        /// <summary> one of the parameters has an invalid value </summary>
        MavMissionInvalid = 5,

        /// <summary> param1 has an invalid value </summary>
        MavMissionInvalidParam1 = 6,

        /// <summary> param2 has an invalid value </summary>
        MavMissionInvalidParam2 = 7,

        /// <summary> param3 has an invalid value </summary>
        MavMissionInvalidParam3 = 8,

        /// <summary> param4 has an invalid value </summary>
        MavMissionInvalidParam4 = 9,

        /// <summary> x/param5 has an invalid value </summary>
        MavMissionInvalidParam5X = 10,

        /// <summary> y/param6 has an invalid value </summary>
        MavMissionInvalidParam6Y = 11,

        /// <summary> param7 has an invalid value </summary>
        MavMissionInvalidParam7 = 12,

        /// <summary> received waypoint out of sequence </summary>
        MavMissionInvalidSequence = 13,

        /// <summary> not accepting any mission commands from this communication partner </summary>
        MavMissionDenied = 14
    };

    /// <summary>
    /// Indicates the severity level, generally used for status messages to indicate their relative urgency. Based on RFC-5424 using expanded definitions at: http://www.kiwisyslog.com/kb/info:-syslog-message-levels/.
    /// </summary>
    public enum MavSeverity
    {

        /// <summary> System is unusable. This is a 'panic' condition. </summary>
        Emergency = 0,

        /// <summary> Action should be taken immediately. Indicates error in non-critical systems. </summary>
        Alert = 1,

        /// <summary> Action must be taken immediately. Indicates failure in a primary system. </summary>
        Critical = 2,

        /// <summary> Indicates an error in secondary/redundant systems. </summary>
        Error = 3,

        /// <summary> Indicates about a possible future error if this is not resolved within a given timeframe. Example would be a low battery warning. </summary>
        Warning = 4,

        /// <summary> An unusual event has occured, though not an error condition. This should be investigated for the root cause. </summary>
        Notice = 5,

        /// <summary> Normal operational messages. Useful for logging. No action is required for these messages. </summary>
        Info = 6,

        /// <summary> Useful non-operational messages that can assist in debugging. These should not occur during normal operation. </summary>
        Debug = 7
    };

    /// <summary>
    /// Power supply status flags (bitmask)
    /// </summary>
    public enum MavPowerStatus
    {

        /// <summary> main brick power supply valid </summary>
        BrickValid = 1,

        /// <summary> main servo power supply valid for FMU </summary>
        ServoValid = 2,

        /// <summary> USB power is connected </summary>
        UsbConnected = 4,

        /// <summary> peripheral supply is in over-current state </summary>
        PeriphOvercurrent = 8,

        /// <summary> hi-power peripheral supply is in over-current state </summary>
        PeriphHipowerOvercurrent = 16,

        /// <summary> Power status has changed since boot </summary>
        Changed = 32
    };

    /// <summary>
    /// SERIAL_CONTROL device types
    /// </summary>
    public enum SerialControlDev
    {

        /// <summary> First telemetry port </summary>
        Telem1 = 0,

        /// <summary> Second telemetry port </summary>
        Telem2 = 1,

        /// <summary> First GPS port </summary>
        Gps1 = 2,

        /// <summary> Second GPS port </summary>
        Gps2 = 3,

        /// <summary> system shell </summary>
        Shell = 10
    };

    /// <summary>
    /// SERIAL_CONTROL flags (bitmask)
    /// </summary>
    public enum SerialControlFlag
    {

        /// <summary> Set if this is a reply </summary>
        Reply = 1,

        /// <summary> Set if the sender wants the receiver to send a response as another SERIAL_CONTROL message </summary>
        Respond = 2,

        /// <summary> Set if access to the serial port should be removed from whatever driver is currently using it, giving exclusive access to the SERIAL_CONTROL protocol. The port can be handed back by sending a request without this flag set </summary>
        Exclusive = 4,

        /// <summary> Block on writes to the serial port </summary>
        Blocking = 8,

        /// <summary> Send multiple replies until port is drained </summary>
        Multi = 16
    };

    /// <summary>
    /// Enumeration of distance sensor types
    /// </summary>
    public enum MavDistanceSensor
    {

        /// <summary> Laser rangefinder, e.g. LightWare SF02/F or PulsedLight units </summary>
        Laser = 0,

        /// <summary> Ultrasound rangefinder, e.g. MaxBotix units </summary>
        Ultrasound = 1,

        /// <summary> Infrared rangefinder, e.g. Sharp units </summary>
        Infrared = 2
    };

    /// <summary>
    /// Enumeration of sensor orientation, according to its rotations
    /// </summary>
    public enum MavSensorOrientation
    {

        /// <summary> Roll: 0, Pitch: 0, Yaw: 0 </summary>
        MavSensorRotationNone = 0,

        /// <summary> Roll: 0, Pitch: 0, Yaw: 45 </summary>
        MavSensorRotationYaw45 = 1,

        /// <summary> Roll: 0, Pitch: 0, Yaw: 90 </summary>
        MavSensorRotationYaw90 = 2,

        /// <summary> Roll: 0, Pitch: 0, Yaw: 135 </summary>
        MavSensorRotationYaw135 = 3,

        /// <summary> Roll: 0, Pitch: 0, Yaw: 180 </summary>
        MavSensorRotationYaw180 = 4,

        /// <summary> Roll: 0, Pitch: 0, Yaw: 225 </summary>
        MavSensorRotationYaw225 = 5,

        /// <summary> Roll: 0, Pitch: 0, Yaw: 270 </summary>
        MavSensorRotationYaw270 = 6,

        /// <summary> Roll: 0, Pitch: 0, Yaw: 315 </summary>
        MavSensorRotationYaw315 = 7,

        /// <summary> Roll: 180, Pitch: 0, Yaw: 0 </summary>
        MavSensorRotationRoll180 = 8,

        /// <summary> Roll: 180, Pitch: 0, Yaw: 45 </summary>
        MavSensorRotationRoll180Yaw45 = 9,

        /// <summary> Roll: 180, Pitch: 0, Yaw: 90 </summary>
        MavSensorRotationRoll180Yaw90 = 10,

        /// <summary> Roll: 180, Pitch: 0, Yaw: 135 </summary>
        MavSensorRotationRoll180Yaw135 = 11,

        /// <summary> Roll: 0, Pitch: 180, Yaw: 0 </summary>
        MavSensorRotationPitch180 = 12,

        /// <summary> Roll: 180, Pitch: 0, Yaw: 225 </summary>
        MavSensorRotationRoll180Yaw225 = 13,

        /// <summary> Roll: 180, Pitch: 0, Yaw: 270 </summary>
        MavSensorRotationRoll180Yaw270 = 14,

        /// <summary> Roll: 180, Pitch: 0, Yaw: 315 </summary>
        MavSensorRotationRoll180Yaw315 = 15,

        /// <summary> Roll: 90, Pitch: 0, Yaw: 0 </summary>
        MavSensorRotationRoll90 = 16,

        /// <summary> Roll: 90, Pitch: 0, Yaw: 45 </summary>
        MavSensorRotationRoll90Yaw45 = 17,

        /// <summary> Roll: 90, Pitch: 0, Yaw: 90 </summary>
        MavSensorRotationRoll90Yaw90 = 18,

        /// <summary> Roll: 90, Pitch: 0, Yaw: 135 </summary>
        MavSensorRotationRoll90Yaw135 = 19,

        /// <summary> Roll: 270, Pitch: 0, Yaw: 0 </summary>
        MavSensorRotationRoll270 = 20,

        /// <summary> Roll: 270, Pitch: 0, Yaw: 45 </summary>
        MavSensorRotationRoll270Yaw45 = 21,

        /// <summary> Roll: 270, Pitch: 0, Yaw: 90 </summary>
        MavSensorRotationRoll270Yaw90 = 22,

        /// <summary> Roll: 270, Pitch: 0, Yaw: 135 </summary>
        MavSensorRotationRoll270Yaw135 = 23,

        /// <summary> Roll: 0, Pitch: 90, Yaw: 0 </summary>
        MavSensorRotationPitch90 = 24,

        /// <summary> Roll: 0, Pitch: 270, Yaw: 0 </summary>
        MavSensorRotationPitch270 = 25,

        /// <summary> Roll: 0, Pitch: 180, Yaw: 90 </summary>
        MavSensorRotationPitch180Yaw90 = 26,

        /// <summary> Roll: 0, Pitch: 180, Yaw: 270 </summary>
        MavSensorRotationPitch180Yaw270 = 27,

        /// <summary> Roll: 90, Pitch: 90, Yaw: 0 </summary>
        MavSensorRotationRoll90Pitch90 = 28,

        /// <summary> Roll: 180, Pitch: 90, Yaw: 0 </summary>
        MavSensorRotationRoll180Pitch90 = 29,

        /// <summary> Roll: 270, Pitch: 90, Yaw: 0 </summary>
        MavSensorRotationRoll270Pitch90 = 30,

        /// <summary> Roll: 90, Pitch: 180, Yaw: 0 </summary>
        MavSensorRotationRoll90Pitch180 = 31,

        /// <summary> Roll: 270, Pitch: 180, Yaw: 0 </summary>
        MavSensorRotationRoll270Pitch180 = 32,

        /// <summary> Roll: 90, Pitch: 270, Yaw: 0 </summary>
        MavSensorRotationRoll90Pitch270 = 33,

        /// <summary> Roll: 180, Pitch: 270, Yaw: 0 </summary>
        MavSensorRotationRoll180Pitch270 = 34,

        /// <summary> Roll: 270, Pitch: 270, Yaw: 0 </summary>
        MavSensorRotationRoll270Pitch270 = 35,

        /// <summary> Roll: 90, Pitch: 180, Yaw: 90 </summary>
        MavSensorRotationRoll90Pitch180Yaw90 = 36,

        /// <summary> Roll: 90, Pitch: 0, Yaw: 270 </summary>
        MavSensorRotationRoll90Yaw270 = 37,

        /// <summary> Roll: 315, Pitch: 315, Yaw: 315 </summary>
        MavSensorRotationRoll315Pitch315Yaw315 = 38
    };

    /// <summary>
    /// Bitmask of (optional) autopilot capabilities (64 bit). If a bit is set, the autopilot supports this capability.
    /// </summary>
    public enum MavProtocolCapability
    {

        /// <summary> Autopilot supports MISSION float message type. </summary>
        MissionFloat = 1,

        /// <summary> Autopilot supports the new param float message type. </summary>
        ParamFloat = 2,

        /// <summary> Autopilot supports MISSION_INT scaled integer message type. </summary>
        MissionInt = 4,

        /// <summary> Autopilot supports COMMAND_INT scaled integer message type. </summary>
        CommandInt = 8,

        /// <summary> Autopilot supports the new param union message type. </summary>
        ParamUnion = 16,

        /// <summary> Autopilot supports the new FILE_TRANSFER_PROTOCOL message type. </summary>
        Ftp = 32,

        /// <summary> Autopilot supports commanding attitude offboard. </summary>
        SetAttitudeTarget = 64,

        /// <summary> Autopilot supports commanding position and velocity targets in local NED frame. </summary>
        SetPositionTargetLocalNed = 128,

        /// <summary> Autopilot supports commanding position and velocity targets in global scaled integers. </summary>
        SetPositionTargetGlobalInt = 256,

        /// <summary> Autopilot supports terrain protocol / data handling. </summary>
        Terrain = 512,

        /// <summary> Autopilot supports direct actuator control. </summary>
        SetActuatorTarget = 1024,

        /// <summary> Autopilot supports the flight termination command. </summary>
        FlightTermination = 2048,

        /// <summary> Autopilot supports onboard compass calibration. </summary>
        CompassCalibration = 4096
    };

    /// <summary>
    /// Enumeration of estimator types
    /// </summary>
    public enum MavEstimatorType
    {

        /// <summary> This is a naive estimator without any real covariance feedback. </summary>
        Naive = 1,

        /// <summary> Computer vision based estimate. Might be up to scale. </summary>
        Vision = 2,

        /// <summary> Visual-inertial estimate. </summary>
        Vio = 3,

        /// <summary> Plain GPS estimate. </summary>
        Gps = 4,

        /// <summary> Estimator integrating GPS and inertial sensing. </summary>
        GpsIns = 5
    };

    /// <summary>
    /// Enumeration of battery types
    /// </summary>
    public enum MavBatteryType
    {

        /// <summary> Not specified. </summary>
        Unknown = 0,

        /// <summary> Lithium polymer battery </summary>
        Lipo = 1,

        /// <summary> Lithium-iron-phosphate battery </summary>
        Life = 2,

        /// <summary> Lithium-ION battery </summary>
        Lion = 3,

        /// <summary> Nickel metal hydride battery </summary>
        Nimh = 4
    };

    /// <summary>
    /// Enumeration of battery functions
    /// </summary>
    public enum MavBatteryFunction
    {

        /// <summary> Battery function is unknown </summary>
        Unknown = 0,

        /// <summary> Battery supports all flight systems </summary>
        All = 1,

        /// <summary> Battery for the propulsion system </summary>
        Propulsion = 2,

        /// <summary> Avionics battery </summary>
        Avionics = 3,

        /// <summary> Payload battery </summary>
        MavBatteryTypePayload = 4
    };

    /// <summary>
    /// Enumeration of VTOL states
    /// </summary>
    public enum MavVtolState
    {

        /// <summary> MAV is not configured as VTOL </summary>
        Undefined = 0,

        /// <summary> VTOL is in transition from multicopter to fixed-wing </summary>
        TransitionToFw = 1,

        /// <summary> VTOL is in transition from fixed-wing to multicopter </summary>
        TransitionToMc = 2,

        /// <summary> VTOL is in multicopter state </summary>
        Mc = 3,

        /// <summary> VTOL is in fixed-wing state </summary>
        Fw = 4
    };

    /// <summary>
    /// Enumeration of landed detector states
    /// </summary>
    public enum MavLandedState
    {

        /// <summary> MAV landed state is unknown </summary>
        Undefined = 0,

        /// <summary> MAV is landed (on ground) </summary>
        OnGround = 1,

        /// <summary> MAV is in air </summary>
        InAir = 2
    };

    /// <summary>
    /// Enumeration of the ADSB altimeter types
    /// </summary>
    public enum AdsbAltitudeType
    {

        /// <summary> Altitude reported from a Baro source using QNH reference </summary>
        PressureQnh = 0,

        /// <summary> Altitude reported from a GNSS source </summary>
        Geometric = 1
    };

    /// <summary>
    /// ADSB classification for the type of vehicle emitting the transponder signal
    /// </summary>
    public enum AdsbEmitterType
    {

        /// <summary>  </summary>
        NoInfo = 0,

        /// <summary>  </summary>
        Light = 1,

        /// <summary>  </summary>
        Small = 2,

        /// <summary>  </summary>
        Large = 3,

        /// <summary>  </summary>
        HighVortexLarge = 4,

        /// <summary>  </summary>
        Heavy = 5,

        /// <summary>  </summary>
        HighlyManuv = 6,

        /// <summary>  </summary>
        Rotocraft = 7,

        /// <summary>  </summary>
        Unassigned = 8,

        /// <summary>  </summary>
        Glider = 9,

        /// <summary>  </summary>
        LighterAir = 10,

        /// <summary>  </summary>
        Parachute = 11,

        /// <summary>  </summary>
        UltraLight = 12,

        /// <summary>  </summary>
        Unassigned2 = 13,

        /// <summary>  </summary>
        Uav = 14,

        /// <summary>  </summary>
        Space = 15,

        /// <summary>  </summary>
        Unassgined3 = 16,

        /// <summary>  </summary>
        EmergencySurface = 17,

        /// <summary>  </summary>
        ServiceSurface = 18,

        /// <summary>  </summary>
        PointObstacle = 19
    };

    /// <summary>
    /// These flags indicate status such as data validity of each data source. Set = data valid
    /// </summary>
    public enum AdsbFlags
    {

        /// <summary>  </summary>
        ValidCoords = 1,

        /// <summary>  </summary>
        ValidAltitude = 2,

        /// <summary>  </summary>
        ValidHeading = 4,

        /// <summary>  </summary>
        ValidVelocity = 8,

        /// <summary>  </summary>
        ValidCallsign = 16,

        /// <summary>  </summary>
        ValidSquawk = 32,

        /// <summary>  </summary>
        Simulated = 64
    };

    /// <summary>
    /// Bitmask of options for the MAV_CMD_DO_REPOSITION
    /// </summary>
    public enum MavDoRepositionFlags
    {

        /// <summary> The aircraft should immediately transition into guided. This should not be set for follow me applications </summary>
        ChangeMode = 1
    };

    /// <summary>
    /// Flags in EKF_STATUS message
    /// </summary>
    public enum EstimatorStatusFlags
    {

        /// <summary> True if the attitude estimate is good </summary>
        EstimatorAttitude = 1,

        /// <summary> True if the horizontal velocity estimate is good </summary>
        EstimatorVelocityHoriz = 2,

        /// <summary> True if the  vertical velocity estimate is good </summary>
        EstimatorVelocityVert = 4,

        /// <summary> True if the horizontal position (relative) estimate is good </summary>
        EstimatorPosHorizRel = 8,

        /// <summary> True if the horizontal position (absolute) estimate is good </summary>
        EstimatorPosHorizAbs = 16,

        /// <summary> True if the vertical position (absolute) estimate is good </summary>
        EstimatorPosVertAbs = 32,

        /// <summary> True if the vertical position (above ground) estimate is good </summary>
        EstimatorPosVertAgl = 64,

        /// <summary> True if the EKF is in a constant position mode and is not using external measurements (eg GPS or optical flow) </summary>
        EstimatorConstPosMode = 128,

        /// <summary> True if the EKF has sufficient data to enter a mode that will provide a (relative) position estimate </summary>
        EstimatorPredPosHorizRel = 256,

        /// <summary> True if the EKF has sufficient data to enter a mode that will provide a (absolute) position estimate </summary>
        EstimatorPredPosHorizAbs = 512,

        /// <summary> True if the EKF has detected a GPS glitch </summary>
        EstimatorGpsGlitch = 1024
    };

    public enum LimitsState
    {

        /// <summary> pre-initialization </summary>
        LimitsInit = 0,

        /// <summary> disabled </summary>
        LimitsDisabled = 1,

        /// <summary> checking limits </summary>
        LimitsEnabled = 2,

        /// <summary> a limit has been breached </summary>
        LimitsTriggered = 3,

        /// <summary> taking action eg. RTL </summary>
        LimitsRecovering = 4,

        /// <summary> we're no longer in breach of a limit </summary>
        LimitsRecovered = 5
    };

    public enum LimitModule
    {

        /// <summary> pre-initialization </summary>
        LimitGpslock = 1,

        /// <summary> disabled </summary>
        LimitGeofence = 2,

        /// <summary> checking limits </summary>
        LimitAltitude = 4
    };

    /// <summary>
    /// Flags in RALLY_POINT message
    /// </summary>
    public enum RallyFlags
    {

        /// <summary> Flag set when requiring favorable winds for landing. </summary>
        FavorableWind = 1,

        /// <summary> Flag set when plane is to immediately descend to break altitude and land without GCS intervention. Flag not set when plane is to loiter at Rally point until commanded to land. </summary>
        LandImmediately = 2
    };

    public enum ParachuteAction
    {

        /// <summary> Disable parachute release </summary>
        ParachuteDisable = 0,

        /// <summary> Enable parachute release </summary>
        ParachuteEnable = 1,

        /// <summary> Release parachute </summary>
        ParachuteRelease = 2
    };

    public enum MotorTestThrottleType
    {

        /// <summary> throttle as a percentage from 0 ~ 100 </summary>
        MotorTestThrottlePercent = 0,

        /// <summary> throttle as an absolute PWM value (normally in range of 1000~2000) </summary>
        MotorTestThrottlePwm = 1,

        /// <summary> throttle pass-through from pilot's transmitter </summary>
        MotorTestThrottlePilot = 2
    };

    /// <summary>
    /// Gripper actions.
    /// </summary>
    public enum GripperActions
    {

        /// <summary> gripper release of cargo </summary>
        GripperActionRelease = 0,

        /// <summary> gripper grabs onto cargo </summary>
        GripperActionGrab = 1
    };

    public enum CameraStatusTypes
    {

        /// <summary> Camera heartbeat, announce camera component ID at 1hz </summary>
        CameraStatusTypeHeartbeat = 0,

        /// <summary> Camera image triggered </summary>
        CameraStatusTypeTrigger = 1,

        /// <summary> Camera connection lost </summary>
        CameraStatusTypeDisconnect = 2,

        /// <summary> Camera unknown error </summary>
        CameraStatusTypeError = 3,

        /// <summary> Camera battery low. Parameter p1 shows reported voltage </summary>
        CameraStatusTypeLowbatt = 4,

        /// <summary> Camera storage low. Parameter p1 shows reported shots remaining </summary>
        CameraStatusTypeLowstore = 5,

        /// <summary> Camera storage low. Parameter p1 shows reported video minutes remaining </summary>
        CameraStatusTypeLowstorev = 6
    };

    public enum CameraFeedbackFlags
    {

        /// <summary> Shooting photos, not video </summary>
        CameraFeedbackPhoto = 0,

        /// <summary> Shooting video, not stills </summary>
        CameraFeedbackVideo = 1,

        /// <summary> Unable to achieve requested exposure (e.g. shutter speed too low) </summary>
        CameraFeedbackBadexposure = 2,

        /// <summary> Closed loop feedback from camera, we know for sure it has successfully taken a picture </summary>
        CameraFeedbackClosedloop = 3,

        /// <summary> Open loop camera, an image trigger has been requested but we can't know for sure it has successfully taken a picture </summary>
        CameraFeedbackOpenloop = 4
    };

    public enum MavModeGimbal
    {

        /// <summary> Gimbal is powered on but has not started initializing yet </summary>
        Uninitialized = 0,

        /// <summary> Gimbal is currently running calibration on the pitch axis </summary>
        CalibratingPitch = 1,

        /// <summary> Gimbal is currently running calibration on the roll axis </summary>
        CalibratingRoll = 2,

        /// <summary> Gimbal is currently running calibration on the yaw axis </summary>
        CalibratingYaw = 3,

        /// <summary> Gimbal has finished calibrating and initializing, but is relaxed pending reception of first rate command from copter </summary>
        Initialized = 4,

        /// <summary> Gimbal is actively stabilizing </summary>
        Active = 5,

        /// <summary> Gimbal is relaxed because it missed more than 10 expected rate command messages in a row. Gimbal will move back to active mode when it receives a new rate command </summary>
        RateCmdTimeout = 6
    };

    public enum GimbalAxis
    {

        /// <summary> Gimbal yaw axis </summary>
        Yaw = 0,

        /// <summary> Gimbal pitch axis </summary>
        Pitch = 1,

        /// <summary> Gimbal roll axis </summary>
        Roll = 2
    };

    public enum GimbalAxisCalibrationStatus
    {

        /// <summary> Axis calibration is in progress </summary>
        InProgress = 0,

        /// <summary> Axis calibration succeeded </summary>
        Succeeded = 1,

        /// <summary> Axis calibration failed </summary>
        Failed = 2
    };

    public enum GimbalAxisCalibrationRequired
    {

        /// <summary> Whether or not this axis requires calibration is unknown at this time </summary>
        Unknown = 0,

        /// <summary> This axis requires calibration </summary>
        True = 1,

        /// <summary> This axis does not require calibration </summary>
        False = 2
    };

    public enum GoproHeartbeatStatus
    {

        /// <summary> No GoPro connected </summary>
        Disconnected = 0,

        /// <summary> The detected GoPro is not HeroBus compatible </summary>
        Incompatible = 1,

        /// <summary> A HeroBus compatible GoPro is connected </summary>
        Connected = 2,

        /// <summary> An unrecoverable error was encountered with the connected GoPro, it may require a power cycle </summary>
        Error = 3
    };

    public enum GoproHeartbeatFlags
    {

        /// <summary> GoPro is currently recording </summary>
        GoproFlagRecording = 1
    };

    public enum GoproRequestStatus
    {

        /// <summary> The write message with ID indicated succeeded </summary>
        GoproRequestSuccess = 0,

        /// <summary> The write message with ID indicated failed </summary>
        GoproRequestFailed = 1
    };

    public enum GoproCommand
    {

        /// <summary> (Get/Set) </summary>
        Power = 0,

        /// <summary> (Get/Set) </summary>
        CaptureMode = 1,

        /// <summary> (___/Set) </summary>
        Shutter = 2,

        /// <summary> (Get/___) </summary>
        Battery = 3,

        /// <summary> (Get/___) </summary>
        Model = 4,

        /// <summary> (Get/Set) </summary>
        VideoSettings = 5,

        /// <summary> (Get/Set) </summary>
        LowLight = 6,

        /// <summary> (Get/Set) </summary>
        PhotoResolution = 7,

        /// <summary> (Get/Set) </summary>
        PhotoBurstRate = 8,

        /// <summary> (Get/Set) </summary>
        Protune = 9,

        /// <summary> (Get/Set) Hero 3+ Only </summary>
        ProtuneWhiteBalance = 10,

        /// <summary> (Get/Set) Hero 3+ Only </summary>
        ProtuneColour = 11,

        /// <summary> (Get/Set) Hero 3+ Only </summary>
        ProtuneGain = 12,

        /// <summary> (Get/Set) Hero 3+ Only </summary>
        ProtuneSharpness = 13,

        /// <summary> (Get/Set) Hero 3+ Only </summary>
        ProtuneExposure = 14,

        /// <summary> (Get/Set) </summary>
        Time = 15,

        /// <summary> (Get/Set) </summary>
        Charging = 16
    };

    public enum GoproCaptureMode
    {

        /// <summary> Video mode </summary>
        Video = 0,

        /// <summary> Photo mode </summary>
        Photo = 1,

        /// <summary> Burst mode, hero 3+ only </summary>
        Burst = 2,

        /// <summary> Time lapse mode, hero 3+ only </summary>
        TimeLapse = 3,

        /// <summary> Multi shot mode, hero 4 only </summary>
        MultiShot = 4,

        /// <summary> Playback mode, hero 4 only, silver only except when LCD or HDMI is connected to black </summary>
        Playback = 5,

        /// <summary> Playback mode, hero 4 only </summary>
        Setup = 6,

        /// <summary> Mode not yet known </summary>
        Unknown = 255
    };

    public enum GoproResolution
    {

        /// <summary> 848 x 480 (480p) </summary>
        _480p = 0,

        /// <summary> 1280 x 720 (720p) </summary>
        _720p = 1,

        /// <summary> 1280 x 960 (960p) </summary>
        _960p = 2,

        /// <summary> 1920 x 1080 (1080p) </summary>
        _1080p = 3,

        /// <summary> 1920 x 1440 (1440p) </summary>
        _1440p = 4,

        /// <summary> 2704 x 1440 (2.7k-17:9) </summary>
        _27k179 = 5,

        /// <summary> 2704 x 1524 (2.7k-16:9) </summary>
        _27k169 = 6,

        /// <summary> 2704 x 2028 (2.7k-4:3) </summary>
        _27k43 = 7,

        /// <summary> 3840 x 2160 (4k-16:9) </summary>
        _4k169 = 8,

        /// <summary> 4096 x 2160 (4k-17:9) </summary>
        _4k179 = 9,

        /// <summary> 1280 x 720 (720p-SuperView) </summary>
        _720pSuperview = 10,

        /// <summary> 1920 x 1080 (1080p-SuperView) </summary>
        _1080pSuperview = 11,

        /// <summary> 2704 x 1520 (2.7k-SuperView) </summary>
        _27kSuperview = 12,

        /// <summary> 3840 x 2160 (4k-SuperView) </summary>
        _4kSuperview = 13
    };

    public enum GoproFrameRate
    {

        /// <summary> 12 FPS </summary>
        _12 = 0,

        /// <summary> 15 FPS </summary>
        _15 = 1,

        /// <summary> 24 FPS </summary>
        _24 = 2,

        /// <summary> 25 FPS </summary>
        _25 = 3,

        /// <summary> 30 FPS </summary>
        _30 = 4,

        /// <summary> 48 FPS </summary>
        _48 = 5,

        /// <summary> 50 FPS </summary>
        _50 = 6,

        /// <summary> 60 FPS </summary>
        _60 = 7,

        /// <summary> 80 FPS </summary>
        _80 = 8,

        /// <summary> 90 FPS </summary>
        _90 = 9,

        /// <summary> 100 FPS </summary>
        _100 = 10,

        /// <summary> 120 FPS </summary>
        _120 = 11,

        /// <summary> 240 FPS </summary>
        _240 = 12,

        /// <summary> 12.5 FPS </summary>
        _125 = 13
    };

    public enum GoproFieldOfView
    {

        /// <summary> 0x00: Wide </summary>
        Wide = 0,

        /// <summary> 0x01: Medium </summary>
        Medium = 1,

        /// <summary> 0x02: Narrow </summary>
        Narrow = 2
    };

    public enum GoproVideoSettingsFlags
    {

        /// <summary> 0=NTSC, 1=PAL </summary>
        GoproVideoSettingsTvMode = 1
    };

    public enum GoproPhotoResolution
    {

        /// <summary> 5MP Medium </summary>
        _5mpMedium = 0,

        /// <summary> 7MP Medium </summary>
        _7mpMedium = 1,

        /// <summary> 7MP Wide </summary>
        _7mpWide = 2,

        /// <summary> 10MP Wide </summary>
        _10mpWide = 3,

        /// <summary> 12MP Wide </summary>
        _12mpWide = 4
    };

    public enum GoproProtuneWhiteBalance
    {

        /// <summary> Auto </summary>
        Auto = 0,

        /// <summary> 3000K </summary>
        _3000k = 1,

        /// <summary> 5500K </summary>
        _5500k = 2,

        /// <summary> 6500K </summary>
        _6500k = 3,

        /// <summary> Camera Raw </summary>
        Raw = 4
    };

    public enum GoproProtuneColour
    {

        /// <summary> Auto </summary>
        Standard = 0,

        /// <summary> Neutral </summary>
        Neutral = 1
    };

    public enum GoproProtuneGain
    {

        /// <summary> ISO 400 </summary>
        _400 = 0,

        /// <summary> ISO 800 (Only Hero 4) </summary>
        _800 = 1,

        /// <summary> ISO 1600 </summary>
        _1600 = 2,

        /// <summary> ISO 3200 (Only Hero 4) </summary>
        _3200 = 3,

        /// <summary> ISO 6400 </summary>
        _6400 = 4
    };

    public enum GoproProtuneSharpness
    {

        /// <summary> Low Sharpness </summary>
        Low = 0,

        /// <summary> Medium Sharpness </summary>
        Medium = 1,

        /// <summary> High Sharpness </summary>
        High = 2
    };

    public enum GoproProtuneExposure
    {

        /// <summary> -5.0 EV (Hero 3+ Only) </summary>
        Neg50 = 0,

        /// <summary> -4.5 EV (Hero 3+ Only) </summary>
        Neg45 = 1,

        /// <summary> -4.0 EV (Hero 3+ Only) </summary>
        Neg40 = 2,

        /// <summary> -3.5 EV (Hero 3+ Only) </summary>
        Neg35 = 3,

        /// <summary> -3.0 EV (Hero 3+ Only) </summary>
        Neg30 = 4,

        /// <summary> -2.5 EV (Hero 3+ Only) </summary>
        Neg25 = 5,

        /// <summary> -2.0 EV </summary>
        Neg20 = 6,

        /// <summary> -1.5 EV </summary>
        Neg15 = 7,

        /// <summary> -1.0 EV </summary>
        Neg10 = 8,

        /// <summary> -0.5 EV </summary>
        Neg05 = 9,

        /// <summary> 0.0 EV </summary>
        Zero = 10,

        /// <summary> +0.5 EV </summary>
        Pos05 = 11,

        /// <summary> +1.0 EV </summary>
        Pos10 = 12,

        /// <summary> +1.5 EV </summary>
        Pos15 = 13,

        /// <summary> +2.0 EV </summary>
        Pos20 = 14,

        /// <summary> +2.5 EV (Hero 3+ Only) </summary>
        Pos25 = 15,

        /// <summary> +3.0 EV (Hero 3+ Only) </summary>
        Pos30 = 16,

        /// <summary> +3.5 EV (Hero 3+ Only) </summary>
        Pos35 = 17,

        /// <summary> +4.0 EV (Hero 3+ Only) </summary>
        Pos40 = 18,

        /// <summary> +4.5 EV (Hero 3+ Only) </summary>
        Pos45 = 19,

        /// <summary> +5.0 EV (Hero 3+ Only) </summary>
        Pos50 = 20
    };

    public enum GoproCharging
    {

        /// <summary> Charging disabled </summary>
        Disabled = 0,

        /// <summary> Charging enabled </summary>
        Enabled = 1
    };

    public enum GoproModel
    {

        /// <summary> Unknown gopro model </summary>
        Unknown = 0,

        /// <summary> Hero 3+ Silver (HeroBus not supported by GoPro) </summary>
        Hero3PlusSilver = 1,

        /// <summary> Hero 3+ Black </summary>
        Hero3PlusBlack = 2,

        /// <summary> Hero 4 Silver </summary>
        Hero4Silver = 3,

        /// <summary> Hero 4 Black </summary>
        Hero4Black = 4
    };

    public enum GoproBurstRate
    {

        /// <summary> 3 Shots / 1 Second </summary>
        _3In1Second = 0,

        /// <summary> 5 Shots / 1 Second </summary>
        _5In1Second = 1,

        /// <summary> 10 Shots / 1 Second </summary>
        _10In1Second = 2,

        /// <summary> 10 Shots / 2 Second </summary>
        _10In2Second = 3,

        /// <summary> 10 Shots / 3 Second (Hero 4 Only) </summary>
        _10In3Second = 4,

        /// <summary> 30 Shots / 1 Second </summary>
        _30In1Second = 5,

        /// <summary> 30 Shots / 2 Second </summary>
        _30In2Second = 6,

        /// <summary> 30 Shots / 3 Second </summary>
        _30In3Second = 7,

        /// <summary> 30 Shots / 6 Second </summary>
        _30In6Second = 8
    };

    public enum LedControlPattern
    {

        /// <summary> LED patterns off (return control to regular vehicle control) </summary>
        Off = 0,

        /// <summary> LEDs show pattern during firmware update </summary>
        Firmwareupdate = 1,

        /// <summary> Custom Pattern using custom bytes fields </summary>
        Custom = 255
    };

    /// <summary>
    /// Flags in EKF_STATUS message
    /// </summary>
    public enum EkfStatusFlags
    {

        /// <summary> set if EKF's attitude estimate is good </summary>
        EkfAttitude = 1,

        /// <summary> set if EKF's horizontal velocity estimate is good </summary>
        EkfVelocityHoriz = 2,

        /// <summary> set if EKF's vertical velocity estimate is good </summary>
        EkfVelocityVert = 4,

        /// <summary> set if EKF's horizontal position (relative) estimate is good </summary>
        EkfPosHorizRel = 8,

        /// <summary> set if EKF's horizontal position (absolute) estimate is good </summary>
        EkfPosHorizAbs = 16,

        /// <summary> set if EKF's vertical position (absolute) estimate is good </summary>
        EkfPosVertAbs = 32,

        /// <summary> set if EKF's vertical position (above ground) estimate is good </summary>
        EkfPosVertAgl = 64,

        /// <summary> EKF is in constant position mode and does not know it's absolute or relative position </summary>
        EkfConstPosMode = 128,

        /// <summary> set if EKF's predicted horizontal position (relative) estimate is good </summary>
        EkfPredPosHorizRel = 256,

        /// <summary> set if EKF's predicted horizontal position (absolute) estimate is good </summary>
        EkfPredPosHorizAbs = 512
    };

    public enum PidTuningAxis
    {

        /// <summary>  </summary>
        PidTuningRoll = 1,

        /// <summary>  </summary>
        PidTuningPitch = 2,

        /// <summary>  </summary>
        PidTuningYaw = 3,

        /// <summary>  </summary>
        PidTuningAccz = 4,

        /// <summary>  </summary>
        PidTuningSteer = 5
    };

    public enum MagCalStatus
    {

        /// <summary>  </summary>
        MagCalNotStarted = 0,

        /// <summary>  </summary>
        MagCalWaitingToStart = 1,

        /// <summary>  </summary>
        MagCalRunningStepOne = 2,

        /// <summary>  </summary>
        MagCalRunningStepTwo = 3,

        /// <summary>  </summary>
        MagCalSuccess = 4,

        /// <summary>  </summary>
        MagCalFailed = 5
    };

    /// <summary>
    /// Special ACK block numbers control activation of dataflash log streaming
    /// </summary>
    public enum MavRemoteLogDataBlockCommands
    {

        /// <summary> UAV to stop sending DataFlash blocks </summary>
        MavRemoteLogDataBlockStop = 2147483645,

        /// <summary> UAV to start sending DataFlash blocks </summary>
        MavRemoteLogDataBlockStart = 2147483646
    };

    /// <summary>
    /// Possible remote log data block statuses
    /// </summary>
    public enum MavRemoteLogDataBlockStatuses
    {

        /// <summary> This block has NOT been received </summary>
        MavRemoteLogDataBlockNack = 0,

        /// <summary> This block has been received </summary>
        MavRemoteLogDataBlockAck = 1
    };
}
