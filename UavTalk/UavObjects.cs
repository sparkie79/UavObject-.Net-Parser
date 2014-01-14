
using UavTalk;

public static class UAVObjectsInitialize
{
	public static void register(UAVObjectManager objMngr) {
		
		objMngr.registerObject( new AccelSensor() );
		
		objMngr.registerObject( new AccelState() );
		
		objMngr.registerObject( new AccessoryDesired() );
		
		objMngr.registerObject( new ActuatorCommand() );
		
		objMngr.registerObject( new ActuatorDesired() );
		
		objMngr.registerObject( new ActuatorSettings() );
		
		objMngr.registerObject( new AirspeedSensor() );
		
		objMngr.registerObject( new AirspeedSettings() );
		
		objMngr.registerObject( new AirspeedState() );
		
		objMngr.registerObject( new AltHoldSmoothed() );
		
		objMngr.registerObject( new AltitudeFilterSettings() );
		
		objMngr.registerObject( new AltitudeHoldDesired() );
		
		objMngr.registerObject( new AltitudeHoldSettings() );
		
		objMngr.registerObject( new AttitudeSettings() );
		
		objMngr.registerObject( new AttitudeSimulated() );
		
		objMngr.registerObject( new AttitudeState() );
		
		objMngr.registerObject( new BaroSensor() );
		
		objMngr.registerObject( new CameraDesired() );
		
		objMngr.registerObject( new CameraStabSettings() );
		
		objMngr.registerObject( new EKFConfiguration() );
		
		objMngr.registerObject( new EKFStateVariance() );
		
		objMngr.registerObject( new FaultSettings() );
		
		objMngr.registerObject( new FirmwareIAPObj() );
		
		objMngr.registerObject( new FixedWingPathFollowerSettings() );
		
		objMngr.registerObject( new FixedWingPathFollowerStatus() );
		
		objMngr.registerObject( new FlightBatterySettings() );
		
		objMngr.registerObject( new FlightBatteryState() );
		
		objMngr.registerObject( new FlightPlanControl() );
		
		objMngr.registerObject( new FlightPlanSettings() );
		
		objMngr.registerObject( new FlightPlanStatus() );
		
		objMngr.registerObject( new FlightStatus() );
		
		objMngr.registerObject( new FlightTelemetryStats() );
		
		objMngr.registerObject( new GCSReceiver() );
		
		objMngr.registerObject( new GCSTelemetryStats() );
		
		objMngr.registerObject( new GPSPositionSensor() );
		
		objMngr.registerObject( new GPSSatellites() );
		
		objMngr.registerObject( new GPSSettings() );
		
		objMngr.registerObject( new GPSTime() );
		
		objMngr.registerObject( new GPSVelocitySensor() );
		
		objMngr.registerObject( new GroundTruth() );
		
		objMngr.registerObject( new GyroSensor() );
		
		objMngr.registerObject( new GyroState() );
		
		objMngr.registerObject( new HomeLocation() );
		
		objMngr.registerObject( new HwSettings() );
		
		objMngr.registerObject( new I2CStats() );
		
		objMngr.registerObject( new MagSensor() );
		
		objMngr.registerObject( new MagState() );
		
		objMngr.registerObject( new ManualControlCommand() );
		
		objMngr.registerObject( new ManualControlSettings() );
		
		objMngr.registerObject( new MixerSettings() );
		
		objMngr.registerObject( new MixerStatus() );
		
		objMngr.registerObject( new Mpu6000Settings() );
		
		objMngr.registerObject( new NedAccel() );
		
		objMngr.registerObject( new ObjectPersistence() );
		
		objMngr.registerObject( new OPLinkReceiver() );
		
		objMngr.registerObject( new OPLinkSettings() );
		
		objMngr.registerObject( new OPLinkStatus() );
		
		objMngr.registerObject( new OsdSettings() );
		
		objMngr.registerObject( new OveroSyncSettings() );
		
		objMngr.registerObject( new OveroSyncStats() );
		
		objMngr.registerObject( new PathAction() );
		
		objMngr.registerObject( new PathDesired() );
		
		objMngr.registerObject( new PathStatus() );
		
		objMngr.registerObject( new PoiLearnSettings() );
		
		objMngr.registerObject( new PoiLocation() );
		
		objMngr.registerObject( new PositionState() );
		
		objMngr.registerObject( new RateDesired() );
		
		objMngr.registerObject( new ReceiverActivity() );
		
		objMngr.registerObject( new RelayTuning() );
		
		objMngr.registerObject( new RelayTuningSettings() );
		
		objMngr.registerObject( new RevoCalibration() );
		
		objMngr.registerObject( new RevoSettings() );
		
		objMngr.registerObject( new SonarAltitude() );
		
		objMngr.registerObject( new StabilizationDesired() );
		
		objMngr.registerObject( new StabilizationSettings() );
		
		objMngr.registerObject( new SystemAlarms() );
		
		objMngr.registerObject( new SystemSettings() );
		
		objMngr.registerObject( new SystemStats() );
		
		objMngr.registerObject( new TaskInfo() );
		
		objMngr.registerObject( new TxPIDSettings() );
		
		objMngr.registerObject( new VelocityDesired() );
		
		objMngr.registerObject( new VelocityState() );
		
		objMngr.registerObject( new VtolPathFollowerSettings() );
		
		objMngr.registerObject( new WatchdogStatus() );
		
		objMngr.registerObject( new Waypoint() );
		
		objMngr.registerObject( new WaypointActive() );
	}
}
// Generated helper templates
// Generated items
// UavTalk\UavTalk\WaypointActive.cs
// UavTalk\UavTalk\Waypoint.cs
// UavTalk\UavTalk\WatchdogStatus.cs
// UavTalk\UavTalk\VtolPathFollowerSettings.cs
// UavTalk\UavTalk\VelocityState.cs
// UavTalk\UavTalk\VelocityDesired.cs
// UavTalk\UavTalk\TxPIDSettings.cs
// UavTalk\UavTalk\TaskInfo.cs
// UavTalk\UavTalk\SystemStats.cs
// UavTalk\UavTalk\SystemSettings.cs
// UavTalk\UavTalk\SystemAlarms.cs
// UavTalk\UavTalk\StabilizationSettings.cs
// UavTalk\UavTalk\StabilizationDesired.cs
// UavTalk\UavTalk\SonarAltitude.cs
// UavTalk\UavTalk\RevoSettings.cs
// UavTalk\UavTalk\RevoCalibration.cs
// UavTalk\UavTalk\RelayTuningSettings.cs
// UavTalk\UavTalk\RelayTuning.cs
// UavTalk\UavTalk\ReceiverActivity.cs
// UavTalk\UavTalk\RateDesired.cs
// UavTalk\UavTalk\PositionState.cs
// UavTalk\UavTalk\PoiLocation.cs
// UavTalk\UavTalk\PoiLearnSettings.cs
// UavTalk\UavTalk\PathStatus.cs
// UavTalk\UavTalk\PathDesired.cs
// UavTalk\UavTalk\PathAction.cs
// UavTalk\UavTalk\OveroSyncStats.cs
// UavTalk\UavTalk\OveroSyncSettings.cs
// UavTalk\UavTalk\OsdSettings.cs
// UavTalk\UavTalk\OPLinkStatus.cs
// UavTalk\UavTalk\OPLinkSettings.cs
// UavTalk\UavTalk\OPLinkReceiver.cs
// UavTalk\UavTalk\ObjectPersistence.cs
// UavTalk\UavTalk\NedAccel.cs
// UavTalk\UavTalk\Mpu6000Settings.cs
// UavTalk\UavTalk\MixerStatus.cs
// UavTalk\UavTalk\MixerSettings.cs
// UavTalk\UavTalk\ManualControlSettings.cs
// UavTalk\UavTalk\ManualControlCommand.cs
// UavTalk\UavTalk\MagState.cs
// UavTalk\UavTalk\MagSensor.cs
// UavTalk\UavTalk\I2CStats.cs
// UavTalk\UavTalk\HwSettings.cs
// UavTalk\UavTalk\HomeLocation.cs
// UavTalk\UavTalk\GyroState.cs
// UavTalk\UavTalk\GyroSensor.cs
// UavTalk\UavTalk\GroundTruth.cs
// UavTalk\UavTalk\GPSVelocitySensor.cs
// UavTalk\UavTalk\GPSTime.cs
// UavTalk\UavTalk\GPSSettings.cs
// UavTalk\UavTalk\GPSSatellites.cs
// UavTalk\UavTalk\GPSPositionSensor.cs
// UavTalk\UavTalk\GCSTelemetryStats.cs
// UavTalk\UavTalk\GCSReceiver.cs
// UavTalk\UavTalk\FlightTelemetryStats.cs
// UavTalk\UavTalk\FlightStatus.cs
// UavTalk\UavTalk\FlightPlanStatus.cs
// UavTalk\UavTalk\FlightPlanSettings.cs
// UavTalk\UavTalk\FlightPlanControl.cs
// UavTalk\UavTalk\FlightBatteryState.cs
// UavTalk\UavTalk\FlightBatterySettings.cs
// UavTalk\UavTalk\FixedWingPathFollowerStatus.cs
// UavTalk\UavTalk\FixedWingPathFollowerSettings.cs
// UavTalk\UavTalk\FirmwareIAPObj.cs
// UavTalk\UavTalk\FaultSettings.cs
// UavTalk\UavTalk\EKFStateVariance.cs
// UavTalk\UavTalk\EKFConfiguration.cs
// UavTalk\UavTalk\CameraStabSettings.cs
// UavTalk\UavTalk\CameraDesired.cs
// UavTalk\UavTalk\BaroSensor.cs
// UavTalk\UavTalk\AttitudeState.cs
// UavTalk\UavTalk\AttitudeSimulated.cs
// UavTalk\UavTalk\AttitudeSettings.cs
// UavTalk\UavTalk\AltitudeHoldSettings.cs
// UavTalk\UavTalk\AltitudeHoldDesired.cs
// UavTalk\UavTalk\AltitudeFilterSettings.cs
// UavTalk\UavTalk\AltHoldSmoothed.cs
// UavTalk\UavTalk\AirspeedState.cs
// UavTalk\UavTalk\AirspeedSettings.cs
// UavTalk\UavTalk\AirspeedSensor.cs
// UavTalk\UavTalk\ActuatorSettings.cs
// UavTalk\UavTalk\ActuatorDesired.cs
// UavTalk\UavTalk\ActuatorCommand.cs
// UavTalk\UavTalk\AccessoryDesired.cs
// UavTalk\UavTalk\AccelState.cs
// UavTalk\UavTalk\AccelSensor.cs
